---
id: existing-objects-in-diagram-document
url: watermark/net/existing-objects-in-diagram-document
title: Existing objects in diagram document
weight: 1
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
The watermarks in Visio documents are usually represented by shapes. But sometimes document headers&footers can also be used to display text that can be considered as the watermark. GroupDocs.Watermark API allows you to find and remove watermarks of both types in Visio document.

## Removing watermark from a particular page

Removing watermark from a particular page of a Visio document using GroupDocs.Watermark consists of following steps.

1.  Load the document
2.  Create and initialize image/text search criteria
3.  [Find](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.contentpart/search/methods/1) possible watermarks
4.  Remove found watermarks
5.  Save the document

Following code sample shows how to remove watermark from a particular page.

**AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams.DiagramRemoveWatermark**

```csharp
DiagramLoadOptions loadOptions = new DiagramLoadOptions();
// Constants.InDiagramVsdx is an absolute or relative path to your document. Ex: @"C:\Docs\diagram.vsdx"
using (Watermarker watermarker = new Watermarker(Constants.InDiagramVsdx, loadOptions))
{
    DiagramContent content = watermarker.GetContent<DiagramContent>();

    // Initialize search criteria
    ImageSearchCriteria imageSearchCriteria = new ImageDctHashSearchCriteria(Constants.LogoPng);
    TextSearchCriteria textSearchCriteria = new TextSearchCriteria("Company Name");

    // Call FindWatermarks method for the first page
    PossibleWatermarkCollection possibleWatermarks = content.Pages[0].Search(textSearchCriteria.Or(imageSearchCriteria));

    // Remove all found watermarks
    possibleWatermarks.Clear();
    watermarker.Save(Constants.OutDiagramVsdx);
}
```

## Working with shapes

### Extracting information about all shapes

*[Search](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.contentpart/search/methods/1)* method searches watermarks of all mentioned types, but in some cases, it's necessary to analyze only one type of Visio objects. Following code sample shows how to get information about all the shapes in a Visio document.

**AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams.DiagramGetShapesInformation**

```csharp
DiagramLoadOptions loadOptions = new DiagramLoadOptions();
// Constants.InDiagramVsdx is an absolute or relative path to your document. Ex: @"C:\Docs\diagram.vsdx"
using (Watermarker watermarker = new Watermarker(Constants.InDiagramVsdx, loadOptions))
{
    DiagramContent content = watermarker.GetContent<DiagramContent>();
    foreach (DiagramPage page in content.Pages)
    {
        foreach (DiagramShape shape in page.Shapes)
        {
            if (shape.Image != null)
            {
                Console.WriteLine(shape.Image.Width);
                Console.WriteLine(shape.Image.Height);
                Console.WriteLine(shape.Image.GetBytes().Length);
            }

            Console.WriteLine(shape.Name);
            Console.WriteLine(shape.X);
            Console.WriteLine(shape.Y);
            Console.WriteLine(shape.Width);
            Console.WriteLine(shape.Height);
            Console.WriteLine(shape.RotateAngle);
            Console.WriteLine(shape.Text);
            Console.WriteLine(shape.Id);
        }
    }
}
```

### Removing a particular shape

You can also remove a particular shape from a page using GroupDocs.Watermark API (as shown in the sample code below).

**AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams.DiagramRemoveShape()**

```csharp
DiagramLoadOptions loadOptions = new DiagramLoadOptions();
// Constants.InDiagramVsdx is an absolute or relative path to your document. Ex: @"C:\Docs\diagram.vsdx"
using (Watermarker watermarker = new Watermarker(Constants.InDiagramVsdx, loadOptions))
{
    DiagramContent content = watermarker.GetContent<DiagramContent>();

    // Remove shape by index
    content.Pages[0].Shapes.RemoveAt(0);

    // Remove shape by reference
    content.Pages[0].Shapes.Remove(content.Pages[0].Shapes[0]);

    watermarker.Save(Constants.OutDiagramVsdx);
}
```

### Removing shapes with particular text formatting

You can also find and remove the shapes with a particular text formatting from a Visio document as shown in the below code sample.

**AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams.DiagramRemoveTextShapesWithParticularTextFormatting**

```csharp
DiagramLoadOptions loadOptions = new DiagramLoadOptions();
// Constants.InDiagramVsdx is an absolute or relative path to your document. Ex: @"C:\Docs\diagram.vsdx"
using (Watermarker watermarker = new Watermarker(Constants.InDiagramVsdx, loadOptions))
{
    DiagramContent content = watermarker.GetContent<DiagramContent>();
    foreach (DiagramPage page in content.Pages)
    {
        for (int i = page.Shapes.Count - 1; i >= 0; i--)
        {
            foreach (FormattedTextFragment fragment in page.Shapes[i].FormattedTextFragments)
            {
                if (fragment.ForegroundColor == Color.Red && fragment.Font.FamilyName == "Arial")
                {
                    page.Shapes.RemoveAt(i);
                    break;
                }
            }
        }
    }

    watermarker.Save(Constants.OutDiagramVsdx);
}
```

### Removing hyperlink associated with a particular shape

Using GroupDocs.Watermark for .NET, you can also remove hyperlink associated with a particular shape inside a Visio document. Use following code sample to achieve this functionality.

**AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams.DiagramRemoveHyperlinks**

```csharp
DiagramLoadOptions loadOptions = new DiagramLoadOptions();
// Constants.InDiagramVsdx is an absolute or relative path to your document. Ex: @"C:\Docs\diagram.vsdx"
using (Watermarker watermarker = new Watermarker(Constants.InDiagramVsdx, loadOptions))
{
    DiagramContent content = watermarker.GetContent<DiagramContent>();
    DiagramShape shape = content.Pages[0].Shapes[0];
    for (int i = shape.Hyperlinks.Count - 1; i >= 0; i--)
    {
        if (shape.Hyperlinks[i].Address.Contains("http://someurl.com"))
        {
            shape.Hyperlinks.RemoveAt(i);
        }
    }

    watermarker.Save(Constants.OutDiagramVsdx);
}
```

### Replacing text for particular shapes

Since version 18.1. GroupDocs.Watermark allows you to replace the text for particular shapes. Following code sample shows how to replace shapes' text.

**AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams.DiagramReplaceTextForParticularShapes**

```csharp
DiagramLoadOptions loadOptions = new DiagramLoadOptions();
// Constants.InDiagramVsdx is an absolute or relative path to your document. Ex: @"C:\Docs\diagram.vsdx"
using (Watermarker watermarker = new Watermarker(Constants.InDiagramVsdx, loadOptions))
{
    DiagramContent content = watermarker.GetContent<DiagramContent>();
    foreach (DiagramShape shape in content.Pages[0].Shapes)
    {
        if (shape.Text != null && shape.Text.Contains("© Aspose 2016"))
        {
            shape.Text = "© GroupDocs 2017";
        }
    }

    // Save changes
    watermarker.Save(Constants.OutDiagramVsdx);
}
```

### Replacing text for particular shapes with formatted text

You can also replace the text with a formatted text as shown in the following code sample.

**AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams.DiagramReplaceTextWithFormatting**

```csharp
DiagramLoadOptions loadOptions = new DiagramLoadOptions();
// Constants.InDiagramVsdx is an absolute or relative path to your document. Ex: @"C:\Docs\diagram.vsdx"
using (Watermarker watermarker = new Watermarker(Constants.InDiagramVsdx, loadOptions))
{
    DiagramContent content = watermarker.GetContent<DiagramContent>();
    foreach (DiagramShape shape in content.Pages[0].Shapes)
    {
        if (shape.Text != null && shape.Text.Contains("© Aspose 2016"))
        {
            shape.FormattedTextFragments.Clear();
            shape.FormattedTextFragments.Add("© GroupDocs 2017", new Font("Calibri", 19, FontStyle.Bold), Color.Red, Color.Aqua);
        }
    }

    // Save changes
    watermarker.Save(Constants.OutDiagramVsdx);
}
```

### Replacing shape image

Since version 18.1. GroupDocs.Watermark also allows you to replace the image of particular shapes as shown in the below code sample.

**AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams.DiagramReplaceShapeImage**

```csharp
DiagramLoadOptions loadOptions = new DiagramLoadOptions();
// Constants.InDiagramVsdx is an absolute or relative path to your document. Ex: @"C:\Docs\diagram.vsdx"
using (Watermarker watermarker = new Watermarker(Constants.InDiagramVsdx, loadOptions))
{
    DiagramContent content = watermarker.GetContent<DiagramContent>();
    foreach (DiagramShape shape in content.Pages[0].Shapes)
    {
        if (shape.Image != null)
        {
            shape.Image = new DiagramWatermarkableImage(File.ReadAllBytes(Constants.TestPng));
        }
    }

    // Save changes
    watermarker.Save(Constants.OutDiagramVsdx);
}
```

## Working with headers and footers

### Extracting information about all headers and footers

The API allows you to extract information about all the headers&footers in a Visio document using following code.

**AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams.DiagramGetHeaderFooterInformation**

```csharp
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
```

### Removing or replacing a particular header and footer

Following code sample shows how to remove and replace a particular header&footer in a Visio document.

**AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams.DiagramRemoveOrReplaceHeaderFooter**

```csharp
DiagramLoadOptions loadOptions = new DiagramLoadOptions();
// Constants.InDiagramVsdx is an absolute or relative path to your document. Ex: @"C:\Docs\diagram.vsdx"
using (Watermarker watermarker = new Watermarker(Constants.InDiagramVsdx, loadOptions))
{
    DiagramContent content = watermarker.GetContent<DiagramContent>();

    // Remove header
    content.HeaderFooter.HeaderCenter = null;

    // Replace footer
    content.HeaderFooter.FooterCenter = "Footer center";
    content.HeaderFooter.Font.Size = 19;
    content.HeaderFooter.Font.FamilyName = "Calibri";
    content.HeaderFooter.TextColor = Color.Red;

    watermarker.Save(Constants.OutDiagramVsdx);
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
