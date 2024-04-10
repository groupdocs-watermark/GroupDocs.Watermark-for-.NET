using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Contents.Pdf;
using GroupDocs.Watermark.Options.Pdf;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    /// <summary>
    /// This example shows how to get watermark aligned to bleed box.
    /// </summary>
    public static class PdfAddWatermarkWithPageMarginType
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(PdfAddWatermarkWithPageMarginType).Name}\n");

            string documentPath = Constants.InDocumentPdf;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            var loadOptions = new PdfLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 42));
                watermark.HorizontalAlignment = HorizontalAlignment.Right;
                watermark.VerticalAlignment = VerticalAlignment.Top;
                watermark.SizingType = SizingType.ScaleToParentDimensions;
                watermark.ScaleFactor = 1;

                PdfContent pdfContent = watermarker.GetContent<PdfContent>();
                pdfContent.PageMarginType = PdfPageMarginType.BleedBox;
                watermark.ConsiderParentMargins = true;

                watermarker.Add(watermark);
                watermarker.Save(outputFileName);
            }
        }
    }
}
