// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddingTextWatermarks
{
    /// <summary>
    /// This example shows how to consider the size of the page/slide/frame on which a watermark will be placed.
    /// </summary>
    public static class AddWatermarkWithSizeType
    {
        public static void Run()
        {
            // Constants.InImagePng is an absolute or relative path to your document. Ex: @"C:\Docs\image.png"
            using (Watermarker watermarker = new Watermarker(Constants.InImagePng))
            {
                Font font = new Font("Calibri", 12);
                TextWatermark watermark = new TextWatermark("This is a test watermark", font);

                // Set sizing type
                watermark.SizingType = SizingType.ScaleToParentDimensions;

                // Set watermark scale
                watermark.ScaleFactor = 0.5;

                watermarker.Add(watermark);
                watermarker.Save(Constants.OutImagePng);
            }
        }
    }
}
