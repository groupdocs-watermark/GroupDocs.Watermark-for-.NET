// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPresentations
{
    using System;
    using Contents.Presentation;
    using Options.Presentation;

    /// <summary>
    /// This example shows how to get the dimensions of a particular slide.
    /// </summary>
    public static class PresentationGetSlideDimensions
    {
        public static void Run()
        {
            PresentationLoadOptions loadOptions = new PresentationLoadOptions();
            // Constants.InPresentationPptx is an absolute or relative path to your document. Ex: @"C:\Docs\presentation.pptx"
            using (Watermarker watermarker = new Watermarker(Constants.InPresentationPptx, loadOptions))
            {
                PresentationContent content = watermarker.GetContent<PresentationContent>();

                Console.WriteLine(content.SlideWidth);
                Console.WriteLine(content.SlideHeight);
            }
        }
    }
}