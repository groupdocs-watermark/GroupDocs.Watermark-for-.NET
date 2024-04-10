using System;
using System.Collections.Generic;
using System.IO;
using GroupDocs.Watermark.Options.WordProcessing;
using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing
{
    
    /// <summary>
    /// This example shows how to add watermark to a particular pages of a Word document.
    /// </summary>
    public static class WordProcessingAddWatermarkToSpecificPages
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(WordProcessingAddWatermarkToSpecificPages).Name}\n");

            string documentPath = Constants.InDocumentDocx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new WordProcessingLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                TextWatermark textWatermark = new TextWatermark("DRAFT", new Font("Arial", 42));
                textWatermark.PagesSetup = new PagesSetup
                {
                    Pages = new List<int> { 2, 3 }
                };
                watermarker.Add(textWatermark);
                watermarker.Save(outputFileName);
            }
        }
    }
}