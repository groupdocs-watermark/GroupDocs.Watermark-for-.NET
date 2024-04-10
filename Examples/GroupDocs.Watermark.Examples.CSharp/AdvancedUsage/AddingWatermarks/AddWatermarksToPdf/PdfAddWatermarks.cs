using GroupDocs.Watermark.Options.Pdf;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    /// <summary>
    /// This example shows how to add watermark to a particular page of a PDF document.
    /// </summary>
    public static class PdfAddWatermarks
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(PdfAddWatermarks).Name}\n");

            string documentPath = Constants.InDocumentPdf;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            var loadOptions = new PdfLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                // Add text watermark to the first page
                TextWatermark textWatermark = new TextWatermark("This is a test watermark", new Font("Arial", 8));
                PdfArtifactWatermarkOptions textWatermarkOptions = new PdfArtifactWatermarkOptions();
                textWatermarkOptions.PageIndex = 0;

                watermarker.Add(textWatermark, textWatermarkOptions);

                // Add image watermark to the second page
                using (ImageWatermark imageWatermark = new ImageWatermark(Constants.ProtectJpg))
                {
                    PdfArtifactWatermarkOptions imageWatermarkOptions = new PdfArtifactWatermarkOptions();
                    imageWatermarkOptions.PageIndex = 1;
                    watermarker.Add(imageWatermark, imageWatermarkOptions);
                }

                watermarker.Save(outputFileName);
            }
        }
    }
}
