using GroupDocs.Watermark.Contents.Pdf;
using GroupDocs.Watermark.Options.Pdf;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    /// <summary>
    /// This example shows how to replace text with formatting.
    /// </summary>
    public static class PdfReplaceTextForParticularXObjectWithFormatting
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(PdfReplaceTextForParticularXObjectWithFormatting).Name}\n");

            string documentPath = Constants.InDocumentPdf;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new PdfLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                PdfContent pdfContent = watermarker.GetContent<PdfContent>();
                foreach (PdfXObject xObject in pdfContent.Pages[0].XObjects)
                {
                    // Replace text
                    if (xObject.Text.Contains("Test"))
                    {
                        xObject.FormattedTextFragments.Clear();
                        xObject.FormattedTextFragments.Add("Passed", new Font("Calibri", 19, FontStyle.Bold), Color.Red, Color.Aqua);
                    }
                }

                // Save document
                watermarker.Save(outputFileName);
            }
        }
    }
}
