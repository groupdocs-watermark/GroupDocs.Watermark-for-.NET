---
id: add-text-or-image-watermark
url: watermark/net/add-text-or-image-watermark
title: Add text or image watermark
weight: 3
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
GroupDocs.Watermark allows to add watermarks and save resultant document. Full list of supported document formats can be found [here]({{< ref "watermark/net/getting-started/supported-document-formats.md" >}}). You may add text and image watermarks to the documents from local disk and from streams.

## Add a text watermark

The following example demostrates how to add a [TextWatermark](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.watermarks/textwatermark) to a local document:

*   [Create](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/watermarker/constructors/4) a watermarker for the local file (line 1);
*   [Create](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.watermarks/textwatermark/constructors/main) a watermark with text and font (line 3);
*   Set the watermark [color](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.watermarks/textwatermark/properties/foregroundcolor), [horizontal](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/watermark/properties/horizontalalignment) and [vertical](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/watermark/properties/verticalalignment) alignments (lines 4-6);
*   [Add](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/watermarker/methods/add) the watermark to the document (line 7);
*   [Save](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.watermarker/save/methods/4) the document to the new file (line 8).

**BasicUsage.AddATextWatermark**

```csharp
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf))
{
    TextWatermark watermark = new TextWatermark("top secret", new Font("Arial", 36));
    watermark.ForegroundColor = Color.Red;
    watermark.HorizontalAlignment = HorizontalAlignment.Center;
    watermark.VerticalAlignment = VerticalAlignment.Center;
    watermarker.Add(watermark);
    watermarker.Save(Constants.OutDocumentPdf);
}
```

## Add an image watermark

The following example demonstrates how to add an [ImageWatermark](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.watermarks/imagewatermark) to a document from a stream:

*   [Create](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/watermarker/constructors/main) a watermarker for the file stream (line 1);
*   [Create](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.watermarks/imagewatermark/constructors/1) a image watermark from the local image file (line 3);
*   Set the watermark [horizontal](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/watermark/properties/horizontalalignment) and [vertical](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/watermark/properties/verticalalignment) alignments (lines 5, 6);
*   [Add](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/watermarker/methods/add) the watetmark to the document (line 7);
*   [Save](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.watermarker/save/methods/4) the document to the new file (line 10).

**BasicUsage.AddAnImageWatermark**

```csharp
// Constants.InDocumentXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\document.xlsx"
using (FileStream stream = File.Open(Constants.InDocumentXlsx, FileMode.Open, FileAccess.ReadWrite))
{
    using (Watermarker watermarker = new Watermarker(stream))
    {
        using (ImageWatermark watermark = new ImageWatermark(Constants.LogoPng))
        {
            watermark.HorizontalAlignment = HorizontalAlignment.Center;
            watermark.VerticalAlignment = VerticalAlignment.Center;
            watermarker.Add(watermark);
        }

        watermarker.Save(Constants.OutDocumentXlsx);
    }
}
```

## More resources

### Advanced usage topics

To learn more about document watermarking features and get familiar how to manage watermarks and more, please refer to the [advanced usage section]({{< ref "watermark/net/developer-guide/advanced-usage/_index.md" >}}).

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Watermark for .NET examples](https://github.com/groupdocs-watermark/GroupDocs.Watermark-for-.NET)
    
*   [GroupDocs.Watermark for Java examples](https://github.com/groupdocs-watermark/GroupDocs.Watermark-for-Java)
    

### Free online document watermarking App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to add watermark to PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Watermarking App](https://products.groupdocs.app/watermark).
