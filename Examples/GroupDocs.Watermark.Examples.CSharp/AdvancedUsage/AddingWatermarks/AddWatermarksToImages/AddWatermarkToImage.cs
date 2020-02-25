// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToImages
{
    using Options.Image;
    using Watermarks;

    /// <summary>
    /// This example shows how to add watermark to some particular frame(s).
    /// </summary>
    public static class AddWatermarkToImage
    {
        public static void Run()
        {
            // Constants.InImageTiff is an absolute or relative path to your document. Ex: @"C:\Docs\image.tiff"
            TiffImageLoadOptions loadOptions = new TiffImageLoadOptions();
            using (Watermarker watermarker = new Watermarker(Constants.InImageTiff, loadOptions))
            {
                // Initialize text or image watermark
                TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 19));

                // Add watermark to the first frame
                TiffImageWatermarkOptions options = new TiffImageWatermarkOptions();
                options.FrameIndex = 0;

                watermarker.Add(watermark, options);
                watermarker.Save(Constants.OutImageTiff);
            }
        }
    }
}