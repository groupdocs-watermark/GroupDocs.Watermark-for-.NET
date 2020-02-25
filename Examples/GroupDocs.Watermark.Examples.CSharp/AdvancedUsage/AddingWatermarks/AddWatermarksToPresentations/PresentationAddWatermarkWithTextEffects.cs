// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPresentations
{
    using Contents;
    using Options.Presentation;
    using Watermarks;

    /// <summary>
    /// This example shows how to apply text effects when adding shape watermark to a PowerPoint slide.
    /// </summary>
    public static class PresentationAddWatermarkWithTextEffects
    {
        public static void Run()
        {
            PresentationLoadOptions loadOptions = new PresentationLoadOptions();
            // Constants.InPresentationPptx is an absolute or relative path to your document. Ex: @"C:\Docs\presentation.pptx"
            using (Watermarker watermarker = new Watermarker(Constants.InPresentationPptx, loadOptions))
            {
                TextWatermark watermark = new TextWatermark("Test watermark", new Font("Segoe UI", 19));

                PresentationTextEffects effects = new PresentationTextEffects();
                effects.LineFormat.Enabled = true;
                effects.LineFormat.Color = Color.Red;
                effects.LineFormat.DashStyle = OfficeDashStyle.DashDotDot;
                effects.LineFormat.LineStyle = OfficeLineStyle.Triple;
                effects.LineFormat.Weight = 1;

                PresentationWatermarkSlideOptions options = new PresentationWatermarkSlideOptions();
                options.Effects = effects;

                watermarker.Add(watermark, options);
                watermarker.Save(Constants.OutPresentationPptx);
            }
        }
    }
}