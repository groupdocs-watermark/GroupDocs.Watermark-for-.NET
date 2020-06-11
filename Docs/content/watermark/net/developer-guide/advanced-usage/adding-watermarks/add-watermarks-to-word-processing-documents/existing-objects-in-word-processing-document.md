---
id: existing-objects-in-word-processing-document
url: watermark/net/existing-objects-in-word-processing-document
title: Existing objects in word processing document
weight: 1
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
Watermarks in Word documents are usually represented by shapes. Using GroupDocs.Watermark API you can easily remove shape of any type from any level of document structure.

## Removing watermark from a particular section

Removing watermark from a particular section of a Word document using GroupDocs.Watermark consists of following steps.

1.  Load the document 
2.  Create and initialize [image](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.search.searchcriteria/imagesearchcriteria) or [text](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.search.searchcriteria/textsearchcriteria) search criteria  
3.  [Find](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents/contentpart/methods/search) possible watermarks
4.  Remove found watermarks 
5.  Save the document

Following code sample shows how to remove watermark from a particular section.

**AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing.WordProcessingRemoveWatermarkFromSection**

```csharp
WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
// Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
{
    // Initialize search criteria
    ImageSearchCriteria imageSearchCriteria = new ImageDctHashSearchCriteria(Constants.LogoPng);
    TextSearchCriteria textSearchCriteria = new TextSearchCriteria("Company Name");

    // Call Search method for the section
    WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();
    PossibleWatermarkCollection possibleWatermarks = content.Sections[0].Search(textSearchCriteria.Or(imageSearchCriteria));

    // Remove all found watermarks
    for (int i = possibleWatermarks.Count - 1; i >= 0; i--)
    {
        possibleWatermarks.RemoveAt(i);
    }

    watermarker.Save(Constants.OutDocumentDocx);
}
```

### Search for particular header or footer  

You can also call *[Search](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents/contentpart/methods/search)* method for a particular [header or footer](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.wordprocessing/wordprocessingheaderfooter) as shown in the below code sample.

**AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing.WordProcessingFindWatermarkInHeaderFooter**

```csharp
WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
// Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
{
    // Initialize search criteria
    ImageSearchCriteria imageSearchCriteria = new ImageDctHashSearchCriteria(Constants.LogoPng);
    TextSearchCriteria textSearchCriteria = new TextSearchCriteria("Company Name");

    WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();
    PossibleWatermarkCollection possibleWatermarks = content.Sections[0]
                                                            .HeadersFooters[OfficeHeaderFooterType.HeaderPrimary]
                                                            .Search(textSearchCriteria.Or(imageSearchCriteria));
    // Remove all found watermarks
    for (int i = possibleWatermarks.Count - 1; i >= 0; i--)
    {
        possibleWatermarks.RemoveAt(i);
    }

    watermarker.Save(Constants.OutDocumentDocx);
}
```

## Extracting information about all shapes in a word document

*[Search](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/watermarker/methods/search)* method returns a collection of*[PossibleWatermark](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.search/possiblewatermark)* instances for all document types. But in some cases, it's necessary to get more information about Word shapes than common API offers. GroupDocs.Watermark enables you to extract the information about all the [shapes](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.wordprocessing/wordprocessingsection/properties/shapes) as shown in the below code sample.

**AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing.WordProcessingGetShapesInformation**

```csharp
WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
// Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
{
    WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();
    foreach (WordProcessingSection section in content.Sections)
    {
        foreach (WordProcessingShape shape in section.Shapes)
        {
            if (shape.HeaderFooter != null)
            {
                Console.WriteLine("In header/footer");
            }

            Console.WriteLine(shape.ShapeType);
            Console.WriteLine(shape.Width);
            Console.WriteLine(shape.Height);
            Console.WriteLine(shape.IsWordArt);
            Console.WriteLine(shape.RotateAngle);
            Console.WriteLine(shape.AlternativeText);
            Console.WriteLine(shape.Name);
            Console.WriteLine(shape.X);
            Console.WriteLine(shape.Y);
            Console.WriteLine(shape.Text);

            if (shape.Image != null)
            {
                Console.WriteLine(shape.Image.Width);
                Console.WriteLine(shape.Image.Height);
                Console.WriteLine(shape.Image.GetBytes().Length);
            }

            Console.WriteLine(shape.HorizontalAlignment);
            Console.WriteLine(shape.VerticalAlignment);
            Console.WriteLine(shape.RelativeHorizontalPosition);
            Console.WriteLine(shape.RelativeVerticalPosition);
        }
    }
}
```

## Working with shape types

You can extract information about the existing shapes of particular types. The *[GroupDocs.Watermark.Contents.WordProcessing.WordProcessingShapeType](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.wordprocessing/wordprocessingshapetype)* enum is available to check the types possibly available shapes.

The following code snippet demonstrates the usage of *[WordProcessingShapeType](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.wordprocessing/wordprocessingshapetype)* enum.

**AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing.WordProcessingShapeTypeUsage**

```csharp
WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
// Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
{
    WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();
    foreach (WordProcessingSection section in content.Sections)
    {
        foreach (WordProcessingShape shape in section.Shapes)
        {
            //Check for Diagonal Corners Rounded shapes
            if (shape.ShapeType == WordProcessingShapeType.DiagonalCornersRounded)
            {
                Console.WriteLine("Diagonal Corners Rounded shape found");

                //Write text on all Diagonal Corners Rounded shapes
                shape.FormattedTextFragments.Add("I am Diagonal Corner Rounded", new Font("Calibri", 8, FontStyle.Bold), Color.Red, Color.Aqua);
            }
        }
    }

    watermarker.Save(Constants.OutDocumentDocx);
}
```

## Removing a particular shape

You can also remove a particular [shape](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.wordprocessing/wordprocessingshape) from a Word document as shown in the below code sample.

**AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing.WordProcessingRemoveShape**

```csharp
WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
// Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
{
    WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();

    // Remove shape by index
    content.Sections[0].Shapes.RemoveAt(0);

    // Remove shape by reference
    content.Sections[0].Shapes.Remove(content.Sections[0].Shapes[0]);

    watermarker.Save(Constants.OutDocumentDocx);
}
```

## Removing shapes with particular text formatting

You can also find and remove the shapes with a particular [text formatting](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.wordprocessing/wordprocessingshape/properties/formattedtextfragments) from a Word document as shown in the below code sample.

**AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing.WordProcessingRemoveShapesWithParticularTextFormatting**

```csharp
WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
// Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
{
    WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();
    foreach (WordProcessingSection section in content.Sections)
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

    watermarker.Save(Constants.OutDocumentDocx);
}
```

## Removing or replacing hyperlink associated with a particular shape

Using GroupDocs.Watermark for .NET, you can also remove or replace [hyperlink](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.wordprocessing/wordprocessingshape/properties/hyperlink) associated with a particular shape inside a Word document. Use following code sample to achieve this functionality.

**AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing.WordProcessingRemoveHyperlinks**

```csharp
WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
// Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
{
    WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();

    // Replace hyperlink
    content.Sections[0].Shapes[0].Hyperlink = "https://www.groupdocs.com/";

    // Remove hyperlink
    content.Sections[0].Shapes[1].Hyperlink = null;

    watermarker.Save(Constants.OutDocumentDocx);
}
```

## Replacing text for particular shapes

### Replacing shape's text

GroupDocs.Watermark supports replacing [text](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.wordprocessing/wordprocessingshape/properties/text) for particular shapes in a Word document. Following code sample shows the usage of this feature.

**AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing.WordProcessingReplaceTextForParticularShape**

```csharp
WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
// Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
{
    WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();

    // Set shape's text
    foreach (WordProcessingShape shape in content.Sections[0].Shapes)
    {
        if (shape.Text.Contains("Some text"))
        {
            shape.Text = "Another text";
        }
    }

    // Save document
    watermarker.Save(Constants.OutDocumentDocx);
}
```

### Replacing shape's text with formatted text

You can also replace the [text](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.wordprocessing/wordprocessingshape/properties/text) of the shapes with [formatted text](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.wordprocessing/wordprocessingshape/properties/formattedtextfragments) as shown in the following code sample.

**AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing.WordProcessingReplaceShapeTextWithFormattedText**

```csharp
WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
// Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
{
    WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();

    // Set shape's text
    foreach (WordProcessingShape shape in content.Sections[0].Shapes)
    {
        if (shape.Text.Contains("Some text"))
        {
            shape.FormattedTextFragments.Clear();
            shape.FormattedTextFragments.Add("Another text", new Font("Calibri", 19, FontStyle.Bold), Color.Red, Color.Aqua);
        }
    }

    // Save document
    watermarker.Save(Constants.OutDocumentDocx);
}
```

## Replacing shape's image

GroupDocs.Watermark also allows you to replace the [image](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.wordprocessing/wordprocessingshape/properties/image) of the particular shapes in a Word document as shown in the following code sample.

**AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing.WordProcessingReplaceShapeImage**

```csharp
WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
// Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
{
    WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();

    // Set shape image
    foreach (WordProcessingShape shape in content.Sections[0].Shapes)
    {
        if (shape.Image != null)
        {
            shape.Image = new WordProcessingWatermarkableImage(File.ReadAllBytes(Constants.TestPng));
        }
    }

    // Save document
    watermarker.Save(Constants.OutDocumentDocx);
}
```

## Modifying shape properties

GroupDocs.Watermark also provides the feature of modifying properties ([AlternativeText](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.wordprocessing/wordprocessingshape/properties/alternativetext), [RotateAngle](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.wordprocessing/wordprocessingshape/properties/rotateangle), [X](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.wordprocessing/wordprocessingshape/properties/x), [Y](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.wordprocessing/wordprocessingshape/properties/y), [Height](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.wordprocessing/wordprocessingshape/properties/height), [Width](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.wordprocessing/wordprocessingshape/properties/width) or [BehindText](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.wordprocessing/wordprocessingshape/properties/behindtext)) of particular shapes in a Word document. Following code sample shows how to use this feature.

**AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing.WordProcessingModifyShapeProperties**

```csharp
WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
// Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
{
    WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();

    // Change shape properties
    foreach (WordProcessingShape shape in content.Sections[0].Shapes)
    {
        if (shape.Text.Contains("Some text"))
        {
            shape.AlternativeText = "watermark";
            shape.RotateAngle = 30;
            shape.X = 200;
            shape.Y = 200;
            shape.Height = 100;
            shape.Width = 400;
            shape.BehindText = false;
        }
    }

    // Save document
    watermarker.Save(Constants.OutDocumentDocx);
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
