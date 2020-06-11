---
id: groupdocs-watermark-for-net-17-7-0-release-notes
url: watermark/net/groupdocs-watermark-for-net-17-7-0-release-notes
title: GroupDocs.Watermark for .NET 17.7.0 Release Notes
weight: 6
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Watermark for .NET 17.7.0.{{< /alert >}}

## Major Features

There are following features in this first release:

*   Ability to search watermarks by text formatting (font, color etc)
*   Ability to work with hyperlinks associated with document entities (all formats)

## Full List of Issues Covering all Changes in this Release

| Key  | Summary | Category |
| --- | --- | --- |
| WATERMARKNET-460 | Implement ability to search watermarks by text formatting (font, color etc)  | New Feature |
| WATERMARKNET-504  | Implement ability to work with hyperlinks associated with document entities (all formats)  | New Feature  |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Watermark for .NET 17.7.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Watermark which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Ability to search watermarks by text formatting (font, color etc)

##### Description

This feature allows user to search watermarks by text formatting.

##### Public API changes

*FormattedTextFragment* class has been added to *GroupDocs.Watermark* namespace.  
*FormattedTextFragmentCollection* class has been added to *GroupDocs.Watermark* namespace.  
*TextFormattingSearchCriteria* class has been added to *GroupDocs.Watermark.Search* namespace.  
*ColorRange* class has been added to *GroupDocs.Watermark.Search* namespace.  
*FormattedTextFragments* property has been added to *PossibleWatermark* class.  
*FormattedTextFragments* property has been added to *CellsShape* class.  
*FormattedTextFragments* property has been added to *DiagramShape* class.  
*FormattedTextFragments* property has been added to *SlidesShape* class.  
*FormattedTextFragments* property has been added to *WordsShape* class.  
*FormattedTextFragments* property has been added to *PdfAnnotation* class.  
*FormattedTextFragments* property has been added to *PdfArtifact* class.  
*FormattedTextFragments* property has been added to *PdfXObject* class.

##### Usage

Remove possible watermarks with a particular text formatting (regardless of document type)

**C#**

```csharp
using (Document doc = Document.Load(@"D:\test.doc"))
{
	TextFormattingSearchCriteria criteria = new TextFormattingSearchCriteria();
	criteria.ForegroundColorRange = new ColorRange();
	criteria.ForegroundColorRange.MinHue = -5;
	criteria.ForegroundColorRange.MaxHue = 10;
	criteria.ForegroundColorRange.MinBrightness = 0.01f;
	criteria.ForegroundColorRange.MaxBrightness = 0.99f;
	criteria.BackgroundColorRange = new ColorRange();
	criteria.BackgroundColorRange.IsEmpty = true;
	criteria.FontName = "Arial";
	criteria.MinFontSize = 19;
	criteria.MaxFontSize = 42;
	criteria.FontBold = true;

	PossibleWatermarkCollection watermarks = doc.FindWatermarks(criteria);
	watermarks.Clear();
	doc.Save();
}
```

Remove all text shapes with a particular text formatting from a Word document

**C#**

```csharp
 using (WordsDocument doc = Document.Load<WordsDocument>(@"D:\doc.docx"))
{
	foreach (WordsSection section in doc.Sections)
	{
		for (var i = section.Shapes.Count - 1; i >= 0; i--)
		{
			foreach (var fragment in section.Shapes[i].FormattedTextFragments)
			{
				if (fragment.ForegroundColor == Color.Red && fragment.Font.FamilyName == "Arial")
				{
					section.Shapes.RemoveAt(i);
					break;
				}
			}
		}
	}
	doc.Save();
}
```

Remove all text shapes with a particular text formatting from an Excel document

**C#**

```csharp
 using (CellsDocument doc = Document.Load<CellsDocument>(@"D:\doc.xlsx"))
{
	foreach (CellsWorksheet section in doc.Worksheets)
	{
		for (var i = section.Shapes.Count - 1; i >= 0; i--)
		{
			foreach (var fragment in section.Shapes[i].FormattedTextFragments)
			{
				if (fragment.ForegroundColor == Color.Red && fragment.Font.FamilyName == "Arial")
				{
					section.Shapes.RemoveAt(i);
					break;
				}
			}
		}
	}
	doc.Save();
}
```

Remove all text shapes with a particular text formatting from a PowerPoint document

**C#**

```csharp
 using (SlidesDocument doc = Document.Load<SlidesDocument>(@"D:\doc.pptx"))
{
	foreach (SlidesSlide slide in doc.Slides)
	{
		for (var i = slide.Shapes.Count - 1; i >= 0; i--)
		{
			foreach (var fragment in slide.Shapes[i].FormattedTextFragments)
			{
				if (fragment.ForegroundColor == Color.Red && fragment.Font.FamilyName == "Arial")
				{
					slide.Shapes.RemoveAt(i);
					break;
				}
			}
		}
	}
	doc.Save();
}
```

Remove all text shapes with a particular text formatting from a Visio document

**C#**

```csharp
 using (DiagramDocument doc = Document.Load<DiagramDocument>(@"D:\doc.vsdx"))
{
	foreach (DiagramPage page in doc.Pages)
	{
		for (var i = page.Shapes.Count - 1; i >= 0; i--)
		{
			foreach (var fragment in page.Shapes[i].FormattedTextFragments)
			{
				if (fragment.ForegroundColor == Color.Red && fragment.Font.FamilyName == "Arial")
				{
					page.Shapes.RemoveAt(i);
					break;
				}
			}
		}
	}
	doc.Save();
}
```

Remove all XObjects containing text with a particular formatting from a pdf document

**C#**

```csharp
 using (PdfDocument doc = Document.Load<PdfDocument>(@"D:\doc.pdf"))
{
	foreach (PdfPage page in doc.Pages)
	{
		for (var i = page.XObjects.Count - 1; i >= 0; i--)
		{
			foreach (var fragment in page.XObjects[i].FormattedTextFragments)
			{
				if (fragment.ForegroundColor == Color.Red)
				{
					page.XObjects.RemoveAt(i);
					break;
				}
			}
		}
	}
	doc.Save();
}
```

Remove all artifacts containing text with a particular formatting from a pdf document

**C#**

```csharp
 using (PdfDocument doc = Document.Load<PdfDocument>(@"D:\doc.pdf"))
{
	foreach (PdfPage page in doc.Pages)
	{
		for (var i = page.Artifacts.Count - 1; i >= 0; i--)
		{
			foreach (var fragment in page.Artifacts[i].FormattedTextFragments)
			{
				if (fragment.Font.Size > 42)
				{
					page.Artifacts.RemoveAt(i);
					break;
				}
			}
		}
	}
	doc.Save();
}
```

Remove all annotations containing text with a particular formatting from a pdf document

**C#**

```csharp
 using (PdfDocument doc = Document.Load<PdfDocument>(@"D:\doc.pdf"))
{
	foreach (PdfPage page in doc.Pages)
	{
		for (var i = page.Annotations.Count - 1; i >= 0; i--)
		{
			foreach (var fragment in page.Annotations[i].FormattedTextFragments)
			{
				if (fragment.Font.FamilyName == "Verdana")
				{
					page.Annotations.RemoveAt(i);
					break;
				}
			}
		}
	}
	doc.Save();
}
```

### Ability to work with hyperlinks associated with document entities (all formats)

##### Description

This feature allows the user to search and remove hyperlinks in a document of any supported format.

##### Public API changes

*HyperlinkPossibleWatermark* class has been added to *GroupDocs.Watermark* namespace.  
*DiagramHyperlink* class has been added to *GroupDocs.Watermark.Office.Diagram* namespace.  
*DiagramHyperlinkCollection* class has been added to *GroupDocs.Watermark.Office.Diagram* namespace.  
*Hyperlink* property has been added to *CellsShape* class.  
*Hyperlink* property has been added to *CellsChart* class.  
*Hyperlinks* property has been added to *DiagramShape* class.  
*Hyperlink* property has been added to *SlidesBaseShape* class.  
*Hyperlink* property has been added to *WordsShape* class.

##### Usage

Remove hyperlinks with a particular url form a document of any supported type.

**C#**

```csharp
 using (Document doc = Document.Load(@"D:\doc.doc"))
{
	PossibleWatermarkCollection watermarks = doc.FindWatermarks(new TextSearchCriteria(new Regex(@"someurl\.com")));
	for (int i = watermarks.Count - 1; i >= 0; i--)
	{
		// Ensure that only hyperlinks will be removed.
		if (watermarks[i] is HyperlinkPossibleWatermark)
		{
			// Output the full url of the hyperlink
			Console.WriteLine(watermarks[i].Text);

			// Remove hyperlink from the document
			watermarks.RemoveAt(i);
		}
	}
	doc.Save();
}
```

In some cases user may want to remove hyperlink associated with a particular entity in a document structure.

Remove/replace hyperlink associated with a particular shape or chart inside a PowerPoint document.

**C#**

```csharp
using (SlidesDocument doc = Document.Load<SlidesDocument>(@"D:\test.pptx"))
{
	// Replace hyperlink
	doc.Slides[0].Charts[0].Hyperlink = "https://www.aspose.com/";
	doc.Slides[0].Shapes[0].Hyperlink = "https://www.groupdocs.com/";

	// Remove hyperlink
	doc.Slides[1].Charts[0].Hyperlink = null;
	doc.Slides[1].Shapes[0].Hyperlink = null;

	doc.Save();
} 
```

Remove/replace hyperlink associated with a particular shape or chart inside an Excel document.

**C#**

```csharp
 using (CellsDocument doc = Document.Load<CellsDocument>(@"D:\test.xlsx"))
{
	// Replace hyperlink
	doc.Worksheets[0].Charts[0].Hyperlink = "https://www.aspose.com/";
	doc.Worksheets[0].Shapes[0].Hyperlink = "https://www.groupdocs.com/";

	// Remove hyperlink
	doc.Worksheets[1].Charts[0].Hyperlink = null;
	doc.Worksheets[1].Shapes[0].Hyperlink = null;

	doc.Save();
}
```

Remove/replace hyperlink associated with a particular shape inside a Word document.

**C#**

```csharp
using (WordsDocument doc = Document.Load<WordsDocument>(@"D:\test.docx"))
{
	// Replace hyperlink
	doc.Sections[0].Shapes[0].Hyperlink = "https://www.groupdocs.com/";

	// Remove hyperlink
	doc.Sections[0].Shapes[1].Hyperlink = null;

	doc.Save();
}
```

Remove hyperlinks associated with a particular shape inside a Visio document.

**C#**

```csharp
using (DiagramDocument doc = Document.Load<DiagramDocument>(@"D:\test.vsdx"))
{
	DiagramShape shape = doc.Pages[0].Shapes[0];
	for (int i = shape.Hyperlinks.Count - 1; i >= 0; i--)
	{
		if (shape.Hyperlinks[i].Address.Contains("http://someurl.com"))
		{
			shape.Hyperlinks.RemoveAt(i);
		}
	}

	doc.Save();
}
```
