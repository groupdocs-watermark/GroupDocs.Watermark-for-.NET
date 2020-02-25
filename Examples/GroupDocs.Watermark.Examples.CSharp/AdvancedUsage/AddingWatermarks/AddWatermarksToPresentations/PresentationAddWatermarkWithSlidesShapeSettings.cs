// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPresentations
{
    using Options.Presentation;
    using Watermarks;

    /// <summary>
    /// This example shows how to set some additional options when adding a shape watermark.
    /// </summary>
    public static class PresentationAddWatermarkWithSlidesShapeSettings
    {
        public static void Run()
        {
            PresentationLoadOptions loadOptions = new PresentationLoadOptions();
            // Constants.InPresentationPptx is an absolute or relative path to your document. Ex: @"C:\Docs\presentation.pptx"
            using (Watermarker watermarker = new Watermarker(Constants.InPresentationPptx, loadOptions))
            {
                TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 19));
                watermark.IsBackground = true;

                PresentationWatermarkSlideOptions options = new PresentationWatermarkSlideOptions();

                // Set the shape name
                options.Name = "Shape 1";

                // Set the descriptive (alternative) text that will be associated with the shape
                options.AlternativeText = "Test watermark";

                // Editing of the shape in PowerPoint is forbidden
                options.IsLocked = true;

                watermarker.Add(watermark, options);

                watermarker.Save(Constants.OutPresentationPptx);
            }
        }
    }
}