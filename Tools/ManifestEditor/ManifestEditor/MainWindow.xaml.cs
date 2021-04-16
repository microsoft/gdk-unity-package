// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Xml;
using System.Xml.Schema;

namespace ManifestEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string GameConfigSchemaResourceName = "ManifestEditor.Schemas.GameConfigSchema.xsd";
        private const string StoreAssociationWizardFileName = "StoreAssociationWizard.exe";
        private const string ShellVisualsNodePath = "/Game/ShellVisuals";
        private const string DefaultDisplayNameAttr = "DefaultDisplayName";
        private const string IdentityNodePath = "/Game/Identity";
        private const string NameAttr = "Name";
        private const string StoreIdNodePath = "/Game/StoreId";
        private const string MSAAppIdNodePath = "/Game/MSAAppId";
        private const string TitleIdNodePath = "/Game/TitleId";
        private const string Square150x150LogoFileName = "Square150x150Logo.png";
        private const string Square44x44LogoFileName = "Square44x44Logo.png";
        private const string SplashScreenImageFileName = "SplashScreenImage.png";
        private const string StoreLogoFileName = "StoreLogo.png";
        private const string Square480x480LogoAttr = "Square480x480Logo";
        private const string Square150x150LogoAttr = "Square150x150Logo";
        private const string Square44x44LogoAttr = "Square44x44Logo";
        private const string SplashScreenImageAttr = "SplashScreenImage";
        private const string StoreLogoAttr = "StoreLogo";
        private const string MultiplayerProtocolNodePath = "/Game/DesktopRegistration/MultiplayerProtocol";
        private const string PublisherIdAttr = "Publisher";
        private const string PublisherNameAttr = "PublisherDisplayName";

        private static EditorData _editorData = new EditorData();

        public static Regex _publisherIdRegex = new Regex(@"(CN|L|O|OU|E|C|S|STREET|T|G|I|SN|DC|SERIALNUMBER|(OID\.(0|[1-9][0-9]*)(\.(0|[1-9][0-9]*))+))=(([^,+=""<>#;])+|"".*"")(, ((CN|L|O|OU|E|C|S|STREET|T|G|I|SN|DC|SERIALNUMBER|(OID\.(0|[1-9][0-9]*)(\.(0|[1-9][0-9]*))+))=(([^,+=""<>#;])+|"".*"")))*", RegexOptions.Compiled);

        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            if (!ParseCommandLine(this, _editorData, Environment.GetCommandLineArgs()))
            {
                DisplayErrorMessageBox("Usage:  ManifestEditor.exe <config file path> [/e:<game engine>] [/i:<path to default image>]");
                CloseEditor(this);
            }
            else
            {
                if (!LoadConfig(this, _editorData))
                {
                    CloseEditor(this);
                }

                InitializeUI(this, _editorData);

                DataContext = _editorData;
            }
        }

        private void btnExe_Click(object sender, RoutedEventArgs e)
        {
            var exePath = GetFilePath(_editorData, "EXE files|*.exe");

            if (!string.IsNullOrWhiteSpace(exePath))
            {
                txtExe.Text = exePath;
            }
        }

        private void btnWizard_Click(object sender, RoutedEventArgs e)
        {
            var editor = System.Reflection.Assembly.GetExecutingAssembly();
            ProcessStartInfo pInfo = new ProcessStartInfo();
            pInfo.FileName = Path.Combine(Path.GetDirectoryName(editor.Location), StoreAssociationWizardFileName);
            string gameConfigFilePathWithQuotesAroundPath = _editorData.GameConfigFilePath;
            if (gameConfigFilePathWithQuotesAroundPath.Length > 1 &&
                gameConfigFilePathWithQuotesAroundPath[0] != '"' &&
                gameConfigFilePathWithQuotesAroundPath[gameConfigFilePathWithQuotesAroundPath.Length - 1] != '"')
            {
                gameConfigFilePathWithQuotesAroundPath = string.Concat("\"", gameConfigFilePathWithQuotesAroundPath, "\"");
            }
            pInfo.Arguments = gameConfigFilePathWithQuotesAroundPath;
            Process p = Process.Start(pInfo);
            p.WaitForInputIdle();
            p.WaitForExit();

            if (!LoadConfig(this, _editorData))
            {
                CloseEditor(this);
            }

            InitializeUI(this, _editorData);
        }

        private void txtPublisherId_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            bool isInputValid = _publisherIdRegex.IsMatch(this.txtPublisherId.Text);
            if (isInputValid)
            {
                _editorData.PublisherId = this.txtPublisherId.Text;
            }
            this.saveButton.IsEnabled = isInputValid;
        }

        private void txtPublisherName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            bool isInputValid = !string.IsNullOrEmpty(this.txtPublisherName.Text);
            if (isInputValid)
            {
                _editorData.PublisherName = this.txtPublisherName.Text;
            }

            this.saveButton.IsEnabled = isInputValid;
        }


        private void txtPublisher_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            this.saveButton.IsEnabled = _publisherIdRegex.IsMatch(this.txtPublisherId.Text);
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            var uri = e.Uri.AbsoluteUri;
            var storeIdNode = _editorData.GameConfig.SelectSingleNode(StoreIdNodePath);

            if (storeIdNode == null || string.IsNullOrWhiteSpace(storeIdNode.InnerText))
            {
                return;
            }

            uri = uri.Replace("__StoreID__", storeIdNode.InnerText);

            Process.Start(new ProcessStartInfo(uri));

            e.Handled = true;
        }

        private void btnTile_Click(object sender, RoutedEventArgs e)
        {
            var imgPath = GetFilePath(_editorData, "Image files|*.png");

            if (!string.IsNullOrWhiteSpace(imgPath))
            {
                LoadImage(this, _editorData, imgPath);
            }
        }

        private void chkMultiplayer_Checked(object sender, RoutedEventArgs e)
        {
            _editorData.IsMultiplayer = (bool)chkMultiplayer.IsChecked;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            CloseEditor(this);
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateGameConfig(this, _editorData);
            CloseEditor(this);
        }

        private static bool ParseCommandLine(MainWindow instance, EditorData editorData, string[] commandLineArgs)
        {
            var numArgs = commandLineArgs.Length;

            if (numArgs != 2 && numArgs != 3 && numArgs != 4)
            {
                return false;
            }

            if (numArgs == 4)
            {
                if (!commandLineArgs[3].StartsWith("/i:"))
                {
                    return false;
                }

                string defaultImagePath = string.Empty;
                try
                {
                    defaultImagePath = commandLineArgs[3].Substring(3);
                    editorData.DefaultImageFilePath = Path.GetFullPath(defaultImagePath);
                }
                catch
                {
                    DisplayErrorMessageBox($"Problem with path '{defaultImagePath}'");
                    CloseEditor(instance);
                }
            }

            if (numArgs >= 3)
            {
                if (!commandLineArgs[2].StartsWith("/e:"))
                {
                    return false;
                }

                GameEngine gameEngine;

                if (Enum.TryParse(commandLineArgs[2].Substring(3), true, out gameEngine))
                {
                    editorData.GameEngine = gameEngine;
                }
                else
                {
                    editorData.GameEngine = GameEngine.Other;
                }
            }
            else
            {
                editorData.GameEngine = GameEngine.Other;
            }

            try
            {
                editorData.GameConfigFilePath = Path.GetFullPath(commandLineArgs[1]);
            }
            catch
            {
                DisplayErrorMessageBox($"Problem with path '{commandLineArgs[1]}'");
                CloseEditor(instance);
            }

            return true;
        }

        private static void DisplayErrorMessageBox(string message)
        {
            System.Windows.Forms.MessageBox.Show(message, "Error");
        }

        private static void CloseEditor(MainWindow instance)
        {
            instance.Close();
        }

        private static string GetFilePath(EditorData editorData, string fileFilter)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = fileFilter;
            ofd.FilterIndex = 1;
            ofd.InitialDirectory = Path.GetDirectoryName(editorData.GameConfigFilePath);

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return ofd.FileName;
            }
            else
            {
                return string.Empty;
            }
        }

        private static bool LoadConfig(MainWindow instance, EditorData editorData)
        {
            instance.saveButton.IsEnabled = false;

            // If config file doesn't exist, declare success and force user to run store association wizard.
            if (!File.Exists(editorData.GameConfigFilePath))
            {
                editorData.IsNewConfig = true;
                instance.txtWizardError.Text = "Current store association is invalid.";
                return true;
            }

            // Don't continue if config file contains validation errors.
            if (!LoadConfigXml(instance, editorData))
            {
                return false;
            }

            if (IsValidStoreAssociation(editorData))
            {
                instance.txtWizardError.Text = string.Empty;
                editorData.CanSave = true;
                instance.saveButton.IsEnabled = true;
            }
            else
            {
                instance.txtWizardError.Text = "Current store association is invalid.";
            }

            return true;
        }

        private static bool LoadConfigXml(MainWindow instance, EditorData editorData)
        {
            try
            {
                var isValid = true;
                var settings = new XmlReaderSettings();
                var assembly = Assembly.GetExecutingAssembly();

                using (var schemaStream = assembly.GetManifestResourceStream(GameConfigSchemaResourceName))
                {
                    using (var schemaReader = XmlReader.Create(schemaStream))
                    {
                        settings.Schemas.Add(null, schemaReader);
                    }
                }

                var sb = new StringBuilder();
                settings.ValidationType = ValidationType.Schema;
                settings.ValidationEventHandler += (o, e) =>
                {
                    switch (e.Severity)
                    {
                        case XmlSeverityType.Error:
                            isValid = false;
                            sb.AppendLine($" - {e.Message}").AppendLine();
                            break;
                    }
                };

                using (var configStream = File.OpenRead(editorData.GameConfigFilePath))
                {
                    XmlReader reader = XmlReader.Create(configStream, settings);

                    editorData.GameConfig = new XmlDocument();
                    editorData.GameConfig.Load(reader);
                }

                if (!isValid)
                {
                    var message = $"Please fix the following validation errors in '{_editorData.GameConfigFilePath}' and rerun the editor:{Environment.NewLine}{Environment.NewLine}{sb.ToString()}";

                    DisplayErrorMessageBox(message);
                }

                return isValid;
            }
            catch (XmlException)
            {
                DisplayErrorMessageBox($"Invalid XML in '{editorData.GameConfigFilePath}'");

                return false;
            }
            catch
            {
                DisplayErrorMessageBox($"Unable to open '{editorData.GameConfigFilePath}'");

                return false;
            }
        }

        private static void InitializeUI(MainWindow instance, EditorData editorData)
        {
            InitializeEngineSpecificUI(instance, editorData);

            if (editorData.GameConfig != null)
            {
                if (IsValidStoreAssociation(editorData))
                {
                    instance.spPublisher.Visibility = Visibility.Visible;
                }

                InitializePublisher(instance, editorData);
                LoadTileImage(instance, editorData);
                InitializeMPCheckbox(instance, editorData);
            }
        }

        private static void InitializeEngineSpecificUI(MainWindow instance, EditorData editorData)
        {
            switch (editorData.GameEngine)
            {
                case GameEngine.Unity:
                case GameEngine.Unreal:
                case GameEngine.VisualStudio:
                    break;

                case GameEngine.Other:
                    instance.spExe.Visibility = Visibility.Visible;
                    break;
            }
        }

        private static void InitializePublisher(MainWindow instance, EditorData editorData)
        {
            editorData.PublisherId = editorData.GameConfig.GetAttributeValue(IdentityNodePath, PublisherIdAttr);
            instance.txtPublisherId.Text = editorData.PublisherId;

            editorData.PublisherName = editorData.GameConfig.GetAttributeValue(ShellVisualsNodePath, PublisherNameAttr);
            instance.txtPublisherName.Text = editorData.PublisherName;
        }

        private static void LoadTileImage(MainWindow instance, EditorData editorData)
        {
            var filename = editorData.GameConfig.GetAttributeValue(ShellVisualsNodePath, Square480x480LogoAttr);

            if (string.IsNullOrWhiteSpace(filename))
            {
                return;
            }

            LoadImage(instance, editorData, Path.Combine(Path.GetDirectoryName(editorData.GameConfigFilePath), filename));
        }

        private static void LoadImage(MainWindow instance, EditorData editorData, string imageFilePath)
        {
            try
            {
                var image = new BitmapImage(new Uri(imageFilePath));

                if (image.PixelWidth == 480 && image.PixelHeight == 480)
                {
                    CopyToDestination(editorData, imageFilePath);

                    editorData.ImageFileName = Path.GetFileName(imageFilePath);

                    instance.imgTile.Source = image;
                    instance.txtImgError.Text = string.Empty;
                }
                else
                {
                    instance.txtImgError.Text = "Image must be a .png, 480x480 pixels in size.";
                }
            }
            catch
            {
                instance.txtImgError.Text = $"Unable to load image '{imageFilePath}'.";
            }
        }

        private static void CopyToDestination(EditorData editorData, string imageFilePath)
        {
            string dstPath = Path.Combine(Path.GetDirectoryName(editorData.GameConfigFilePath), Path.GetFileName(imageFilePath));

            if (!File.Exists(dstPath))
            {
                File.Copy(imageFilePath, dstPath);
            }
        }

        private static void InitializeMPCheckbox(MainWindow instance, EditorData editorData)
        {
            var node = editorData.GameConfig.SelectSingleNode(MultiplayerProtocolNodePath);

            if (node == null)
            {
                return;
            }

            instance.chkMultiplayer.IsChecked = !string.IsNullOrWhiteSpace(node.InnerText) && node.InnerText.ToLowerInvariant() == "true";
        }

        private static bool IsValidStoreAssociation(EditorData editorData)
        {
            var gameConfig = editorData.GameConfig;

            return gameConfig.IsValidAttribute(ShellVisualsNodePath, DefaultDisplayNameAttr)
                && gameConfig.IsValidAttribute(IdentityNodePath, NameAttr)
                && gameConfig.IsValidNode(StoreIdNodePath)
                && gameConfig.IsValidNode(MSAAppIdNodePath)
                && gameConfig.IsValidNode(TitleIdNodePath);
        }

        private static Image ResizeImage(System.Drawing.Image image, System.Drawing.Size size, bool preserveAspectRatio = false)
        {
            int newWidth;
            int newHeight;
            if (preserveAspectRatio)
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;
                float percentWidth = (float)size.Width / (float)originalWidth;
                float percentHeight = (float)size.Height / (float)originalHeight;
                float percent = percentHeight < percentWidth ? percentHeight : percentWidth;
                newWidth = (int)(originalWidth * percent);
                newHeight = (int)(originalHeight * percent);
            }
            else
            {
                newWidth = size.Width;
                newHeight = size.Height;
            }
            System.Drawing.Image newImage = new Bitmap(newWidth, newHeight);
            using (Graphics graphicsHandle = Graphics.FromImage(newImage))
            {
                graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return newImage;
        }

        private static void ResizedAndSaveImage(EditorData editorData, string destImageName, int desiredWidth, int desiredHeight)
        {
            string fullSourceImagePath = Path.Combine(Path.GetDirectoryName(editorData.GameConfigFilePath), Path.GetFileName(editorData.ImageFileName));
            string fullDestinationImagePath = Path.Combine(Path.GetDirectoryName(editorData.GameConfigFilePath), Path.GetFileName(destImageName));

            System.Drawing.Image original = System.Drawing.Image.FromFile(fullSourceImagePath);
            System.Drawing.Image resizedSquare150x150Logo = ResizeImage(original, new System.Drawing.Size(desiredWidth, desiredHeight));
            MemoryStream memStream = new MemoryStream();
            resizedSquare150x150Logo.Save(memStream, ImageFormat.Png);
            resizedSquare150x150Logo.Save(fullDestinationImagePath);
        }

        private static void UpdateGameConfig(MainWindow instance, EditorData editorData)
        {
            // TODO: Update the EXE path, if game engine is Other.
            var gameConfigFilePath = editorData.GameConfigFilePath;
            var gameConfig = editorData.GameConfig;

            if (string.IsNullOrWhiteSpace(editorData.ImageFileName) &&
                !string.IsNullOrWhiteSpace(editorData.DefaultImageFilePath))
            {
                // Use default image.
                CopyToDestination(editorData, editorData.DefaultImageFilePath);
                editorData.ImageFileName = Path.GetFileName(editorData.DefaultImageFilePath);
            }

            ResizedAndSaveImage(editorData, Square150x150LogoFileName, 150, 150);
            ResizedAndSaveImage(editorData, Square44x44LogoFileName, 44, 44);
            ResizedAndSaveImage(editorData, SplashScreenImageFileName, 1920, 1080);
            ResizedAndSaveImage(editorData, StoreLogoFileName, 100, 100);

            gameConfig.CreateOrUpdateAttribute(ShellVisualsNodePath, Square150x150LogoAttr, Square150x150LogoFileName);
            gameConfig.CreateOrUpdateAttribute(ShellVisualsNodePath, Square44x44LogoAttr, Square44x44LogoFileName);
            gameConfig.CreateOrUpdateAttribute(ShellVisualsNodePath, SplashScreenImageAttr, SplashScreenImageFileName);
            gameConfig.CreateOrUpdateAttribute(ShellVisualsNodePath, StoreLogoAttr, StoreLogoFileName);
            gameConfig.CreateOrUpdateAttribute(IdentityNodePath, PublisherIdAttr, editorData.PublisherId.Trim());
            gameConfig.CreateOrUpdateAttribute(ShellVisualsNodePath, PublisherNameAttr, editorData.PublisherName.Trim());
            gameConfig.CreateOrUpdateNode(MultiplayerProtocolNodePath, instance.chkMultiplayer.IsChecked.ToString().ToLowerInvariant());

            try
            {
                gameConfig.Save(gameConfigFilePath);
            }
            catch
            {
                DisplayErrorMessageBox("Unable to save config file");
            }
        }

        private void PCDirectEditGameConfig_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(_editorData.GameConfigFilePath);
            }
            catch (Exception ex)
            {
                DisplayErrorMessageBox(ex.Message);
            }
        }
    }
}
