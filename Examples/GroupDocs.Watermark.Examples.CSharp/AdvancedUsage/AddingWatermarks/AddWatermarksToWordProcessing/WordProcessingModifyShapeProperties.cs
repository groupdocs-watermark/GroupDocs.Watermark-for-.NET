using GroupDocs.Watermark.Contents.WordProcessing;
using GroupDocs.Watermark.Options.WordProcessing;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing
{
    /// <summary>
    /// This example shows how to modify properties of particular shapes in a Word document.
    /// </summary>
    public static class WordProcessingModifyShapeProperties
    {
        public static void Run()
        {
            WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
            // Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
            {
                WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();

                // Change shape properties
                foreach (WordProcessingShape shape in content.Sections[0].Shapes)
                {
                    if (shape.Text.Contains("Some text"))
                    {
                        shape.AlternativeText = "watermark";
                        shape.RotateAngle = 30;
                        shape.X = 200;
                        shape.Y = 200;
                        shape.Height = 100;
                        shape.Width = 400;
                        shape.BehindText = false;
                    }
                }

                // Save document
                watermarker.Save(Constants.OutDocumentDocx);
            }
        }
    }
}
