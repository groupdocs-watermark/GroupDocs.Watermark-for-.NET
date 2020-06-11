---
id: working-with-spreadsheet-document-attachments
url: watermark/net/working-with-spreadsheet-document-attachments
title: Working with spreadsheet document attachments
weight: 2
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
## Extract all attachments from excel document 

GroupDocs.Watermark API allows you to extract [attachments](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.spreadsheet/spreadsheetworksheet/properties/attachments) in Excel document. Following code performs this functionality.

**AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets.SpreadsheetExtractAllAttachments**

```csharp
SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
// Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
{
    SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();
    foreach (SpreadsheetWorksheet worksheet in content.Worksheets)
    {
        foreach (SpreadsheetAttachment attachment in worksheet.Attachments)
        {
            Console.WriteLine("Alternative text: {0}", attachment.AlternativeText);
            Console.WriteLine("Attachment frame x-coordinate: {0}", attachment.X);
            Console.WriteLine("Attachment frame y-coordinate: {0}", attachment.Y);
            Console.WriteLine("Attachment frame width: {0}", attachment.Width);
            Console.WriteLine("Attachment frame height: {0}", attachment.Height);
            Console.WriteLine("Preview image size: {0}", attachment.PreviewImageContent != null ? attachment.PreviewImageContent.Length : 0);
            if (attachment.IsLink)
            {
                // The document contains only a link to the attached file
                Console.WriteLine("Full path to the attached file: {0}", attachment.SourceFullName);
            }
            else
            {
                // The attached file is stored in the document
                Console.WriteLine("File type: {0}", attachment.GetDocumentInfo().FileType);
                Console.WriteLine("Name of the source file: {0}", attachment.SourceFullName);
                Console.WriteLine("File size: {0}", attachment.Content.Length);
            }
        }
    }
```

## Add an attachment to excel document

 GroupDocs.Watermark API allows you to [add attachments](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.spreadsheet/spreadsheetattachmentcollection/methods/addattachment) in Excel document. Following code performs this functionality.

**AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets.SpreadsheetAddAttachment**

```csharp
SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
// Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
{
    SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();
    SpreadsheetWorksheet worksheet = content.Worksheets[0];
    // Add the attachment
    worksheet.Attachments.AddAttachment(File.ReadAllBytes(Constants.InDocumentDocx), // File content
                                        "sample document.docx", // Source file full name (the extension is used
                                        // to determine appropriate application to open
                                        // the file) 
                                        File.ReadAllBytes(Constants.DocumentPreviewPng), // Preview image content
                                        50, // X-coordinate of the attachment frame
                                        100, // Y-coordinate of the attachment frame
                                        200, // Attachment frame width
                                        400); // Attachment frame height
    // Save changes
    watermarker.Save(Constants.OutSpreadsheetXlsx);
}
```

## Add linked attachment to excel document

 GroupDocs.Watermark API allows you to [add linked attachments](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.spreadsheet/spreadsheetattachmentcollection/methods/addlink) in Excel document. Following code performs this functionality.

**AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets.SpreadsheetAddLinkedAttachment**

```csharp
SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
// Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
{
    SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();
    SpreadsheetWorksheet worksheet = content.Worksheets[0];

    // Add the attachment
    worksheet.Attachments.AddLink(Constants.InDocumentDocx, // Source file path
                                  File.ReadAllBytes(Constants.DocumentPreviewPng), // Preview image content
                                  50, // X-coordinate of the attachment frame
                                  100, // Y-coordinate of the attachment frame
                                  200, // Attachment frame width
                                  400); // Attachment frame height
    // Save changes
    watermarker.Save(Constants.OutSpreadsheetXlsx);
}
```

## Remove attachment from excel document

GroupDocs.Watermark API allows you to remove [attachments](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.spreadsheet/spreadsheetattachmentcollection) in Excel document. Following code performs this functionality.

**AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets.SpreadsheetRemoveAttachment**

```csharp
SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
// Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
{
    SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();
    foreach (SpreadsheetWorksheet worksheet in content.Worksheets)
    {
        for (int i = worksheet.Attachments.Count - 1; i >= 0; i--)
        {
            SpreadsheetAttachment attachment = worksheet.Attachments[i];
            if (attachment.IsLink &&
                !File.Exists(attachment.SourceFullName) || // Linked file that is not available at this moment
                attachment.GetDocumentInfo().IsEncrypted) // Attached file protected with a password
            {
                // Remove the file if it meets at least one of the conditions above
                worksheet.Attachments.RemoveAt(i);
            }
        }
    }

    // Save changes
    watermarker.Save(Constants.OutSpreadsheetXlsx);
}
```

## Add watermark to all attachments  

GroupDocs.Watermark API allows you to add watermark to all [attachments](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.spreadsheet/spreadsheetattachmentcollection) in Excel document. Following code performs this functionality.

**AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets.SpreadsheetAddWatermarkToAttachment**

```csharp
TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 19));
SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
// Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions))
{
    SpreadsheetContent content = watermarker.GetContent<SpreadsheetContent>();
    foreach (SpreadsheetWorksheet worksheet in content.Worksheets)
    {
        foreach (SpreadsheetAttachment attachment in worksheet.Attachments)
        {
            // Check if the attached file is supported by GroupDocs.Watermark
            IDocumentInfo info = attachment.GetDocumentInfo();
            if (info.FileType != FileType.Unknown && !info.IsEncrypted)
            {
                // Load the attached document
                using (Watermarker attachedWatermarker = attachment.CreateWatermarker())
                {
                    // Add wateramrk
                    attachedWatermarker.Add(watermark);

                    // Save changes in the attached file
                    attachedWatermarker.Save();
                }
            }
        }
    }

    // Save changes
    watermarker.Save(Constants.OutSpreadsheetXlsx);
}
```

## Search for images in attached files

GroupDocs.Watermark API allows you to search for all the [images and watermarkable attachments](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.search.objects/spreadsheetsearchableobjects) in Excel document. Following code performs this functionality.

**AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets.SpreadsheetSearchImageInAttachment**

```csharp
// Consider only the attached images
WatermarkerSettings settings = new WatermarkerSettings();
settings.SearchableObjects.SpreadsheetSearchableObjects = SpreadsheetSearchableObjects.AttachedImages;

SpreadsheetLoadOptions loadOptions = new SpreadsheetLoadOptions();
// Constants.InSpreadsheetXlsx is an absolute or relative path to your document. Ex: @"C:\Docs\spreadsheet.xlsx"
using (Watermarker watermarker = new Watermarker(Constants.InSpreadsheetXlsx, loadOptions, settings))
{
    // Specify sample image to compare document images with
    ImageSearchCriteria criteria = new ImageDctHashSearchCriteria(Constants.AttachmentPng);

    // Search for similar images
    PossibleWatermarkCollection possibleWatermarks = watermarker.Search(criteria);

    // Remove or modify found image watermarks
    // ...

    Console.WriteLine("Found {0} possible watermark(s).", possibleWatermarks.Count);
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
