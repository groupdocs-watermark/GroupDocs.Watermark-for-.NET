---
id: rasterize-document-or-page
url: watermark/net/rasterize-document-or-page
title: Rasterize document or page
weight: 3
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
The watermark can be removed from the PDF documents using third-party tools. However, if you want to get a watermark that is almost impossible to remove, you can consider PDF document rasterization. GroupDocs.Watermark provides the feature to convert all the pages of a PDF document to raster images with only one line of code.

## Rasterize PDF document

Following code snippet is used to [rasterize](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.pdf/pdfcontent/methods/rasterize) the PDF document to protect added watermarks.  

**AdvancedUsage.AddingWatermarks.AddWatermarksToPdf.PdfRasterizeDocument**

```csharp
PdfLoadOptions loadOptions = new PdfLoadOptions();
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
{
    // Initialize image or text watermark
    TextWatermark watermark = new TextWatermark("Do not copy", new Font("Arial", 8));
    watermark.HorizontalAlignment = HorizontalAlignment.Center;
    watermark.VerticalAlignment = VerticalAlignment.Center;
    watermark.RotateAngle = 45;
    watermark.SizingType = SizingType.ScaleToParentDimensions;
    watermark.ScaleFactor = 1;
    watermark.Opacity = 0.5;

    // Add watermark of any type first
    watermarker.Add(watermark);
    PdfContent pdfContent = watermarker.GetContent<PdfContent>();

    // Rasterize all pages
    pdfContent.Rasterize(100, 100, PdfImageConversionFormat.Png);

    // Content of all pages is replaced with raster images
    watermarker.Save(Constants.OutDocumentPdf);
}
```

{{< alert style="warning" >}}You can't restore document content after saving the document. Rasterization significantly increases the size of the resultant PDF file.{{< /alert >}}

## Rasterize particular page of the PDF document

The API also allows you to [rasterize](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.pdf/pdfpage/methods/rasterize) any particular page of the PDF document. Following code snippet is used to rasterize a page of the PDF document.

**AdvancedUsage.AddingWatermarks.AddWatermarksToPdf.PdfRasterizePage**

```csharp
PdfLoadOptions loadOptions = new PdfLoadOptions();
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
{
    // Initialize image or text watermark
    TextWatermark watermark = new TextWatermark("Do not copy", new Font("Arial", 8));
    watermark.HorizontalAlignment = HorizontalAlignment.Center;
    watermark.VerticalAlignment = VerticalAlignment.Center;
    watermark.RotateAngle = 45;
    watermark.SizingType = SizingType.ScaleToParentDimensions;
    watermark.ScaleFactor = 1;
    watermark.Opacity = 0.5;

    // Add watermark of any type first
    PdfArtifactWatermarkOptions options = new PdfArtifactWatermarkOptions();
    options.PageIndex = 0;
    watermarker.Add(watermark, options);

    // Rasterize the first page
    PdfContent pdfContent = watermarker.GetContent<PdfContent>();
    pdfContent.Pages[0].Rasterize(100, 100, PdfImageConversionFormat.Png);

    // Content of the first page is replaced with raster image
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
