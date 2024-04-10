using GroupDocs.Watermark.Contents.Pdf;
using GroupDocs.Watermark.Options.Pdf;
using GroupDocs.Watermark.Search;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    /// <summary>
    /// This example shows how to find and remove all XObjects containing text with a particular formatting from a PDF document.
    /// </summary>
    public static class PdfRemoveXObjectWithParticularTextFormatting
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(PdfRemoveXObjectWithParticularTextFormatting).Name}\n");

            string documentPath = Constants.InDocumentPdf;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            var loadOptions = new PdfLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                PdfContent pdfContent = watermarker.GetContent<PdfContent>();
                foreach (PdfPage page in pdfContent.Pages)
                {
                    for (int i = page.XObjects.Count - 1; i >= 0; i--)
                    {
                        foreach (FormattedTextFragment fragment in page.XObjects[i].FormattedTextFragments)
                        {
                            if (fragment.ForegroundColor.Equals(Color.Red))
                            {
                                page.XObjects.RemoveAt(i);
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
