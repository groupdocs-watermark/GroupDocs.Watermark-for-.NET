using GroupDocs.Watermark.Options.Email;
using GroupDocs.Watermark.Options.Image;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToImages
{
    /// <summary>
    /// This example shows how to add watermark to some particular frame(s).
    /// </summary>
    public static class AddWatermarkToImage
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(AddWatermarkToImage).Name}");

            string documentPath = Constants.InImageTiff;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            var loadOptions = new TiffImageLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                // Initialize text or image watermark
                TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 19));

                // Add watermark to the first frame
                TiffImageWatermarkOptions options = new TiffImageWatermarkOptions();
                options.FrameIndex = 0;

                watermarker.Add(watermark, options);
                watermarker.Save(outputFileName);
            }

            Console.WriteLine($"Watermark added successfully.\nCheck output in {outputDirectory}\n");
        }
    }
}
