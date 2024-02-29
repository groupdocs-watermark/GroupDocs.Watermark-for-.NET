using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddingTextWatermarks
{
    /// <summary>
    /// This example shows how to add text watermark to a document.
    /// </summary>
    public static class AddTextTiledWatermark
    {
        public static void Run()
        {
            // Constants.InImagePng is an absolute or relative path to your document. Ex: @"C:\Docs\image.png"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf))
            {
                // Initialize the font to be used for watermark
                Font font = new Font("Arial", 19, FontStyle.Bold | FontStyle.Italic);

                // Create the watermark object
                TextWatermark watermark = new TextWatermark("Test watermark", font);

                // Configure tile options
                watermark.TileOptions = new TileOptions()
                {
                    LineSpacing = new MeasureValue()
                    {
                        MeasureType = TileMeasureType.Percent,
                        Value = 12
                    },
                    WatermarkSpacing = new MeasureValue()
                    {
                        MeasureType = TileMeasureType.Percent,
                        Value = 10
                    },
                };

                // Set watermark properties
                watermark.ForegroundColor = Color.Red;
                watermark.BackgroundColor = Color.Blue;
                watermark.TextAlignment = TextAlignment.Right;
                watermark.Opacity = 0.5;

                // Add watermark
                watermarker.Add(watermark);

                watermarker.Save(Constants.OutDocumentPdf);
            }
        }
    }
}
