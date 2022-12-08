// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Watermark.Options.Presentation;
using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPresentations
{
    /// <summary>
    /// This example shows how to apply image effects to the shape watermark.
    /// </summary>
    public static class PresentationAddWatermarkWithImageEffects
    {
        public static void Run()
        {
            PresentationLoadOptions loadOptions = new PresentationLoadOptions();
            // Constants.InPresentationPptx is an absolute or relative path to your document. Ex: @"C:\Docs\presentation.pptx"
            using (Watermarker watermarker = new Watermarker(Constants.InPresentationPptx, loadOptions))
            {
                using (ImageWatermark watermark = new ImageWatermark(Constants.LogoPng))
                {
                    PresentationImageEffects effects = new PresentationImageEffects();
                    effects.Brightness = 0.7;
                    effects.Contrast = 0.6;
                    effects.ChromaKey = Color.Red;
                    effects.BorderLineFormat.Enabled = true;
                    effects.BorderLineFormat.Weight = 1;

                    PresentationWatermarkSlideOptions options = new PresentationWatermarkSlideOptions();
                    options.Effects = effects;

                    watermarker.Add(watermark, options);
                }

                watermarker.Save(Constants.OutPresentationPptx);
            }
        }
    }
}
