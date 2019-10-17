// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing
{
    using Contents.WordProcessing;
    using Options.WordProcessing;
    using Search;
    using Watermarks;

    /// <summary>
    /// This example shows how to find and remove the shapes with a particular text formatting.
    /// </summary>
    public static class WordProcessingRemoveShapesWithParticularTextFormatting
    {
        public static void Run()
        {
            WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
            // Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
            {
                WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();
                foreach (WordProcessingSection section in content.Sections)
                {
                    for (int i = section.Shapes.Count - 1; i >= 0; i--)
                    {
                        foreach (FormattedTextFragment fragment in section.Shapes[i].FormattedTextFragments)
                        {
                            if (fragment.ForegroundColor == Color.Red && fragment.Font.FamilyName == "Arial")
                            {
                                section.Shapes.RemoveAt(i);
                                break;
                            }
                        }
                    }
                }

                watermarker.Save(Constants.OutDocumentDocx);
            }
        }
    }
}