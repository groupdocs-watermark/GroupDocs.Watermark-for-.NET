---
id: adding-text-watermarks
url: watermark/net/adding-text-watermarks
title: Adding text watermarks
weight: 2
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
Following code snippet shows how to add text watermark to a document. If the document consists of multiple parts (pages, worksheets, slides, frames etc), the watermark will be added to all of them.

**AdvancedUsage.AddingTextWatermarks.AddTextWatermark**

```csharp
// Constants.InImagePng is an absolute or relative path to your document. Ex: @"C:\Docs\image.png"
using (Watermarker watermarker = new Watermarker(Constants.InImagePng))
{
    // Initialize the font to be used for watermark
    Font font = new Font("Arial", 19, FontStyle.Bold | FontStyle.Italic);

    // Create the watermark object
    TextWatermark watermark = new TextWatermark("Test watermark", font);

    // Set watermark properties
    watermark.ForegroundColor = Color.Red;
    watermark.BackgroundColor = Color.Blue;
    watermark.TextAlignment = TextAlignment.Right;
    watermark.Opacity = 0.5;

    // Add watermark
    watermarker.Add(watermark);
    watermarker.Save(Constants.OutImagePng);
}
```

## Sizing and positioning of watermark

### Absolute watermark positioning

Using GroupDocs.Watermark, you can also add watermark to some absolute position in the document. Following example shows how to add a text watermark with absolute positioning using properties [X](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/watermark/properties/x), [Y](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/watermark/properties/y), [Width](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/watermark/properties/width) and [Height](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/watermark/properties/height). The values of all properties for absolute sizing and positioning are measured in default document units.

**AdvancedUsage.AddingTextWatermarks.AddWatermarkToAbsolutePosition**

```csharp
// Constants.InImagePng is an absolute or relative path to your document. Ex: @"C:\Docs\image.png"
using (Watermarker watermarker = new Watermarker(Constants.InImagePng))
{
    Font font = new Font("Times New Roman", 8);
    TextWatermark watermark = new TextWatermark("Test watermark", font);

    // Set watermark coordinates
    watermark.X = 10;
    watermark.Y = 20;

    // Set watermark size
    watermark.Width = 100;
    watermark.Height = 40;

    watermarker.Add(watermark);
    watermarker.Save(Constants.OutImagePng);
}
```

{{< alert style="warning" >}}Note that the origin of coordinates may be different for different document types (relative positioning doesn't have these specifics and can be used as a unified positioning approach).{{< /alert >}}

Following are the origin of the coordinates for different formats of the documents.

| Document Format | Unit of Measure | Origin of Coordinates |
| --- | --- | --- |
| PDF | Point | Left bottom corner of page |
| WordProcessing | Point | Left top corner of page  |
| Spreadsheet | Point | Left top corner of worksheet  |
| Presentation | Point | Left top corner of slide  |
| Image | Pixel | Left top corner of image (frame)  |
| Diagram | Point | Left top corner of page |

### Relative watermark positioning 

Instead of exact coordinates, you can also use parent relative alignment. Furthermore, you can also set offset from parent's borders by using [Margins](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/watermark/properties/margins) property as shown in below example. Following example shows how to align the watermark vertically and horizontally.

**AdvancedUsage.AddingTextWatermarks.AddWatermarkToRelativePosition**

```csharp
// Constants.InImagePng is an absolute or relative path to your document. Ex: @"C:\Docs\image.png"
using (Watermarker watermarker = new Watermarker(Constants.InImagePng))
{
    Font font = new Font("Calibri", 12);
    TextWatermark watermark = new TextWatermark("Test watermark", font);
    watermark.HorizontalAlignment = HorizontalAlignment.Right;
    watermark.VerticalAlignment = VerticalAlignment.Bottom;

    // Set absolute margins. Values are measured in document units.
    watermark.Margins.Right = 10;
    watermark.Margins.Bottom = 5;

    watermarker.Add(watermark);
    watermarker.Save(Constants.OutImagePng);
}
```

{{< alert style="warning" >}}Excel worksheets don't have explicit borders, therefore, the most right bottom non-empty cell is used to determine working area size.{{< /alert >}}

### Using [MarginType](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.watermarks/margins/properties/margintype)

In the example above, absolute margin values are used. This means that margins are measured in document units. But you can set relative margins for a watermark as well (as shown in below example).

**AdvancedUsage.AddingTextWatermarks.AddWatermarkWithMarginType**

```csharp
// Constants.InImagePng is an absolute or relative path to your document. Ex: @"C:\Docs\image.png"
using (Watermarker watermarker = new Watermarker(Constants.InImagePng))
{
    Font font = new Font("Calibri", 12);
    TextWatermark watermark = new TextWatermark("Test watermark", font);
    watermark.HorizontalAlignment = HorizontalAlignment.Right;
    watermark.VerticalAlignment = VerticalAlignment.Bottom;

    // Set relative margins. Margin value will be interpreted as a portion
    // of appropriate parent dimension. If this type is chosen, margin value
    // must be between 0.0 and 1.0.
    watermark.Margins.MarginType = MarginType.RelativeToParentDimensions;
    watermark.Margins.Right = 0.1;
    watermark.Margins.Bottom = 0.2;

    watermarker.Add(watermark);
    watermarker.Save(Constants.OutImagePng);
}
```

### Size types

In most cases, to add good looking watermark, you should consider the size of the page/slide/frame on which it will be placed. [ SizingType](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/watermark/properties/sizingtype) and [ScaleFactor ](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/watermark/properties/scalefactor)properties can be used to scale the watermark depending on the parent size.

**AdvancedUsage.AddingTextWatermarks.AddWatermarkWithSizeType**

```csharp
// Constants.InImagePng is an absolute or relative path to your document. Ex: @"C:\Docs\image.png"
using (Watermarker watermarker = new Watermarker(Constants.InImagePng))
{
    Font font = new Font("Calibri", 12);
    TextWatermark watermark = new TextWatermark("This is a test watermark", font);

    // Set sizing type
    watermark.SizingType = SizingType.ScaleToParentDimensions;

    // Set watermark scale
    watermark.ScaleFactor = 0.5;

    watermarker.Add(watermark);
    watermarker.Save(Constants.OutImagePng);
}
```

{{< alert style="info" >}}Using of relative size and positioning is the simplest way to add watermark to a document of any type.{{< /alert >}}

### Watermark rotation

GroupDocs.Watermark API also supports rotation of the watermark. You can use [RotateAngle](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/watermark/properties/rotateangle) property to define watermark rotation angle in degrees. A positive value means clockwise rotation.

**AdvancedUsage.AddingTextWatermarks.AddTextWatermarkWithRotationAngle**

```csharp
// Constants.InTestDocx is an absolute or relative path to your document. Ex: @"C:\Docs\test.docx"
using (Watermarker watermarker = new Watermarker(Constants.InTestDocx))
{
    Font font = new Font("Calibri", 8);
    TextWatermark watermark = new TextWatermark("Test watermark", font);
    watermark.HorizontalAlignment = HorizontalAlignment.Right;
    watermark.VerticalAlignment = VerticalAlignment.Top;
    watermark.SizingType = SizingType.ScaleToParentDimensions;
    watermark.ScaleFactor = 0.5;

    // Set rotation angle
    watermark.RotateAngle = 45;

    watermarker.Add(watermark);
    watermarker.Save(Constants.OutTestDocx);
}
```

If rotation angle is set, it is assumed that watermark size is equal to axis-aligned bounding box size. The following picture illustrates what is the watermark bounding box and how it is used for sizing and positioning. The picture shows a result of execution of the above code snippet. The actual watermark bounds are colored in blue and the bounding box is colored in red. As you can see, the bounding box size is used to calculate watermark relative size.

![](watermark/net/images/adding-text-watermarks.png)

### Considering parent margins

For most document formats you can set page margins when working with a document. By default, GroupDocs.Watermark ignores document margins and uses maximum available space for watermarking as shown in below image.

![](watermark/net/images/adding-text-watermarks_1.png)

  

As you can see, the watermark goes beyond page margins. To change this behavior, set [ConsiderParentMargins](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/watermark/properties/considerparentmargins) property to true (as shown in below example).

**AdvancedUsage.AddingTextWatermarks.AddWatermarkWithParentMargin**

```csharp
// Constants.InInputVsdx is an absolute or relative path to your document. Ex: @"C:\Docs\input.vsdx"
using (Watermarker watermarker = new Watermarker(Constants.InInputVsdx))
{
    TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 42));
    watermark.HorizontalAlignment = HorizontalAlignment.Right;
    watermark.VerticalAlignment = VerticalAlignment.Top;
    watermark.SizingType = SizingType.ScaleToParentDimensions;
    watermark.ScaleFactor = 1;
    watermark.RotateAngle = 45;
    watermark.ForegroundColor = Color.Red;
    watermark.BackgroundColor = Color.Aqua;

    // Add watermark considering parent margins
    watermark.ConsiderParentMargins = true;

    watermarker.Add(watermark);
    watermarker.Save(Constants.OutInputVsdx);
}
```

Now, the watermark is aligned with respect to page margins.

![](watermark/net/images/adding-text-watermarks_2.png)

## Watermark in documents of different types

Watermarks in documents of different types are represented by different objects. Some of these objects do not support some watermark properties. For example, the background color can not be set for WordArt object which is used as text watermark in a Word document. The full list of supported properties for all document types is available at [Adding text watermarks]({{< ref "watermark/net/developer-guide/advanced-usage/adding-watermarks/adding-text-watermarks.md" >}}).

## More resources

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Watermark for .NET examples](https://github.com/groupdocs-watermark/GroupDocs.Watermark-for-.NET)
    
*   [GroupDocs.Watermark for Java examples](https://github.com/groupdocs-watermark/GroupDocs.Watermark-for-Java)
    

### Free online document watermarking App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to add watermark to PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Watermarking App](https://products.groupdocs.app/watermark).
