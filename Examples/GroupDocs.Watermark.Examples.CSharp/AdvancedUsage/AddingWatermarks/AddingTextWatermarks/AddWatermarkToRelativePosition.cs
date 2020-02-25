// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddingTextWatermarks
{
    using Common;
    using Watermarks;

    /// <summary>
    /// This example shows how to align the watermark vertically and horizontally.
    /// </summary>
    public static class AddWatermarkToRelativePosition
    {
        public static void Run()
        {
            // Constants.InImagePng is an absolute or relative path to your document. Ex: @"C:\Docs\image.png"
            using (Watermarker watermarker = new Watermarker(Constants.InImagePng))
            {
                Font font = new Font("Calibri", 12);
                TextWatermark watermark = new TextWatermark("Test watermark", font);
                watermark.HorizontalAlignment = HorizontalAlignment.Right;
                watermark.VerticalAlignment = VerticalAlignment.Bottom;

                // Set absolute margins. Values are measured in document units.
                watermark.Margins.Right = 10;
                watermark.Margins.Bottom = 5;

                watermarker.Add(watermark);
                watermarker.Save(Constants.OutImagePng);
            }
        }
    }
}