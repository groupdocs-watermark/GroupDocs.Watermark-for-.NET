// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Watermark.Options.Spreadsheet;
using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.LoadingDocuments
{
    /// <summary>
    /// This examle demonstrates how to create a watermarker for the Spreadsheet document:
    /// </summary>
    public static class LoadingDocumentOfSpecificFormat
    {
        public static void Run()
        {
            // Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
            string filePath = Constants.InSpreadsheetXlsx;
            SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
            using (Watermarker watermarker = new Watermarker(filePath, loadOptions))
            {
                // use watermarker methods to manage watermarks in the Spreadsheet document
                TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 12));

                watermarker.Add(watermark);

                watermarker.Save(Constants.OutSpreadsheetXlsx);
            }
        }
    }
}
