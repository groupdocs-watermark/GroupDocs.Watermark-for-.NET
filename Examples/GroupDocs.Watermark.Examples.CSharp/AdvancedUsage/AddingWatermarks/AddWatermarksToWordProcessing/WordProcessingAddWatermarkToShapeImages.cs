// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing
{
    using Common;
    using Contents.WordProcessing;
    using Options.WordProcessing;
    using Watermarks;

    /// <summary>
    /// This example shows how to add watermark to images in a document.
    /// </summary>
    public static class WordProcessingAddWatermarkToShapeImages
    {
        public static void Run()
        {
            WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
            // Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
            {
                TextWatermark watermark = new TextWatermark("Protected image", new Font("Arial", 8));
                watermark.HorizontalAlignment = HorizontalAlignment.Center;
                watermark.VerticalAlignment = VerticalAlignment.Center;
                watermark.RotateAngle = 45;
                watermark.SizingType = SizingType.ScaleToParentDimensions;
                watermark.ScaleFactor = 1;

                WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();
                foreach (WordProcessingSection section in content.Sections)
                {
                    foreach (WordProcessingShape shape in section.Shapes)
                    {
                        // Headers&Footers usually contains only service information.
                        // So, we skip images in headers/footers, expecting that they are probably watermarks or backgrounds
                        if (shape.HeaderFooter == null && shape.Image != null)
                        {
                            shape.Image.Add(watermark);
                        }
                    }
                }

                watermarker.Save(Constants.OutDocumentDocx);
            }
        }
    }
}