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
            //Utilities.ApplyLicense();
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
            #endregion

            Console.Write("Operation completed...");
            Console.ReadKey();
        }
    }
}
