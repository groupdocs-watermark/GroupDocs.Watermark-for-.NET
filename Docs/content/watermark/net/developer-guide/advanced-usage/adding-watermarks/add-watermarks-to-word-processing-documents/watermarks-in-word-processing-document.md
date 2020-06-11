---
id: watermarks-in-word-processing-document
url: watermark/net/watermarks-in-word-processing-document
title: Watermarks in word processing document
weight: 4
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
# Watermarks in word pocessing document

When adding watermark in Microsoft Word application, it places a shape with appropriate content in section headers. GroupDocs.Watermark API uses the same approach. When calling *[Add](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/watermarker/methods/add)* method of *[Watermarker](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/watermarker)* class, the shape is added to a document.

## Using properties of [WordProcessingWatermarkBaseOptions](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.wordprocessing/wordprocessingwatermarkbaseoptions)

You can also set some additional options ([Name](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.wordprocessing/wordprocessingwatermarkbaseoptions/properties/name) or [AlternativeText](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.wordprocessing/wordprocessingwatermarkbaseoptions/properties/alternativetext)) when adding shape watermark to a Word document using GroupDocs.Watermark. Following code samples demonstrates it.

**AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing.WordProcessingAddWatermarkWithShapeSettings**

```csharp
WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
// Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
{
    TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 19));

    //Some settings for watermark
    watermark.VerticalAlignment = VerticalAlignment.Center;
    watermark.HorizontalAlignment = HorizontalAlignment.Center;
    watermark.RotateAngle = 25.0;
    watermark.ForegroundColor = Color.Red;
    watermark.Opacity = 1.0;

    WordProcessingWatermarkSectionOptions options = new WordProcessingWatermarkSectionOptions();

    // Set the shape name
    options.Name = "Shape 1";

    // Set the descriptive (alternative) text that will be associated with the shape
    options.AlternativeText = "Test watermark";

    watermarker.Add(watermark, options);
    watermarker.Save(Constants.OutDocumentDocx);
}
```

## Using [WordProcessingTextEffects](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.wordprocessing/wordprocessingtexteffects)

You can also apply some text effects to the shape watermarks as shown in the below code.

**AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing.WordProcessingAddWatermarkWithTextEffects**

```csharp
WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
// Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
{
    TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 19));

    WordProcessingTextEffects effects = new WordProcessingTextEffects();
    effects.LineFormat.Enabled = true;
    effects.LineFormat.Color = Color.Red;
    effects.LineFormat.DashStyle = OfficeDashStyle.DashDotDot;
    effects.LineFormat.LineStyle = OfficeLineStyle.Triple;
    effects.LineFormat.Weight = 1;

    WordProcessingWatermarkSectionOptions options = new WordProcessingWatermarkSectionOptions();
    options.Effects = effects;

    watermarker.Add(watermark, options);
    watermarker.Save(Constants.OutDocumentDocx);
}
```

## Using [WordProcessingImageEffects](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.wordprocessing/wordprocessingimageeffects)

GroupDocs.Watermark also provides the facility to apply image effects to the shape watermarks.

**AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing.WordProcessingAddWatermarkWithImageEffects**

```csharp
WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
// Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
{
    using (ImageWatermark watermark = new ImageWatermark(Constants.LogoPng))
    {
        WordProcessingImageEffects effects = new WordProcessingImageEffects();
        effects.Brightness = 0.7;
        effects.Contrast = 0.6;
        effects.ChromaKey = Color.Red;
        effects.BorderLineFormat.Enabled = true;
        effects.BorderLineFormat.Weight = 1;

        WordProcessingWatermarkSectionOptions options = new WordProcessingWatermarkSectionOptions();
        options.Effects = effects;

        watermarker.Add(watermark, options);
    }

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
