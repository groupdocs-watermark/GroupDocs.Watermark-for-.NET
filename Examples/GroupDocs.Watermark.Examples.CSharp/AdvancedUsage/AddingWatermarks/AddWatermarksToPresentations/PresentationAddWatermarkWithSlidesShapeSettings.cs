using GroupDocs.Watermark.Options.Presentation;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPresentations
{
    /// <summary>
    /// This example shows how to set some additional options when adding a shape watermark.
    /// </summary>
    public static class PresentationAddWatermarkWithSlidesShapeSettings
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(PresentationAddWatermarkWithSlidesShapeSettings).Name}\n");

            string documentPath = Constants.InPresentationPptx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new PresentationLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 19));
                watermark.IsBackground = true;

                PresentationWatermarkSlideOptions options = new PresentationWatermarkSlideOptions();

                // Set the shape name
                options.Name = "Shape 1";

                // Set the descriptive (alternative) text that will be associated with the shape
                options.AlternativeText = "Test watermark";

                // Editing of the shape in PowerPoint is forbidden
                options.IsLocked = true;

                watermarker.Add(watermark, options);

                watermarker.Save(outputFileName);
            }
        }
    }
}
