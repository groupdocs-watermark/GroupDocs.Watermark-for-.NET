---
id: groupdocs-watermark-for-net-18-2-release-notes
url: watermark/net/groupdocs-watermark-for-net-18-2-release-notes
title: GroupDocs.Watermark for .NET 18.2 Release Notes
weight: 4
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Watermark for .NET 18.2.{{< /alert >}}

## Major Features

There is the following new feature in this monthly release:

*   Implement ability to edit Word document objects that can be considered as watermarks

## Full List of Issues Covering all Changes in this Release

| Key  | Summary | Category |
| --- | --- | --- |
| WATERMARKNET-787 | Implement ability to edit Word document objects that can be considered as watermarks  | New Feature  |
| WATERMARKNET-668  | Remove SlidesBaseShape.Hyperlink property (obsolete code)  | Enhancement |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Watermark for .NET 18.2. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Watermark which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Edit Word document objects that can be considered as watermarks

##### Description

This feature allows a user to edit existing shapes in a Word document.

##### Public API changes

*WordsFormattedTextFragmentCollection* class is now inherited from *ShapeFormattedTextFragmentMutableCollection*.  
Return type of *WordsShape.FormattedTextFragments* property has been changed to *FormattedTextFragmentMutableCollection*.  
Return type of *WordsShape.Image* property has been changed to *WordsWatermarkableImage*.  
*WordsShapeFormattedTextFragmentCollection* class has been added to *GroupDocs.Watermark.Office.Words* namespace  
*WordsTextFormattedTextFragment* class has been added to *GroupDocs.Watermark.Office.Words* namespace  
*WordsWordArtShapeFormattedTextFragment* class has been added to *GroupDocs.Watermark.Office.Words* namespace  
*WordsWordArtShapeFormattedTextFragmentCollection* class has been added to *GroupDocs.Watermark.Office.Words* namespace  
Setter has been added to *WordsShape.Text* property.  
Setter has been added to *WordsShape.Image* property.  
Setter has been added to *WordsShape.AlternativeText* property.  
Setter has been added to *WordsShape.X* property.  
Setter has been added to *WordsShape.Y* property.  
Setter has been added to *WordsShape.Width* property.  
Setter has been added to *WordsShape.Height* property.  
Setter has been added to *WordsShape.RotateAngle* property.  
*BehindText* property has been added to *WordsShape* class.

##### Usage

Replace text for particular shapes

**C#**

```csharp
using (WordsDocument doc = Document.Load<WordsDocument>(@"D:\input.docx"))
{
    foreach (WordsShape shape in doc.Sections[0].Shapes)
    {
        if (shape.Text.Contains("Some text"))
        {
            shape.Text = "Another text";
        }
    }
    doc.Save(@"D:\output.docx");
}
```

Replace text with formatting

**C#**

```csharp
using (WordsDocument doc = Document.Load<WordsDocument>(@"D:\input.docx"))
{
    foreach (WordsShape shape in doc.Sections[0].Shapes)
    {
        if (shape.Text.Contains("Some text"))
        {
            shape.FormattedTextFragments.Clear();
            shape.FormattedTextFragments.Add("Another text", new Font("Calibri", 19, FontStyle.Bold), Color.Red, Color.Aqua);
        }
    }
    doc.Save(@"D:\output.docx");
}
```

Replace shape image

**C#**

```csharp
using (WordsDocument doc = Document.Load<WordsDocument>(@"D:\input.doc"))
{
    foreach (WordsShape shape in doc.Sections[0].Shapes)
    {
        if (shape.Image != null)
        {
            shape.Image = new WordsWatermarkableImage(File.ReadAllBytes(@"D:\test.png"));
        }
    }
    doc.Save(@"D:\output.doc");
}
```

Modify shape properties

**C#**

```csharp
using (WordsDocument doc = Document.Load<WordsDocument>(@"D:\input.docx"))
{
    foreach (WordsShape shape in doc.Sections[0].Shapes)
    {
        if (shape.Text.Contains("Some text"))
        {
            shape.AlternativeText = "watermark";
            shape.RotateAngle = 30;
            shape.X = 200;
            shape.Y = 200;
            shape.Height = 100;
            shape.Width = 400;
            shape.BehindText = false;
        }
    }
    doc.Save(@"D:\output.docx");
}
```

### Remove SlidesBaseShape.Hyperlink property (obsolete code)

##### Description

Obsolete *SlidesBaseShape.Hyperlink* property has been removed from public API.

##### Public API changes

*Hyperlink* property has been removed from *SlidesBaseShape* class.

##### Usage

Use *GetHyperlink* and *SetHyperlink* methods of SlidesBaseShape class instead.

**C#**

```csharp
using (SlidesDocument doc = Document.Load<SlidesDocument>(@"D:\input.pptx"))
{
    Console.WriteLine(doc.Slides[0].Shapes[0].GetHyperlink(SlidesHyperlinkActionType.MouseClick));
    Console.WriteLine(doc.Slides[0].Charts[0].GetHyperlink(SlidesHyperlinkActionType.MouseOver));

    doc.Slides[0].Shapes[0].SetHyperlink(SlidesHyperlinkActionType.MouseClick, "http://aspose.com");
    doc.Slides[0].Charts[0].SetHyperlink(SlidesHyperlinkActionType.MouseOver, "http://aspose.com");

    doc.Save(@"D:\output.pptx");
}
```
