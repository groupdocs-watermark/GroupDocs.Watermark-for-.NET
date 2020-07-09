---
id: save-document-to-the-specified-location
url: watermark/net/save-document-to-the-specified-location
title: Save document to the specified location
weight: 2
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
Following code shows usage of [Save(string)](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.watermarker/save/methods/4) method.

**AdvancedUsage.SavingDocuments.SaveDocumentToTheSpecifiedLocation**

```csharp
// Constants.InTestDoc is an absolute or relative path to your document. Ex: @"C:\Docs\test.doc"
using (Watermarker watermarker = new Watermarker(Constants.InTestDoc))
{
    // watermarking goes here
    TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 12));
    watermarker.Add(watermark);

    // Saves the document to the specified location
    watermarker.Save(Constants.OutTestDoc);
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
