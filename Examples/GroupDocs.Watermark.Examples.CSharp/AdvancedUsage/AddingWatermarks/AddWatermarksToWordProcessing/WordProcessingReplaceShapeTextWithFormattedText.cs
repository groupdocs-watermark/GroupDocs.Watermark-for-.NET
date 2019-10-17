// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing
{
    using Contents.WordProcessing;
    using Options.WordProcessing;
    using Watermarks;

    /// <summary>
    /// This example shows how to replace the text of the shapes with formatted text.
    /// </summary>
    public static class WordProcessingReplaceShapeTextWithFormattedText
    {
        public static void Run()
        {
            WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
            // Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
            {
                WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();

                // Set shape's text
                foreach (WordProcessingShape shape in content.Sections[0].Shapes)
                {
                    if (shape.Text.Contains("Some text"))
                    {
                        shape.FormattedTextFragments.Clear();
                        shape.FormattedTextFragments.Add("Another text", new Font("Calibri", 19, FontStyle.Bold), Color.Red, Color.Aqua);
                    }
                }

                // Save document
                watermarker.Save(Constants.OutDocumentDocx);
            }
        }
    }
}