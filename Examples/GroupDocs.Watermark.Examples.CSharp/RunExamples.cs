// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp
{
    using System;
    using AdvancedUsage.AddingWatermarks.AddingImageWatermarks;
    using AdvancedUsage.AddingWatermarks.AddingTextWatermarks;
    using AdvancedUsage.AddingWatermarks.AddWatermarksToDiagrams;
    using AdvancedUsage.AddingWatermarks.AddWatermarksToEmailAttachments;
    using AdvancedUsage.AddingWatermarks.AddWatermarksToImages;
    using AdvancedUsage.AddingWatermarks.AddWatermarksToPdf;
    using AdvancedUsage.AddingWatermarks.AddWatermarksToPresentations;
    using AdvancedUsage.AddingWatermarks.AddWatermarksToSpreadsheets;
    using AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing;
    using AdvancedUsage.LoadingDocuments;
    using AdvancedUsage.SavingDocuments;
    using AdvancedUsage.SearchingAndModifyingWatermarks.ModifingFoundWatermarkProperties;
    using AdvancedUsage.SearchingAndModifyingWatermarks.RemovingFoundWatermarks;
    using AdvancedUsage.SearchingAndModifyingWatermarks.SearchingWatermarks;
    using BasicUsage;
    using QuickStart;

    internal class RunExamples
    {
        private static void Main()
        {
            Console.WriteLine("Open RunExamples.cs.");
            Console.WriteLine("In Main() method uncomment the example that you want to run.");
            Console.WriteLine("=====================================================");

            // NOTE: Please uncomment the example you want to try out

            #region Quick Start

            SetLicenseFromFile.Run();
            //SetLicenseFromStream.Run();
            //SetMeteredLicense.Run();
            HelloWorld.Run();

            #endregion            
            
            #region Basic Usage

            //GetSupportedFileFormats.Run();
            //GetDocumentInfoForTheFileFromLocalDisk.Run();
            //GetDocumentInfoForTheFileFromStream.Run();

            //AddATextWatermark.Run();
            //AddAnImageWatermark.Run();

            #endregion

            #region Advanced Usage

            #region Loading Documents

            //LoadFromLocalDisk.Run();
            //LoadFromStream.Run();
            //LoadingDocumentOfSpecificFormat.Run();
            //LoadPasswordProtectedDocument.Run();
            //LoadPasswordProtectedWordProcessingDocument.Run();

            #endregion

            #region AddingTextWatermarks

            //AddTextWatermark.Run();
            //AddWatermarkToAbsolutePosition.Run();
            //AddWatermarkToRelativePosition.Run();
            //AddWatermarkWithMarginType.Run();
            //AddWatermarkWithSizeType.Run();
            //AddTextWatermarkWithRotationAngle.Run();
            //AddWatermarkWithParentMargin.Run();

            #endregion

            #region AddingImageWatermarks

            //AddImageWatermark.Run();
            //AddImageWatermarkUsingStream.Run();

            #endregion

            #region AddWatermarksToDiagrams

            //DiagramAddWatermarkToAllPagesOfParticularType.Run();
            //DiagramAddWatermarkToSeparateBackgroundPage.Run();
            //DiagramAddWatermarkToParticularPage.Run();
            //DiagramLockWatermarkShape.Run();

            //DiagramRemoveWatermark.Run();
            //DiagramGetShapesInformation.Run();
            //DiagramRemoveShape.Run();
            //DiagramRemoveTextShapesWithParticularTextFormatting.Run();
            //DiagramRemoveHyperlinks.Run();
            //DiagramReplaceTextForParticularShapes.Run();
            //DiagramReplaceTextWithFormatting.Run();
            //DiagramReplaceShapeImage.Run();
            //DiagramGetHeaderFooterInformation.Run();
            //DiagramRemoveOrReplaceHeaderFooter.Run();

            #endregion

            #region AddWatermarksToEmailAttachments

            //EmailAddWatermarkToAllAttachments.Run();

            //EmailExtractAllAttachments.Run();
            //EmailRemoveAttachment.Run();
            //EmailAddAttachment.Run();

            //EmailUpdateBody.Run();
            //EmailAddEmbeddedImage.Run();
            //EmailRemoveEmbeddedImages.Run();
            //EmailSearchTextInBody.Run();
            //EmailListRecipients.Run();

            #endregion

            #region AddWatermarksToImages

            //AddWatermarkToImage.Run();
            //AddWatermarkToImagesInsideDocument.Run();

            #endregion

            #region AddWatermarksToPdf

            //PdfAddWatermarks.Run();
            //PdfAddWatermarkToImages.Run();
            //PdfGetDimensions.Run();
            //PdfAddWatermarkWithPageMarginType.Run();
            //PdfAddWatermarkToAllAttachments.Run();

            //PdfAddArtifactWatermark.Run();
            //PdfAddAnnotationWatermark.Run();
            //PdfAddPrintOnlyAnnotationWatermark.Run();

            //PdfRasterizeDocument.Run();
            //PdfRasterizePage.Run();

            //PdfRemoveWatermark.Run();
            //PdfExtractXObjectInformation.Run();
            //PdfRemoveXObject.Run();
            //PdfRemoveXObjectWithParticularTextFormatting.Run();
            //PdfAddWatermarkToXObjects.Run();
            //PdfReplaceTextForParticularXObject.Run();
            //PdfReplaceTextForParticularXObjectWithFormatting.Run();
            //PdfReplaceImageForParticularXObject.Run();
            //PdfExtractArtifactInformation.Run();
            //PdfRemoveArtifact.Run();
            //PdfRemoveArtifactsWithParticularTextFormatting.Run();
            //PdfAddWatermarkToImageArtifacts.Run();
            //PdfReplaceTextForParticularArtifact.Run();
            //PdfReplaceTextForParticularArtifactWithFormatting.Run();
            //PdfReplaceImageForParticularArtifact.Run();
            //PdfExtractAnnotationInformation.Run();
            //PdfRemoveAnnotation.Run();
            //PdfRemoveAnnotationsWithParticularTextFormatting.Run();
            //PdfAddWatermarkToAnnotationImages.Run();
            //PdfReplaceTextForParticularAnnotation.Run();
            //PdfReplaceTextForParticularAnnotationWithFormatting.Run();
            //PdfReplaceImageForParticularAnnotation.Run();

            //PdfExtractAllAttachments.Run();
            //PdfAddAttachment.Run();
            //PdfRemoveAttachment.Run();
            //PdfSearchImageInAttachment.Run();

            #endregion

            #region AddWatermarksToPresentations

            //PresentationAddWatermarkToSlide.Run();
            //PresentationProtectWatermarkUsingUnreadableCharacters.Run();
            //PresentationGetSlideDimensions.Run();
            //PresentationAddWatermarkToSlideImages.Run();
            //PresentationAddWatermarkToAllSlideTypes.Run();
            //PresentationAddWatermarkWithSlidesShapeSettings.Run();
            //PresentationAddWatermarkWithTextEffects.Run();
            //PresentationAddWatermarkWithImageEffects.Run();

            //PresentationGetSlideBackgroundsInformation.Run();
            //PresentationRemoveSlideBackground.Run();
            //PresentationAddWatermarkToSlideBackgroundImages.Run();
            //PresentationSetTiledSemitransparentBackground.Run();
            //PresentationSetBackgroundImageForChart.Run();

            #endregion

            #region AddWatermarksToSpreadsheets

            //SpreadsheetAddWatermarkToWorksheet.Run();
            //SpreadsheetGetContentAreaDimensions.Run();
            //SpreadsheetAddWatermarkToWorksheetImages.Run();
            //SpreadsheetAddModernWordArtWatermark.Run();
            //SpreadsheetAddWatermarkUsingShapeSettings.Run();
            //SpreadsheetAddWatermarkWithTextEffects.Run();
            //SpreadsheetAddWatermarkWithImageEffects.Run();
            //SpreadsheetAddWatermarkAsBackground.Run();
            //SpreadsheetAddWatermarkAsBackgroundWithRelativeSizeAndPosition.Run();
            //SpreadsheetAddTextWatermarkAsBackground.Run();
            //SpreadsheetAddImageWatermarkIntoHeaderFooter.Run();
            //SpreadsheetAddTextWatermarkIntoHeaderFooter.Run();

            //SpreadsheetGetInformationOfWorksheetBackgrounds.Run();
            //SpreadsheetRemoveWorksheetBackground.Run();
            //SpreadsheetAddWatermarkToBackgroundImages.Run();
            //SpreadsheetSetBackgroundImageForChart.Run();

            //SpreadsheetGetHeaderFooterInformation.Run();
            //SpreadsheetClearHeaderFooter.Run();
            //SpreadsheetClearSectionOfHeaderFooter.Run();
            //SpreadsheetAddWatermarkToImagesInHeaderFooter.Run();

            //SpreadsheetExtractAllAttachments.Run();
            //SpreadsheetAddAttachment.Run();
            //SpreadsheetAddLinkedAttachment.Run();
            //SpreadsheetRemoveAttachment.Run();
            //SpreadsheetAddWatermarkToAttachment.Run();
            //SpreadsheetSearchImageInAttachment.Run();

            //SpreadsheetGetShapesInformation.Run();
            //SpreadsheetRemoveShape.Run();
            //SpreadsheetRemoveTextShapesWithParticularTextFormatting.Run();
            //SpreadsheetRemoveHyperlinks.Run();
            //SpreadsheetReplaceTextForParticularShapes.Run();
            //SpreadsheetReplaceTextWithFormattingForParticularShapes.Run();
            //SpreadsheetReplaceImageOfParticularShapes.Run();
            //SpreadsheetSetBackgroundImageForParticularShapes.Run();
            //SpreadsheetUpdateShapeProperties.Run();

            #endregion

            #region AddWatermarksToWordProcessing

            //WordProcessingAddWatermarkToSection.Run();
            //WordProcessingGetSectionProperties.Run();
            //WordProcessingAddWatermarkToSectionImages.Run();
            //WordProcessingAddWatermarkToShapeImages.Run();
            //WordProcessingAddWatermarkToParticularPage.Run();
            //WordProcessingLinkHeaderFooterInSection.Run();
            //WordProcessingLinkAllHeaderFooterInSection.Run();
            //WordProcessingAddImageWatermarkToAllHeaders.Run();
            //WordProcessingSetDifferentFirstPageHeaderFooter.Run();

            //WordProcessingAddLockedWatermarkToAllPages.Run();
            //WordProcessingAddLockedWatermarkToParticularPages.Run();
            //WordProcessingAddLockedWatermarkToSection.Run();

            //WordProcessingAddWatermarkWithShapeSettings.Run();
            //WordProcessingAddWatermarkWithTextEffects.Run();
            //WordProcessingAddWatermarkWithImageEffects.Run();

            //WordProcessingRemoveWatermarkFromSection.Run();
            //WordProcessingFindWatermarkInHeaderFooter.Run();
            //WordProcessingGetShapesInformation.Run();
            //WordProcessingShapeTypeUsage.Run();
            //WordProcessingRemoveShape.Run();
            //WordProcessingRemoveShapesWithParticularTextFormatting.Run();
            //WordProcessingRemoveHyperlinks.Run();
            //WordProcessingReplaceTextForParticularShape.Run();
            //WordProcessingReplaceShapeTextWithFormattedText.Run();
            //WordProcessingReplaceShapeImage.Run();
            //WordProcessingModifyShapeProperties.Run();

            //WordProcessingProtectDocument.Run();
            //WordProcessingUnProtectDocument.Run();

            #endregion

            #region SavingDocuments

            //SaveDocumentToTheSameFileOrStream.Run();
            //SaveDocumentToTheSpecifiedLocation.Run();
            //SaveDocumentToTheSpecifiedStream.Run();

            #endregion

            #region SearchAndRemoveWatermarks

            //SearchWatermark.Run();
            //SearchWatermarkWithSearchString.Run();
            //SearchWatermarkWithRegularExpression.Run();
            //SearchImageWatermark.Run();
            //SearchWatermarkWithCombinedSearch.Run();
            //SearchWatermarkWithParticularTextFormatting.Run();
            //SearchWatermarkInParticularObjectsAllInstances.Run();
            //SearchWatermarkInParticularObjectsForParticularDocument.Run();
            //SearchTextWatermarkSkippingUnreadableCharacters.Run();

            //RemoveWatermark.Run();
            //RemoveWatermarkWithParticularTextFormatting.Run();
            //RemoveHyperlinksWithParticularUrl.Run();

            //ModifyTextInFoundWatermarks.Run();
            //ModifyTextWithFormattingInFoundWatermarks.Run();
            //ModifyImageInFoundWatermarks.Run();

            #endregion

            #endregion

            Console.WriteLine();
            Console.WriteLine("All done.");
            Console.ReadKey();
        }
    }
}