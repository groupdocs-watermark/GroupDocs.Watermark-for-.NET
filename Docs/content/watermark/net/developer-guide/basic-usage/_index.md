---
id: basic-usage
url: watermark/net/basic-usage
title: Basic Usage
weight: 1
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
GroupDocs.Watermark library provides ability to manipulate with different watermark types such as [TextWatermark](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.watermarks/textwatermark), [ImageWatermark](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.watermarks/imagewatermark). These watermarks could be added to document, updated, removed, or searched inside already watermarked documents. Our product also provides information about document type and structure - file type, size, pages count, etc. and generates document pages preview based on provided options.  

Here are main GroupDocs.Watermark API concepts:

*   [Watermarker](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/watermarker) is the main class that contains all required methods for manipulating with document watermarks.
    
*   Most part of methods expects different options to add, update, search or remove watermarks inside document.
    
*   [Watermarker](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/watermarker) class implements [IDisposable](https://docs.microsoft.com/en-us/dotnet/api/system.idisposable) interface to correctly release used resources - like safely closing document streams when all operations completed.
    

## Referencing required namespaces

The following code shows how to include required namespace for all code examples.  

```csharp
using GroupDocs.Watermark;
using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Contents;
using GroupDocs.Watermark.Options;
using GroupDocs.Watermark.Search;
using GroupDocs.Watermark.Watermarks;
```

## Watermarker object definition

The following code shows most used code pattern to define [Watermarker](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/watermarker) object and call its methods.

```csharp
// Add text watermark to PDF document
using (Watermarker watermarker = new Watermarker("document.pdf"))
{
    TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 36, FontStyle.Bold | FontStyle.Italic));
    watermarker.Add(watermark);
    watermarker.Save("Watermarked_document.pdf");
}
```

Let’s review common usage scenarios when documents and watermarks are stored in a local drive and you want to manage them using GroupDocs.Watermark API:

## More resources

### Advanced usage topics

To learn more about document watermarking features and get familiar how to manage watermarks and more, please refer to the [advanced usage section]({{< ref "watermark/net/developer-guide/basic-usage/_index.md" >}}).

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Watermark for .NET examples](https://github.com/groupdocs-watermark/GroupDocs.Watermark-for-.NET)
    
*   [GroupDocs.Watermark for Java examples](https://github.com/groupdocs-watermark/GroupDocs.Watermark-for-Java)
    

### Free online document watermarking app

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to add watermark to PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Watermarking App](https://products.groupdocs.app/watermark).
