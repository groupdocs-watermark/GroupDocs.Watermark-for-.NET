using System.Collections.Generic;
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
            WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
            // Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
            {
                TextWatermark textWatermark = new TextWatermark("DRAFT", new Font("Arial", 42));
                textWatermark.PagesSetup = new PagesSetup
                {
                    Pages = new List<int> { 2, 3 }
                };
                watermarker.Add(textWatermark);
                watermarker.Save(Constants.OutDocumentDocx);
            }
        }
    }
}