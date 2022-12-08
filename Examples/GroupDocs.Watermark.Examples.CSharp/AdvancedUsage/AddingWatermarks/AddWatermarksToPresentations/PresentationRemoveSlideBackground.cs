// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Watermark.Contents.Presentation;
using GroupDocs.Watermark.Options.Presentation;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPresentations
{
    /// <summary>
    /// This example shows how to remove the background image of a particular slide.
    /// </summary>
    public static class PresentationRemoveSlideBackground
    {
        public static void Run()
        {
            PresentationLoadOptions loadOptions = new PresentationLoadOptions();
            // Constants.InPresentationPptx is an absolute or relative path to your document. Ex: @"C:\Docs\presentation.pptx"
            using (Watermarker watermarker = new Watermarker(Constants.InPresentationPptx, loadOptions))
            {
                PresentationContent content = watermarker.GetContent<PresentationContent>();
                content.Slides[0].ImageFillFormat.BackgroundImage = null;

                watermarker.Save(Constants.OutPresentationPptx);
            }
        }
    }
}
