---
id: working-with-worksheet-headers-and-footers
url: watermark/net/working-with-worksheet-headers-and-footers
title: Working with worksheet headers and footers
weight: 4
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
## Extracting information about all headers and footers in an excel document

You can extract [information](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.spreadsheet/spreadsheetworksheet/properties/headersfooters) about all the headers and footers in an Excel document as shown in the below code sample.

**AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets.SpreadsheetGetHeaderFooterInformation**

```csharp
SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
// Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
{
    SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();
    foreach (SpreadsheetWorksheet worksheet in content.Worksheets)
    {
        foreach (SpreadsheetHeaderFooter headerFooter in worksheet.HeadersFooters)
        {
            Console.WriteLine(headerFooter.HeaderFooterType);
            foreach (SpreadsheetHeaderFooterSection section in headerFooter.Sections)
            {
                Console.WriteLine(section.SectionType);
                if (section.Image != null)
                {
                    Console.WriteLine(section.Image.Width);
                    Console.WriteLine(section.Image.Height);
                    Console.WriteLine(section.Image.GetBytes().Length);
                }

                Console.WriteLine(section.Script);
            }
        }
    }
}
```

## Clearing a particular header or footer

You can also clear a particular [header or footer](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.spreadsheet/spreadsheetheaderfootersection) using GroupDocs.Watermark as shown in the below code sample.

**AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets.SpreadsheetClearHeaderFooter**

```csharp
SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
// Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
{
    SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();
    foreach (SpreadsheetHeaderFooterSection section in content
                                                       .Worksheets[0].HeadersFooters[OfficeHeaderFooterType.HeaderPrimary]
                                                       .Sections)
    {
        section.Script = null;
        section.Image = null;
    }

    watermarker.Save(Constants.OutSpreadsheetXlsx);
}
```

## Clearing a particular section of header or footer

Using GroupDocs.Watermark, you can also clear a particular section of [header or footer](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.spreadsheet/spreadsheetheaderfootersection) as shown in the sample code below.

**AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets.SpreadsheetClearSectionOfHeaderFooter**

```csharp
SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
// Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
{
    SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();
    SpreadsheetHeaderFooterSection section = content.Worksheets[0]
                                                    .HeadersFooters[OfficeHeaderFooterType.HeaderEven]
                                                    .Sections[SpreadsheetHeaderFooterSectionType.Left];
    section.Image = null;
    section.Script = null;

    watermarker.Save(Constants.OutSpreadsheetXlsx);
}
```

## Adding watermark to all images in header and footer

GroupDocs.Watermark enables you to add watermark to [images](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.spreadsheet/spreadsheetheaderfootersection/properties/image) inside any header or footer. You can use below code sample to achieve this.

**AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets.SpreadsheetAddWatermarkToImagesInHeaderFooter**

```csharp
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
        foreach (SpreadsheetHeaderFooter headerFooter in worksheet.HeadersFooters)
        {
            foreach (SpreadsheetHeaderFooterSection section in headerFooter.Sections)
            {
                if (section.Image != null)
                {
                    // Add watermark to the image
                    section.Image.Add(watermark);
                }
            }
        }
    }

    watermarker.Save(Constants.OutSpreadsheetXlsx);
}
```

## More resources

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Watermark for .NET examples](https://github.com/groupdocs-watermark/GroupDocs.Watermark-for-.NET)
    
*   [GroupDocs.Watermark for Java examples](https://github.com/groupdocs-watermark/GroupDocs.Watermark-for-Java)
    

### Free online document watermarking App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to add watermark to PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Watermarking App](https://products.groupdocs.app/watermark).
