// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Watermark.Contents.WordProcessing;
using GroupDocs.Watermark.Options.WordProcessing;
using GroupDocs.Watermark.Watermarks;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing
{
    /// <summary>
    /// This example demonstrates the usage of WordProcessingShapeType enum.
    /// </summary>
    public static class WordProcessingShapeTypeUsage
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
                    foreach (WordProcessingShape shape in section.Shapes)
                    {
                        //Check for Diagonal Corners Rounded shapes
                        if (shape.ShapeType == WordProcessingShapeType.DiagonalCornersRounded)
                        {
                            Console.WriteLine("Diagonal Corners Rounded shape found");

                            //Write text on all Diagonal Corners Rounded shapes
                            shape.FormattedTextFragments.Add("I am Diagonal Corner Rounded", new Font("Calibri", 8, FontStyle.Bold), Color.Red, Color.Aqua);
                        }
                    }
                }

                watermarker.Save(Constants.OutDocumentDocx);
            }
        }
    }
}
