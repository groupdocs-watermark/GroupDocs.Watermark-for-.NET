using GroupDocs.Watermark.Contents.Spreadsheet;
using GroupDocs.Watermark.Options.Spreadsheet;
using GroupDocs.Watermark.Search;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets
{
    /// <summary>
    /// This example shows how to find and remove the shapes with a particular text formatting from an Excel document.
    /// </summary>
    public static class SpreadsheetRemoveTextShapesWithParticularTextFormatting
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(SpreadsheetRemoveWorksheetBackground).Name}\n");

            string documentPath = Constants.InSpreadsheetXlsx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new SpreadsheetLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();
                foreach (SpreadsheetWorksheet section in content.Worksheets)
                {
                    for (int i = section.Shapes.Count - 1; i >= 0; i--)
                    {
                        foreach (FormattedTextFragment fragment in section.Shapes[i].FormattedTextFragments)
                        {
                            if (fragment.ForegroundColor.Equals(Color.Red) && fragment.Font.FamilyName == "Arial")
                            {
                                section.Shapes.RemoveAt(i);
                                break;
                            }
                        }
                    }
                }

                watermarker.Save(outputFileName);
            }
        }
    }
}
