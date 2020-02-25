// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing
{
    using Contents.WordProcessing;
    using Options.WordProcessing;
    using Search;
    using Search.SearchCriteria;

    /// <summary>
    /// This example shows how to remove watermark from a particular section.
    /// </summary>
    public static class WordProcessingRemoveWatermarkFromSection
    {
        public static void Run()
        {
            WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
            // Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
            {
                // Initialize search criteria
                ImageSearchCriteria imageSearchCriteria = new ImageDctHashSearchCriteria(Constants.LogoPng);
                TextSearchCriteria textSearchCriteria = new TextSearchCriteria("Company Name");

                // Call Search method for the section
                WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();
                PossibleWatermarkCollection possibleWatermarks = content.Sections[0].Search(textSearchCriteria.Or(imageSearchCriteria));

                // Remove all found watermarks
                for (int i = possibleWatermarks.Count - 1; i >= 0; i--)
                {
                    possibleWatermarks.RemoveAt(i);
                }

                watermarker.Save(Constants.OutDocumentDocx);
            }
        }
    }
}