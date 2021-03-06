// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams
{
    using System;
    using Contents.Diagram;
    using Options.Diagram;

    /// <summary>
    /// This example shows how to extract information about all the headers and footers in a Diagram document.
    /// </summary>
    public static class DiagramGetHeaderFooterInformation
    {
        public static void Run()
        {
            DiagramLoadOptions loadOptions = new DiagramLoadOptions();
            // Constants.InDiagramVsdx is an absolute or relative path to your document. Ex: @"C:\Docs\diagram.vsdx"
            using (Watermarker watermarker = new Watermarker(Constants.InDiagramVsdx, loadOptions))
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