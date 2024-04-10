using GroupDocs.Watermark.Options.Pdf;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    /// <summary>
    /// This example shows how to add watermark to particular pages of a PDF document.
    /// </summary>
    public static class PdfAddWatermarksToSpecificPages
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(PdfAddWatermarksToSpecificPages).Name}\n");

            string documentPath = Constants.InDocumentPdf;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            var loadOptions = new PdfLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                // Add text watermark to the odd pages
                TextWatermark textWatermark = new TextWatermark("This is a test watermark", new Font("Arial", 8));
                textWatermark.PagesSetup = new PagesSetup
                {
                    OddPages = true
                };
                
                PdfArtifactWatermarkOptions textWatermarkOptions = new PdfArtifactWatermarkOptions();

                watermarker.Add(textWatermark, textWatermarkOptions);

                // Add image watermark to the first page
                using (ImageWatermark imageWatermark = new ImageWatermark(Constants.ProtectJpg))
                {
                    imageWatermark.PagesSetup = new PagesSetup
                    {
                        FirstPage = true
                    };
                    
                    PdfArtifactWatermarkOptions imageWatermarkOptions = new PdfArtifactWatermarkOptions();
                    watermarker.Add(imageWatermark, imageWatermarkOptions);
                }

                watermarker.Save(outputFileName);
            }
        }
    }
}