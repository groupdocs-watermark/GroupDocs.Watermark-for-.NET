---
id: groupdocs-watermark-for-net-17-9-0-release-notes
url: watermark/net/groupdocs-watermark-for-net-17-9-0-release-notes
title: GroupDocs.Watermark for .NET 17.9.0 Release Notes
weight: 4
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Watermark for .NET 17.9.0.{{< /alert >}}

## Major Features

There are the following features and enhancements in this release:

*   Ability to work with hyperlinks that are activated on mouse over (PowerPoint)
*   Ability to work with ODT files

## Full List of Issues Covering all Changes in this Release

| Key  | Summary | Category |
| --- | --- | --- |
| WATERMARKNET-582 | Implement ability to work with hyperlinks that are activated on mouse over (PowerPoint)  | New Feature  |
| WATERMARKNET-609  | Add support of ODT format  | New Feature  |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Watermark for .NET 17.9.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Watermarkwhich may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Ability to work with hyperlinks that are activated on mouse over (PowerPoint)

This feature allows user to replace/remove hyperlinks that are activated on mouse over (in PowerPoint presentations).

**Replace hyperlinks in a PowerPoint document**

**C#**

```csharp
static void Main(string[] args)
{
        // Set license
	License license = new License();
	license.SetLicense(@"D:\GroupDocs.Watermark.lic");

	using (var doc = Document.Load<SlidesDocument>(@"D:\test.pptx"))
	{
		foreach (var slide in doc.Slides)
		{
			string oldUrl = "http://aspose.com/";

			// Assign null to remove hyperlink
			string newUrl = "http://groupdocs.com/";

			// Replace hyperlinks in shapes
			foreach (var shape in slide.Shapes)
			{
				ReplaceHyperlink(shape, SlidesHyperlinkActionType.MouseOver, oldUrl, newUrl);
				ReplaceHyperlink(shape, SlidesHyperlinkActionType.MouseClick, oldUrl, newUrl);

				// Replace hyperlinks in text fragments
				foreach (var fragment in shape.FormattedTextFragments)
				{
					ReplaceHyperlink((ISlidesHyperlinkContainer)fragment, SlidesHyperlinkActionType.MouseClick, oldUrl, newUrl);
					ReplaceHyperlink((ISlidesHyperlinkContainer)fragment, SlidesHyperlinkActionType.MouseOver, oldUrl, newUrl);
				}
			}

			// Replace hyperlinks in charts
			foreach (var chart in slide.Charts)
			{
				ReplaceHyperlink(chart, SlidesHyperlinkActionType.MouseOver, oldUrl, newUrl);
				ReplaceHyperlink(chart, SlidesHyperlinkActionType.MouseClick, oldUrl, newUrl);
			}
		}

		// Save changes
		doc.Save();
	}
}

private static void ReplaceHyperlink(ISlidesHyperlinkContainer hyperlinkContainer, SlidesHyperlinkActionType hyperlinkActionType, string oldUrl, string newUrl)
{
	if (hyperlinkContainer.GetHyperlink(hyperlinkActionType) == oldUrl)
	{
		hyperlinkContainer.SetHyperlink(hyperlinkActionType, newUrl);
	}
}
```

Hyperlinks of all types can also be removed by using *FindWatermarks* method

**C#**

```csharp
using (var doc = Document.Load(@"D:\test.pptx"))
{
	doc.SearchableObjects.SlidesSearchableObjects = SlidesSearchableObjects.Hyperlinks;

	// Find all hyperlinks
	var watermarks = doc.FindWatermarks();

	// Remove found watermarks
	watermarks.Clear();

	// Save changes
	doc.Save();
}
```
