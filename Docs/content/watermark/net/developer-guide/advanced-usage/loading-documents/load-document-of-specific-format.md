---
id: load-document-of-specific-format
url: watermark/net/load-document-of-specific-format
title: Load document of specific format
weight: 3
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
# Loading document of specific format

The constructors [Watermarker(String)](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/watermarker/constructors/4) and [Watermarker(Stream)](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/watermarker/constructors/main) can load a document of any supported format. When you're loading a document, GroupDocs.Watermark automatically detects its type and creates an instance of the appropriate class. If document format is not supported, constructor throws [UnsupportedFileTypeException](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.exceptions/unsupportedfiletypeexception). If you need specify the format of a document to load, you can use constructors with [LoadOptions](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options/loadoptions) parameter.

The following examle demonstrates how to create a watermarker for the Spreadsheet document:

**AdvancedUsage.LoadingDocuments.LoadingDocumentOfSpecificFormat**

```csharp
// Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
string filePath = Constants.InSpreadsheetXlsx;
SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
using (Watermarker watermarker = new Watermarker(filePath, loadOptions))
{
    // use watermarker methods to manage watermarks in the Spreadsheet document
    TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 12));
    watermarker.Add(watermark);
    watermarker.Save(Constants.OutSpreadsheetXlsx);
}

```

Any supported format family has the specific [LoadOptions](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options/loadoptions) descendant:

| Format | LoadOptions descendant |
| --- | --- |
| Diagram | [DiagramLoadOptions](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.diagram/diagramloadoptions) |
| Email | [EmailLoadOptions](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.email/emailloadoptions) |
| Image | [ImageLoadOptions](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.image/imageloadoptions) |
| GifImage | [GifImageLoadOptions](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.image/gifimageloadoptions) |
| TiffImage | [TiffImageLoadOptions](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.image/tiffimageloadoptions) |
| PDF | [PdfLoadOptions](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.pdf/pdfloadoptions) |
| Presentation | [PresentationLoadOptions](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.presentation/presentationloadoptions) |
| Spreadsheet | [SpreadsheetLoadOptions](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.spreadsheet/spreadsheetloadoptions) |
| WordProcessing | [WordProcessingLoadOptions](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.wordprocessing/wordprocessingloadoptions) |

## More resources

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Watermark for .NET examples](https://github.com/groupdocs-watermark/GroupDocs.Watermark-for-.NET)
    
*   [GroupDocs.Watermark for Java examples](https://github.com/groupdocs-watermark/GroupDocs.Watermark-for-Java)
    

### Free online document watermarking App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to add watermark to PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Watermarking App](https://products.groupdocs.app/watermark).
