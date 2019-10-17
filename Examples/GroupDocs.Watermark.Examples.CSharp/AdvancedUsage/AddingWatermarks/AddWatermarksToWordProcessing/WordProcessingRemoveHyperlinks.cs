// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing
{
    using Contents.WordProcessing;
    using Options.WordProcessing;

    /// <summary>
    /// This example shows how to remove/replace hyperlink associated with a particular shape inside a Word document.
    /// </summary>
    public static class WordProcessingRemoveHyperlinks
    {
        public static void Run()
        {
            WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
            // Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
            {
                WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();

                // Replace hyperlink
                content.Sections[0].Shapes[0].Hyperlink = "https://www.groupdocs.com/";

                // Remove hyperlink
                content.Sections[0].Shapes[1].Hyperlink = null;

                watermarker.Save(Constants.OutDocumentDocx);
            }
        }
    }
}