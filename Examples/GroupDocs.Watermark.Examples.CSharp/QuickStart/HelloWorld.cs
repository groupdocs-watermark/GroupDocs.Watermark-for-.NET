using GroupDocs.Watermark.Options.Pdf;
using GroupDocs.Watermark.Watermarks;
using System;
using System.IO;

namespace GroupDocs.Watermark.Examples.CSharp.QuickStart
{
    public static class HelloWorld
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Quick start] # HelloWorld\n");

            string documentPath = Constants.InDocumentPdf; // NOTE: Put here actual path for your document

            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            PdfLoadOptions loadOptions = new PdfLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 36, FontStyle.Bold | FontStyle.Italic));
                PdfXObjectWatermarkOptions options = new PdfXObjectWatermarkOptions();
                options.PageIndex = 0;

                watermarker.Add(watermark, options);

                watermarker.Save(outputFileName);
            }
        }
    }
}
