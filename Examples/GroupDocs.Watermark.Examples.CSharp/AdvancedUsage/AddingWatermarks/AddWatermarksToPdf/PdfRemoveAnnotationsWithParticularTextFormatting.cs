using GroupDocs.Watermark.Contents.Pdf;
using GroupDocs.Watermark.Options.Pdf;
using GroupDocs.Watermark.Search;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    /// <summary>
    /// This example shows how to find and remove all annotations containing text with a particular formatting from a PDF document.
    /// </summary>
    public static class PdfRemoveAnnotationsWithParticularTextFormatting
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(PdfRemoveAnnotationsWithParticularTextFormatting).Name}\n");

            string documentPath = Constants.InDocumentPdf;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            var loadOptions = new PdfLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                PdfContent pdfContent = watermarker.GetContent<PdfContent>();
                foreach (PdfPage page in pdfContent.Pages)
                {
                    for (int i = page.Annotations.Count - 1; i >= 0; i--)
                    {
                        foreach (FormattedTextFragment fragment in page.Annotations[i].FormattedTextFragments)
                        {
                            if (fragment.Font.FamilyName == "Verdana")
                            {
                                page.Annotations.RemoveAt(i);
                                break;
                            }
                        }
                    }
                }

                watermarker.Save(outputFileName);
            }
        }
    }
}
