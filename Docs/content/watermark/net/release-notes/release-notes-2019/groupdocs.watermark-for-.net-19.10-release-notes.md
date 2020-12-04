---
id: groupdocs-watermark-for-net-19-10-release-notes
url: watermark/net/groupdocs-watermark-for-net-19-10-release-notes
title: GroupDocs.Watermark for .NET 19.10 Release Notes
weight: 2
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: True
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Watermark for .NET 19.10{{< /alert >}}

{{< alert style="danger" >}}In this version we're introducing new public API which was designed to be simple and easy to use. For more details about new API please check Public Docs section. The legacy API have been moved into Legacy namespace so after update to this version it is required to make project-wide replacement of namespace usages from GroupDocs.Watermark. to GroupDocs.Watermark.Legacy. to resolve build issues.{{< /alert >}}

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| WATERMARKNET-1093 | New Public API | Feature |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Watermark for .NET 19.10 It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Watermark which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### All public types from GroupDocs.Watermark namespace are moved and marked as obsolete

#### All public types from GroupDocs.Watermark namespace

1. Have been moved into **GroupDocs.Watermark.Legacy** namespace
2. Marked as **Obsolete** with message: *This interface/class/enumeration is obsolete and will be available till January 2020 (v20.1).*

#### Full list of types that have been moved and marked as obsolete

##### GroupDocs.Watermark

New namespace: **GroupDocs.Watermark.Legacy**

Types:

* AttachedImagePossibleWatermark
* Attachment
* AttachmentWatermarkableImage
* DetachedImageException
* Document
* DocumentFactory
* DocumentInfo
* DocumentPart
* EncryptionIsNotSupportedException
* FloatingAttachedImagePossibleWatermark
* Font
* FormattedTextFragment
* FormattedTextFragmentCollection
* HyperlinkPossibleWatermark
* ImageWatermark
* InvalidPasswordException
* LoadOptions
* Margins
* PossibleWatermark
* PossibleWatermarkCollection
* ReadOnlyListBase
* RemoveOnlyListBase
* ShapePossibleWatermark
* ShapeSearchAdapter
* TextWatermark
* TwoDObjectPossibleWatermark
* UnexpectedDocumentStructureException
* UnsupportedFileTypeException
* Watermark
* WatermarkableImage
* WatermarkableImageCollection
* Color
* IDocumentFactory
* IRotatableTwoDObject
* ITwoDObject
* Dimension
* FileFormat
* FontStyle
* FormattedTextFragmentCollectionType
* HorizontalAlignment
* MarginType
* SizingType
* TextAlignment
* UnitOfMeasurement
* VerticalAlignment

##### GroupDocs.Watermark.Email

New namespace: **GroupDocs.Watermark.Legacy.Email**

Types:

* EmailAddress
* EmailAddressCollection
* EmailAttachedImagePossibleWatermark
* EmailAttachment
* EmailAttachmentBase
* EmailAttachmentCollection
* EmailBodyTextPossibleWatermark
* EmailDocument
* EmailEmbeddedImagePossibleWatermark
* EmailEmbeddedObject
* EmailEmbeddedObjectCollection
* EmailHtmlBodyTextPossibleWatermark
* EmailSubjectTextPossibleWatermark
* EmailTextPossibleWatermark
* NamespaceDoc
* EmailBodyType

##### GroupDocs.Watermark.Images

New namepace: **GroupDocs.Watermark.Legacy.Images**

Types:

* GifImageDocument
* ImageDocument
* ImageFrame
* ImageFrameCollection
* MultiframeImageDocument
* NamespaceDoc
* TiffImageDocument

##### GroupDocs.Watermark.Office

New namespace: **GroupDocs.Watermark.Legacy.Office**

Types:

* NamespaceDoc
* OfficeImageEffects
* OfficeImageFillFormatTWatermarkableImage
* OfficeLineFormat
* OfficeShapeSettings
* OfficeTextEffects
* OfficeDashStyle
* OfficeHeaderFooterType
* OfficeLineStyle

##### GroupDocs.Watermark.Office.Cells

New namespace: **GroupDocs.Watermark.Legacy.Office.Cells**

Types:

* CellsAttachedImagePossibleWatermark
* CellsAttachment
* CellsAttachmentCollection
* CellsBackgroundPossibleWatermark
* CellsCellFormattedTextFragment
* CellsCellFormattedTextFragmentCollection
* CellsCellPossibleWatermark
* CellsChart
* CellsChartBackgroundPossibleWatermark
* CellsChartCollection
* CellsDocument
* CellsHeaderFooter
* CellsHeaderFooterCollection
* CellsHeaderFooterPossibleWatermark
* CellsHeaderFooterSection
* CellsHeaderFooterSectionCollection
* CellsHyperlinkPossibleWatermark
* CellsImageEffects
* CellsImageFillFormat
* CellsPageSetup
* CellsShape
* CellsShapeCollection
* CellsShapeFormattedTextFragment
* CellsShapeFormattedTextFragmentCollection
* CellsShapePossibleWatermark
* CellsShapeSettings
* CellsTextEffectFormattedTextFragment
* CellsTextEffectFormattedTextFragmentCollection
* CellsTextEffects
* CellsWatermarkableImage
* CellsWorksheet
* CellsWorksheetCollection
* NamespaceDoc
* CellsAutoShapeType
* CellsHeaderFooterSectionType
* CellsMsoDrawingType

##### GroupDocs.Watermark.Office.Diagram

New namespace: **GroupDocs.Watermark.Legacy.Office.Diagram**

Types:

* DiagramCommentPossibleWatermark
* DiagramDocument
* DiagramFormattedTextFragment
* DiagramFormattedTextFragmentCollection
* DiagramHeaderFooter
* DiagramHeaderFooterFont
* DiagramHeaderFooterPossibleWatermark
* DiagramHyperlink
* DiagramHyperlinkCollection
* DiagramHyperlinkPossibleWatermark
* DiagramPage
* DiagramPageCollection
* DiagramShape
* DiagramShapeCollection
* DiagramShapePossibleWatermark
* DiagramShapeSettings
* DiagramWatermarkableImage
* NamespaceDoc
* DiagramWatermarkPlacementType

##### GroupDocs.Watermark.Office.Slides

New namespace: **GroupDocs.Watermark.Legacy.Office.Slides**

Types:

* NamespaceDoc
* SlidesBackgroundPossibleWatermark
* SlidesBaseShape
* SlidesBaseSlide
* SlidesChart
* SlidesChartBackgroundPossibleWatermark
* SlidesChartCollection
* SlidesDocument
* SlidesFormattedTextFragment
* SlidesFormattedTextFragmentCollection
* SlidesHyperlinkPossibleWatermark
* SlidesImageEffects
* SlidesImageFillFormat
* SlidesLayoutSlide
* SlidesLayoutSlideCollection
* SlidesMasterHandoutSlide
* SlidesMasterNotesSlide
* SlidesMasterSlide
* SlidesMasterSlideCollection
* SlidesNotesSlide
* SlidesShape
* SlidesShapeCollection
* SlidesShapePossibleWatermark
* SlidesShapeSettings
* SlidesSlide
* SlidesSlideCollection
* SlidesSlideImageFillFormat
* SlidesTextEffects
* SlidesWatermarkableImage
* ISlidesHyperlinkContainer
* SlidesHyperlinkActionType
* SlidesShapeType

##### GroupDocs.Watermark.Office.Words

New namespace: **GroupDocs.Watermark.Legacy.Office.Words**

Types:

* NamespaceDoc
* WordsDocument
* WordsFormattedTextFragmentCollection
* WordsHeaderFooter
* WordsHeaderFooterCollection
* WordsImageEffects
* WordsPageSetup
* WordsSection
* WordsSectionCollection
* WordsShape
* WordsShapeCollection
* WordsShapeFormattedTextFragmentCollection
* WordsShapePossibleWatermark
* WordsShapeSettings
* WordsTextEffects
* WordsTextFormattedTextFragment
* WordsTextFormattedTextFragmentCollection
* WordsTextHyperlinkPossibleWatermark
* WordsTextPossibleWatermark
* WordsWatermarkableImage
* WordsWordArtShapeFormattedTextFragment
* WordsWordArtShapeFormattedTextFragmentCollection
* WordsFlipOrientation
* WordsHorizontalAlignment
* WordsLockType
* WordsProtectionType
* WordsRelativeHorizontalPosition
* WordsRelativeVerticalPosition
* WordsShapeType
* WordsVerticalAlignment

##### GroupDocs.Watermark.Pdf

New namespace: **GroupDocs.Watermark.Legacy.Pdf**

Types:

* NamespaceDoc
* PdfAnnotation
* PdfAnnotationCollection
* PdfAnnotationPossibleWatermark
* PdfArtifact
* PdfArtifactCollection
* PdfArtifactPossibleWatermark
* PdfAttachedImagePossibleWatermark
* PdfAttachment
* PdfAttachmentCollection
* PdfDocument
* PdfFormattedTextFragment
* PdfFormattedTextFragmentCollection
* PdfHyperlinkPossibleWatermark
* PdfPage
* PdfPageCollection
* PdfShape
* PdfShapeFormattedTextFragmentCollection
* PdfTextFormattedTextFragmentCollection
* PdfTextPossibleWatermark
* PdfWatermarkableImage
* PdfXForm
* PdfXImage
* PdfXObject
* PdfXObjectCollection
* PdfXObjectPossibleWatermark
* PdfAnnotationType
* PdfArtifactSubtype
* PdfArtifactType
* PdfCryptoAlgorithm
* PdfImageConversionFormat
* PdfPageMarginType
* PdfPermissions

##### GroupDocs.Watermark.Preview

New namespace: **GroupDocs.Watermark.Legacy.Preview**

Types:

* PreviewFactory
* PreviewHandler
* PreviewImageData
* PreviewNotSupportedException
* PreviewPage
* PreviewUnitOfMeasurement

##### GroupDocs.Watermark.Search

New namespace: **GroupDocs.Watermark.Legacy.Search**

Types:

* AndSearchCriteria
* ColorRange
* ImageColorHistogramSearchCriteria
* ImageDctHashSearchCriteria
* ImageSearchCriteria
* ImageThumbnailSearchCriteria
* IsImageSearchCriteria
* IsTextSearchCriteria
* NamespaceDoc
* NotSearchCriteria
* OrSearchCriteria
* RotateAngleSearchCriteria
* SearchableObjects
* SearchCriteria
* SizeSearchCriteria
* TextFormattingSearchCriteria
* TextSearchCriteria
* CellsSearchableObjects
* DiagramSearchableObjects
* EmailSearchableObjects
* PdfSearchableObjects
* SlidesSearchableObjects
* WordsSearchableObjects
