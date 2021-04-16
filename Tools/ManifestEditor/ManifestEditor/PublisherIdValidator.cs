// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using System.Globalization;
using System.Windows.Controls;

namespace ManifestEditor
{
    public class PublisherIdValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (!MainWindow._publisherIdRegex.IsMatch((string)value))
            {
                return new ValidationResult(false, "Invalid Publisher format.");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}