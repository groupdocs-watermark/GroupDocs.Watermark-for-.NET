---
id: add-watermarks-to-word-processing-documents
url: watermark/net/add-watermarks-to-word-processing-documents
title: Add watermarks to word processing documents
weight: 9
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
Microsoft Word allows the user to divide and format the [document](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.wordprocessing/wordprocessingcontent) into multiple [sections](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.wordprocessing/wordprocessingcontent/properties/sections). Defining sections in the document enables the user to set specific page layout and formatting for different parts of the document. An example of the sections is headers and footers. Headers and footers are used to display text or any graphical object on all the pages.

## Adding watermark to a particular section

GroupDocs.Watermark API allows you to add watermark objects in the headers and footers of the page. Adding watermark to a section of a Word document using GroupDocs.Watermark consists of following steps.

1.  Load the document 
2.  Create and initialize watermark object 
3.  Set watermark properties
4.  Create [WordProcessingWatermarkSectionOptions](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.wordprocessing/wordprocessingwatermarksectionoptions) and set [SectionIndex](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.wordprocessing/wordprocessingwatermarksectionoptions/properties/sectionindex)
5.  Add watermark to the section of the document
6.  Save the document

Following code adds watermark to the headers of a particular section.

**AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing.WordProcessingAddWatermarkToSection**

```csharp
WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
// Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
{
    TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 19));

    // Add watermark to all headers of the first section
    WordProcessingWatermarkSectionOptions options = new WordProcessingWatermarkSectionOptions();
    options.SectionIndex = 0;

    watermarker.Add(watermark, options);
    watermarker.Save(Constants.OutDocumentDocx);
}
```

The code snippet above adds watermark to the first section (to all headers of this section). So, it will be displayed on all pages belonging to the section.

## Getting page size 

If for some reasons you want to use absolute sizing and positioning, you may also need to get some [page properties](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.wordprocessing/wordprocessingsection/properties/pagesetup) for a section. GroupDocs.Watermark allows you to extract information about a particular section.

**AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing.WordProcessingGetSectionProperties**

```csharp
WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
// Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
{
    WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();

    Console.WriteLine(content.Sections[0].PageSetup.Width);
    Console.WriteLine(content.Sections[0].PageSetup.Height);
    Console.WriteLine(content.Sections[0].PageSetup.TopMargin);
    Console.WriteLine(content.Sections[0].PageSetup.RightMargin);
    Console.WriteLine(content.Sections[0].PageSetup.BottomMargin);
    Console.WriteLine(content.Sections[0].PageSetup.LeftMargin);
}
```

## Adding watermark to the images inside a particular section

Using GroupDocs.Watermark, you can add watermark to the [images](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents/contentpart/methods/findimages) that belong to a particular section.

**AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing.WordProcessingAddWatermarkToSectionImages**

```csharp
WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
// Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
{
    TextWatermark watermark = new TextWatermark("Protected image", new Font("Arial", 8));
    watermark.HorizontalAlignment = HorizontalAlignment.Center;
    watermark.VerticalAlignment = VerticalAlignment.Center;
    watermark.RotateAngle = 45;
    watermark.SizingType = SizingType.ScaleToParentDimensions;
    watermark.ScaleFactor = 1;

    // Get all images belonging to the first section
    WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();
    WatermarkableImageCollection images = content.Sections[0].FindImages();

    // Add watermark to all found images
    foreach (WatermarkableImage image in images)
    {
        image.Add(watermark);
    }

    watermarker.Save(Constants.OutDocumentDocx);
}
```

## Adding watermark to the image shapes in a word document

Word document may also contain different [shapes](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.wordprocessing/wordprocessingsection/properties/shapes). The API allows you to use shape collection to add watermark to [images](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.wordprocessing/wordprocessingshape/properties/image) in a document. Below example shows how to add watermark to image shapes.

**AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing.WordProcessingAddWatermarkToShapeImages**

```csharp
WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
// Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
{
    TextWatermark watermark = new TextWatermark("Protected image", new Font("Arial", 8));
    watermark.HorizontalAlignment = HorizontalAlignment.Center;
    watermark.VerticalAlignment = VerticalAlignment.Center;
    watermark.RotateAngle = 45;
    watermark.SizingType = SizingType.ScaleToParentDimensions;
    watermark.ScaleFactor = 1;

    WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();
    foreach (WordProcessingSection section in content.Sections)
    {
        foreach (WordProcessingShape shape in section.Shapes)
        {
            // Headers&Footers usually contains only service information.
            // So, we skip images in headers/footers, expecting that they are probably watermarks or backgrounds
            if (shape.HeaderFooter == null && shape.Image != null)
            {
                shape.Image.Add(watermark);
            }
        }
    }

    watermarker.Save(Constants.OutDocumentDocx);
}
```

## Adding watermark to a particular page of word document

GroupDocs.Watermark enables you to add watermark to a [particular page](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.wordprocessing/wordprocessingwatermarkpagesoptions) of a Word document. You can use following example to achieve this.

**AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing.WordProcessingAddWatermarkToParticularPage**

```csharp
WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
// Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
{
    TextWatermark textWatermark = new TextWatermark("DRAFT", new Font("Arial", 42));

    // Add watermark to the last page
    WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();
    WordProcessingWatermarkPagesOptions options = new WordProcessingWatermarkPagesOptions();
    options.PageNumbers = new int[] {content.PageCount};

    watermarker.Add(textWatermark, options);
    watermarker.Save(Constants.OutDocumentDocx);
}
```

## Working with headers and footers

### Linking headers and footers

Header or footer in a Word document can be linked to the corresponding header or footer in the previous section. In this way, the same content is displayed in the linked header or footer. GroupDocs.Watermark API provides the option to link the header or footer using [IsLinkedToPrevious](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.wordprocessing/wordprocessingheaderfooter/properties/islinkedtoprevious) property of [WordProcessingHeaderFooter ](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.wordprocessing/wordprocessingheaderfooter) class. Following code snippet serves this purpose.

**AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing.WordProcessingLinkHeaderFooterInSection**

```csharp
WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
// Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
{
    WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();

    // Link footer for even numbered pages to corresponding footer in previous section
    content.Sections[1].HeadersFooters[OfficeHeaderFooterType.FooterEven].IsLinkedToPrevious = true;

    watermarker.Save(Constants.OutDocumentDocx);
}
```

### Linking all headers and footers  

Following code snippet links all the [headers and footers](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.wordprocessing/wordprocessingsection/properties/headersfooters) in a particular section.

**AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing.WordProcessingLinkAllHeaderFooterInSection**

```csharp
WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
// Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
{
    WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();

    // Link footer for even numbered pages to corresponding footer in previous section
    content.Sections[1].HeadersFooters[1].IsLinkedToPrevious = true;

    watermarker.Save(Constants.OutDocumentDocx);
}
```

### Add watermark to headers and footers with linking  

This feature can be useful to reduce resultant file size when you're adding image watermark to all [sections](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.wordprocessing/wordprocessingcontent/properties/sections).

**AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing.WordProcessingAddImageWatermark**

```csharp
WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
// Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
{
    using (ImageWatermark watermark = new ImageWatermark(Constants.LargePng))
    {
        // Add watermark to all headers of the first section
        WordProcessingWatermarkSectionOptions options = new WordProcessingWatermarkSectionOptions();
        options.SectionIndex = 0;
        watermarker.Add(watermark, options);
    }

    // Link all other headers&footers to corresponding headers&footers of the first section
    WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();
    for (int i = 1; i < content.Sections.Count; i++)
    {
        content.Sections[i].HeadersFooters.LinkToPrevious(true);
    }

    watermarker.Save(Constants.OutDocumentDocx);
}
```

### Setting different headers or footers 

Using GroupDocs.Watermark API, you can also set [different](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.wordprocessing/wordprocessingpagesetup/properties/differentfirstpageheaderfooter) headers or footers for [even and odd](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.wordprocessing/wordprocessingpagesetup/properties/oddandevenpagesheaderfooter) numbered pages and for the first page of the document (as shown in below example).

**AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing.WordProcessingSetDifferentFirstPageHeaderFooter**

```csharp
WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
// Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
{
    WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();

    content.Sections[0].PageSetup.DifferentFirstPageHeaderFooter = true;
    content.Sections[0].PageSetup.OddAndEvenPagesHeaderFooter = true;

    watermarker.Save(Constants.OutDocumentDocx);
}
```

## Advanced use cases

## More resources

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Watermark for .NET examples](https://github.com/groupdocs-watermark/GroupDocs.Watermark-for-.NET)
    
*   [GroupDocs.Watermark for Java examples](https://github.com/groupdocs-watermark/GroupDocs.Watermark-for-Java)
    

### Free online document watermarking App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to add watermark to PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Watermarking App](https://products.groupdocs.app/watermark).
