using System;
using System.IO;
using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.SavingDocuments
{
    /// <summary>
    /// This example shows how to save the document to the specified stream.
    /// </summary>
    public static class SaveDocumentToTheSpecifiedStream
    {
        public static void Run()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                Console.WriteLine($"[Example Advanced Usage] # {typeof(SaveDocumentToTheSpecifiedStream).Name}\n");

                using (Watermarker watermarker = new Watermarker(Constants.InTestDoc))
                {
                    // watermarking goes here
                    TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 12));
                    watermarker.Add(watermark);

                    // Saves the document to the specified stream
                    watermarker.Save(stream);
                }
            }
        }
    }
}
