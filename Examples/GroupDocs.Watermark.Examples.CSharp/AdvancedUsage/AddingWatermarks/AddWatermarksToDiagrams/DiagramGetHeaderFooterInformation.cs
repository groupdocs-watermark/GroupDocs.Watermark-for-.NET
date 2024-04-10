using GroupDocs.Watermark.Contents.Diagram;
using GroupDocs.Watermark.Options.Diagram;
using System;
using System.IO;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams
{
    /// <summary>
    /// This example shows how to extract information about all the headers and footers in a Diagram document.
    /// </summary>
    public static class DiagramGetHeaderFooterInformation
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(DiagramGetHeaderFooterInformation).Name}\n");

            string documentPath = Constants.InDiagramVsdx;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            DiagramLoadOptions loadOptions = new DiagramLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                DiagramContent content = watermarker.GetContent<DiagramContent>();

                // Get header&footer font settings
                Console.WriteLine(content.HeaderFooter.Font.FamilyName);
                Console.WriteLine(content.HeaderFooter.Font.Size);
                Console.WriteLine(content.HeaderFooter.Font.Bold);
                Console.WriteLine(content.HeaderFooter.Font.Italic);
                Console.WriteLine(content.HeaderFooter.Font.Underline);
                Console.WriteLine(content.HeaderFooter.Font.Strikeout);

                // Get text contained in headers&footers
                Console.WriteLine(content.HeaderFooter.HeaderLeft);
                Console.WriteLine(content.HeaderFooter.HeaderCenter);
                Console.WriteLine(content.HeaderFooter.HeaderRight);
                Console.WriteLine(content.HeaderFooter.FooterLeft);
                Console.WriteLine(content.HeaderFooter.FooterCenter);
                Console.WriteLine(content.HeaderFooter.FooterRight);

                // Get text color
                Console.WriteLine(content.HeaderFooter.TextColor.ToArgb());

                // Get header&footer margins
                Console.WriteLine(content.HeaderFooter.FooterMargin);
                Console.WriteLine(content.HeaderFooter.HeaderMargin);
            }
        }
    }
}
