// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddingTextWatermarks
{
    /// <summary>
    /// This example shows how to set relative margins for a watermark.
    /// </summary>
    public static class AddWatermarkWithMarginType
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

                // Set relative margins. Margin value will be interpreted as a portion
                // of appropriate parent dimension. If this type is chosen, margin value
                // must be between 0.0 and 1.0.
                watermark.Margins.MarginType = MarginType.RelativeToParentDimensions;
                watermark.Margins.Right = 0.1;
                watermark.Margins.Bottom = 0.2;

                watermarker.Add(watermark);
                watermarker.Save(Constants.OutImagePng);
            }
        }
    }
}
