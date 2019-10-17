// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    using System.IO;
    using Contents.Spreadsheet;
    using Options.Spreadsheet;

    /// <summary>
    /// This example shows how to set the background image for a chart inside an Excel document.
    /// </summary>
    public static class SpreadsheetSetBackgroundImageForChart
    {
        public static void Run()
        {
            SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
            // Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
            using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
            {
                SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();

                content.Worksheets[0].Charts[0].ImageFillFormat.BackgroundImage = new SpreadsheetWatermarkableImage(File.ReadAllBytes(Constants.TestPng));
                content.Worksheets[0].Charts[0].ImageFillFormat.Transparency = 0.5;
                content.Worksheets[0].Charts[0].ImageFillFormat.TileAsTexture = true;

                watermarker.Save(Constants.OutSpreadsheetXlsx);
            }
        }
    }
}