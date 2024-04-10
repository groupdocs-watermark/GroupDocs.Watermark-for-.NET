using GroupDocs.Watermark.Contents.Pdf;
using GroupDocs.Watermark.Options.Pdf;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    /// <summary>
    /// This example shows how to edit and replace the text with formatting.
    /// </summary>
    public static class PdfReplaceTextForParticularAnnotationWithFormatting
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(PdfReplaceTextForParticularAnnotationWithFormatting).Name}\n");

            string documentPath = Constants.InDocumentPdf;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new PdfLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                PdfContent pdfContent = watermarker.GetContent<PdfContent>();
                foreach (PdfAnnotation annotation in pdfContent.Pages[0].Annotations)
                {
                    // Replace text
                    if (annotation.Text.Contains("Test"))
                    {
                        annotation.FormattedTextFragments.Clear();
                        annotation.FormattedTextFragments.Add("Passed", new Font("Calibri", 19, FontStyle.Bold), Color.Red, Color.Aqua);
                    }
                }

                // Save document
                watermarker.Save(outputFileName);
            }
        }
    }
}
