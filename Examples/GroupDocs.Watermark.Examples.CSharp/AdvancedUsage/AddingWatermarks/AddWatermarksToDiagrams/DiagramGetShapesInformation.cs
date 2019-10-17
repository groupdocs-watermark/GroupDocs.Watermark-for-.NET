// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams
{
    using System;
    using Contents.Diagram;
    using Options.Diagram;

    /// <summary>
    /// This example shows how to get information about all the shapes in a Diagram document.
    /// </summary>
    public static class DiagramGetShapesInformation
    {
        public static void Run()
        {
            DiagramLoadOptions loadOptions = new DiagramLoadOptions();
            // Constants.InDiagramVsdx is an absolute or relative path to your document. Ex: @"C:\Docs\diagram.vsdx"
            using (Watermarker watermarker = new Watermarker(Constants.InDiagramVsdx, loadOptions))
            {
                DiagramContent content = watermarker.GetContent<DiagramContent>();
                foreach (DiagramPage page in content.Pages)
                {
                    foreach (DiagramShape shape in page.Shapes)
                    {
                        if (shape.Image != null)
                        {
                            Console.WriteLine(shape.Image.Width);
                            Console.WriteLine(shape.Image.Height);
                            Console.WriteLine(shape.Image.GetBytes().Length);
                        }

                        Console.WriteLine(shape.Name);
                        Console.WriteLine(shape.X);
                        Console.WriteLine(shape.Y);
                        Console.WriteLine(shape.Width);
                        Console.WriteLine(shape.Height);
                        Console.WriteLine(shape.RotateAngle);
                        Console.WriteLine(shape.Text);
                        Console.WriteLine(shape.Id);
                    }
                }
            }
        }
    }
}