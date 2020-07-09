---
id: attachments-in-pdf-document
url: watermark/net/attachments-in-pdf-document
title: Attachments in PDF document
weight: 1
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
  

# Attachments in PDF document

## Extract all attachments from PDF document 

GroupDocs.Watermark API allows you to extract [attachments](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.pdf/pdfcontent/properties/attachments) in PDF document. Following code performs this functionality.

**AdvancedUsage.AddingWatermarks.AddWatermarksToPdf.PdfExtractAllAttachments**

```csharp
PdfLoadOptions loadOptions = new PdfLoadOptions();
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
{
    PdfContent pdfContent = watermarker.GetContent<PdfContent>();
    foreach (PdfAttachment attachment in pdfContent.Attachments)
    {
        Console.WriteLine("Name: {0}", attachment.Name);
        Console.WriteLine("Description: {0}", attachment.Description);
        Console.WriteLine("File type: {0}", attachment.GetDocumentInfo().FileType);

        // Save the attached file on disk
        File.WriteAllBytes(Path.Combine(Constants.OutputPath, attachment.Name), attachment.Content);
    }
}
```

## Add an attachment to PDF document

The API also allows you to add attachments to the PDF document. Following code snippet shows how to remove an attachment

**AdvancedUsage.AddingWatermarks.AddWatermarksToPdf.PdfAddAttachment**

```csharp
PdfLoadOptions loadOptions = new PdfLoadOptions();
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
{
    PdfContent pdfContent = watermarker.GetContent<PdfContent>();

    // Add the attachment
    pdfContent.Attachments.Add(File.ReadAllBytes(Constants.InSampleDocx), "sample doc", "sample doc as attachment");

    // Save changes
    watermarker.Save(Constants.OutDocumentPdf);
}
```

## Remove attachment from PDF document

The API also allows you to remove attachments from the PDF document. Following code snippet shows how to remove an attachment.

**AdvancedUsage.AddingWatermarks.AddWatermarksToPdf.PdfRemoveAttachment**

```csharp
PdfLoadOptions loadOptions = new PdfLoadOptions();
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
{
    PdfContent pdfContent = watermarker.GetContent<PdfContent>();
    for (int i = pdfContent.Attachments.Count - 1; i >= 0; i--)
    {
        PdfAttachment attachment = pdfContent.Attachments[i];

        // Remove all attached pdf files with a particular name
        if (attachment.Name.Contains("sample") && attachment.GetDocumentInfo().FileType == FileType.DOCX)
        {
            pdfContent.Attachments.RemoveAt(i);
        }
    }

    watermarker.Save(Constants.OutDocumentPdf);
}
```

## Search for images attachments

In case you want to search for all the images attachments in a PDF document, you can use GroupDocs.Watermark. Following code sample shows how to search images attachments of PDF document.

**AdvancedUsage.AddingWatermarks.AddWatermarksToPdf.PdfSearchImageInAttachment**

```csharp
PdfLoadOptions loadOptions = new PdfLoadOptions();
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
{
    // Consider only the attached images
    watermarker.SearchableObjects.PdfSearchableObjects = PdfSearchableObjects.AttachedImages;

    // Search for similar images
    WatermarkableImageCollection possibleWatermarks = watermarker.GetImages();
    Console.WriteLine("Found {0} image(s).", possibleWatermarks.Count);
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
