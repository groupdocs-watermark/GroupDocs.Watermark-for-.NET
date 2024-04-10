using System;
using System.IO;
using GroupDocs.Watermark.Contents.Pdf;
using GroupDocs.Watermark.Options.Pdf;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    /// <summary>
    /// This example shows how to  replace the image of a particular artifact.
    /// </summary>
    public static class PdfReplaceImageForParticularArtifact
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(PdfReplaceImageForParticularArtifact).Name}\n");

            string documentPath = Constants.InDocumentPdf;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            var loadOptions = new PdfLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                PdfContent pdfContent = watermarker.GetContent<PdfContent>();

                // Replace image
                foreach (PdfArtifact artifact in pdfContent.Pages[0].Artifacts)
                {
                    if (artifact.Image != null)
                    {
                        artifact.Image = new PdfWatermarkableImage(File.ReadAllBytes(Constants.TestPng));
                    }
                }

                // Save document
                watermarker.Save(outputFileName);
            }
        }
    }
}
