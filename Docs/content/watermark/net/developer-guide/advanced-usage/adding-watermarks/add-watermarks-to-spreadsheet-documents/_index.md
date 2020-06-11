---
id: add-watermarks-to-spreadsheet-documents
url: watermark/net/add-watermarks-to-spreadsheet-documents
title: Add watermarks to spreadsheet documents
weight: 8
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
## Adding watermark to a particular worksheet 

GroupDocs.Watermark provides an easy way to add watermark to the worksheets of any Excel document. Adding watermark to a particular Excel worksheet using GroupDocs.Watermark consists of following steps.

1.  Load the document
2.  Create and initialize watermark object
3.  Set watermark properties
4.  Create [SpreadsheetWatermarkShapeOptions](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.spreadsheet/spreadsheetwatermarkshapeoptions) and set property [WorksheetIndex](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.spreadsheet/spreadsheetwatermarkshapeoptions/properties/worksheetindex)
5.  Add watermark to the worksheet
6.  Save the document

Following code shows how to add watermark to a particular worksheet.

**AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets.SpreadsheetAddWatermarkToWorksheet**

```csharp
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
```

## Getting size of content area

If for some reasons you want to use absolute sizing and positioning, you may also need to get the [width](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.spreadsheet/spreadsheetworksheet/properties/contentareawidth) and the [height](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.spreadsheet/spreadsheetworksheet/properties/contentareaheight) of the content area (range of cells which contains data).

**AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets.SpreadsheetGetContentAreaDimensions**

```csharp
SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
// Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
{
    SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();

    // Get the size of content area
    Console.WriteLine(content.Worksheets[0].ContentAreaHeight);
    Console.WriteLine(content.Worksheets[0].ContentAreaWidth);

    // Get the size of particular cell
    Console.WriteLine(content.Worksheets[0].GetColumnWidth(0));
    Console.WriteLine(content.Worksheets[0].GetRowHeight(0));
}
```

## Adding watermark to the images from a particular worksheet

Using GroupDocs.Watermark, you can add watermark to the images that belong to a particular worksheet using method [FindImages()](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents/contentpart/methods/findimages) of [SpreadsheetWorksheet](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.spreadsheet/spreadsheetworksheet).

**AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets.SpreadsheetAddWatermarkToWorksheetImages**

```csharp
SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
// Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
{
    TextWatermark watermark = new TextWatermark("Protected image", new Font("Arial", 8));
    watermark.HorizontalAlignment = HorizontalAlignment.Center;
    watermark.VerticalAlignment = VerticalAlignment.Center;
    watermark.RotateAngle = 45;
    watermark.SizingType = SizingType.ScaleToParentDimensions;
    watermark.ScaleFactor = 1;

    // Get all images from the first worksheet
    SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();
    WatermarkableImageCollection images = content.Worksheets[0].FindImages();

    // Add watermark to all found images
    foreach (WatermarkableImage image in images)
    {
        image.Add(watermark);
    }

    watermarker.Save(Constants.OutSpreadsheetXlsx);
}
```

## Different types of watermark in excel documents

### Shapes

When you're calling [Add](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.watermarker/add/methods/1) method of [Watermarker](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/watermarker) class with [SpreadsheetWatermarkShapeOptions](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.spreadsheet/spreadsheetwatermarkshapeoptions) parameter, simple shape is added to an Excel document. Besides [SpreadsheetWatermarkShapeOptions](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.spreadsheet/spreadsheetwatermarkshapeoptions) there is [SpreadsheetWatermarkModernWordArtOptions](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.spreadsheet/spreadsheetwatermarkmodernwordartoptions) type which is used only with [TextWatermark](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.watermarks/textwatermark). Both options add watermark to an Excel document as a shape, however, there are some differences. When [TextWatermark](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.watermarks/textwatermark) is added with [SpreadsheetWatermarkShapeOptions](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.spreadsheet/spreadsheetwatermarkshapeoptions) there options, it looks and behaves like WordArt object added in Excel'2003, and [SpreadsheetWatermarkModernWordArtOptions](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.spreadsheet/spreadsheetwatermarkmodernwordartoptions) option adds text watermark that looks and behaves like Excel'2013 WordArt object.

The code sample below shows how to add modern WordArt watermark to Excel document worksheet.

**AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets.SpreadsheetAddModernWordArdWatermark**

```csharp
SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
// Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
{
    TextWatermark textWatermark = new TextWatermark("Test watermark", new Font("Arial", 8));
    SpreadsheetWatermarkModernWordArtOptions options = new SpreadsheetWatermarkModernWordArtOptions();
    options.WorksheetIndex = 0;

    watermarker.Add(textWatermark, options);
    watermarker.Save(Constants.OutSpreadsheetXlsx);
}
```

### Shape additional options

The API also provides the feature to set some additional options ([Name](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.spreadsheet/spreadsheetwatermarkbaseoptions/properties/name), [AlternativeText](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.spreadsheet/spreadsheetwatermarkbaseoptions/properties/alternativetext) and [IsLocked](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.spreadsheet/spreadsheetwatermarkbaseoptions/properties/islocked)) when adding shape watermark to Excel worksheet (as shown in the below sample).

**AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets.SpreadsheetAddWatermarkUsingShapeSettings**

```csharp
SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
// Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
{
    TextWatermark watermark = new TextWatermark("Test watermark", new Font("Segoe UI", 19));
    SpreadsheetWatermarkShapeOptions options = new SpreadsheetWatermarkShapeOptions();

    // Set the shape name
    options.Name = "Shape 1";

    // Set the descriptive (alternative) text that will be associated with the shape
    options.AlternativeText = "Test watermark";

    // Editing of the shape in Excel is forbidden
    options.IsLocked = true;

    watermarker.Add(watermark, options);
    watermarker.Save(Constants.OutSpreadsheetXlsx);
}
```

### Text effects

You can also apply [text effects](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.spreadsheet/spreadsheettexteffects) when adding shape watermark in Excel worksheet as shown in below code sample.

**AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets.SpreadsheetAddWatermarkWithTextEffects**

```csharp
SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
// Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
{
    TextWatermark watermark = new TextWatermark("Test watermark", new Font("Segoe UI", 19));

    SpreadsheetTextEffects effects = new SpreadsheetTextEffects();
    effects.LineFormat.Enabled = true;
    effects.LineFormat.Color = Color.Red;
    effects.LineFormat.DashStyle = OfficeDashStyle.DashDotDot;
    effects.LineFormat.LineStyle = OfficeLineStyle.Triple;
    effects.LineFormat.Weight = 1;

    SpreadsheetWatermarkShapeOptions options = new SpreadsheetWatermarkShapeOptions();
    options.Effects = effects;

    watermarker.Add(watermark, options);
    watermarker.Save(Constants.OutSpreadsheetXlsx);
}
```

### Image effects

The API also allows you to apply [image effects](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.spreadsheet/spreadsheetimageeffects) to the shape watermark using below code sample.

**AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets.SpreadsheetAddWatermarkWithImageEffects**

```csharp
SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
// Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
{
    using (ImageWatermark watermark = new ImageWatermark(Constants.LogoPng))
    {
        SpreadsheetImageEffects effects = new SpreadsheetImageEffects();
        effects.Brightness = 0.7;
        effects.Contrast = 0.6;
        effects.ChromaKey = Color.Red;
        effects.BorderLineFormat.Enabled = true;
        effects.BorderLineFormat.Weight = 1;

        SpreadsheetWatermarkShapeOptions options = new SpreadsheetWatermarkShapeOptions();
        options.Effects = effects;

        watermarker.Add(watermark, options);
    }

    watermarker.Save(Constants.OutSpreadsheetXlsx);
}
```

### Worksheet backgrounds

[Microsoft Office documentation](https://support.office.com/en-us/article/Add-a-watermark-in-Excel-a372182a-d733-484e-825c-18ddf3edf009?ui=en-US&rs=en-US&ad=US&fromAR=1) says that Excel does not support adding of watermarks, however, it offers some workarounds. [One of them](https://support.office.com/en-us/article/Add-a-watermark-in-Excel-a372182a-d733-484e-825c-18ddf3edf009?ui=en-US&rs=en-US&ad=US&fromAR=1#odh_background) is using worksheet background images as watermarks.

Use the following code sample to add [background watermark](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.spreadsheet/spreadsheetbackgroundwatermarkoptions) to all worksheets of Excel document.

**AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets.SpreadsheetAddWatermarkAsBackground**

```csharp
SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
// Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
{
    using (ImageWatermark watermark = new ImageWatermark(Constants.LogoGif))
    {
        SpreadsheetBackgroundWatermarkOptions options = new SpreadsheetBackgroundWatermarkOptions();
        watermarker.Add(watermark, options);
    }

    watermarker.Save(Constants.OutSpreadsheetXlsx);
}
```

{{< alert style="info" >}}Backgrounds are viewable in Normal View in the worksheet and are invisible in Page Layout mode. The image is automatically tiled on the background of the worksheet. Excel formats don't support background image customization. Using properties of image watermark (size, rotation etc) will cause image redrawing. This may lead to the decrease in performance.{{< /alert >}}

### Worksheet background image size

You can also define the size ([width](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.spreadsheet/spreadsheetbackgroundwatermarkoptions/properties/backgroundwidth) and [height](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.spreadsheet/spreadsheetbackgroundwatermarkoptions/properties/backgroundheight)) of the background image on which your watermark will be drawn. This feature allows you to mimic watermark relative size and position.

**AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets.SpreadsheetAddWatermarkAsBackgroundWithRelativeSizeAndPosition**

```csharp
SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
// Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
{
    using (ImageWatermark watermark = new ImageWatermark(Constants.LogoGif))
    {
        watermark.HorizontalAlignment = HorizontalAlignment.Center;
        watermark.VerticalAlignment = VerticalAlignment.Center;
        watermark.RotateAngle = 90;
        watermark.SizingType = SizingType.ScaleToParentDimensions;
        watermark.ScaleFactor = 0.5;

        SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();
        SpreadsheetBackgroundWatermarkOptions options = new SpreadsheetBackgroundWatermarkOptions();
        options.BackgroundWidth = content.Worksheets[0].ContentAreaWidthPx; /* set background width */
        options.BackgroundHeight = content.Worksheets[0].ContentAreaHeightPx; /* set background height */

        watermarker.Add(watermark, options);
    }

    watermarker.Save(Constants.OutSpreadsheetXlsx);
}
```

{{< alert style="warning" >}}This method assumes that watermark absolute coordinates and size are measured in pixels (if they are assigned).{{< /alert >}}

### [TextWatermark](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.watermarks/textwatermark) as background

Excel does not support text backgrounds but you still can pass [TextWatermark](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.watermarks/textwatermark) instance with the [SpreadsheetBackgroundWatermarkOptions](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.spreadsheet/spreadsheetbackgroundwatermarkoptions) option. The text will be converted to image preserving formatting. The following code sample demonstrates this feature.

**AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets.SpreadsheetAddTextWatermarkAsBackground**

```csharp
SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
// Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
{
    TextWatermark watermark = new TextWatermark("Test watermark", new Font("Segoe UI", 19));
    watermark.HorizontalAlignment = HorizontalAlignment.Center;
    watermark.VerticalAlignment = VerticalAlignment.Center;
    watermark.RotateAngle = 45;
    watermark.SizingType = SizingType.ScaleToParentDimensions;
    watermark.ScaleFactor = 0.5;
    watermark.Opacity = 0.5;

    SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();

    SpreadsheetBackgroundWatermarkOptions options = new SpreadsheetBackgroundWatermarkOptions();
    options.BackgroundWidth = content.Worksheets[0].ContentAreaWidthPx; /* set background width */
    options.BackgroundHeight = content.Worksheets[0].ContentAreaHeightPx; /* set background height */

    watermarker.Add(watermark, options);
    watermarker.Save(Constants.OutSpreadsheetXlsx);
}
```

### Header and footer image watermark

Another way to mimic watermark in Excel is to [use Headers and Footers](https://support.office.com/en-us/article/Add-a-watermark-in-Excel-a372182a-d733-484e-825c-18ddf3edf009?ui=en-US&rs=en-US&ad=US&fromAR=1). You can [add](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.spreadsheet/spreadsheetwatermarkheaderfooteroptions) watermark to worksheet's header or footer using below code sample.

**AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets.SpreadsheetAddImageWatermarkIntoHeaderFooter**

```csharp
SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
// Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
{
    using (ImageWatermark watermark = new ImageWatermark(Constants.LogoPng))
    {
        watermark.VerticalAlignment = VerticalAlignment.Top;
        watermark.HorizontalAlignment = HorizontalAlignment.Center;
        watermark.SizingType = SizingType.ScaleToParentDimensions;
        watermark.ScaleFactor = 1;

        SpreadsheetWatermarkHeaderFooterOptions options = new SpreadsheetWatermarkHeaderFooterOptions();
        options.WorksheetIndex = 0;

        watermarker.Add(watermark, options);
    }

    watermarker.Save(Constants.OutSpreadsheetXlsx);
}
```

### Header and footer text watermark

You can also add [text watermark](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.watermarks/textwatermark) in header or footer as shown in the below code sample.

**AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets.SpreadsheetAddTextWatermarkIntoHeaderFooter**

```csharp
SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
// Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
{
    TextWatermark watermark = new TextWatermark("Test watermark", new Font("Segoe UI", 19, FontStyle.Bold));
    watermark.ForegroundColor = Color.Red;
    watermark.BackgroundColor = Color.Aqua;
    watermark.VerticalAlignment = VerticalAlignment.Top;
    watermark.HorizontalAlignment = HorizontalAlignment.Center;

    SpreadsheetWatermarkHeaderFooterOptions options = new SpreadsheetWatermarkHeaderFooterOptions();
    options.WorksheetIndex = 0;

    watermarker.Add(watermark, options);
    watermarker.Save(Constants.OutSpreadsheetXlsx);
}
```

{{< alert style="warning" >}}You’ll see the watermark in Excel only when you’re in Page Layout view or Print Preview.{{< /alert >}}{{< alert style="warning" >}}Excel Headersand footers are not designed for watermarking, so, some features don't work for header and footer watermarks.{{< /alert >}}

## Advanced use cases

## More resources

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Watermark for .NET examples](https://github.com/groupdocs-watermark/GroupDocs.Watermark-for-.NET)
    
*   [GroupDocs.Watermark for Java examples](https://github.com/groupdocs-watermark/GroupDocs.Watermark-for-Java)
    

### Free online document watermarking App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to add watermark to PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Watermarking App](https://products.groupdocs.app/watermark).
