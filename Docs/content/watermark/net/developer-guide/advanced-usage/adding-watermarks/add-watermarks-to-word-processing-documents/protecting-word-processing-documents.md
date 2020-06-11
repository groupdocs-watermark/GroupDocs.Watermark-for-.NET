---
id: protecting-word-processing-documents
url: watermark/net/protecting-word-processing-documents
title: Protecting word processing documents
weight: 3
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
Since version 18.6, GroupDocs.Watermark provides a simplified way of protecting the Word documents with the password. The API allows you to protect as well as unprotect the Word documents. The following protection types are supported:

*   *AllowOnlyRevisions*: user can only add revision marks to the document.
    
*   *AllowOnlyComments*: user can only modify comments in the document.
    
*   *AllowOnlyFormFields*: user can only enter data in the form fields in the document.
    
*   *ReadOnly*: no changes are allowed to the document.
    

The protection types are added to the [*WordProcessingProtectionType*](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.wordprocessing/wordprocessingprotectiontype) enum. Following code samples demonstrate how to protect and unprotect Word documents.

## Protecting a document

Following code sample [protects](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.wordprocessing/wordprocessingcontent/methods/protect) a Word document with the password.

**AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing.WordProcessingProtectDocument**

```csharp
WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
// Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
{
    WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();

    content.Protect(WordProcessingProtectionType.ReadOnly, "7654321");

    watermarker.Save(Constants.OutDocumentDocx);
}
```

## Unprotecting a document

The following code sample shows how to [unprotect](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.wordprocessing/wordprocessingcontent/methods/unprotect) a Word document regardless of password.

**AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing.WordProcessingUnProtectDocument**

```csharp
WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
// Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
{
    WordProcessingContent content = watermarker.GetContent<WordProcessingContent>();

    content.Unprotect();

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
