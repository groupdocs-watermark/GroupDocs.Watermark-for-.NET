// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddingImageWatermarks
{
    using System.IO;
    using Watermarks;

    /// <summary>
    /// This example shows how to an image watermark from stream.
    /// </summary>
    public static class AddImageWatermarkUsingStream
    {
        public static void Run()
        {
            // Constants.WatermarkJpg is an absolute or relative path to your document. Ex: @"C:\Docs\watermark.jpg"
            using (Stream watermarkStream = File.OpenRead(Constants.WatermarkJpg))
            {
                using (Watermarker watermarker = new Watermarker(Constants.InImagePng))
                {
                    // Use stream containing an image as constructor parameter
                    using (ImageWatermark watermark = new ImageWatermark(watermarkStream))
                    {
                        // Add watermark to the document
                        watermarker.Add(watermark);

                        watermarker.Save(Constants.OutImagePng);
                    }
                }
            }
        }
    }
}