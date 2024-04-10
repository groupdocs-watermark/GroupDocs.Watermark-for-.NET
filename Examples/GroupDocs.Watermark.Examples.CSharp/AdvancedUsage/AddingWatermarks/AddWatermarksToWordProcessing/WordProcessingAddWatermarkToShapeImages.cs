using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Contents.WordProcessing;
using GroupDocs.Watermark.Options.WordProcessing;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing
{
    /// <summary>
    /// This example shows how to add watermark to images in a document.
    /// </summary>
    public static class WordProcessingAddWatermarkToShapeImages
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(WordProcessingAddWatermarkToShapeImages).Name}\n");

            string documentPath = Constants.InDocumentDocx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new WordProcessingLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                TextWatermark watermark = new TextWatermark("Protected image", new Font("Arial", 8));
                watermark.HorizontalAlignment = HorizontalAlignment.Center;
                watermark.VerticalAlignment = VerticalAlignment.Center;
                watermark.RotateAngle = 45;
                watermark.SizingType = SizingType.ScaleToParentDimensions;
                watermark.ScaleFactor = 1;

                WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();
                foreach (WordProcessingSection section in content.Sections)
                {
                    foreach (WordProcessingShape shape in section.Shapes)
                    {
                        // Headers&Footers usually contains only service information.
                        // So, we skip images in headers/footers, expecting that they are probably watermarks or backgrounds
                        if (shape.HeaderFooter == null && shape.Image != null)
                        {
                            shape.Image.Add(watermark);
                        }
                    }
                }

                watermarker.Save(outputFileName);
            }
        }
    }
}
