// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage
{
    using System;
    using Exceptions;
    using Options;
    using Watermarks;

    /// <summary>
    ///     This example shows how to receive the information via ILogger interface.
    /// </summary>
    public static class Logging
    {
        public static void Run()
        {
            try
            {
                // Create an instance of Logger class
                Logger logger = new Logger();

                WatermarkerSettings watermarkerSettings = new WatermarkerSettings();
                watermarkerSettings.Logger = logger;

                LoadOptions loadOptions = new LoadOptions();
                loadOptions.Password = "InvalidPassword";
                // Constants.InProtectedDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\protected-document.docx"
                string filePath = Constants.InProtectedDocumentDocx;
                using (Watermarker watermarker = new Watermarker(filePath, loadOptions, watermarkerSettings))
                {
                    // use watermarker methods to manage watermarks in the document
                    TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 12));
                    watermarker.Add(watermark);
                    watermarker.Save(Constants.OutProtectedDocumentDocx);
                }
            }
            catch (InvalidPasswordException)
            {
                ; // Ignore the exception
            }
        }

        private class Logger : ILogger
        {
            public void Error(string message, Exception exception)
            {
                // Print error message
                Console.WriteLine("Error: " + message);
            }

            public void Trace(string message)
            {
                // Print event message
                Console.WriteLine("Event: " + message);
            }

            public void Warning(string message)
            {
                // Print warning message
                Console.WriteLine("Warning: " + message);
            }
        }
    }
}
