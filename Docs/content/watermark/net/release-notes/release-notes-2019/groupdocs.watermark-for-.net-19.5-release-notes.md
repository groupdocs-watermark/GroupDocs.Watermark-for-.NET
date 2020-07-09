---
id: groupdocs-watermark-for-net-19-5-release-notes
url: watermark/net/groupdocs-watermark-for-net-19-5-release-notes
title: GroupDocs.Watermark for .NET 19.5 Release Notes
weight: 4
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Watermark for .NET 19.5.{{< /alert >}}

## Major Features

There are the following features, enhancements, and bug fixes in this release:

*   WordsDocument.save() throws exception when setting WordsLockType.ReadOnlyWithEditableContent
*   Add new types of a shape in a Word document

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| WATERMARKNET-994 | WordsDocument.save() throws exception when setting WordsLockType.ReadOnlyWithEditableContent | Bug |
| WATERMARKNET-1024 | Add new types of a shape in a Word document | Enhancement |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Watermark for .NET 19.5. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Watermark which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### WordsDocument.Save() throws exception when setting WordsLockType.ReadOnlyWithEditableContent has been fixed

There is the exception at *WordsDocument.Save()* method when adding watermark with *WordsLockType.ReadOnlyWithEditableContent* settings. This issue has been fixed.

##### Public API changes

None.

### Add new types of a shape in a Word document

The following new elements of *GroupDocs.Watermark.Office.Words.WordsShapeType* enum have been added:

*   SingleCornerSnipped
*   TopCornersSnipped
*   DiagonalCornersSnipped
*   TopCornersOneRoundedOneSnipped
*   SingleCornerRounded
*   TopCornersRounded
*   DiagonalCornersRounded

##### Public API changes

*SingleCornerSnipped *value has been added to *GroupDocs.Watermark.Office.Words.WordsShapeType* enum.

*TopCornersSnipped *value has been added to *GroupDocs.Watermark.Office.Words.WordsShapeType* enum.

*DiagonalCornersSnipped *value has been added to *GroupDocs.Watermark.Office.Words.WordsShapeType* enum.

*TopCornersOneRoundedOneSnipped *value has been added to *GroupDocs.Watermark.Office.Words.WordsShapeType* enum.

*SingleCornerRounded *value has been added to *GroupDocs.Watermark.Office.Words.WordsShapeType* enum.

*TopCornersRounded *value has been added to *GroupDocs.Watermark.Office.Words.WordsShapeType* enum.

*DiagonalCornersRounded* value has been added to *GroupDocs.Watermark.Office.Words.WordsShapeType* enum.
