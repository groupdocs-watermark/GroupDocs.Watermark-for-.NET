// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddingTextWatermarks
{
    /// <summary>
    /// This example show how to rotate a watermark.
    /// </summary>
    public static class AddTextWatermarkWithRotationAngle
    {
        public static void Run()
        {
            // Constants.InTestDocx is an absolute or relative path to your document. Ex: @"C:\Docs\test.docx"
            using (Watermarker watermarker = new Watermarker(Constants.InTestDocx))
            {
                Font font = new Font("Calibri", 8);
                TextWatermark watermark = new TextWatermark("Test watermark", font);
                watermark.HorizontalAlignment = HorizontalAlignment.Right;
                watermark.VerticalAlignment = VerticalAlignment.Top;
                watermark.SizingType = SizingType.ScaleToParentDimensions;
                watermark.ScaleFactor = 0.5;

                // Set rotation angle
                watermark.RotateAngle = 45;

                watermarker.Add(watermark);
                watermarker.Save(Constants.OutTestDocx);
            }
        }
    }
}
