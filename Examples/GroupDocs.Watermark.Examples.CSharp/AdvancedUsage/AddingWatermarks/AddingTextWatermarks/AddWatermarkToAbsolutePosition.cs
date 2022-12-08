// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddingTextWatermarks
{
    /// <summary>
    /// This example shows how to add a text watermark with absolute positioning.
    /// </summary>
    public static class AddWatermarkToAbsolutePosition
    {
        public static void Run()
        {
            // Constants.InImagePng is an absolute or relative path to your document. Ex: @"C:\Docs\image.png"
            using (Watermarker watermarker = new Watermarker(Constants.InImagePng))
            {
                Font font = new Font("Times New Roman", 8);
                TextWatermark watermark = new TextWatermark("Test watermark", font);

                // Set watermark coordinates
                watermark.X = 10;
                watermark.Y = 20;

                // Set watermark size
                watermark.Width = 100;
                watermark.Height = 40;

                watermarker.Add(watermark);
                watermarker.Save(Constants.OutImagePng);
            }
        }
    }
}
