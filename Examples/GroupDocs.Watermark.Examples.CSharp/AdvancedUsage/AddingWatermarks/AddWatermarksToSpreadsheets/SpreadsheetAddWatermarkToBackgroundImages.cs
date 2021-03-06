// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    using Common;
    using Contents.Spreadsheet;
    using Options.Spreadsheet;
    using Watermarks;

    /// <summary>
    /// This example shows how to add watermark to the background images that belong to an Excel document.
    /// </summary>
    public static class SpreadsheetAddWatermarkToBackgroundImages
    {
        public static void Run()
        {
            SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
            // Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
            using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
            {
                // Initialize image or text watermark
                TextWatermark watermark = new TextWatermark("Protected image", new Font("Arial", 8));
                watermark.HorizontalAlignment = HorizontalAlignment.Center;
                watermark.VerticalAlignment = VerticalAlignment.Center;
                watermark.RotateAngle = 45;
                watermark.SizingType = SizingType.ScaleToParentDimensions;
                watermark.ScaleFactor = 1;

                SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();
                foreach (SpreadsheetWorksheet worksheet in content.Worksheets)
                {
                    if (worksheet.BackgroundImage != null)
                    {
                        // Add watermark to the image
                        worksheet.BackgroundImage.Add(watermark);
                    }
                }

                watermarker.Save(Constants.OutSpreadsheetXlsx);
            }
        }
    }
}