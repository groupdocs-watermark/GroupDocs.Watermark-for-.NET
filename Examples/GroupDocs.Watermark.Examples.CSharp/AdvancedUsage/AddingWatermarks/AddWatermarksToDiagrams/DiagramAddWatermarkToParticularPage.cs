// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams
{
    using Options.Diagram;
    using Watermarks;

    /// <summary>
    /// This example shows how to add watermark to a particular page of the document.
    /// </summary>
    public static class DiagramAddWatermarkToParticularPage
    {
        public static void Run()
        {
            DiagramLoadOptions loadOptions = new DiagramLoadOptions();
            // Constants.InDiagramVsdx is an absolute or relative path to your document. Ex: @"C:\Docs\diagram.vsdx"
            using (Watermarker watermarker = new Watermarker(Constants.InDiagramVsdx, loadOptions))
            {
                TextWatermark textWatermark = new TextWatermark("Test watermark", new Font("Calibri", 19));

                DiagramPageWatermarkOptions textWatermarkOptions = new DiagramPageWatermarkOptions();
                textWatermarkOptions.PageIndex = 0;

                // Add text watermark to the first page
                watermarker.Add(textWatermark, textWatermarkOptions);

                using (ImageWatermark imageWatermark = new ImageWatermark(Constants.LogoJpg))
                {
                    DiagramPageWatermarkOptions imageWatermarkOptions = new DiagramPageWatermarkOptions();
                    imageWatermarkOptions.PageIndex = 1;

                    // Add image watermark to the second page
                    watermarker.Add(imageWatermark, imageWatermarkOptions);
                }

                watermarker.Save(Constants.OutDiagramVsdx);
            }
        }
    }
}