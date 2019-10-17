// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing
{
    using System;
    using Contents.WordProcessing;
    using Options.WordProcessing;
    using Watermarks;

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