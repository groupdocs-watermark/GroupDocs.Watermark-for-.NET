// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams
{
    using Options.Diagram;
    using Watermarks;

    /// <summary>
    /// This example shows how to protect watermark from editing.
    /// </summary>
    public static class DiagramLockWatermarkShape
    {
        public static void Run()
        {
            DiagramLoadOptions loadOptions = new DiagramLoadOptions();
            // Constants.InDiagramVsdx is an absolute or relative path to your document. Ex: @"C:\Docs\diagram.vsdx"
            using (Watermarker watermarker = new Watermarker(Constants.InDiagramVsdx, loadOptions))
            {
                TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 19));

                DiagramShapeWatermarkOptions options = new DiagramShapeWatermarkOptions();
                options.IsLocked = true;

                // Editing of the shape in Visio is forbidden
                watermarker.Add(watermark, options);

                watermarker.Save(Constants.OutDiagramVsdx);
            }
        }
    }
}