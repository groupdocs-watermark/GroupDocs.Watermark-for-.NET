using System;
using System.IO;
using GroupDocs.Watermark.Contents.WordProcessing;
using GroupDocs.Watermark.Options.WordProcessing;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing
{
    /// <summary>
    /// This example shows how to extract the information about all the shapes.
    /// </summary>
    public static class WordProcessingGetShapesInformation
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(WordProcessingGetShapesInformation).Name}\n");

            string documentPath = Constants.InDocumentDocx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new WordProcessingLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();
                foreach (WordProcessingSection section in content.Sections)
                {
                    foreach (WordProcessingShape shape in section.Shapes)
                    {
                        if (shape.HeaderFooter != null)
                        {
                            Console.WriteLine("In header/footer");
                        }

                        Console.WriteLine(shape.ShapeType);
                        Console.WriteLine(shape.Width);
                        Console.WriteLine(shape.Height);
                        Console.WriteLine(shape.IsWordArt);
                        Console.WriteLine(shape.RotateAngle);
                        Console.WriteLine(shape.AlternativeText);
                        Console.WriteLine(shape.Name);
                        Console.WriteLine(shape.X);
                        Console.WriteLine(shape.Y);
                        Console.WriteLine(shape.Text);
                        if (shape.Image != null)
                        {
                            Console.WriteLine(shape.Image.Width);
                            Console.WriteLine(shape.Image.Height);
                            Console.WriteLine(shape.Image.GetBytes().Length);
                        }

                        Console.WriteLine(shape.HorizontalAlignment);
                        Console.WriteLine(shape.VerticalAlignment);
                        Console.WriteLine(shape.RelativeHorizontalPosition);
                        Console.WriteLine(shape.RelativeVerticalPosition);
                    }
                }
            }
        }
    }
}
