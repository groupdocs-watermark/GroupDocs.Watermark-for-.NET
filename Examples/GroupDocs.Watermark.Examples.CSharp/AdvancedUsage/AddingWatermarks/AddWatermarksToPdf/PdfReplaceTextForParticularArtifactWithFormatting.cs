using GroupDocs.Watermark.Contents.Pdf;
using GroupDocs.Watermark.Options.Pdf;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    /// <summary>
    /// This example shows how to replace the text of the particular artifacts with formatted text.
    /// </summary>
    public static class PdfReplaceTextForParticularArtifactWithFormatting
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(PdfReplaceTextForParticularArtifactWithFormatting).Name}\n");

            string documentPath = Constants.InDocumentPdf;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new PdfLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                PdfContent pdfContent = watermarker.GetContent<PdfContent>();
                foreach (PdfArtifact artifact in pdfContent.Pages[0].Artifacts)
                {
                    // Replace text
                    if (artifact.Text.Contains("Test"))
                    {
                        artifact.FormattedTextFragments.Clear();
                        artifact.FormattedTextFragments.Add("Passed", new Font("Calibri", 19, FontStyle.Bold), Color.Red, Color.Aqua);
                    }
                }

                // Save document
                watermarker.Save(outputFileName);
            }
        }
    }
}
