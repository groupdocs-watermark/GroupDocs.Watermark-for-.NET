---
id: working-with-worksheet-backgrounds
url: watermark/net/working-with-worksheet-backgrounds
title: Working with worksheet backgrounds
weight: 3
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
## Extracting information about all worksheet backgrounds in an excel document

The API allows you to extract [information](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.spreadsheet/spreadsheetworksheet/properties/backgroundimage) about all the worksheet backgrounds in an Excel document as shown in the following code sample.

**AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets.SpreadsheetGetInformationOfWorksheetBackgrounds**

```csharp
SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
// Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
{
    SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();
    foreach (SpreadsheetWorksheet worksheet in content.Worksheets)
    {
        if (worksheet.BackgroundImage != null)
        {
            Console.WriteLine(worksheet.BackgroundImage.Width);
            Console.WriteLine(worksheet.BackgroundImage.Height);
            Console.WriteLine(worksheet.BackgroundImage.GetBytes().Length);
        }
    }
}
```

## Removing a particular background

Following code sample can be used to remove the [background](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.spreadsheet/spreadsheetworksheet/properties/backgroundimage) of a particular worksheet.

**AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets.SpreadsheetRemoveWorksheetBackground**

```csharp
SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
// Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
{
    SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();
    content.Worksheets[0].BackgroundImage = null;

    watermarker.Save(Constants.OutSpreadsheetXlsx);
}
```

## Adding watermark to all backgrounds in an excel worksheet

You can [add](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.image/watermarkableimage/methods/add) watermark to the background images that belong to an Excel document as shown in the below code sample.

**AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets.SpreadsheetAddWatermarkToBackgroundImages**

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
        if (worksheet.BackgroundImage != null)
        {
            // Add watermark to the image
            worksheet.BackgroundImage.Add(watermark);
        }
    }

    watermarker.Save(Constants.OutSpreadsheetXlsx);
}
```

## Settings background image for charts

GroupDocs.Watermark for .NET also allows you to set the [background image](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.spreadsheet/spreadsheetchart/properties/imagefillformat) for a chart inside an Excel document. Following code sample shows how to achieve this functionality.

**AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets.SpreadsheetSetBackgroundImageForChart**

```csharp
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
```

## More resources

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Watermark for .NET examples](https://github.com/groupdocs-watermark/GroupDocs.Watermark-for-.NET)
    
*   [GroupDocs.Watermark for Java examples](https://github.com/groupdocs-watermark/GroupDocs.Watermark-for-Java)
    

### Free online document watermarking App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to add watermark to PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Watermarking App](https://products.groupdocs.app/watermark).
