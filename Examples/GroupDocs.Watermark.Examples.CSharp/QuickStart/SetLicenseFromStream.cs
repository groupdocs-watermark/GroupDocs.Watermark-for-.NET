﻿// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using System;
using System.IO;

namespace GroupDocs.Watermark.Examples.CSharp.QuickStart
{
    /// <summary>
    ///     This example demonstrates how to set license from stream.
    /// </summary>
    public static class SetLicenseFromStream
    {
        public static void Run()
        {
            if (File.Exists(Constants.LicenseFilePath))
            {
                using (FileStream stream = File.OpenRead(Constants.LicenseFilePath))
                {
                    License license = new License();
                    license.SetLicense(stream);
                }

                Console.WriteLine("License set successfully.");
            }
            else
            {
                Console.WriteLine("\nWe do not ship any license with this example. " +
                                  "\nVisit the GroupDocs site to obtain either a temporary or permanent license. " +
                                  "\nLearn more about licensing at https://purchase.groupdocs.com/faqs/licensing. " +
                                  "\nLearn how to request temporary license at https://purchase.groupdocs.com/temporary-license.");
            }
        }
    }
}
