// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Watermark.Contents.WordProcessing;
using GroupDocs.Watermark.Options.WordProcessing;
using System.IO;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing
{
    /// <summary>
    /// This example shows how to replace the image of the particular shapes in a Word document.
    /// </summary>
    public static class WordProcessingReplaceShapeImage
    {
        public static void Run()
        {
            WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
            // Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
            {
                WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();

                // Set shape image
                foreach (WordProcessingShape shape in content.Sections[0].Shapes)
                {
                    if (shape.Image != null)
                    {
                        shape.Image = new WordProcessingWatermarkableImage(File.ReadAllBytes(Constants.TestPng));
                    }
                }

                // Save document
                watermarker.Save(Constants.OutDocumentDocx);
            }
        }
    }
}
