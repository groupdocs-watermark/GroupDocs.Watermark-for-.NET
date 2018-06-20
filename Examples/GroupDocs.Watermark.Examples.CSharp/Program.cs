using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Watermark.Examples.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {

            //ExStart:ApplyingLicense
            /**
             *  Applying product license
             *  Please uncomment the statement if you do have license.
             */
            Utilities.ApplyLicense();
            //ExEnd:ApplyingLicense


            #region Working with Watermark Operations
            // Add image watermark to any supported document
            //WatermarkOperations.AddImageWatermark();

            // Add image watermark to any supported document using stream
            //WatermarkOperations.AddImageWatermarkUsingStream();

            // Add text watermark to any supported document
            //WatermarkOperations.AddTextWatermark();

            // Add watermark to absolute position
            //WatermarkOperations.AddWatermarkToAbsolutePosition();

            // Add watermark to the images inside a document
            //WatermarkOperations.AddWatermarkToImages();

            // Add watermark to relative position
            //WatermarkOperations.AddWatermarkToRelativePosition();

            // Add watermark with margin type
            //WatermarkOperations.AddWatermarkWithMarginType();

            // Add watermark with size type
            //WatermarkOperations.AddWatermarkWithSizeType();

            // Add watermark specifying parent margin
            //WatermarkOperations.AddWatermarkWithParentMargin();

            // Remove watermark
            //WatermarkOperations.RemoveWatermark();

            // Search image watermark
            //WatermarkOperations.SearchImageWatermark();

            // Search watermark
            //WatermarkOperations.SearchWatermark();

            // Search watermark with combined search criteria
            //WatermarkOperations.SearchWatermarkWithCombinedSearch();

            //Search for watermark specifying which objects should be included in the search for all document instances
            //WatermarkOperations.SearchWatermarkInParticularObjects();

            //Search for watermark specifying which objects should be included in the search for particular document instance
            //WatermarkOperations.SearchWatermarkInParticularObjectsForParticularDocument();

            // Edit text in found watermarks
            //WatermarkOperations.EditTextInFoundWatermarks();

            // Edit text with formatting in found watermarks
            //WatermarkOperations.EditTextWithFormattingInFoundWatermarks();

            // Replace image in the found watermarks
            //WatermarkOperations.ReplacesImageInFoundWatermarks();
            #endregion

            #region Working with PDF Documents
            // Add annotation watermark
            //Documents.PDF.AddAnnotationWatermark();

            // Add artifact watermark
            //Documents.PDF.AddArtifactWatermark();

            // Add print only watermark
            //Documents.PDF.AddPrintOnlyAnnotationWatermark();

            // Add watermark
            //Documents.PDF.AddWatermark();

            // Add watermark to annotations
            //Documents.PDF.AddWatermarkToAnnotations();

            // Add watermark to artifact 
            //Documents.PDF.AddWatermarkToArtifacts();

            // Add watermark to images
            //Documents.PDF.AddWatermarkToImages();

            // Add watermark to XObjects 
            //Documents.PDF.AddWatermarkToXObjects();

            // Extract information of annotations in document
            //Documents.PDF.ExtractAnnotationInformation();

            // Extract information of artifacts in document
            //Documents.PDF.ExtractArtifactInformation();

            // Extract information of XObjects in document
            //Documents.PDF.ExtractXObjectInformation();

            // Get dimenstion 
            //Documents.PDF.GetDimensions();

            // Rasterize a PDF document
            //Documents.PDF.RasterizePDFDocument();

            // Remove annotation
            //Documents.PDF.RemoveAnnotation();

            // Remove artifact 
            //Documents.PDF.RemoveArtifact();

            // Remove watermark 
            //Documents.PDF.RemoveWatermark();

            // Remove XObject
            //Documents.PDF.RemoveXObject();

            // Add watermark with page margin type
            //Documents.PDF.AddWatermarkWithPageMrginType();

            // Replaces text for particular XObject
            //Documents.PDF.ReplaceTextForParticularXObject();

            // Replaces text for particular artifact 
            //Documents.PDF.ReplaceTextForParticularArtifact();

            // Replaces text for particular annotation 
            //Documents.PDF.ReplaceTextForParticularAnnotation();

            // Replaces text for particular XObject with formatting 
            //Documents.PDF.ReplaceTextForParticularXObjectWithFormatting();

            // Replaces text for particular artifact with formatting 
            //Documents.PDF.ReplaceTextForParticularArtifactWithFormatting();

            // Replaces text for particular annotation with formatting 
            //Documents.PDF.ReplaceTextForParticularAnnotationWithFormatting();

            // Replaces image for particular XObject
            //Documents.PDF.ReplaceImageForParticularXObject();

            // Replaces image for particular artifact
            //Documents.PDF.ReplaceImageForParticularArtifact();

            // Replaces image for particular annotation
            //Documents.PDF.ReplaceImageForParticularAnnotation();


            #endregion

            #region Working with attachments in a PDF document
            // Extract all attachments from a PDF document
            //Documents.PDF.ExtractAllAttachments();

            // Add an attachment to a PDF document
            //Documents.PDF.AddAttachment();

            // Remove particular attachments from a PDF document
            //Documents.PDF.RemoveAttachment();

            // Add watermark to all attached files of supported types
            //Documents.PDF.AddWatermarkToAttachment();

            // Add watermark to all attached files of supported types
            //Documents.PDF.SearchImageInAttachment();

            #endregion

            #region Working with Word Documents
            // Add image watermark
            //Documents.Word.AddImageWatermark();

            // Add watermark to images inside document
            //Documents.Word.AddWatermarkToImages();

            // Add watermark to the shapes inside document
            //Documents.Word.AddWatermarkToImageShapes();

            // Add watermark to a section
            //Documents.Word.AddWatermarkToSection();

            // Add image watermark with effects 
            //Documents.Word.AddWatermarkWithImageEffects();

            // Add text watermark with effects 
            //Documents.Word.AddWatermarkWithTextEffects();

            // Add watermark with words shape settings
            //Documents.Word.AddWatermarkWithWordsShapeSettings();

            // Add watermark in header/footer
            //Documents.Word.FindWatermarkInHeaderFooter();

            // Get section properties
            //Documents.Word.GetSectionProperties();

            // Get information of shapes inside a document
            //Documents.Word.GetShapesInformation();

            // Link header footer in section
            //Documents.Word.LinkHeaderFooterInSection();

            // Link all header/footer in sections
            //Documents.Word.LinkAllHeaderFooterInSection(); 

            // Remove shape
            //Documents.Word.RemoveShape();

            // Remove watermark from section
            //Documents.Word.RemoveWatermarkFromSection();

            // Replace text for particular shape
            //Documents.Word.ReplaceTextForParticularShape();

            // Replace shape text with formatted text
            //Documents.Word.ReplaceShapeTextWithFormattedText();

            // Replace shape image
            //Documents.Word.ReplaceShapeImage();

            // Modify shape properties
            //Documents.Word.ModifyShapeProperties();

            // Protect Word document
            //Documents.Word.ProtectWordDocument();

            // UnProtect Word document
            //Documents.Word.UnProtectWordDocument();

            // Add locked watermark to a section of Word document
            //Documents.Word.AddLockedWatermarkToSection();

            // Add locked watermark to all pages of Word document
            //Documents.Word.AddLockedWatermarkToAllPages();

            // Add locked watermark to particular pages of Word document
            //Documents.Word.AddLockedWatermarkToParticularPages();

            #endregion

            #region Working with Excel Documents
            // Add modern word art watermark 
            //Documents.Excel.AddModernWordArdWatermark();

            // Add watermark
            //Documents.Excel.AddWatermark();

            // Add watermark as background
            //Documents.Excel.AddWatermarkAsBackground();

            // Add watermark as background with relative size and position
            //Documents.Excel.AddWatermarkAsBackgroundWithRelativeSizeAndPosition();

            // Add watermark to header/footer
            //Documents.Excel.AddWatermarkIntoHeaderFooter();

            // Add watermark to background images
            //Documents.Excel.AddWatermarkToBackgroundImages();

            // Add watermark to images inside a document
            //Documents.Excel.AddWatermarkToImages();

            // Add watermark to shapes 
            //Documents.Excel.AddWatermarkToImageShapes();

            // Add watermark to images inside a section
            //Documents.Excel.AddWatermarkToImagesInHeaderFooter();

            // Add watermark using cells shape settings
            //Documents.Excel.AddWatermarkUsingCellsShapeSettings();

            // Add watermark with image effects 
            //Documents.Excel.AddWatermarkWithImageEffects();

            // Add watermark with text effects 
            //Documents.Excel.AddWatermarkWithTextEffects();

            // Clear header/footer
            //Documents.Excel.ClearHeaderFooter();

            // Clear section of header/footer
            //Documents.Excel.ClearSectionOfHeaderFooter();

            // Get content area dimensions
            //Documents.Excel.GetContentAreaDimensions();

            // Get header/footer information 
            //Documents.Excel.GetHeaderFooterInformation();

            // Get information of worksheet backgrounds 
            //Documents.Excel.GetInformationOfWorksheetBackgrounds();

            // Get information of shapes inside a document
            //Documents.Excel.GetShapesInformation();

            // Remove a shape 
            //Documents.Excel.RemoveShape();

            // Remove watermark
            //Documents.Excel.RemoveWatermark();

            // Remove worksheet background
            //Documents.Excel.RemoveWorksheetBackground();
            #endregion

            #region Working with attachments in Excel document
            // Extract all attachments from Excel document
            //Documents.Excel.ExtractAllAttachments();

            // Add an attachment to a PDF document
            //Documents.Excel.AddAttachment();

            // Add a linked file to an Excel document
            //Documents.Excel.AddLinkedAttachment();

            // Remove particular attachments from an Excel document
            //Documents.Excel.RemoveAttachment();

            // Add watermark to all attached files of supported types
            //Documents.Excel.AddWatermarkToAttachment();

            // Add watermark to all attached files of supported types
            //Documents.Excel.SearchImageInAttachment();
            #endregion

            #region Working with PowerPoint Documents
            // Add watermark
            //Documents.PowerPoint.AddWatermark();

            // Add watermark to all background images
            //Documents.PowerPoint.AddWatermarkToAllBackgroundImages();

            // Add watermark to all slide types
            //Documents.PowerPoint.AddWatermarkToAllSlideTypes();

            // Add watermark to images inside document
            //Documents.PowerPoint.AddWatermarkToImages();

            // Add watermark to the shapes 
            //Documents.PowerPoint.AddWatermarkToImageShapes();

            // Add watermark with image effects 
            //Documents.PowerPoint.AddWatermarkWithImageEffects();

            // Add watermark with slides shape settings 
            //Documents.PowerPoint.AddWatermarkWithSlidesShapeSettings();

            // Add watermark with text effects 
            //Documents.PowerPoint.AddWatermarkWithTextEffects();

            // Get dimensions of slide
            //Documents.PowerPoint.GetDimensionsOfSlide();

            // Get information of the slide background
            //Documents.PowerPoint.GetInformationOfSlideBackgrounds();

            // Get information of the shapes inside a document
            //Documents.PowerPoint.GetShapesInformation();

            // Remove background
            //Documents.PowerPoint.RemoveBackground();

            // Remove shape 
            //Documents.PowerPoint.RemoveShape();

            // Remve watermark
            //Documents.PowerPoint.RemoveWatermark();

            //Replace hyperlinks that are activated on mouse over
            //Documents.PowerPoint.ReplaceMouseOverHyperlinks();

            //Remove hyperlinks of all types using FindWatermarks method
            //Documents.PowerPoint.RemoveHyperlinksUsingFindWatermark();

            // Replace text for a particular shape
            //Documents.PowerPoint.ReplaceTextForParticularShape();

            // Replace text with a particular formatting
            //Documents.PowerPoint.ReplaceTextWithParticularFormatting();

            // Replace shape image
            //Documents.PowerPoint.ReplaceShapeImage();

            // Set background image for particular shapes
            //Documents.PowerPoint.SetBackgroundImageForParticularShapes();

            // Modify shape properties
            //Documents.PowerPoint.ModifyShapeProperties();
            #endregion

            #region Working with Visio Documents

            // Add watermark to a particular page
            //Documents.Visio.AddWatermarkToParticularPage();

            // Add watermark to all pages of a particular type 
            //Documents.Visio.AddWatermarkToAllPagesOfParticularType();

            // Add watermark to all images in a particular page
            //Documents.Visio.AddWatermarkToImages();

            // Add watermark to a separate newly created background pages
            //Documents.Visio.AddWatermarkToSeparateBackgroundPage();

            // Get information about headers&footers 
            //Documents.Visio.GetHeaderFooterInformation();

            // Get information about pages
            //Documents.Visio.GetPagesInformation();

            // Get information about shapes
            //Documents.Visio.GetShapesInformation();

            // Lock watermark shape to prevent editing
            //Documents.Visio.LockWatermarkShape();

            // Remove watermark 
            //Documents.Visio.RemoveWatermark();

            // Remove or replace a particular header&footer
            //Documents.Visio.RemoveOrReplaceHeaderFooter();

            // Remove a particular shape
            //Documents.Visio.RemoveShape();

            //Replace text for particular shapes
            //Documents.Visio.ReplaceTextForParticularShapes();

            //Replace text with formatting
            //Documents.Visio.ReplaceTextWithFormatting();

            // Replace shape image
            //Documents.Visio.ReplaceShapeImage();
            #endregion

            #region Working with Emails
            // Load an email message
            // Documents.Email.LoadEmailMessage();

            // Extract all attachments from an email message 
            // Documents.Email.ExtractAllAttachments();

            // Remove particular attachments from an email message
            // Documents.Email.RemoveAttachment();

            // Add watermark to all attached files of supported types
            //Documents.Email.AddWatermarkToAllAttachment();

            // Add an attachment to an email message
            //Documents.Email.AddAttachment();

            // Modify email message body and subject
            //Documents.Email.UpdateEmailBody();

            // Remove all embedded jpeg images from an email message
            //Documents.Email.RemoveEmbeddedImages();

            // Embed image into email message body
            //Documents.Email.AddEmbeddedImage();

            // List all message recipients 
            //Documents.Email.ListEmailRecipients();

            // Find particular text fragments in email message body/subject
            //Documents.Email.SearchTextInBody();

            #endregion

            Console.Write("Operation completed...");
            Console.ReadKey();
        }
    }
}
