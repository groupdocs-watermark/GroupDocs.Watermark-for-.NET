---
id: locking-watermark-in-word-processing-document
url: watermark/net/locking-watermark-in-word-processing-document
title: Locking watermark in word processing document
weight: 2
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
There might be the case when you need to lock the watermarks in a Word document to restrict the editing. To deal with such cases, GroupDocs.Watermark provides 5 variants of locking Word document when adding watermark.

*   **AllowOnlyRevisions**: user can only add revision marks to the document.
*   **AllowOnlyComments**: user can only modify comments in the document.
*   **AllowOnlyFormFields**: the document is split into one-page sections and locked section with watermark is added between each two adjacent document sections.
*   **ReadOnly**: the entire document is read-only.
*   **ReadOnlyWithEditableContent**: the document is read-only, but all the content except the watermark is marked as editable.

*[LockType](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.wordprocessing/wordprocessingwatermarkbaseoptions/properties/locktype)* property has been added to *[WordProcessingWatermarkBaseOptions](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.wordprocessing/wordprocessingwatermarkbaseoptions)* class (and all descendants) to set any of the above-mentioned lock types. *[*WordProcessing*LockType](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.wordprocessing/wordprocessinglocktype)* enum in [*GroupDocs.Watermark.Options.WordProcessing*](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.wordprocessing/) namespace is used to define the lock type. The following code samples show how to lock watermark in different scenarios.

## Adding watermark to all pages

This example uses [WordProcessingWatermarkPagesOptions](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.wordprocessing/wordprocessingwatermarkpagesoptions) with empty [PageNumbers](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.wordprocessing/wordprocessingwatermarkpagesoptions/properties/pagenumbers).

**AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing.WordProcessingAddLockedWatermarkToAllPages**

```csharp
WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
// Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
{
    TextWatermark watermark = new TextWatermark("Watermark text", new Font("Arial", 19));
    watermark.ForegroundColor = Color.Red;

    WordProcessingWatermarkPagesOptions options = new WordProcessingWatermarkPagesOptions();
    options.IsLocked = true;
    options.LockType = WordProcessingLockType.AllowOnlyFormFields;

    // To protect with password
    //options.Password = "7654321";

    watermarker.Add(watermark, options);
    watermarker.Save(Constants.OutDocumentDocx);
}
```

## Adding watermark to particular pages

This example uses [WordProcessingWatermarkPagesOptions](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.wordprocessing/wordprocessingwatermarkpagesoptions) with [PageNumbers](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.wordprocessing/wordprocessingwatermarkpagesoptions/properties/pagenumbers) containing numbers of two pages.

**AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing.WordProcessingAddLockedWatermarkToParticularPages**

```csharp
WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
// Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
{
    TextWatermark watermark = new TextWatermark("Watermark text", new Font("Arial", 19));
    watermark.ForegroundColor = Color.Red;

    WordProcessingWatermarkPagesOptions options = new WordProcessingWatermarkPagesOptions();
    options.PageNumbers = new int[] { 1, 3 };
    options.IsLocked = true;
    options.LockType = WordProcessingLockType.AllowOnlyComments;

    // To protect with password
    //options.Password = "7654321";

    watermarker.Add(watermark, options);
    watermarker.Save(Constants.OutDocumentDocx);
}
```

## Adding watermark to a section

This example uses [WordProcessingWatermarkSectionOptions](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.wordprocessing/wordprocessingwatermarksectionoptions) with [SectionIndex](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.wordprocessing/wordprocessingwatermarksectionoptions/properties/sectionindex).

**AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing.WordProcessingAddLockedWatermarkToSection**

```csharp
WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
// Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
{
    TextWatermark watermark = new TextWatermark("Watermark text", new Font("Arial", 19));
    watermark.ForegroundColor = Color.Red;

    WordProcessingWatermarkSectionOptions options = new WordProcessingWatermarkSectionOptions();
    options.SectionIndex = 0;
    options.IsLocked = true;
    options.LockType = WordProcessingLockType.ReadOnlyWithEditableContent;

    // To protect with password
    //options.Password = "7654321";

    watermarker.Add(watermark, options);
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
