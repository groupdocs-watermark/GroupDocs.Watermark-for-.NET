---
id: groupdocs-watermark-for-net-19-11-release-notes
url: watermark/net/groupdocs-watermark-for-net-19-11-release-notes
title: GroupDocs.Watermark for .NET 19.11 Release Notes
weight: 1
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
  

{{< alert style="info" >}}This page contains release notes for GroupDocs.Watermark for .NET 19.11{{< /alert >}}

### Major Features

There are the following features, enhancements, and bug fixes in this release:

*   FindWatermarks method throws System.NullReferenceException
*   Add FormatFamily enumeration
    
*   Add Password property to the common LoadOptions
    
*   Throw FontNotFoundException when adding TextWatermark with non-existence font to PDF document
    
*   Add MultiframeImageWatermarkOptions
    

## Full List of Issues Covering all Changes in this Release 

| Key | Summary | Category |
| --- | --- | --- |
| WATERMARKNET-1143 | FindWatermarks method throws System.NullReferenceException | Bug |
| WATERMARKNET-1172 | Add FormatFamily enumeration | Improvement |
| WATERMARKNET-1170 | Add Password property to the common LoadOptions | Improvement |
| WATERMARKNET-1171 | Throw FontNotFoundException when adding TextWatermark with non-existence font to PDF document | Improvement |
| WATERMARKNET-1209 | Add MultiframeImageWatermarkOptions | Improvement |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Watermark for .NET 19.11 It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Watermark which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Added *FormatFamily* enumeration

*FormatFamily* enumeration has been added to *GroupDocs.Watermark.Common* namespace to group formats of supported documents.

##### Public API changes

*FormatFamily* enumeration has been added to *GroupDocs.Watermark.Common* namespace.

*Unknown* value has been added to *FormatFamily* enumeration.

*Diagram* value has been added to *FormatFamily* enumeration.

*Email* value has been added to *FormatFamily* enumeration.

*Image* value has been added to *FormatFamily* enumeration.

*MultiframeImage* value has been added to *FormatFamily* enumeration.

*Pdf* value has been added to *FormatFamily* enumeration.

*Presentation* value has been added to *FormatFamily* enumeration.

*Spreadsheet* value has been added to *FormatFamily* enumeration.

*WordProcessing* value has been added to *FormatFamily* enumeration.

*FormatFamily* property has been added to *GroupDocs.Watermark.Common.FileType* class.

### Added *Password* property to the common *LoadOptions*

The property Password was added to the common LoadOptions. This will simplify opening password-protected document of any supported format.

##### Public API changes

*Password* property has been added to *LoadOptions* class.

*LoadOptions(string)* constructor has been added to *LoadOptions* class.

### Added FontNotFoundException for non-existence font to PDF document

When adding TextWatermark with non-existence font to the PDF document FontNotFoundException is thrown.

##### Public API changes

*FontNotFoundException* class has been added to *GroupDocs.Watermark.Exceptions* namespace.

*FontNotFoundException(string)* constructor has been added to *FontNotFoundException* class.

*FontName* property has been added to *FontNotFoundException* class.

### Added class MultiframeImageWatermarkOptions

MultiframeImageWatermarkOptions class has been added to simplify adding watermarks to any supported multiframe image.

##### Public API changes

*MultiframeImageWatermarkOptions* class has been added to *GroupDocs.Watermark.Options.Image* namespace.

*MultiframeImageWatermarkOptions(int)* constructor has been added to *MultiframeImageWatermarkOptions* class.

*FrameIndex* property has been added to *MultiframeImageWatermarkOptions* class.

*GifImageWatermarkOptions(int)* constructor has been added to *GifImageWatermarkOptions* class.

*TiffImageWatermarkOptions(int)* constructor has been added to *TiffImageWatermarkOptions* class.
