using GroupDocs.Watermark.Contents.Pdf;
using GroupDocs.Watermark.Options.Pdf;
using System;
using System.IO;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    /// <summary>
    /// This example shows how to extract the information about the artifacts in a PDF document.
    /// </summary>
    public static class PdfExtractArtifactInformation
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(PdfExtractArtifactInformation).Name}\n");

            string documentPath = Constants.InDocumentPdf;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            var loadOptions = new PdfLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                PdfContent pdfContent = watermarker.GetContent<PdfContent>();
                foreach (PdfPage page in pdfContent.Pages)
                {
                    foreach (PdfArtifact artifact in page.Artifacts)
                    {
                        Console.WriteLine(artifact.ArtifactType);
                        Console.WriteLine(artifact.ArtifactSubtype);
                        if (artifact.Image != null)
                        {
                            Console.WriteLine(artifact.Image.Width);
                            Console.WriteLine(artifact.Image.Height);
                            Console.WriteLine(artifact.Image.GetBytes().Length);
                        }

                        Console.WriteLine(artifact.Text);
                        Console.WriteLine(artifact.Opacity);
                        Console.WriteLine(artifact.X);
                        Console.WriteLine(artifact.Y);
                        Console.WriteLine(artifact.Width);
                        Console.WriteLine(artifact.Height);
                        Console.WriteLine(artifact.RotateAngle);
                    }
                }
            }
        }
    }
}
