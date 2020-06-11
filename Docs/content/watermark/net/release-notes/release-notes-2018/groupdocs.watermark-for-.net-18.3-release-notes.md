---
id: groupdocs-watermark-for-net-18-3-release-notes
url: watermark/net/groupdocs-watermark-for-net-18-3-release-notes
title: GroupDocs.Watermark for .NET 18.3 Release Notes
weight: 3
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Watermark for .NET 18.3.{{< /alert >}}

## Major Features

There are the following new features in this monthly release:

*   Implement ability to edit Pdf document objects that can be considered as watermarks
*   Implement ability to edit text and image in found possible watermarks (across all formats)

## Full List of Issues Covering all Changes in this Release

| Key  | Summary | Category |
| --- | --- | --- |
| WATERMARKNET-788 | Implement ability to edit Pdf document objects that can be considered as watermarks  | New Feature  |
| WATERMARKNET-789  | Implement ability to edit text and image in found possible watermarks (across all formats)  | New Feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Watermark for .NET 18.3. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Watermark which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Edit Pdf document objects that can be considered as watermarks

##### Description

This feature allows a user to edit existing XObjects, Artifacts and Annotations in a Pdf document.

##### Public API changes

*PdfShapeFormattedTextFragmentCollection* class has been added to *GroupDocs.Watermark.Pdf* namespace.  
*PdfTextFormattedTextFragmentCollection* class has been added to *GroupDocs.Watermark.Pdf* namespace.  
*PdfXForm* class has been added to *GroupDocs.Watermark.Pdf* namespace.  
*PdfXImage* class has been added to *GroupDocs.Watermark.Pdf* namespace.  
*PdfShape* class has been added to *GroupDocs.Watermark.Pdf* namespace.  
*PdfXObject* class is now inherited from *PdfShape*.  
*PdfArtifact* class is now inherited from *PdfShape*.  
*PdfAnnotation* class is now inherited from *PdfShape*.

##### Usage

Replace text for particular XObjects.

**C#**

```csharp
using (PdfDocument doc = Document.Load<PdfDocument>(@"D:\xobjects.pdf"))
{
    foreach (PdfXObject xObject in doc.Pages[0].XObjects)
    {
        if (xObject.Text.Contains("Test"))
        {
            xObject.Text = "Passed";
        }
    }
    doc.Save(@"D:\output.pdf");
}
```

Replace text for particular Artifacts.

**C#**

```csharp
using (PdfDocument doc = Document.Load<PdfDocument>(@"D:\artifacts.pdf"))
{
    foreach (PdfArtifact artifact in doc.Pages[0].Artifacts)
    {
        if (artifact.Text.Contains("Test"))
        {
            artifact.Text = "Passed";
        }
    }
    doc.Save(@"D:\output.pdf");
}
```

Replace text for particular Annotations.

**C#**

```csharp
using (PdfDocument doc = Document.Load<PdfDocument>(@"D:\annotations.pdf"))
{
    foreach (PdfAnnotation annotation in doc.Pages[0].Annotations)
    {
        if (annotation.Text.Contains("Test"))
        {
            annotation.Text = "Passed";
        }
    }
    doc.Save(@"D:\output.pdf");
}
```

Replace text with formatting (XObjects).

**C#**

```csharp
using (PdfDocument doc = Document.Load<PdfDocument>(@"D:\xobjects.pdf"))
{
    foreach (PdfXObject xObject in doc.Pages[0].XObjects)
    {
        if (xObject.Text.Contains("Test"))
        {
            xObject.FormattedTextFragments.Clear();
            xObject.FormattedTextFragments.Add("Passed", new Font("Calibri", 19, FontStyle.Bold), Color.Red, Color.Aqua);
        }
    }
    doc.Save(@"D:\output.pdf");
}
```

Replace text with formatting (Artifacts).

**C#**

```csharp
using (PdfDocument doc = Document.Load<PdfDocument>(@"D:\artifacts.pdf"))
{
    foreach (PdfArtifact artifact in doc.Pages[0].Artifacts)
    {
        if (artifact.Text.Contains("Test"))
        {
            artifact.FormattedTextFragments.Clear();
            artifact.FormattedTextFragments.Add("Passed", new Font("Calibri", 19, FontStyle.Bold), Color.Red, Color.Aqua);
        }
    }
    doc.Save(@"D:\output.pdf");
}
```

Replace text with formatting (Annotations).

**C#**

```csharp
using (PdfDocument doc = Document.Load<PdfDocument>(@"D:\annotations.pdf"))
{
    foreach (PdfAnnotation annotation in doc.Pages[0].Annotations)
    {
        if (annotation.Text.Contains("Test"))
        {
            annotation.FormattedTextFragments.Clear();
            annotation.FormattedTextFragments.Add("Passed", new Font("Calibri", 19, FontStyle.Bold), Color.Red, Color.Aqua);
        }
    }
    doc.Save(@"D:\output.pdf");
}
```

Replace XObject image.

**C#**

```csharp
using (PdfDocument doc = Document.Load<PdfDocument>(@"D:\xobjects.pdf"))
{
    foreach (PdfXObject xObject in doc.Pages[0].XObjects)
    {
        if (xObject.Image != null)
        {
            xObject.Image = new PdfWatermarkableImage(File.ReadAllBytes(@"D:\test.png"));
        }
    }
    doc.Save(@"D:\output.pdf");
}
```

Replace Artifact image.

**C#**

```csharp
using (PdfDocument doc = Document.Load<PdfDocument>(@"D:\artifacts.pdf"))
{
    foreach (PdfArtifact artifact in doc.Pages[0].Artifacts)
    {
        if (artifact.Image != null)
        {
            artifact.Image = new PdfWatermarkableImage(File.ReadAllBytes(@"D:\test.png"));
        }
    }
    doc.Save(@"D:\output.pdf");
}
```

Replace Annotation image.

**C#**

```csharp
using (PdfDocument doc = Document.Load<PdfDocument>(@"D:\annotations.pdf"))
{
    foreach (PdfAnnotation annotation in doc.Pages[0].Annotations)
    {
        if (annotation.Image != null)
        {
            annotation.Image = new PdfWatermarkableImage(File.ReadAllBytes(@"D:\test.png"));
        }
    }
    doc.Save(@"D:\output.pdf");
}
```

### Edit text and image in found possible watermarks (across all formats)

##### Description

This feature allows a user to edit image and text in found possible watermarks.

##### Public API changes

*FormattedTextFragmentCollection* and *FormattedTextFragmentMutableCollection* classes have been merged into one class called *FormattedTextFragmentCollection*.  
Setter has been added to *PossibleWatermark.Text* property.  
Setter has been added to *PossibleWatermark.ImageData* property.

##### Usage

Replace text of found possible watermarks.

**C#**

```csharp
using (Document doc = Document.Load(@"D:\input.pptx"))
{
    TextSearchCriteria searchCriteria = new TextSearchCriteria("test", false);
    PossibleWatermarkCollection watermarks = doc.FindWatermarks(searchCriteria);
    foreach (PossibleWatermark watermark in watermarks)
    {
        try
        {
            watermark.Text = "passed";
        }
        catch (Exception e)
        {
            // Found entity may not support text editing
            // Passed argument can have inappropriate value
            // Process such cases here
        }
    }

    doc.Save(@"D:\output.pptx");
}
```

Replace text with formatting.

**C#**

```csharp
using (Document doc = Document.Load(@"D:\input.docx"))
{
    TextSearchCriteria searchCriteria = new TextSearchCriteria("test", false);
    PossibleWatermarkCollection watermarks = doc.FindWatermarks(searchCriteria);
    foreach (PossibleWatermark watermark in watermarks)
    {
        try
        {
            watermark.FormattedTextFragments.Clear();
            watermark.FormattedTextFragments.Add("passed", new Font("Calibri", 19, FontStyle.Bold), Color.Red, Color.Aqua);
        }
        catch (Exception e)
        {
            // Found entity may not support text editing
            // Passed arguments can have inappropriate value
            // Process such cases here
        }
    }

    doc.Save(@"D:\output.docx");
}
```

Replace images of found possible watermarks.

**C#**

```csharp
byte[] imageData = File.ReadAllBytes(@"D:\new_logo.png");

using (Document doc = Document.Load(@"D:\input.pdf"))
{
    SearchCriteria searchCriteria = new ImageDctHashSearchCriteria(@"D:\logo.bmp");
    PossibleWatermarkCollection watermarks = doc.FindWatermarks(searchCriteria);
    foreach (PossibleWatermark watermark in watermarks)
    {
        try
        {
            watermark.ImageData = imageData;
        }
        catch (Exception e)
        {
            // Found entity may not support image replacing
            // Passed image can have inappropriate format
            // Process such cases here
        }
    }

    doc.Save(@"D:\output.pdf");
}
```
