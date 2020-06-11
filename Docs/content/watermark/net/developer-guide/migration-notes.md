---
id: migration-notes
url: watermark/net/migration-notes
title: Migration Notes
weight: 3
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
  

# Migration notes

## Why to migrate?

Here are the key reasons to use the new updated API provided by GroupDocs.Watermark for .NET since version 19.5:

*   [Watermarker](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/watermarker) class is introduced as a single entry point to manage watermarks in the document (instead of  [Document ](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.legacy/document) class from previous versions).
*   Adding watermarks was unified for all supported document formats.
*   Product architecture was redesigned from scratch in order to simplify passing options to manage watermarks.
*   Document information and preview generation procedures were simplified.

## How to migrate?

Here is a brief comparison of how to manage watermarks using the old and new API.

#### Load documents

##### Any supported format

The folowing examples show how to load a document of any supported format.

**Old API**

```csharp
using (Document doc = Document.Load(@"C:\test.doc"))
{
        // watermarking goes here
        // ...
}
```

**New API**

```csharp
using (Watermarker watermarker = new Watermarker(@"C:\test.doc"))
{
        // watermarking goes here
        // ...
}
```

##### Document of specific format

The following examples show how to load a diagram document.

**Old API**

```csharp
using (DiagramDocument doc = Document.Load<DiagramDocument>(@"C:\diagram.vsdx"))
{
        // watermarking goes here
        // ...
}
```

**New API**

```csharp
DiagramLoadOptions loadOptions = new DiagramLoadOptions();
using (Watermarker watermarker = new Watermarker(@"C:\diagram.vsdx", loadOptions))
{
        // watermarking goes here
        // ...
}
```

#### Add watermarks

The following examples show how to add text watermark to a document of any supported type.

**Old API**

```csharp
foreach (string filePath in Directory.GetFiles(@"C:\Documents"))
{
    using (Document document = Document.Load(filePath))
    {
        TextWatermark watermark = new TextWatermark("top secret", new Font("Arial", 36))
        watermark.ForegroundColor = Color.Red;
        watermark.HorizontalAlignment = HorizontalAlignment.Center;
        watermark.VerticalAlignment = VerticalAlignment.Center;

        document.AddWatermark(watermark);
        document.Save();
    }
}
```

**New API**

```csharp
foreach (string filePath in Directory.GetFiles(@"C:\Documents"))                        
{                                                                                       
    using (Watermarker watermarker = new Watermarker(filePath))                         
    {                                                                                   
        TextWatermark watermark = new TextWatermark("top secret", new Font("Arial", 36));
        watermark.ForegroundColor = Color.Red;
        watermark.HorizontalAlignment = HorizontalAlignment.Center;
        watermark.VerticalAlignment = VerticalAlignment.Center;

        watermarker.Add(watermark);                                            
        watermarker.Save();                                                             
    }                                                                                   
}
```

##### Add watermark with options

The following examples show how to add watermark to the first page of a diagram document.

**Old API**

```csharp
using (DiagramDocument doc = Document.Load<DiagramDocument>(@"C:\diagram.vsdx"))
{
    TextWatermark textWatermark = new TextWatermark("Test watermark", new Font("Calibri", 19));

    doc.Pages[0].AddWatermark(textWatermark);

    doc.Save();
}
```

**New API**

```csharp
using (Watermarker watermarker = new Watermarker(@"C:\diagram.vsdx"))
{
    TextWatermark textWatermark = new TextWatermark("Test watermark", new Font("Calibri", 19));

    watermarker.Add(textWatermark, new DiagramPageWatermarkOptions { PageIndex = 0 });

    watermarker.Save();
}
```

#### Search watermarks

The following examles show how to find watermarks using search criteria.

**Old API**

```csharp
using (Document doc = Document.Load(@"C:\test.some_ext"))
{
    SizeSearchCriteria widthRange = new SizeSearchCriteria(Dimension.Width, 50, 100);
    RotateAngleSearchCriteria rotateAngle = new RotateAngleSearchCriteria(0, 45);
    TextSearchCriteria textCriteria = new TextSearchCriteria(new Regex("^Test watermark$"));

    PossibleWatermarkCollection watermarks = doc.FindWatermarks(textCriteria.And(widthRange.Or(rotateAngle)));

    Console.WriteLine("Found {0} possible watermarks.", watermarks.Count);
}
```

**New API**

```csharp
using (Watermarker watermarker = new Watermarker(@"C:\test.some_ext"))
{
    SizeSearchCriteria widthRange = new SizeSearchCriteria(Dimension.Width, 50, 100);
    RotateAngleSearchCriteria rotateAngle = new RotateAngleSearchCriteria(0, 45);
    TextSearchCriteria textCriteria = new TextSearchCriteria(new Regex("^Test watermark$"));

    PossibleWatermarkCollection watermarks = watermarker.Search(textCriteria.And(widthRange.Or(rotateAngle)));

    Console.WriteLine("Found {0} possible watermarks.", watermarks.Count);
}
```

#### Remove watermarks

The following examples show how to remove all possible watermarks.

**Old API**

```csharp
using (Document doc = Document.Load(@"C:\document.pdf"))
{
    PossibleWatermarkCollection watermarks = doc.FindWatermarks();
    watermarks.Clear();
    doc.Save(@"C:\document_without_watermarks.pdf");
}
```

**New API**

```csharp
using (Watermarker watermarker = new Watermarker(@"C:\document.pdf"))
{
    PossibleWatermarkCollection watermarks = watermarker.Search();
    watermarker.Remove(watermarks);
    watermarker.Save(@"C:\document_without_watermarks.pdf");
}
```

#### Get document info

The following examples show how to get document information from the local file.

**Old API**

```csharp
DocumentInfo documentInfo = Document.GetInfo(@"C:\test.ppt");
Console.WriteLine(documentInfo.FileFormat);
Console.WriteLine(documentInfo.IsEncrypted);
```

**New API**

```csharp
using (Watermarker watermarker = new Watermarker(@"C:\test.ppt"))
{
    IDocumentInfo info = watermarker.GetDocumentInfo();
    Console.WriteLine("File type: {0}", info.FileType);
    Console.WriteLine("Number of pages: {0}", info.PageCount);
    Console.WriteLine("Document size: {0} bytes", info.Size);
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
