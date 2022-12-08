// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddingImageWatermarks
{
    /// <summary>
    /// This example shows how to add image watermark from a local file.
    /// </summary>
    public static class AddImageWatermark
    {
        public static void Run()
        {
            // Constants.InPresentationPptx is an absolute or relative path to your document. Ex: @"C:\Docs\presentation.pptx"
            using (Watermarker watermarker = new Watermarker(Constants.InPresentationPptx))
            {
                // Use path to the image as constructor parameter
                using (ImageWatermark watermark = new ImageWatermark(Constants.WatermarkJpg))
                {
                    // Add watermark to the document
                    watermarker.Add(watermark);

                    watermarker.Save(Constants.OutPresentationPptx);
                }
            }
        }
    }
}
