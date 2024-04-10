using GroupDocs.Watermark.Options.WordProcessing;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.SavingDocuments
{
    /// <summary>
    /// This example shows how to save the document to the specified location.
    /// </summary>
    public static class SaveDocumentToTheSpecifiedLocation
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(SaveDocumentToTheSpecifiedLocation).Name}\n");

            string documentPath = Constants.InTestDoc;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            using (Watermarker watermarker = new Watermarker(documentPath))
            {
                // watermarking goes here
                TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 12));
                watermarker.Add(watermark);

                // Saves the document to the specified location
                watermarker.Save(outputFileName);
            }
        }
    }
}
