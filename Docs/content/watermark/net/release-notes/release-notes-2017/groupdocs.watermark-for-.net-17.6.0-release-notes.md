---
id: groupdocs-watermark-for-net-17-6-0-release-notes
url: watermark/net/groupdocs-watermark-for-net-17-6-0-release-notes
title: GroupDocs.Watermark for .NET 17.6.0 Release Notes
weight: 7
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Watermark for .NET 17.6.0.{{< /alert >}}

## Major Features

There are following features in this first release:

*   Ability to set additional options for slide background image in PowerPoint document
*   Ability to add watermark to a particular page of a Word document
*   Ability to set background image for a chart in Excel document
*   Ability to set background image for a chart in PowerPoint document

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| WATERMARKNET-482 | Implement ability to add watermark to a particular page of a Word document | New Feature |
| WATERMARKNET-507 | Implement ability to set background image for a chart in Excel document | New Feature |
| WATERMARKNET-509 | Implement ability to set background image for a chart in PowerPoint document | New Feature |
| WATERMARKNET-540 | Implement ability to set additional options for slide background image in PowerPoint document | Enhancement |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Watermark for .NET 17.6.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Watermark which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Ability to set additional options for slide background image in PowerPoint document

This enhancement provides new functionality for slide's background image. It allows the user to tile picture across slide's background and to make the image semitransparent.

##### Public API changes

*ImageFillFormat* property has been added to *SlidesBaseSlide* class.

*SlidesBaseSlide.BackgroundImage* property has been marked as obsolete.

##### Usage

Set tiled semitransparent image background for a particular slide.

**C#**

```csharp
using (SlidesDocument doc = Document.Load<SlidesDocument>(@"D:\input.pptx"))
{
	SlidesSlide slide = doc.Slides[0];
	slide.ImageFillFormat.BackgroundImage = new SlidesWatermarkableImage(File.ReadAllBytes(@"D:\background.png"));
	slide.ImageFillFormat.TileAsTexture = true;
	slide.ImageFillFormat.Transparency = 0.5;
	doc.Save();
}
```

### Ability to add watermark to a particular page of a Word document

This feature allows the user to add watermark to a particular page of a Word document.

##### Public API changes

*PageCount* property has been added to *WordsDocument* class.  
*AddWatermark(Watermark, int)* method has been added to *WordsDocument*.

##### Usage

Add watermark to the last page of a Word document.

**C#**

```csharp
using (WordsDocument doc = Document.Load<WordsDocument>(@"D:\test.doc"))
{
	TextWatermark textWatermark = new TextWatermark("DRAFT", new Font("Arial", 42));

        // Add watermark to the last page
	doc.AddWatermark(textWatermark, doc.PageCount);
	doc.Save();
}
```

### Ability to set background image for a chart in Excel document

This feature allows the user to set the background image for a chart inside Excel document.

##### Public API changes

*Charts* property has been added to *CellsWorksheet* class.

*CellsChartCollection* class has been added to *GroupDocs.Watermark.Office.Cells* namespace.

*CellsChart* class has been added to *GroupDocs.Watermark.Office.Cells* namespace.

*CellsImageFillFormat* class has been added to *GroupDocs.Watermark.Office.Cells* namespace.

##### Usage

Set image background for a particular chart in Excel document.

**C#**

```csharp
using (CellsDocument doc = Document.Load<CellsDocument>(@"D:\test.xlsx"))
{
	doc.Worksheets[0].Charts[0].ImageFillFormat.BackgroundImage = new CellsWatermarkableImage(File.ReadAllBytes(@"D:\test.png"));
	doc.Worksheets[0].Charts[0].ImageFillFormat.Transparency = 0.5;
	doc.Worksheets[0].Charts[0].ImageFillFormat.TileAsTexture = true;
	doc.Save();
}
```

{{< alert style="warning" >}}Transparency and TileAsTexture options work only for xlsx format.{{< /alert >}}

### Ability to set background image for a chart in PowerPoint document

This feature allows the user to set the background image for a chart inside PowerPoint document.

##### Public API changes

*Charts* property has been added to *SlidesBaseSlide* class.

*SlidesChartCollection* class has been added to *GroupDocs.Watermark.Office.Slides* namespace.

*SlidesChart* class has been added to *GroupDocs.Watermark.Office.Slides* namespace.

*SlidesImageFillFormat* class has been added to *GroupDocs.Watermark.Office.Slides* namespace.

##### Usage

Set image background for a particular chart in PowerPoint document.

  

**C#**

```csharp
using (var doc = Document.Load<SlidesDocument>(@"D:\test.pptx"))
{
	doc.Slides[0].Charts[0].ImageFillFormat.BackgroundImage = new SlidesWatermarkableImage(File.ReadAllBytes(@"D:\test.png"));
	doc.Slides[0].Charts[0].ImageFillFormat.Transparency = 0.5;
	doc.Slides[0].Charts[0].ImageFillFormat.TileAsTexture = true;
	doc.Save();
}
```

{{< alert style="warning" >}}This feature works only for pptx format.{{< /alert >}}
