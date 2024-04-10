using GroupDocs.Watermark.Contents.Diagram;
using GroupDocs.Watermark.Options.Diagram;
using System;
using System.IO;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams
{
    /// <summary>
    /// This example shows how to get information about all the shapes in a Diagram document.
    /// </summary>
    public static class DiagramGetShapesInformation
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(DiagramGetShapesInformation).Name}\n");

            string documentPath = Constants.InDiagramVsdx;

            DiagramLoadOptions loadOptions = new DiagramLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
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
