// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Watermark.Contents.WordProcessing;
using GroupDocs.Watermark.Options.WordProcessing;
using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing
{
    /// <summary>
    /// This example shows how to add watermark with linking headers and footers.
    /// </summary>
    public static class WordProcessingAddImageWatermarkToAllHeaders
    {
        public static void Run()
        {
            // Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
            WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
            {
                using (ImageWatermark watermark = new ImageWatermark(Constants.LargePng))
                {
                    // Add watermark to all headers of the first section
                    WordProcessingWatermarkSectionOptions options = new WordProcessingWatermarkSectionOptions();
                    options.SectionIndex = 0;
                    watermarker.Add(watermark, options);
                }

                // Link all other headers&footers to corresponding headers&footers of the first section
                WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();
                for (int i = 1; i < content.Sections.Count; i++)
                {
                    content.Sections[i].HeadersFooters.LinkToPrevious(true);
                }

                watermarker.Save(Constants.OutDocumentDocx);
            }
        }
    }
}
