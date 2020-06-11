---
id: groupdocs-watermark-for-net-17-8-0-release-notes
url: watermark/net/groupdocs-watermark-for-net-17-8-0-release-notes
title: GroupDocs.Watermark for .NET 17.8.0 Release Notes
weight: 5
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Watermark for .NET 17.8.0.{{< /alert >}}

## Major Features

There are the following features and enhancements in this release:

*   Ability to specify which objects should be included in watermark search
*   Ability to specify Dynabic.Metered account to run GroupDocs.Watermark in licensed mode

## Full List of Issues Covering all Changes in this Release

| Key  | Summary | Category |
| --- | --- | --- |
| WATERMARKNET-516 | Implement settings allowing user to specify which objects should be included in watermark search  | New Feature  |
| WATERMARKNET-611 | Intergrate metered licensing API to GroupDocs.Watermark | New Feature  |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Watermark for .NET 17.8.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Watermarkwhich may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Settings to specify which objects should be included in watermark search

##### Description

This feature allows the user to specify which objects should be included in watermark search. Restricting searchable objects, the user can significantly increase search performance.

##### Public API changes

*SearchableObjects* class has been added to *GroupDocs.Watermark.Search* namespace.  
*CellsSearchableObjects* enum has been added to *GroupDocs.Watermark.Search* namespace.  
*DiagramSearchableObjects* enum has been added to *GroupDocs.Watermark.Search* namespace.  
*SlidesSearchableObjects* enum has been added to *GroupDocs.Watermark.Search* namespace.  
*WordsSearchableObjects* enum has been added to *GroupDocs.Watermark.Search* namespace.  
*PdfSearchableObjects* enum has been added to *GroupDocs.Watermark.Search* namespace.  
*DefaultSearchableObjects* static property has been added to *Document* class.  
*SearchableObjects* property has been added to *Document* class.

##### Usage

Set searchable objects globally (for all documents that will be created after that)

**C#**

```csharp
Document.DefaultSearchableObjects = new SearchableObjects
{
	WordsSearchableObjects = WordsSearchableObjects.Hyperlinks | WordsSearchableObjects.Text,
	CellsSearchableObjects = CellsSearchableObjects.HeadersFooters,
	SlidesSearchableObjects = SlidesSearchableObjects.SlidesBackgrounds | SlidesSearchableObjects.Shapes,
	DiagramSearchableObjects = DiagramSearchableObjects.None,
	PdfSearchableObjects = PdfSearchableObjects.All
};

foreach (var file in Directory.GetFiles(@"D:\files"))
{
	using (var doc = Document.Load(file))
	{
		var watermarks = doc.FindWatermarks();

		// The code for working with found watermarks goes here.
	}
}
```

{{< alert style="warning" >}}This setting should be configured before document instance creation. It has no effect on already created instances.{{< /alert >}}{{< alert style="warning" >}}This property also specifies document objects that are analyzed during image search (performed by FindImages method).{{< /alert >}}

Set searchable objects for a particular document instance

**C#**

```csharp
using (var doc = Document.Load(@"D:\test.pdf"))
{
	// Search for hyperlinks only.
	doc.SearchableObjects.PdfSearchableObjects = PdfSearchableObjects.Hyperlinks;
	var watermarks = doc.FindWatermarks();

	// The code for working with found watermarks goes here.
}
```

### Integrate metered licensing API to GroupDocs.Watermark

##### Description

This feature allows the user to specify Dynabic.Metered account to run GroupDocs.Watermark in licensed mode.

##### Public API changes

*Metered* class has been added to *GroupDocs.Watermark* namespace.

##### Usage

This example demonstrates how to use the library in licensed mode using Dynabic.Metered account:

**C#**

```csharp
string publicKey = "[Your Dynabic.Metered public key]";
string privateKey = "[Your Dynabic.Metered private key]";

Metered metered = new Metered();
metered.SetMeteredKey(publicKey, privateKey);

// Use the library in licensed mode
```
