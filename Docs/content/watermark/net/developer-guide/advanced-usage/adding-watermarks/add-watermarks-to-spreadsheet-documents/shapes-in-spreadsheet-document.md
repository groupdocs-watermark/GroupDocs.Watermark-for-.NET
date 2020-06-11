---
id: shapes-in-spreadsheet-document
url: watermark/net/shapes-in-spreadsheet-document
title: Shapes in spreadsheet document
weight: 1
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
## Extracting information about all shapes in an excel document

[*Search*](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/watermarker/methods/search) method searches watermarks of all mentioned types, but in some cases, it's necessary to analyze only one class of Excel objects. Following code sample shows how to get information about all the [shapes](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.spreadsheet/spreadsheetworksheet/properties/shapes) in an Excel document.

**AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets.SpreadsheetGetShapesInformation**

```csharp
SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
// Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
{
    SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();
    foreach (SpreadsheetWorksheet worksheet in content.Worksheets)
    {
        foreach (SpreadsheetShape shape in worksheet.Shapes)
        {
            Console.WriteLine(shape.AutoShapeType);
            Console.WriteLine(shape.MsoDrawingType);
            Console.WriteLine(shape.Text);
            if (shape.Image != null)
            {
                Console.WriteLine(shape.Image.Width);
                Console.WriteLine(shape.Image.Height);
                Console.WriteLine(shape.Image.GetBytes().Length);
            }

            Console.WriteLine(shape.Id);
            Console.WriteLine(shape.AlternativeText);
            Console.WriteLine(shape.X);
            Console.WriteLine(shape.Y);
            Console.WriteLine(shape.Width);
            Console.WriteLine(shape.Height);
            Console.WriteLine(shape.RotateAngle);
            Console.WriteLine(shape.IsWordArt);
            Console.WriteLine(shape.Name);
        }
    }
}
```

## Removing a particular shape

You can also remove a particular [shape](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.spreadsheet/spreadsheetworksheet/properties/shapes) from the worksheet as shown in the below code sample.

**AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets.SpreadsheetRemoveShape**

```csharp
SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
// Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
{
    SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();

    // Remove shape by index
    content.Worksheets[0].Shapes.RemoveAt(0);

    // Remove shape by reference
    content.Worksheets[0].Shapes.Remove(content.Worksheets[0].Shapes[0]);

    watermarker.Save(Constants.OutSpreadsheetXlsx);
}
```

## Removing shapes with particular text formatting

You can also find and remove the shapes with a [particular text formatting](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.spreadsheet/spreadsheetshape/properties/formattedtextfragments) from an Excel document as shown in the below code sample.

**AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets.SpreadsheetRemoveTextShapesWithParticularTextFormatting**

```csharp
SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
// Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
{
    SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();
    foreach (SpreadsheetWorksheet section in content.Worksheets)
    {
        for (int i = section.Shapes.Count - 1; i >= 0; i--)
        {
            foreach (FormattedTextFragment fragment in section.Shapes[i].FormattedTextFragments)
            {
                if (fragment.ForegroundColor == Color.Red && fragment.Font.FamilyName == "Arial")
                {
                    section.Shapes.RemoveAt(i);
                    break;
                }
            }
        }
    }

    watermarker.Save(Constants.OutSpreadsheetXlsx);
}
```

## Removing/replacing hyperlink associated with a particular shape

Using GroupDocs.Watermark for .NET, you can also remove/replace hyperlink associated with a particular [shape](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.spreadsheet/spreadsheetshape/properties/hyperlink) or [chart](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.spreadsheet/spreadsheetchart/properties/hyperlink) inside an Excel document. Use following code sample to achieve this functionality.

**AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets.SpreadsheetRemoveHyperlinks**

```csharp
SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
// Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
{
    SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();

    // Replace hyperlink
    content.Worksheets[0].Charts[0].Hyperlink = "https://www.aspose.com/";
    content.Worksheets[0].Shapes[0].Hyperlink = "https://www.groupdocs.com/";

    // Remove hyperlink
    content.Worksheets[1].Charts[0].Hyperlink = null;
    content.Worksheets[1].Shapes[0].Hyperlink = null;

    watermarker.Save(Constants.OutSpreadsheetXlsx);
}
```

{{< alert style="warning" >}}This feature is also supported for charts.{{< /alert >}}

## Replacing text for particular shapes

Since version 17.12, GroupDocs.Watermark supports replacing [text](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.spreadsheet/spreadsheetshape/properties/text) for particular shapes in an Excel Worksheet. Following code sample shows the usage of this feature.

**AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets.SpreadsheetReplaceTextForParticularShapes**

```csharp
SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
// Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
{
    SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();
    foreach (SpreadsheetShape shape in content.Worksheets[0].Shapes)
    {
        if (shape.Text == "© Aspose 2016")
        {
            shape.Text = "© GroupDocs 2017";
        }
    }

    watermarker.Save(Constants.OutSpreadsheetXlsx);
}
```

## Replacing text for particular shapes with formatted text

You can also replace the [text](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.spreadsheet/spreadsheetshape/properties/text) of the shapes with [formatted text](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.spreadsheet/spreadsheetshape/properties/formattedtextfragments) as shown in the following code sample.

**AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets.SpreadsheetReplaceTextWithFormattingForParticularShapes**

```csharp
SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
// Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
{
    SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();
    foreach (SpreadsheetShape shape in content.Worksheets[0].Shapes)
    {
        if (shape.Text == "© Aspose 2016")
        {
            shape.FormattedTextFragments.Clear();
            shape.FormattedTextFragments.Add("© GroupDocs 2017", new Font("Calibri", 19, FontStyle.Bold), Color.Red, Color.Aqua);
        }
    }

    watermarker.Save(Constants.OutSpreadsheetXlsx);
}
```

## Replacing shape image

GroupDocs.Watermark also allows you to replace the [image](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.spreadsheet/spreadsheetshape/properties/image) of the particular shapes in an Excel Worksheet as shown in the following code sample. This feature is supported since version 17.12.

**AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets.SpreadsheetReplaceImageOfParticularShapes**

```csharp
SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
// Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
{
    SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();
    foreach (SpreadsheetShape shape in content.Worksheets[0].Shapes)
    {
        if (shape.Image != null)
        {
            shape.Image = new SpreadsheetWatermarkableImage(File.ReadAllBytes(Constants.TestPng));
        }
    }

    watermarker.Save(Constants.OutSpreadsheetXlsx);
}
```

## Setting background image for particular shapes

Since version 17.12, GroupDocs.Watermark enables you to set the [background image](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.spreadsheet/spreadsheetshape/properties/imagefillformat) for the particular shapes in an Excel Worksheet. Following code sample shows the usage of this feature.

**AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets.SpreadsheetSetBackgroundImageForParticularShapes**

```csharp
SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
// Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
{
    SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();
    foreach (SpreadsheetShape shape in content.Worksheets[0].Shapes)
    {
        if (shape.Text == "© Aspose 2016")
        {
            shape.ImageFillFormat.BackgroundImage = new SpreadsheetWatermarkableImage(File.ReadAllBytes(Constants.TestPng));
            shape.ImageFillFormat.Transparency = 0.5;
            shape.ImageFillFormat.TileAsTexture = true;
        }
    }

    watermarker.Save(Constants.OutSpreadsheetXlsx);
}
```

## Updating shape properties

Since version 17.12, GroupDocs.Watermark also provides the feature of modifying properties ([X](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.spreadsheet/spreadsheetshape/properties/x), [Y](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.spreadsheet/spreadsheetshape/properties/y), [Width](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.spreadsheet/spreadsheetshape/properties/width), [Height](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.spreadsheet/spreadsheetshape/properties/height), [RotateAngle](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.spreadsheet/spreadsheetshape/properties/rotateangle) or [AlternativeText](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.spreadsheet/spreadsheetshape/properties/alternativetext)) of particular shapes in an Excel Worksheet. Following code sample shows how to use this feature.

**AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets.SpreadsheetUpdateShapeProperties**

```csharp
SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
// Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
{
    SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();
    foreach (SpreadsheetShape shape in content.Worksheets[0].Shapes)
    {
        if (shape.Text == "© Aspose 2019")
        {
            shape.AlternativeText = "watermark";
            shape.RotateAngle = 30;
            shape.X = 200;
            shape.Y = 200;
            shape.Width = 400;
            shape.Height = 100;
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
