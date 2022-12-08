// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using System;
using GroupDocs.Watermark.Contents.WordProcessing;
using GroupDocs.Watermark.Options.WordProcessing;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing
{
    /// <summary>
    /// This example shows how to get some page properties for a section.
    /// </summary>
    public static class WordProcessingGetSectionProperties
    {
        public static void Run()
        {
            WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
            // Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
            {
                WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();

                Console.WriteLine(content.Sections[0].PageSetup.Width);
                Console.WriteLine(content.Sections[0].PageSetup.Height);
                Console.WriteLine(content.Sections[0].PageSetup.TopMargin);
                Console.WriteLine(content.Sections[0].PageSetup.RightMargin);
                Console.WriteLine(content.Sections[0].PageSetup.BottomMargin);
                Console.WriteLine(content.Sections[0].PageSetup.LeftMargin);
            }
        }
    }
}
