---
id: groupdocs-watermark-for-net-17-12-release-notes
url: watermark/net/groupdocs-watermark-for-net-17-12-release-notes
title: GroupDocs.Watermark for .NET 17.12 Release Notes
weight: 1
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Watermark for .NET 17.12.{{< /alert >}}

## Major Features

There are following features in this first release:

*   Support for EMLX and OFT email formats
*   Ability to edit Excel document objects that can be considered as watermark

## Full List of Issues Covering all Changes in this Release

| Key  | Summary | Category |
| --- | --- | --- |
| WATERMARKNET-706 | Support for EMLX and OFT email formats  | New Feature  |
| WATERMARKNET-712  | Ability to edit Excel document objects that can be considered as watermarks  | New Feature  |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Watermark for .NET 17.12. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Watermark which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Support for EMLX and OFT Email Formats

##### Description

This feature allows a user to work with email messages stored in EMLX and OFT formats.

##### Public API changes

None

##### Usage

Load an email message.

```csharp
using (EmailDocument doc = Document.Load<EmailDocument>(@"D:\test.emlx"))
{
	// ...
}
```

### Ability to Edit Excel Document Objects that can be Considered as Watermark

##### Description

This feature allows a user to edit existing shapes in an Excel document.

##### Public API changes

*FormattedTextFragmentMutableCollection* class has been added to *GroupDocs.Watermark* namespace.  
*CellsShapeFormattedTextFragmentCollection* class has been added to *GroupDocs.Watermark.Office.Cells* namespace.  
*CellsTextEffectFormattedTextFragmentCollection* class has been added to *GroupDocs.Watermark.Office.Cells* namespace.  
Return type of *CellsShape.FormattedTextFragments* property has been changed to *FormattedTextFragmentMutableCollection*.  
Return type of *CellsShape.Image* property has been changed to *CellsWatermarkableImage*.  
*ImageFillFormat* property has been added to *CellsShape* class.  
Setter has been added to *CellsShape.Text* property.  
Setter has been added to *CellsShape.Image* property.  
Setter has been added to *CellsShape.AlternativeText* property.  
Setter has been added to *CellsShape.X* property.  
Setter has been added to *CellsShape.Y* property.  
Setter has been added to *CellsShape.Width* property.  
Setter has been added to *CellsShape.Height* property.  
Setter has been added to *CellsShape.RotateAngle* property.

##### Usage

Replace text for particular shapes.

```csharp
using (CellsDocument doc = Document.Load<CellsDocument>(@"D:\input.xls"))
{
	foreach (CellsShape shape in doc.Worksheets[0].Shapes)
	{
		if (shape.Text == "© Aspose 2016")
		{
			shape.Text = "© GroupDocs 2017";
		}
	}
	doc.Save(@"D:\output.xls");
}
```

Replace text with formatting

```csharp
 using (CellsDocument doc = Document.Load<CellsDocument>(@"D:\input.xlsx"))
{
	foreach (CellsShape shape in doc.Worksheets[0].Shapes)
	{
		if (shape.Text == "© Aspose 2016")
		{
			shape.FormattedTextFragments.Clear();
			shape.FormattedTextFragments.Add("© GroupDocs 2017", new Font("Calibri", 19, FontStyle.Bold), Color.Red, Color.Aqua);
		}
	}
	doc.Save(@"D:\output.xlsx");
}
```

Replace shape image

```csharp
 using (CellsDocument doc = Document.Load<CellsDocument>(@"D:\input.xls"))
{
	foreach (CellsShape shape in doc.Worksheets[0].Shapes)
	{
		if (shape.Image != null)
		{
			shape.Image = new CellsWatermarkableImage(File.ReadAllBytes(@"D:\test.png"));
		}
	}
	doc.Save(@"D:\output.xls");
}
```

Set background image for particular shapes

```csharp
using (CellsDocument doc = Document.Load<CellsDocument>(@"D:\input.xlsx"))
{
	foreach (CellsShape shape in doc.Worksheets[0].Shapes)
	{
		if (shape.Text == "© Aspose 2016")
		{
			shape.ImageFillFormat.BackgroundImage = new CellsWatermarkableImage(File.ReadAllBytes(@"D:\test.png"));
			shape.ImageFillFormat.Transparency = 0.5;
			shape.ImageFillFormat.TileAsTexture = true;
		}
	}
	doc.Save(@"D:\output.xlsx");
}
```

Modify other shape properties

```csharp
using (CellsDocument doc = Document.Load<CellsDocument>(@"D:\input.xls"))
{
	foreach (CellsShape shape in doc.Worksheets[0].Shapes)
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
	doc.Save(@"D:\output.xls");
}
```
