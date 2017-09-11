using GroupDocs.Watermark.Search;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GroupDocs.Watermark.Examples.CSharp
{
    public static class WatermarkOperations
    {
        // initialize file paths
        //ExStart:SourceDocumentFilesPath
        private const string PngFilePath = "Images/sample.JPG";
        private const string DocFilePath = "Documents/sample.docx";
        private const string PptFilePath = "Documents/sample.pptx";
        private const string XlsFilePath = "Documents/sample.xlsx";
        //ExEnd:SourceDocumentFilesPath

        #region Adding Watermark 
        /// <summary>
        /// Adds text watermark to a supported document
        /// </summary> 
        public static void AddTextWatermark()
        {
            try
            {
                //ExStart:AddTextWatermark
                using (Document doc = Document.Load(Utilities.MapSourceFilePath (PngFilePath)))
                {
                    // Initialize the font to be used for watermark
                    Font font = new Font("Arial", 19, FontStyle.Bold | FontStyle.Italic);

                    TextWatermark watermark = new TextWatermark("Test watermark", font);

                    // Set watermark properties
                    watermark.ForegroundColor = Color.Red;
                    watermark.BackgroundColor = Color.Blue;
                    watermark.TextAlignment = TextAlignment.Right;
                    watermark.Opacity = 0.5;

                    doc.AddWatermark(watermark);

                    doc.Save();
                }
                //ExEnd:AddTextWatermark
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }
        
        /// <summary>
        /// Adds image watermark to a supported document
        /// </summary> 
        public static void AddImageWatermark()
        {
            try
            {
                //ExStart:AddImageWatermark
                using (Document doc = Document.Load(Utilities.MapSourceFilePath (PptFilePath)))
                {
                    // Use path to the image as constructor parameter
                    using (ImageWatermark watermark = new ImageWatermark(@"D:\watermark.jpg"))
                    {
                        // Add watermark to the document
                        doc.AddWatermark(watermark);

                        doc.Save();
                    }
                }
                //ExEnd:AddImageWatermark
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        /// <summary>
        /// Adds image watermark using stream to a supported document
        /// </summary> 
        public static void AddImageWatermarkUsingStream()
        {
            try
            {
                //ExStart:AddImageWatermarkUsingStream
                using (Stream watermarkStream = File.OpenRead(@"D:\watermark.jpg"))
                {
                    using (Document doc = Document.Load(Utilities.MapSourceFilePath (PngFilePath)))
                    {
                        // Use stream containing an image as constructor parameter
                        using (ImageWatermark watermark = new ImageWatermark(watermarkStream))
                        {
                            // Add watermark to the document
                            doc.AddWatermark(watermark);

                            doc.Save();
                        }
                    }
                }
                //ExEnd:AddImageWatermarkUsingStream
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        /// <summary>
        /// Adds watermark to an absolute position
        /// </summary> 
        public static void AddWatermarkToAbsolutePosition()
        {
            try
            {
                //ExStart:AddWatermarkToAbsolutePosition
                using (Document doc = Document.Load(Utilities.MapSourceFilePath (DocFilePath)))
                {
                    Font font = new Font("Times New Roman", 8);
                    TextWatermark watermark = new TextWatermark("Test watermark", font);

                    // Set watermark coordinates
                    watermark.X = 10;
                    watermark.Y = 20;

                    // Set watermark size
                    watermark.Width = 100;
                    watermark.Height = 40;

                    doc.AddWatermark(watermark);
                    doc.Save();
                }
                //ExEnd:AddWatermarkToAbsolutePosition
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        /// <summary>
        /// Adds watermark to relative position
        /// </summary> 
        public static void AddWatermarkToRelativePosition()
        {
            try
            {
                //ExStart:AddWatermarkToRelativePosition
                using (Document doc = Document.Load(Utilities.MapSourceFilePath (XlsFilePath)))
                {
                    Font font = new Font("Calibri", 12);
                    TextWatermark watermark = new TextWatermark("Test watermark", font);
                    watermark.HorizontalAlignment = HorizontalAlignment.Right;
                    watermark.VerticalAlignment = VerticalAlignment.Bottom;

                    // Set absolute margins. Values are measured in document units.
                    watermark.Margins.Right = 10;
                    watermark.Margins.Bottom = 5;

                    doc.AddWatermark(watermark);
                    doc.Save();
                }
                //ExEnd:AddWatermarkToRelativePosition
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        /// <summary>
        /// Adds watermark with a particular margin type
        /// </summary> 
        public static void AddWatermarkWithMarginType()
        {
            try
            {
                //ExStart:AddWatermarkWithMarginType
                using (Document doc = Document.Load(Utilities.MapSourceFilePath (XlsFilePath)))
                {
                    Font font = new Font("Calibri", 12);
                    TextWatermark watermark = new TextWatermark("Test watermark", font);
                    watermark.HorizontalAlignment = HorizontalAlignment.Right;
                    watermark.VerticalAlignment = VerticalAlignment.Bottom;
                    
                    // Set relative margins. Margin value will be interpreted as a portion of appropriate parent dimension.
                    // If this type is chosen, margin value must be between 0.0 and 1.0.
                    watermark.Margins.MarginType = MarginType.RelativeToParentDimensions;
                    watermark.Margins.Right = 0.1;
                    watermark.Margins.Bottom = 0.2;

                    doc.AddWatermark(watermark);
                    doc.Save();
                }
                //ExEnd:AddWatermarkWithMarginType
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        /// <summary>
        /// Adds watermark with a particular size type
        /// </summary> 
        public static void AddWatermarkWithSizeType()
        {
            try
            {
                //ExStart:AddWatermarkWithSizeType
                using (Document doc = Document.Load(Utilities.MapSourceFilePath (PngFilePath)))
                {
                    Font font = new Font("Calibri", 12);
                    TextWatermark watermark = new TextWatermark("This is a test watermark", font);

                    // Set sizing type
                    watermark.SizingType = SizingType.ScaleToParentDimensions;

                    // Set watermark scale
                    watermark.ScaleFactor = 0.5;

                    doc.AddWatermark(watermark);
                    doc.Save();
                }
                //ExEnd:AddWatermarkWithSizeType
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        /// <summary>
        /// Adds watermark according to the parent margins
        /// </summary> 
        public static void AddWatermarkWithParentMargin()
        {
            try
            {
                //ExStart:AddWatermarkWithParentMargin
                using (Document doc = Document.Load(Utilities.MapSourceFilePath(DocFilePath)))
                {
                    var watermark = new TextWatermark("Test watermark", new Font("Arial", 42));
                    watermark.HorizontalAlignment = HorizontalAlignment.Right;
                    watermark.VerticalAlignment = VerticalAlignment.Top;
                    watermark.SizingType = SizingType.ScaleToParentDimensions;
                    watermark.ScaleFactor = 1;
                    watermark.RotateAngle = 45;
                    watermark.ForegroundColor = Color.Red;
                    watermark.BackgroundColor = Color.Aqua;

                    // Add watermark considering parent margins
                    watermark.ConsiderParentMargins = true;
                    doc.AddWatermark(watermark);
                    doc.Save();
                }
                //ExEnd:AddWatermarkWithParentMargin
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        /// <summary>
        /// Adds watermark with rotation angle
        /// <param name="RotationAngle">Rotation angle</param>
        /// </summary> 
        public static void AddTextWatermark(int RotationAngle)
        {
            try
            {
                //ExStart:AddTextWatermarkWithRotationAngle
                using (Document doc = Document.Load(Utilities.MapSourceFilePath (DocFilePath)))
                {
                    Font font = new Font("Calibri", 8);
                    TextWatermark watermark = new TextWatermark("Test watermark", font);
                    watermark.HorizontalAlignment = HorizontalAlignment.Right;
                    watermark.VerticalAlignment = VerticalAlignment.Top;
                    watermark.SizingType = SizingType.ScaleToParentDimensions;
                    watermark.ScaleFactor = 0.5;

                    // Set rotation angle
                    watermark.RotateAngle = 45;

                    doc.AddWatermark(watermark);
                    doc.Save();
                }
                //ExEnd:AddTextWatermarkWithRotationAngle
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        /// <summary>
        /// Adds watermark to the images inside a document
        /// </summary> 
        public static void AddWatermarkToImages()
        {
            try
            {
                //ExStart:AddWatermarkToImages
                using (Document doc = Document.Load(Utilities.MapSourceFilePath (PptFilePath)))
                {
                    // Initialize text watermark
                    TextWatermark textWatermark = new TextWatermark("Protected image", new Font("Arial", 8));
                    textWatermark.HorizontalAlignment = HorizontalAlignment.Center;
                    textWatermark.VerticalAlignment = VerticalAlignment.Center;
                    textWatermark.RotateAngle = 45;
                    textWatermark.SizingType = SizingType.ScaleToParentDimensions;
                    textWatermark.ScaleFactor = 1;

                    // Initialize image watermark
                    using (ImageWatermark imageWatermark = new ImageWatermark(@"D:\protect.jpg"))
                    {
                        imageWatermark.HorizontalAlignment = HorizontalAlignment.Center;
                        imageWatermark.VerticalAlignment = VerticalAlignment.Center;
                        imageWatermark.RotateAngle = -45;
                        imageWatermark.SizingType = SizingType.ScaleToParentDimensions;
                        imageWatermark.ScaleFactor = 1;

                        // Find all images in a document
                        WatermarkableImageCollection images = doc.FindImages();

                        for (int i = 0; i < images.Count; i++)
                        {
                            if (images[i].Width > 100 && images[i].Height > 100)
                            {
                                if (i % 2 == 0)
                                {
                                    images[i].AddWatermark(textWatermark);
                                }
                                else
                                {
                                    images[i].AddWatermark(imageWatermark);
                                }
                            }
                        }
                    }
                    doc.Save();
                }
                //ExEnd:AddWatermarkToImages
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }
        #endregion

        #region Searching and Removing Watermark

        /// <summary>
        /// Searches for watermark in a document
        /// </summary> 
        public static void SearchWatermark()
        {
            try
            {
                //ExStart:SearchWatermark
                using (Document doc = Document.Load(Utilities.MapSourceFilePath (DocFilePath)))
                {
                    PossibleWatermarkCollection possibleWatermarks = doc.FindWatermarks();
                    foreach (PossibleWatermark possibleWatermark in possibleWatermarks)
                    {
                        if (possibleWatermark.ImageData != null)
                        {
                            Console.WriteLine(possibleWatermark.ImageData.Length);
                        }
                        Console.WriteLine(possibleWatermark.Text);
                        Console.WriteLine(possibleWatermark.X);
                        Console.WriteLine(possibleWatermark.Y);
                        Console.WriteLine(possibleWatermark.RotateAngle);
                        Console.WriteLine(possibleWatermark.Width);
                        Console.WriteLine(possibleWatermark.Height);
                    }
                }
                //ExEnd:SearchWatermark
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        /// <summary>
        /// Searches for watermark with a particular text
        /// <param name="SearchString">Search String</param>
        /// </summary> 
        public static void SearchWatermark(string SearchString)
        {
            try
            {
                //ExStart:SearchWatermarkWithSearchString
                using (Document doc = Document.Load(Utilities.MapSourceFilePath (PptFilePath)))
                {
                    // Search by exact string
                    TextSearchCriteria textSearchCriteria = new TextSearchCriteria("© 2017");

                    // Find all possible watermarks containing some specific text
                    PossibleWatermarkCollection possibleWatermarks = doc.FindWatermarks(textSearchCriteria);

                    // ...
                }
                //ExEnd:SearchWatermarkWithSearchString
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        /// <summary>
        /// Searches for watermark with a regular expression
        /// <param name="RegularExpression">Regular Expression</param>
        /// </summary> 
        public static void SearchWatermark(Regex RegularExpression)
        {
            try
            {
                //ExStart:SearchWatermarkWithRegularExpression
                using (Document doc = Document.Load(Utilities.MapSourceFilePath (DocFilePath)))
                {
                    Regex regex = new Regex(@"^© \d{4}$");

                    // Search by regular expression
                    TextSearchCriteria textSearchCriteria = new TextSearchCriteria(regex);

                    // Find possible watermarks using regular expression
                    PossibleWatermarkCollection possibleWatermarks = doc.FindWatermarks(textSearchCriteria);

                    // ...
                }
                //ExEnd:SearchWatermarkWithRegularExpression
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        /// <summary>
        /// Searches for image watermark
        /// </summary> 
        public static void SearchImageWatermark()
        {
            try
            {
                //ExStart:SearchImageWatermark
                using (Document doc = Document.Load(Utilities.MapSourceFilePath (PptFilePath)))
                {
                    // Initialize criteria with the image
                    ImageSearchCriteria imageSearchCriteria = new ImageDctHashSearchCriteria(@"D:\watermark.jpg");

                    //Set maximum allowed difference between images
                    imageSearchCriteria.MaxDifference = 0.9;

                    PossibleWatermarkCollection possibleWatermarks = doc.FindWatermarks(imageSearchCriteria);
                    
                    // ...
                }
                //ExEnd:SearchImageWatermark
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        /// <summary>
        /// Searches for watermark with combination of different search criterias
        /// </summary> 
        public static void SearchWatermarkWithCombinedSearch()
        {
            try
            {
                //ExStart:SearchWatermarkWithCombinedSearch
                using (Document doc = Document.Load(Utilities.MapSourceFilePath (DocFilePath)))
                {
                    ImageSearchCriteria imageSearchCriteria = new ImageDctHashSearchCriteria(@"D:\logo.png");
                    imageSearchCriteria.MaxDifference = 0.9;

                    TextSearchCriteria textSearchCriteria = new TextSearchCriteria("Company Name");

                    RotateAngleSearchCriteria rotateAngleSearchCriteria = new RotateAngleSearchCriteria(30, 60);

                    SearchCriteria combinedSearchCriteria = imageSearchCriteria.Or(textSearchCriteria).And(rotateAngleSearchCriteria);
                    PossibleWatermarkCollection possibleWatermarks = doc.FindWatermarks(combinedSearchCriteria);

                    // ...
                }
                //ExEnd:SearchWatermarkWithCombinedSearch
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        /// <summary>
        /// Removes watermark
        /// </summary> 
        public static void RemoveWatermark()
        {
            try
            {
                //ExStart:RemoveWatermark
                using (Document doc = Document.Load(Utilities.MapSourceFilePath (XlsFilePath)))
                {
                    PossibleWatermarkCollection possibleWatermarks = doc.FindWatermarks();

                    // Remove possible watermark at the specified index from the document.
                    possibleWatermarks.RemoveAt(0);

                    // Remove specified possible watermark from the document.
                    possibleWatermarks.Remove(possibleWatermarks[0]);

                    doc.Save();
                }
                //ExEnd:RemoveWatermark
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        /// <summary>
        /// Removes watermark with a prticular text formatting
        /// </summary> 
        public static void RemoveWatermarkWithParticularTextFormatting()
        {
            try
            {
                //ExStart:RemoveWatermarkWithParticularTextFormatting
                using (Document doc = Document.Load(Utilities.MapSourceFilePath(DocFilePath)))
                {
                    TextFormattingSearchCriteria criteria = new TextFormattingSearchCriteria();
                    criteria.ForegroundColorRange = new ColorRange();
                    criteria.ForegroundColorRange.MinHue = -5;
                    criteria.ForegroundColorRange.MaxHue = 10;
                    criteria.ForegroundColorRange.MinBrightness = 0.01f;
                    criteria.ForegroundColorRange.MaxBrightness = 0.99f;
                    criteria.BackgroundColorRange = new ColorRange();
                    criteria.BackgroundColorRange.IsEmpty = true;
                    criteria.FontName = "Arial";
                    criteria.MinFontSize = 19;
                    criteria.MaxFontSize = 42;
                    criteria.FontBold = true;

                    PossibleWatermarkCollection watermarks = doc.FindWatermarks(criteria);
                    watermarks.Clear();
                    doc.Save();
                }
                //ExEnd:RemoveWatermarkWithParticularTextFormatting
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        /// <summary>
        /// Searches for watermark specifying which objects should be included in the search for all document instances
        /// </summary> 
        public static void SearchWatermarkInParticularObjects()
        {
            try
            {
                //ExStart:SearchWatermarkInParticularObjectsAllInstances
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
                //ExEnd:SearchWatermarkInParticularObjectsAllInstances
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        /// <summary>
        /// Searches for watermark specifying which objects should be included in the search for particular document instance
        /// </summary> 
        public static void SearchWatermarkInParticularObjectsForParticularDocument()
        {
            try
            {
                //ExStart:SearchWatermarkInParticularObjectsForParticularDocument
                using (var doc = Document.Load(Utilities.MapSourceFilePath(DocFilePath)))
                {
                    // Search for hyperlinks only.
                    doc.SearchableObjects.PdfSearchableObjects = PdfSearchableObjects.Hyperlinks;
                    var watermarks = doc.FindWatermarks();

                    // The code for working with found watermarks goes here.
                }
                //ExEnd:SearchWatermarkInParticularObjectsForParticularDocument
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }
        #endregion

        /// <summary>
        /// Removes hyperlinks with a particular URL
        /// </summary> 
        public static void RemoveHyperlinksWithParticularURL()
        {
            try
            {
                //ExStart:RemoveHyperlinksWithParticularURL
                using (Document doc = Document.Load(Utilities.MapSourceFilePath(DocFilePath)))
                {
                    PossibleWatermarkCollection watermarks = doc.FindWatermarks(new TextSearchCriteria(new Regex(@"someurl\.com")));
                    for (int i = watermarks.Count - 1; i >= 0; i--)
                    {
                        // Ensure that only hyperlinks will be removed.
                        if (watermarks[i] is HyperlinkPossibleWatermark)
                        {
                            // Output the full url of the hyperlink
                            Console.WriteLine(watermarks[i].Text);

                            // Remove hyperlink from the document
                            watermarks.RemoveAt(i);
                        }
                    }
                    doc.Save();
                }
                //ExEnd:RemoveHyperlinksWithParticularURL
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }
    }
}
