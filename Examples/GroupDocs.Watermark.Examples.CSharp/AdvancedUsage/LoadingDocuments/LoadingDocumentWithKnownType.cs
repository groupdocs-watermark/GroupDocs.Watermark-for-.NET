using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Watermarks;
using System;
using System.IO;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.LoadingDocuments
{
    /// <summary>
    /// This example demonstrates how to create a watermark the document with known type for best performance:
    /// </summary>
    public static class LoadingDocumentWithKnownType
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(LoadingDocumentWithKnownType).Name}\n");

            string documentPath = Constants.InSpreadsheetXlsx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new Options.LoadOptions()
            {
                FileType = FileType.FromExtension(Path.GetExtension(documentPath))
            };

            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                TextWatermark watermark = new TextWatermark("Test\nwatermark", new Font("Arial", 12));
                watermark.TextAlignment = TextAlignment.Center;
                watermarker.Add(watermark);

                watermarker.Save(outputFileName);
            }
        }
    }
}
