using System;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XGamingRuntime;
using System.Diagnostics;

namespace TestGame
{
    public partial class MultiplayerManagerForm : Form
    {
        private const string SCID = "00000000-0000-0000-0000-000076029b4d";
        private const UInt32 TitleId = 1979882317;
        private XUserHandle userHandle = null;
        private UInt64 userId = 0;

        private XblContextHandle xblContextHandle = null;
        private XRegistrationToken inviteToken = null;

        private bool processingEvents = false;
        private string ctxObject = "ContextTest";
        private XblMultiplayerSearchHandle searchHandle;

        public MultiplayerManagerForm()
        {
            InitializeComponent();

            Int32 hresult = SDK.XBL.XblInitialize(SCID);
            LOG("XblInitialize", hresult);

            SDK.XUserAddAsync(XUserAddOptions.AddDefaultUserAllowingUI, (hr, userHandle) =>
            {
                LOG("XUserAddAsync", hr);
                if (hr >= 0)
                {
                    this.userHandle = userHandle;
                    hr = SDK.XBL.XblContextCreateHandle(userHandle, out xblContextHandle);
                    LOG("XblContextCreateHandle", hr);

                    hr = SDK.XUserGetId(userHandle, out userId);
                    LOG("XUserGetId", hr);

                    if (hr >= 0)
                    {
                        initButton.Enabled = true;
                        registerForInvitesButton.Enabled = true;
                    }
                }
            });
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            SDK.XTaskQueueDispatch();

            // Calling DoWork clobbers the existing multiplayer events, which we want to avoid
            // but logging or modifying UI elements will cause the WndProc to get called again
            // This flag protects us from reentering DoWork
            if (!processingEvents)
            {
                SDK.XBL.XblMultiplayerManagerDoWork(out XblMultiplayerEvent[] events);
                ProcessEvents(events);
            }
        }

        private void LOG(string s)
        {
            textBox1.AppendText(s + "\r\n");
        }

        private void LOG(string s, Int32 hr)
        {
            textBox1.AppendText(String.Format("{0} -- hresult = 0x{1}\r\n", s, hr.ToString("X8")));
        }

        private void ProcessEvents(XblMultiplayerEvent[] events)
        {
            processingEvents = true;
            foreach (var evt in events)
            {
                var type = evt.EventType;
                LOG(string.Format("Event: {0}", type));
                ulong xuid = 0;
                 
                switch (type)
                {
                    case XblMultiplayerEventType.UserAdded:
                        SDK.XBL.XblMultiplayerEventArgsXuid(evt.EventArgsHandle, out xuid);
                        lobbyUserList.Items.Add(xuid.ToString(), false);
                        setSessionPropsButton.Enabled = true;
                        listLobbyMembersButton.Enabled = true;
                        break;

                    case XblMultiplayerEventType.UserRemoved:
                        SDK.XBL.XblMultiplayerEventArgsXuid(evt.EventArgsHandle, out xuid);
                        lobbyUserList.Items.Remove(xuid.ToString());
                        break;

                    case XblMultiplayerEventType.JoinLobbyCompleted:
                        if (evt.Result < 0)
                        {
                            LOG("JoinLobbyCompleted Failed: ", evt.Result);
                            LOG(evt.ErrorMessage);
                        }
                        else
                        {
                            UpdateLobbyMembers();
                        }
                        break;

                    case XblMultiplayerEventType.MemberJoined:
                        SDK.XBL.XblMultiplayerEventArgsMembers(evt.EventArgsHandle, out XblMultiplayerManagerMember[] newMembers);
                        foreach(var newMember in newMembers)
                        {
                            lobbyUserList.Items.Add(newMember.Xuid.ToString(), false);
                        }
                        break;

                    case XblMultiplayerEventType.MemberLeft:
                        SDK.XBL.XblMultiplayerEventArgsMembers(evt.EventArgsHandle, out XblMultiplayerManagerMember[] removedMembers);
                        foreach(var removedMember in removedMembers)
                        {
                            lobbyUserList.Items.Remove(removedMember.Xuid.ToString());
                        }
                        break;

                    case XblMultiplayerEventType.SessionSynchronizedPropertyWriteCompleted:
                        Debug.Assert(evt.Context == (object)this.ctxObject);
                        break;

                    case XblMultiplayerEventType.SessionPropertyChanged:
                        SDK.XBL.XblMultiplayerEventArgsPropertiesJson(evt.EventArgsHandle, out string props);
                        LOG(string.Format("Session props changed: {0}", props));
                        break;
                }
            }
            processingEvents = false;
        }

        private void initButton_Click(object sender, EventArgs e)
        {
            int hr = SDK.XBL.XblMultiplayerManagerInitialize("LobbySession");
            LOG("XblMultiplayerManagerInitialize", hr);

            if (hr >= 0)
            {
                addUserButton.Enabled = true;
                joinLobbyButton.Enabled = true;
                searchForSessionButton.Enabled = true;
            }
        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            int hr = SDK.XBL.XblMultiplayerManagerLobbySessionAddLocalUser(userHandle);
            if (hr >= 0)
            {
                inviteFriendsButton.Enabled = true;
                searchButton.Enabled = true;
            }
        }

        private void inviteFriendsButton_Click(object sender, EventArgs e)
        {
            int hr = SDK.XBL.XblMultiplayerManagerLobbySessionInviteFriends(userHandle, string.Empty, string.Empty);
            LOG("InviteFriends", hr);
        }

        private void registerForInvitesButton_Click(object sender, EventArgs e)
        {
            int hr = SDK.XGameInviteRegisterForEvent(gameInviteCallback, out inviteToken);
            LOG("XGameInviteRegisterForEvent", hr);
            if (hr >= 0)
            {
                registerForInvitesButton.Enabled = false;
                unregisterForInvitesButton.Enabled = true;
            }
        }

        private void gameInviteCallback(string inviteUri)
        {
            LOG(string.Format("Received game invite with uri {0}", inviteUri));

            // ms-xbl-multiplayer://activityHandleJoin?joinerXuid=2814672821595782&handle=799e5069-830a-4f4c-94fd-aaba40cd772b&joineeXuid=2814617550604488
            Uri uri = new Uri(inviteUri);
            var queryProps = HttpUtility.ParseQueryString(uri.Query);
            if (queryProps.AllKeys.Contains("handle"))
            {
                lobbyHandleTextBox.Text = queryProps["handle"];
            }
        }

        private void unregisterForInvitesButton_Click(object sender, EventArgs e)
        {
            SDK.XGameInviteUnregisterForEvent(inviteToken);
            registerForInvitesButton.Enabled = true;
            unregisterForInvitesButton.Enabled = false;
        }

        private void joinLobbyButton_Click(object sender, EventArgs e)
        {
            SDK.XBL.XblMultiplayerManagerJoinLobby(lobbyHandleTextBox.Text, userHandle);
        }

        private void UpdateLobbyMembers()
        {
            int hr = SDK.XBL.XblMultiplayerManagerLobbySessionMembers(out XblMultiplayerManagerMember[] members);
            LOG("XblMultiplayerManagerLobbySessionMembers", hr);

            if (hr >= 0)
            {
                lobbyUserList.Items.Clear();
                foreach (var member in members)
                {
                    lobbyUserList.Items.Add(member.Xuid.ToString(), false);
                }
            }
        }

        private void setSessionPropsButton_Click(object sender, EventArgs e)
        {
            int hr = SDK.XBL.XblMultiplayerManagerLobbySessionSetSynchronizedProperties("testProp", "testValue", ctxObject);
            LOG("XblMultiplayerManagerLobbySessionSetSynchronizedProperties", hr);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SDK.XBL.XblMultiplayerManagerLobbySessionSessionReference(
                out XblMultiplayerSessionReference sessionReference);

            var sessionTags = new XblMultiplayerSessionTag[]
            {
                new XblMultiplayerSessionTag("testTag1"),
                new XblMultiplayerSessionTag("testTag2")
            };

            var numberAttributes = new XblMultiplayerSessionNumberAttribute[]
            {
                new XblMultiplayerSessionNumberAttribute("num1", 100.0),
                new XblMultiplayerSessionNumberAttribute("num2", 3.14159)
            };

            var stringAttributes = new XblMultiplayerSessionStringAttribute[]
            {
                new XblMultiplayerSessionStringAttribute("str1", "stringOne"),
                new XblMultiplayerSessionStringAttribute("str2", "stringTwo")
            };

            SDK.XBL.XblMultiplayerCreateSearchHandleAsync(
                xblContextHandle,
                sessionReference,
                sessionTags,
                numberAttributes,
                stringAttributes,
                (hr, handle) => 
                {
                    LOG("XblMultiplayerCreateSearchHandleAsync", hr);
                    if (hr >= 0)
                    {
                        deleteSearchHandleButton.Enabled = true;
                        DumpMultiplayerSearchHandle(handle);
                        searchHandle = handle;
                    }
                });
        }

        private void DumpMultiplayerSearchHandle(XblMultiplayerSearchHandle searchHandle)
        {
            int hr = SDK.XBL.XblMultiplayerSearchHandleGetTags(searchHandle, out XblMultiplayerSessionTag[] tags);
            LOG("XblMultiplayerSearchHandleGetTags", hr);
            if (hr >= 0)
            {
                foreach (var tag in tags)
                {
                    LOG($"    {tag.Value}");
                }
            }

            hr = SDK.XBL.XblMultiplayerSearchHandleGetNumberAttributes(searchHandle, out XblMultiplayerSessionNumberAttribute[] numberAttributes);
            LOG("XblMultiplayerSearchHandleGetNumberAttributes", hr);
            if (hr >= 0)
            {
                foreach (var attr in numberAttributes)
                {
                    LOG($"    {attr.Name} = {attr.Value}");
                }
            }

            hr = SDK.XBL.XblMultiplayerSearchHandleGetId(searchHandle, out string id);
            LOG("XblMultiplayerSearchHandleGetId", hr);
            if (hr >= 0)
            {
                LOG($"    id = {id}");
            }

            hr = SDK.XBL.XblMultiplayerSearchHandleDuplicateHandle(searchHandle, out XblMultiplayerSearchHandle duplicateHandle);
            LOG("XblMultiplayerSearchHandleDuplicateHandle", hr);

            hr = SDK.XBL.XblMultiplayerSearchHandleGetId(duplicateHandle, out string duplicateHandleId);
            LOG("XblMultiplayerSearchHandleGetId", hr);
            if (hr >= 0)
            {
                LOG($"    id (dupe handle) = {duplicateHandleId}");
            }

            hr = SDK.XBL.XblMultiplayerSearchHandleGetVisibility(searchHandle, out XblMultiplayerSessionVisibility visibility);
            LOG("XblMultiplayerSearchHandleGetVisibility", hr);
            if (hr >= 0)
            {
                LOG($"    visibility = {visibility}");
            }

            hr = SDK.XBL.XblMultiplayerSearchHandleGetCreationTime(searchHandle, out DateTime creationTime);
            LOG("XblMultiplayerSearchHandleGetCreationTime", hr);
            if (hr >= 0)
            {
                LOG($"    creationTime = {creationTime.ToLongDateString()}");
            }

            hr = SDK.XBL.XblMultiplayerSearchHandleGetMemberCounts(searchHandle, out uint maxMembers, out uint currentMembers);
            LOG("XblMultiplayerSearchHandleGetMemberCounts", hr);
            if (hr >= 0)
            {
                LOG($"    maxMembers     = {maxMembers}");
                LOG($"    currentMembers = {currentMembers}");
            }

            hr = SDK.XBL.XblMultiplayerSearchHandleGetSessionReference(searchHandle, out XblMultiplayerSessionReference sessionReference);
            LOG("XblMultiplayerSearchHandleGetSessionReference", hr);
            if (hr >= 0)
            {
                LOG($"    sessionReference = {sessionReference.SessionName}");
            }

            hr = SDK.XBL.XblMultiplayerSearchHandleGetStringAttributes(searchHandle, out XblMultiplayerSessionStringAttribute[] stringAttributes);
            LOG("XblMultiplayerSearchHandleGetStringAttributes", hr);
            if (hr >= 0)
            {
                foreach (var attr in stringAttributes)
                {
                    LOG($"    {attr.Name} = {attr.Value}");
                }
            }

            hr = SDK.XBL.XblMultiplayerSearchHandleGetSessionOwnerXuids(searchHandle, out UInt64[] xuids);
            LOG("XblMultiplayerSearchHandleGetSessionOwnerXuids", hr);
            if (hr >= 0)
            {
                foreach (var xuid in xuids)
                {
                    LOG($"    {xuid}");
                }
            }

            hr = SDK.XBL.XblMultiplayerSearchHandleGetJoinRestriction(searchHandle, out XblMultiplayerSessionRestriction joinRestriction);
            LOG("XblMultiplayerSearchHandleGetJoinRestriction", hr);
            if (hr >= 0)
            {
                LOG($"    joinRestriction = {joinRestriction}");
            }

            hr = SDK.XBL.XblMultiplayerSearchHandleGetCustomSessionPropertiesJson(searchHandle, out string customPropertiesJson);
            LOG("XblMultiplayerSearchHandleGetCustomSessionPropertiesJson", hr);
            if (hr >= 0)
            {
                LOG($"    customPropertiesJson = {customPropertiesJson}");
            }

            hr = SDK.XBL.XblMultiplayerSearchHandleGetSessionClosed(searchHandle, out bool closed);
            LOG("XblMultiplayerSearchHandleGetSessionClosed", hr);
            if (hr >= 0)
            {
                LOG($"    closed = {closed}");
            }
        }

        private void listLobbyMembersButton_Click(object sender, EventArgs e)
        {
            UpdateLobbyMembers();
        }

        private void searchForSessionButton_Click(object sender, EventArgs e)
        {
            SDK.XBL.XblMultiplayerGetSearchHandlesAsync(
                xblContextHandle,
                SCID,
                "LobbySession",
                string.Empty,
                true,
                null,
                null,
                (hresult, handles) =>
                {
                    LOG("XblMultiplayerGetSearchHandlesAsync", hresult);
                    if (hresult >= 0)
                    {
                        LOG($"    Retrieved {handles.Length} handles");

                        int counter = 1;
                        foreach(var handle in handles)
                        {
                            LOG($"--- Handle {counter++} ---");
                            DumpMultiplayerSearchHandle(handle);
                        }
                    }
                });
        }

        private void deleteSearchHandleButton_Click(object sender, EventArgs e)
        {
            if (searchHandle != null)
            {
                Int32 hr = SDK.XBL.XblMultiplayerSearchHandleGetId(searchHandle, out string id);
                LOG("XblMultiplayerSearchHandleGetId", hr);
                if (hr >= 0)
                {
                    LOG($" deleting id {id}");
                    SDK.XBL.XblMultiplayerDeleteSearchHandleAsync(xblContextHandle, id, (Int32 result) =>
                    {
                        LOG("DeleteSearchHandleAsync", hr);
                        searchHandle = null;
                    });
                }
            }
        }
    }
}
