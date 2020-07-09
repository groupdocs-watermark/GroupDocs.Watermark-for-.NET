---
id: groupdocs-watermark-for-net-18-8-release-notes
url: watermark/net/groupdocs-watermark-for-net-18-8-release-notes
title: GroupDocs.Watermark for .NET 18.8 Release Notes
weight: 1
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Watermark for .NET 18.8.{{< /alert >}}

## Major Features

There are the following features, enhancements, and bug fixes in this release:

*   Ability to skip unreadable characters during text watermark search
*   Protection of text watermark using unreadable characters for Slides
*   SmartArt and CustomXml drawing types for Worksheets
*   Fix locking watermark in PPTX, PPT

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| WATERMARKNET-895 | Locking watermark in PPTX, PPT is not working | Bug |
| WATERMARKNET-981 | Add SmartArt and CustomXml drawing types | Enhancement |
| WATERMARKNET-998 | Implement ability to skip unreadable characters during text watermark search | New Feature |
| WATERMARKNET-999 | Implement protection of text watermark using unreadable characters for Slides | New Feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Watermark for .NET 18.8. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Watermark which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Added SmartArt and CustomXml drawing types

##### Description

This enhancement adds two new supported drawing types to **CellsMsoDrawingType** enum: **SmartArt** and **CustomXml**.

##### Public API changes

*SmartArt* value has been added to *CellsMsoDrawingType* enum.  
*CustomXml* value has been added to *CellsMsoDrawingType* enum.

##### Usage

Remove shapes of *SmartArt and* *CustomXml type from document worksheet:*

**C#**

```csharp
string inputFileName = @"G:\Input.xlsx";
string outputFileName = @"G:\Output.xlsx";
  
using (CellsDocument document = Document.Load<CellsDocument>(inputFileName))
{
    var shapes = document.Worksheets[0].Shapes;
    for (int i = shapes.Count - 1; i >= 0; i--)
    {
        CellsShape shape = shapes[i];
        if (shape.MsoDrawingType == CellsMsoDrawingType.SmartArt ||
            shape.MsoDrawingType == CellsMsoDrawingType.CustomXml)
        {
            shapes.RemoveAt(i);
        }
    }
    document.Save(outputFileName);
}
```

### Ability to skip unreadable characters during text watermark search

##### Description

This feature allows finding text watermark even if it contains unreadable characters between letters.

##### Public API changes

*SkipUnreadableCharacters* property has been added to *GroupDocs.Watermark.Search.TextSearchCriteria* class.

##### Usage

Search for text watermarks with skipping unreadable characters:

**C#**

```csharp
string inputFileName = @"d:\input.pptx";
 
using (SlidesDocument document = Document.Load<SlidesDocument>(inputFileName))
{
    string watermarkText = "Company name";
    TextSearchCriteria criterion = new TextSearchCriteria(watermarkText);
 
    // Enabling skipping of unreadable characters
    criterion.SkipUnreadableCharacters = true;
 
    PossibleWatermarkCollection result = document.FindWatermarks(criterion);
}
```

### Protection of text watermark using unreadable characters for Slides

##### Description

This feature allows strengthening protection of text watermark in case of modifying with Find and Replace dialog.

##### Public API changes

*ProtectWithUnreadableCharacters* property has been added to *GroupDocs.Watermark.Office.Slides.SlidesShapeSettings* class.

##### Usage

Protect text watermark with unreadable characters:

**C#**

```csharp
string inputFileName = @"d:\input.pptx";
string outputFileName = @"d:\output.pptx";
 
using (SlidesDocument document = Document.Load<SlidesDocument>(inputFileName))
{
    TextWatermark watermark = new TextWatermark("Watermark text", new Font("Arial", 19));
 
    SlidesShapeSettings settings = new SlidesShapeSettings();
    settings.IsLocked = true;
    settings.ProtectWithUnreadableCharacters = true;
 
    document.AddWatermark(watermark, settings);
 
    document.Save(outputFileName);
}
```
