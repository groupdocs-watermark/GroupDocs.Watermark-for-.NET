using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Contents.Image;
using GroupDocs.Watermark.Contents.Spreadsheet;
using GroupDocs.Watermark.Options.Spreadsheet;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    /// <summary>
    /// This example shows how to add watermark to the images that belong to a particular worksheet.
    /// </summary>
    public static class SpreadsheetAddWatermarkToWorksheetImages
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(SpreadsheetAddWatermarkToWorksheetImages).Name}\n");

            string documentPath = Constants.InSpreadsheetXlsx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new SpreadsheetLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                TextWatermark watermark = new TextWatermark("Protected image", new Font("Arial", 8));
                watermark.HorizontalAlignment = HorizontalAlignment.Center;
                watermark.VerticalAlignment = VerticalAlignment.Center;
                watermark.RotateAngle = 45;
                watermark.SizingType = SizingType.ScaleToParentDimensions;
                watermark.ScaleFactor = 1;

                // Get all images from the first worksheet
                SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();
                WatermarkableImageCollection images = content.Worksheets[0].FindImages();

                // Add watermark to all found images
                foreach (WatermarkableImage image in images)
                {
                    image.Add(watermark);
                }

                watermarker.Save(outputFileName);
            }
        }
    }
}
