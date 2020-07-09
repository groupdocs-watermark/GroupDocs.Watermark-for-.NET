---
id: load-password-protected-document
url: watermark/net/load-password-protected-document
title: Load password-protected document
weight: 4
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
Some document formats also support content encryption. To load these type of documents you will have to provide the password. GroupDocs.Watermark API allows you to load content of these documents to manage watermark.

## Load password-protected document of any supported format

The following example demonstrates how to load an encrypted document of any supported format using the password. If the password is incorrect, [InvalidPasswordException ](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.exceptions/invalidpasswordexception)is thrown.

**AdvancedUsage.LoadingDocuments.LoadPasswordProtectedDocument**

```csharp
LoadOptions loadOptions = new LoadOptions();
loadOptions.Password = "P@$$w0rd";
// Constants.InProtectedDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\protected-document.docx"
string filePath = Constants.InProtectedDocumentDocx;
using (Watermarker watermarker = new Watermarker(filePath, loadOptions))
{
    // use watermarker methods to manage watermarks in the document
    TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 12));

    watermarker.Add(watermark);

    watermarker.Save(Constants.OutProtectedDocumentDocx);
} 
```

## Load password-protected word processing document

The following example demontrates how to load an encrypted word processing document (DOC, DOCX etc) using the password.

**AdvancedUsage.LoadingDocuments.LoadPasswordProtectedWordProcessingDocument**

```csharp
WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
loadOptions.Password = "P@$$w0rd";
// Constants.InProtectedDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\protected-document.docx"
string filePath = Constants.InProtectedDocumentDocx;
using (Watermarker watermarker = new Watermarker(filePath, loadOptions))
{
    // use watermarker methods to manage watermarks in the WordProcessing document
    TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 12));
    watermarker.Add(watermark);
    watermarker.Save(Constants.OutProtectedDocumentDocx);
}

```

The following [LoadOptions](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options/loadoptions) descendants use [Password](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options/loadoptions/properties/password) property:

*   [DiagramLoadOptions](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.diagram/diagramloadoptions)
*   [PdfLoadOptions](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.pdf/pdfloadoptions)
*   [PresentationLoadOptions](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.presentation/presentationloadoptions)
*   [SpreadsheetLoadOptions](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.spreadsheet/spreadsheetloadoptions)
*   [WordProcessingLoadOptions](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.wordprocessing/wordprocessingloadoptions)

## More resources

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Watermark for .NET examples](https://github.com/groupdocs-watermark/GroupDocs.Watermark-for-.NET)
    
*   [GroupDocs.Watermark for Java examples](https://github.com/groupdocs-watermark/GroupDocs.Watermark-for-Java)
    

### Free online document watermarking App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to add watermark to PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Watermarking App](https://products.groupdocs.app/watermark).
