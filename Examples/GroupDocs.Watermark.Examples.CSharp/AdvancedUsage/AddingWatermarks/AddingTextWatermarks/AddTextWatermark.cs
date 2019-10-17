// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddingTextWatermarks
{
    using Watermarks;

    /// <summary>
    /// This example shows how to add text watermark to a document.
    /// </summary>
    public static class AddTextWatermark
    {
        public static void Run()
        {
            // Constants.InImagePng is an absolute or relative path to your document. Ex: @"C:\Docs\image.png"
            using (Watermarker watermarker = new Watermarker(Constants.InImagePng))
            {
                // Initialize the font to be used for watermark
                Font font = new Font("Arial", 19, FontStyle.Bold | FontStyle.Italic);

                // Create the watermark object
                TextWatermark watermark = new TextWatermark("Test watermark", font);

                // Set watermark properties
                watermark.ForegroundColor = Color.Red;
                watermark.BackgroundColor = Color.Blue;
                watermark.TextAlignment = TextAlignment.Right;
                watermark.Opacity = 0.5;

                // Add watermark
                watermarker.Add(watermark);

                watermarker.Save(Constants.OutImagePng);
            }
        }
    }
}