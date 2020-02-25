// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPresentations
{
    using Options.Presentation;
    using Watermarks;

    /// <summary>
    /// This example shows how to add watermark to a particular slide of a PowerPoint presentation.
    /// </summary>
    public static class PresentationAddWatermarkToSlide
    {
        public static void Run()
        {
            PresentationLoadOptions loadOptions = new PresentationLoadOptions();
            // Constants.InPresentationPptx is an absolute or relative path to your document. Ex: @"C:\Docs\presentation.pptx"
            using (Watermarker watermarker = new Watermarker(Constants.InPresentationPptx, loadOptions))
            {
                // Add text watermark to the first slide
                TextWatermark textWatermark = new TextWatermark("Test watermark", new Font("Arial", 8));
                PresentationWatermarkSlideOptions textWatermarkOptions = new PresentationWatermarkSlideOptions();
                textWatermarkOptions.SlideIndex = 0;
                watermarker.Add(textWatermark, textWatermarkOptions);

                // Add image watermark to the second slide
                using (ImageWatermark imageWatermark = new ImageWatermark(Constants.LogoJpg))
                {
                    PresentationWatermarkSlideOptions imageWatermarkOptions = new PresentationWatermarkSlideOptions();
                    imageWatermarkOptions.SlideIndex = 1;
                    watermarker.Add(imageWatermark, imageWatermarkOptions);
                }

                watermarker.Save(Constants.OutPresentationPptx);
            }
        }
    }
}