using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Options.Image;
using GroupDocs.Watermark.Options.Pdf;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    /// <summary>
    /// Thies example shows how to add watermark annotation to a PDF document.
    /// </summary>
    public static class PdfAddAnnotationWatermark
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(PdfAddAnnotationWatermark).Name}\n");

            string documentPath = Constants.SamplePdf;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            var loadOptions = new PdfLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                PdfAnnotationWatermarkOptions options = new PdfAnnotationWatermarkOptions();

                // Add text watermark
                TextWatermark textWatermark = new TextWatermark("This is a annotation watermark", new Font("Arial", 8));
                textWatermark.HorizontalAlignment = HorizontalAlignment.Left;
                textWatermark.VerticalAlignment = VerticalAlignment.Top;
                watermarker.Add(textWatermark, options);

                // Add image watermark
                using (ImageWatermark imageWatermark = new ImageWatermark(Constants.ProtectJpg))
                {
                    imageWatermark.HorizontalAlignment = HorizontalAlignment.Right;
                    imageWatermark.VerticalAlignment = VerticalAlignment.Top;
                    watermarker.Add(imageWatermark, options);
                }

                watermarker.Save(outputFileName);
            }
        }
    }
}
