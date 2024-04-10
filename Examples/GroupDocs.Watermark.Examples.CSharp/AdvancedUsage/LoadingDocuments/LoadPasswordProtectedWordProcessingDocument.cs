using GroupDocs.Watermark.Options.WordProcessing;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.LoadingDocuments
{
    /// <summary>
    /// This example demontrates how to load an encrypted WordProcessing document using the password.
    /// </summary>
    public static class LoadPasswordProtectedWordProcessingDocument
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(LoadPasswordProtectedWordProcessingDocument).Name}\n");

            string documentPath = Constants.InProtectedDocumentDocx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new WordProcessingLoadOptions();
            loadOptions.Password = "P@$$w0rd";
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                // use watermarker methods to manage watermarks in the WordProcessing document
                TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 12));

                watermarker.Add(watermark);

                watermarker.Save(outputFileName);
            }
        }
    }
}
