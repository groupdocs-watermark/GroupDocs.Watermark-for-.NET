---
id: save-document-to-the-same-file-or-stream
url: watermark/net/save-document-to-the-same-file-or-stream
title: Save document to the same file or stream
weight: 1
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
Following code shows usage of [Save()](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/watermarker/methods/save) method.

**AdvancedUsage.SavingDocuments.SaveDocumentToTheSameFileOrStream**

```csharp
// Constants.InTestDoc is an absolute or relative path to your document. Ex: @"C:\Docs\test.doc"
File.Copy(Constants.InTestDoc, Constants.OutTestDoc);
using (Watermarker watermarker = new Watermarker(Constants.OutTestDoc))
{
    // watermarking goes here
    TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 12));
    watermarker.Add(watermark);

    // Saves the document to the underlying source (stream or file)
    watermarker.Save();
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
