// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing
{
    using Contents;
    using Contents.WordProcessing;
    using Options.WordProcessing;

    /// <summary>
    /// This example shows how to link the header/footer.
    /// </summary>
    public static class WordProcessingLinkHeaderFooterInSection
    {
        public static void Run()
        {
            WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
            // Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
            {
                WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();

                // Link footer for even numbered pages to corresponding footer in previous section
                content.Sections[1].HeadersFooters[OfficeHeaderFooterType.FooterEven].IsLinkedToPrevious = true;

                watermarker.Save(Constants.OutDocumentDocx);
            }
        }
    }
}