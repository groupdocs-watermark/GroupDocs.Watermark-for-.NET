---
id: groupdocs-watermark-for-net-18-1-release-notes
url: watermark/net/groupdocs-watermark-for-net-18-1-release-notes
title: GroupDocs.Watermark for .NET 18.1 Release Notes
weight: 5
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Watermark for .NET 18.1.{{< /alert >}}

## Major Features

There are the following features and enhancements in this release:

*   Ability to edit PowerPoint document objects that can be considered as watermark
*   Ability to edit Visio document objects that can be considered as watermark

## Full List of Issues Covering all Changes in this Release

| Key  | Summary | Category |
| --- | --- | --- |
| WATERMARKNET-713 | Implement ability to edit PowerPoint document objects that can be considered as watermarks  | New Feature  |
| WATERMARKNET-714  | Implement ability to edit Visio document objects that can be considered as watermarks  | New Feature  |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Watermark for .NET 18.1. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Watermark which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Edit PowerPoint document objects that can be considered as watermark

##### Description

This feature allows a user to edit existing shapes in a PowerPoint document.

##### Public API changes

*SlidesShapeFormattedTextFragmentCollection* class is now inherited from *ShapeFormattedTextFragmentMutableCollection*.  
Return type of *SlidesShape.FormattedTextFragments* property has been changed to *FormattedTextFragmentMutableCollection*.  
The return type of *SlidesShape.Image* property has been changed to *SlidesWatermarkableImage*.  
*ImageFillFormat* property has been moved from *SlidesChart* class to *SlidesBaseShape* class.  
Setter has been added to *SlidesShape.Text* property.  
Setter has been added to *SlidesShape.Image* property.  
Setter has been added to *SlidesBaseShape.AlternativeText* property.  
Setter has been added to *SlidesBaseShape.X* property.  
Setter has been added to *SlidesBaseShape.Y* property.  
Setter has been added to *SlidesBaseShape.Width* property.  
Setter has been added to *SlidesBaseShape.Height* property.  
Setter has been added to *SlidesBaseShape.RotateAngle* property.

##### Usage

Replace text for particular shapes

**C#**

```csharp
using (SlidesDocument doc = Document.Load<SlidesDocument>(@"D:\input.pptx"))
{
	foreach (SlidesShape shape in doc.Slides[0].Shapes)
	{
		if (shape.Text == "© Aspose 2016")
		{
			shape.Text = "© GroupDocs 2017";
		}
	}
	doc.Save(@"D:\output.pptx");
}
```

Replace text with formatting

**C#**

```csharp
 using (SlidesDocument doc = Document.Load<SlidesDocument>(@"D:\input.ppt"))
{
	foreach (SlidesShape shape in doc.Slides[0].Shapes)
	{
		if (shape.Text == "© Aspose 2016")
		{
			shape.FormattedTextFragments.Clear();
			shape.FormattedTextFragments.Add("© GroupDocs 2017", new Font("Calibri", 19, FontStyle.Bold), Color.Red, Color.Aqua);
		}
	}
	doc.Save(@"D:\output.ppt");
}
```

Replace shape image

**C#**

```csharp
 using (SlidesDocument doc = Document.Load<SlidesDocument>(@"D:\input.pptx"))
{
	foreach (SlidesShape shape in doc.Slides[0].Shapes)
	{
		if (shape.Image != null)
		{
			shape.Image = new SlidesWatermarkableImage(File.ReadAllBytes(@"D:\test.png"));
		}
	}
	doc.Save(@"D:\output.pptx");
}
```

Set background image for particular shapes

**C#**

```csharp
  using (SlidesDocument doc = Document.Load<SlidesDocument>(@"D:\input.ppt"))
{
	foreach (SlidesShape shape in doc.Slides[0].Shapes)
	{
		if (shape.Text == "© Aspose 2016")
		{
			shape.ImageFillFormat.BackgroundImage = new SlidesWatermarkableImage(File.ReadAllBytes(@"D:\test.png"));
			shape.ImageFillFormat.Transparency = 0.5;
			shape.ImageFillFormat.TileAsTexture = true;
		}
	}
	doc.Save(@"D:\output.ppt");
}
```

Modify other shape properties

**C#**

```csharp
using (SlidesDocument doc = Document.Load<SlidesDocument>(@"D:\input.pptx"))
{
	foreach (SlidesShape shape in doc.Slides[0].Shapes)
	{
		if (shape.Text == "© Aspose 2016")
		{
			shape.AlternativeText = "watermark";
			shape.RotateAngle = 30;
			shape.X = 200;
			shape.Y = 200;
			shape.Width = 400;
			shape.Height = 100;
		}
	}
	doc.Save(@"D:\output.pptx");
}
```

### Edit Visio document objects that can be considered as watermark

##### Description

This feature allows a user to edit existing shapes in a Visio document.

##### Public API changes

*DiagramFormattedTextFragmentCollection* class is now inherited from *ShapeFormattedTextFragmentMutableCollection*.  
Return type of *DiagramShape.FormattedTextFragments* property has been changed to *FormattedTextFragmentMutableCollection*.  
The return type of *DiagramShape.Image* property has been changed to *DiagramWatermarkableImage*.  
Setter has been added to *DiagramShape.Text* property.  
Setter has been added to *DiagramShape.Image* property.

##### Usage

Replace text for particular shapes

**C#**

```csharp
 using (DiagramDocument doc = Document.Load<DiagramDocument>(@"D:\input.vdx"))
{
	foreach (DiagramShape shape in doc.Pages[0].Shapes)
	{
		if (shape.Text != null && shape.Text.Contains("© Aspose 2016"))
		{
			shape.Text = "© GroupDocs 2017";
		}
	}
	doc.Save(@"D:\output.vdx");
}
```

Replace text with formatting

**C#**

```csharp
using (DiagramDocument doc = Document.Load<DiagramDocument>(@"D:\input.vsdx"))
{
	foreach (DiagramShape shape in doc.Pages[0].Shapes)
	{
		if (shape.Text != null && shape.Text.Contains("© Aspose 2016"))
		{
			shape.FormattedTextFragments.Clear();
			shape.FormattedTextFragments.Add("© GroupDocs 2017", new Font("Calibri", 19, FontStyle.Bold), Color.Red, Color.Aqua);
		}
	}
	doc.Save(@"D:\output.vsdx");
}
```

Replace shape image

**C#**

```csharp
using (DiagramDocument doc = Document.Load<DiagramDocument>(@"D:\input.vdx"))
{
	foreach (DiagramShape shape in doc.Pages[0].Shapes)
	{
		if (shape.Image != null)
		{
			shape.Image = new DiagramWatermarkableImage(File.ReadAllBytes(@"D:\test.png"));
		}
	}
	doc.Save(@"D:\output.vdx");
}
```
