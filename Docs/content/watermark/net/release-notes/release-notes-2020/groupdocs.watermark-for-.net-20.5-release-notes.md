---
id: groupdocs-watermark-for-net-20-5-release-notes
url: watermark/net/groupdocs-watermark-for-net-20-5-release-notes
title: GroupDocs.Watermark for .NET 20.5 Release Notes
weight: 2
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
# Major features

There are the following improvements in this release:

*   Allow to edit minor shape properties in Visio documents

# Full List of Issues Covering all Changes in this Release

| Key | Summary | Issue Type |
| --- | --- | --- |
| WATERMARKNET-1264 | Footer and header watermark adds line break using .NET | Bug |
| WATERMARKNET-772 | Allow to edit minor shape properties in Visio documents | Improvement |
| WATERMARKNET-1268 | Watermarking of Word document uses existing paragraph if available | Improvement |
| WATERMARKNET-1269 | After removing found watermark in Word document, the empty parent paragraph is removed too | Improvement |

# Public API and Backward Incompatible Changes

### Allow to edit minor shape properties in Visio documents

#### Description

This improvement allows to edit the following shape properties in Visio documents:

*   Width
*   Height
*   X
*   Y
*   RotateAngle

#### Public API changes

[DiagramShape](https://apireference.groupdocs.com/watermark/net/groupdocs.watermark.contents.diagram/diagramshape) class was updated with changes as follows:

*   Added the setter for the property [Width](https://apireference.groupdocs.com/watermark/net/groupdocs.watermark.contents.diagram/diagramshape/properties/width)
*   Added the setter for the property [Height](https://apireference.groupdocs.com/watermark/net/groupdocs.watermark.contents.diagram/diagramshape/properties/height)
*   Added the setter for the property [X](https://apireference.groupdocs.com/watermark/net/groupdocs.watermark.contents.diagram/diagramshape/properties/x)
*   Added the setter for the property [Y](https://apireference.groupdocs.com/watermark/net/groupdocs.watermark.contents.diagram/diagramshape/properties/y)
*   Added the setter for the property [RotateAngle](https://apireference.groupdocs.com/watermark/net/groupdocs.watermark.contents.diagram/diagramshape/properties/rotateangle)
