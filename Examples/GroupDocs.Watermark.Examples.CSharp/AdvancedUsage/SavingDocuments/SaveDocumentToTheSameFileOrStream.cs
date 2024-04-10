using System;
using System.IO;
using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.SavingDocuments
{
    /// <summary>
    /// This example shows how to save the document to the underlying source.
    /// </summary>
    public static class SaveDocumentToTheSameFileOrStream
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(SaveDocumentToTheSameFileOrStream).Name}\n");
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(Constants.InTestDoc));

            File.Copy(Constants.InTestDoc, outputFileName);
            using (Watermarker watermarker = new Watermarker(outputFileName))
            {
                // watermarking goes here
                TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 12));
                watermarker.Add(watermark);

                // Saves the document to the underlying source (stream or file)
                watermarker.Save();
            }
        }
    }
}
