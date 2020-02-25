// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPdf
{
    using System;
    using Contents.Pdf;
    using Options.Pdf;

    /// <summary>
    /// This example shows how to extract the information about the artifacts in a PDF document.
    /// </summary>
    public static class PdfExtractArtifactInformation
    {
        public static void Run()
        {
            PdfLoadOptions loadOptions = new PdfLoadOptions();
            // Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
            {
                PdfContent pdfContent = watermarker.GetContent<PdfContent>();
                foreach (PdfPage page in pdfContent.Pages)
                {
                    foreach (PdfArtifact artifact in page.Artifacts)
                    {
                        Console.WriteLine(artifact.ArtifactType);
                        Console.WriteLine(artifact.ArtifactSubtype);
                        if (artifact.Image != null)
                        {
                            Console.WriteLine(artifact.Image.Width);
                            Console.WriteLine(artifact.Image.Height);
                            Console.WriteLine(artifact.Image.GetBytes().Length);
                        }

                        Console.WriteLine(artifact.Text);
                        Console.WriteLine(artifact.Opacity);
                        Console.WriteLine(artifact.X);
                        Console.WriteLine(artifact.Y);
                        Console.WriteLine(artifact.Width);
                        Console.WriteLine(artifact.Height);
                        Console.WriteLine(artifact.RotateAngle);
                    }
                }
            }
        }
    }
}