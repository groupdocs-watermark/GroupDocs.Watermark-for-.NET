// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing
{
    using Contents.WordProcessing;
    using Options.WordProcessing;

    /// <summary>
    /// This example shows how to remove a particular shape from a Word document.
    /// </summary>
    public static class WordProcessingRemoveShape
    {
        public static void Run()
        {
            WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
            // Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
            {
                WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();

                // Remove shape by index
                content.Sections[0].Shapes.RemoveAt(0);

                // Remove shape by reference
                content.Sections[0].Shapes.Remove(content.Sections[0].Shapes[0]);

                watermarker.Save(Constants.OutDocumentDocx);
            }
        }
    }
}