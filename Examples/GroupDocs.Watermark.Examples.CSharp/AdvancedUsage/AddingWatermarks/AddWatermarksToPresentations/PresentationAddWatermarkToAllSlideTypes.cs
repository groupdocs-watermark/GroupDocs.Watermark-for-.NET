using GroupDocs.Watermark.Contents.Presentation;
using GroupDocs.Watermark.Options.Pdf;
using GroupDocs.Watermark.Options.Presentation;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPresentations
{
    /// <summary>
    /// This example shows how to access each type of the slides in a PowerPoint presentation.
    /// </summary>
    public static class PresentationAddWatermarkToAllSlideTypes
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(PresentationAddWatermarkToAllSlideTypes).Name}\n");

            string documentPath = Constants.InPresentationPptx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new PresentationLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 8));

                PresentationContent content = watermarker.GetContent<PresentationContent>();

                // Add watermark to all master slides
                PresentationWatermarkMasterSlideOptions masterSlideOptions = new PresentationWatermarkMasterSlideOptions();
                masterSlideOptions.MasterSlideIndex = -1;
                watermarker.Add(watermark, masterSlideOptions);

                // Add watermark to all layout slides
                if (content.LayoutSlides != null)
                {
                    PresentationWatermarkLayoutSlideOptions layoutSlideOptions = new PresentationWatermarkLayoutSlideOptions();
                    layoutSlideOptions.LayoutSlideIndex = -1;
                    watermarker.Add(watermark, masterSlideOptions);
                }

                // Add watermark to all notes slides
                for (int i = 0; i < content.Slides.Count; i++)
                {
                    if (content.Slides[i].NotesSlide != null)
                    {
                        PresentationWatermarkNoteSlideOptions noteSlideOptions = new PresentationWatermarkNoteSlideOptions();
                        noteSlideOptions.SlideIndex = i;
                        watermarker.Add(watermark, noteSlideOptions);
                    }
                }

                // Add watermark to handout master
                if (content.MasterHandoutSlide != null)
                {
                    PresentationWatermarkMasterHandoutSlideOptions handoutSlideOptions = new PresentationWatermarkMasterHandoutSlideOptions();
                    watermarker.Add(watermark, handoutSlideOptions);
                }

                // Add watermark to notes master
                if (content.MasterNotesSlide != null)
                {
                    PresentationWatermarkMasterNotesSlideOptions masterNotesSlideOptions = new PresentationWatermarkMasterNotesSlideOptions();
                    watermarker.Add(watermark, masterNotesSlideOptions);
                }

                watermarker.Save(outputFileName);
            }
        }
    }
}
