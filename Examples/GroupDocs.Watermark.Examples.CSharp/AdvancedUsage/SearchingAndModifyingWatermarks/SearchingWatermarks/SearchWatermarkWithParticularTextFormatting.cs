using System;
using GroupDocs.Watermark.Search;
using GroupDocs.Watermark.Search.SearchCriteria;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.SearchingAndModifyingWatermarks.SearchingWatermarks
{
    /// <summary>
    /// This example shows how to search watermark with a particular text formatting.
    /// </summary>
    public static class SearchWatermarkWithParticularTextFormatting
    {
        public static void Run()
        {
            // Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf))
            {
                TextFormattingSearchCriteria criteria = new TextFormattingSearchCriteria();
                criteria.ForegroundColorRange = new ColorRange();
                criteria.ForegroundColorRange.MinHue = -5;
                criteria.ForegroundColorRange.MaxHue = 10;
                criteria.ForegroundColorRange.MinBrightness = 0.01f;
                criteria.ForegroundColorRange.MaxBrightness = 0.99f;
                criteria.BackgroundColorRange = new ColorRange();
                criteria.BackgroundColorRange.IsEmpty = true;
                criteria.FontName = "Arial";
                criteria.MinFontSize = 19;
                criteria.MaxFontSize = 42;
                criteria.FontBold = true;

                PossibleWatermarkCollection watermarks = watermarker.Search(criteria);
                // The code for working with found watermarks goes here.

                Console.WriteLine("Found {0} possible watermark(s).", watermarks.Count);
            }
        }
    }
}
