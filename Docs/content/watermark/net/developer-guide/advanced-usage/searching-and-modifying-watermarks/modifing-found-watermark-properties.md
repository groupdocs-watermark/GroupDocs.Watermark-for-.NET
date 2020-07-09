---
id: modifing-found-watermark-properties
url: watermark/net/modifing-found-watermark-properties
title: Modifing found watermark properties
weight: 1
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
GroupDocs.Watermark also allows you to replace text and image in the found possible watermarks. Following sections will show you how to replace text and image of a found watermark.

## Replacing text

To replace text of the found watermarks, loop through the possible watermarks in the [watermark collection](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.search/possiblewatermarkcollection) and replace [Text](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.search/possiblewatermark/properties/text) property as shown in the following code sample.

**AdvancedUsage.SearchAndRemoveWatermarks.EditTextInFoundWatermarks**

```csharp
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf))
{
    TextSearchCriteria searchCriteria = new TextSearchCriteria("test", false);
    PossibleWatermarkCollection watermarks = watermarker.Search(searchCriteria);
    foreach (PossibleWatermark watermark in watermarks)
    {
        try
        {
            // Edit text
            watermark.Text = "passed";
        }
        catch (Exception e)
        {
            // Found entity may not support text editing
            // Passed argument can have inappropriate value
            // Process such cases here
        }
    }

    // Save document
    watermarker.Save(Constants.OutDocumentPdf);
}
```

## Replacing text with formatting

You can also replace the watermark's text with [formatting](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.search/possiblewatermark/properties/formattedtextfragments) as shown in the below code sample.

**AdvancedUsage.SearchAndRemoveWatermarks.EditTextWithFormattingInFoundWatermarks**

```csharp
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf))
{
    TextSearchCriteria searchCriteria = new TextSearchCriteria("test", false);
    PossibleWatermarkCollection watermarks = watermarker.Search(searchCriteria);
    foreach (PossibleWatermark watermark in watermarks)
    {
        try
        {
            // Edit text 
            watermark.FormattedTextFragments.Clear();
            watermark.FormattedTextFragments.Add("passed", new Font("Calibri", 19, FontStyle.Bold), Color.Red, Color.Aqua);
        }
        catch (Exception e)
        {
            // Found entity may not support text editing
            // Passed arguments can have inappropriate value
            // Process such cases here
        }
    }

    // Save document
    watermarker.Save(Constants.OutDocumentPdf);
}
```

## Replacing image

Following code sample shows how to replace the [image](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.search/possiblewatermark/properties/imagedata) of the found watermarks using GroupDocs.Watermark.

**AdvancedUsage.SearchAndRemoveWatermarks.ReplacesImageInFoundWatermarks**

```csharp
byte[] imageData = File.ReadAllBytes(Constants.ImagePng);

// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf))
{
    // Search watermark matching a particular image
    SearchCriteria searchCriteria = new ImageDctHashSearchCriteria(Constants.LogoBmp);
    PossibleWatermarkCollection watermarks = watermarker.Search(searchCriteria);
    foreach (PossibleWatermark watermark in watermarks)
    {
        try
        {
            // Replace image
            watermark.ImageData = imageData;
        }
        catch (Exception e)
        {
            // Found entity may not support image replacment
            // Passed image can have inappropriate format
            // Process such cases here
        }
    }

    // Save document
    watermarker.Save(Constants.OutDocumentPdf);
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
