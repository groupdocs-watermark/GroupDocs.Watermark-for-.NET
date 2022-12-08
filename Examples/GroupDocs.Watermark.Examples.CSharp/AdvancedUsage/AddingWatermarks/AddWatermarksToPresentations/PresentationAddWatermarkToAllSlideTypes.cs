using GroupDocs.Watermark.Contents.Presentation;
using GroupDocs.Watermark.Options.Presentation;
using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToPresentations
{
    /// <summary>
    /// This example shows how to access each type of the slides in a PowerPoint presentation.
    /// </summary>
    public static class PresentationAddWatermarkToAllSlideTypes
    {
        public static void Run()
        {
            PresentationLoadOptions loadOptions = new PresentationLoadOptions();
            // Constants.InPresentationPptx is an absolute or relative path to your document. Ex: @"C:\Docs\presentation.pptx"
            using (Watermarker watermarker = new Watermarker(Constants.InPresentationPptx, loadOptions))
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

                watermarker.Save(Constants.OutPresentationPptx);
            }
        }
    }
}
