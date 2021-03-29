---
id: groupdocs-watermark-for-net-21-3-release-notes
url: watermark/net/groupdocs-watermark-for-net-21-3-release-notes
title: GroupDocs.Watermark for .NET 21.3 Release Notes
weight: 2
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: True
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Watermark for .NET 21.3{{< /alert >}}

## Major features

There are the following improvements in this release:

* Implement logging functionality
* Add custom PreviewOptions for Office document formats
* Add page info list to IDocumenInfo

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Issue Type |
| --- | --- | --- |
| WATERMARKNET-1282 | Implement logging functionality | Improvement |
| WATERMARKNET-1329 | Add custom PreviewOptions for Office document formats | Improvement |
| WATERMARKNET-1328 | Add page info list to IDocumenInfo | Improvement |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Watermark for .NET 21.3. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Watermark which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Implement logging functionality

This improvement allows you to record events that occur in GroupDocs.Watermark library.

### Public API changes

*ILogger* interface has been added to *GroupDocs.Watermark.Options* namespace.

*Logger* property has been added to *GroupDocs.Watermark.WatermarkerSettings* class.

### Add custom PreviewOptions for Office document formats

This improvement enables custom PreviewOptions to be used for each of supported Office document format.

##### Public API changes

*DiagramPreviewOptions* class had been added to *GroupDocs.Watermark.Options.Diagram* namespace.

*EmailPreviewOptions* class had been added to *GroupDocs.Watermark.Options.Email* namespace.

*PdfPreviewOptions* class had been added to *GroupDocs.Watermark.Options.Pdf* namespace.

*PresentationPreviewOptions* class had been added to *GroupDocs.Watermark.Options.Presentation* namespace.

*SpreadsheetPreviewOptions* class had been added to *GroupDocs.Watermark.Options.Spreadsheet* namespace.

*WordProcessingPreviewOptions* class had been added to *GroupDocs.Watermark.Options.WordProcessing* namespace.

### Add page info list to IDocumenInfo

This improvement allows you to get a collection of document pages descriptions.

##### Public API changes

*Pages* property has been added to *GroupDocs.Watermark.Common.IDocumentInfo* interface.

*PageInfo* class has been added to *GroupDocs.Watermark.Common* namespace.
