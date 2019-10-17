// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    using Options.Spreadsheet;
    using Watermarks;

    /// <summary>
    /// This example shows how to add watermark to a particular worksheet.
    /// </summary>
    public static class SpreadsheetAddWatermarkToWorksheet
    {
        public static void Run()
        {
            SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
            // Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
            using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
            {
                // Add text watermark to the first worksheet
                TextWatermark textWatermark = new TextWatermark("Test watermark", new Font("Arial", 8));
                SpreadsheetWatermarkShapeOptions textWatermarkOptions = new SpreadsheetWatermarkShapeOptions();
                textWatermarkOptions.WorksheetIndex = 0;
                watermarker.Add(textWatermark, textWatermarkOptions);

                // Add image watermark to the second worksheet
                using (ImageWatermark imageWatermark = new ImageWatermark(Constants.LogoJpg))
                {
                    SpreadsheetWatermarkShapeOptions imageWatermarkOptions = new SpreadsheetWatermarkShapeOptions();
                    imageWatermarkOptions.WorksheetIndex = 1;
                    watermarker.Add(imageWatermark, imageWatermarkOptions);
                }

                watermarker.Save(Constants.OutSpreadsheetXlsx);
            }
        }
    }
}