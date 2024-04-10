using GroupDocs.Watermark.Options.Spreadsheet;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.LoadingDocuments
{
    /// <summary>
    /// This examle demonstrates how to create a watermarker for the Spreadsheet document:
    /// </summary>
    public static class LoadingDocumentOfSpecificFormat
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(LoadingDocumentOfSpecificFormat).Name}\n");

            string documentPath = Constants.InSpreadsheetXlsx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new SpreadsheetLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                // use watermarker methods to manage watermarks in the Spreadsheet document
                TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 12));

                watermarker.Add(watermark);

                watermarker.Save(outputFileName);
            }
        }
    }
}
