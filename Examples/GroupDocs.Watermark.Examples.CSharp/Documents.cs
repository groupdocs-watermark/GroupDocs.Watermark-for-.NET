using GroupDocs.Watermark.Office;
using GroupDocs.Watermark.Office.Cells;
using GroupDocs.Watermark.Office.Diagram;
using GroupDocs.Watermark.Office.Slides;
using GroupDocs.Watermark.Office.Words;
using GroupDocs.Watermark.Pdf;
using GroupDocs.Watermark.Search;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Watermark.Examples.CSharp
{
    public static class Documents
    {
        public static class PDF
        {
            // initialize file path
            //ExStart:SourcePDFFilePath
            private const string FilePath = "Documents/sample.pdf";
            //ExEnd:SourcePDFFilePath

            /// <summary>
            /// Adds watermark to a PDF document
            /// </summary> 
            public static void AddWatermark()
            {
                try
                {
                    //ExStart:AddWatermarkToPDF
                    using (PdfDocument doc = Document.Load<PdfDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        // Add text watermark
                        TextWatermark textWatermark = new TextWatermark("This is a test watermark", new Font("Arial", 8));
                        doc.Pages[0].AddWatermark(textWatermark);

                        // Add image watermark
                        using (ImageWatermark imageWatermark = new ImageWatermark(@"D:\protect.jpg"))
                        {
                            doc.Pages[1].AddWatermark(imageWatermark);
                        }
                        doc.Save();
                    }
                    //ExEnd:AddWatermarkToPDF
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Gets dimensions of a PDF document
            /// </summary> 
            public static void GetDimensions()
            {
                try
                {
                    //ExStart:GetDimensionsPDF
                    using (PdfDocument doc = Document.Load<PdfDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        Console.WriteLine(doc.Pages[0].Width);
                        Console.WriteLine(doc.Pages[0].Height);
                    }
                    //ExEnd:GetDimensionsPDF
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Adds watermark to all images inside a PDF document
            /// </summary> 
            public static void AddWatermarkToImages()
            {
                try
                {
                    //ExStart:AddWatermarkToImagesPDF
                    using (PdfDocument doc = Document.Load<PdfDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        // Initialize image or text watermark
                        TextWatermark watermark = new TextWatermark("Protected image", new Font("Arial", 8));
                        watermark.HorizontalAlignment = HorizontalAlignment.Center;
                        watermark.VerticalAlignment = VerticalAlignment.Center;
                        watermark.RotateAngle = 45;
                        watermark.SizingType = SizingType.ScaleToParentDimensions;
                        watermark.ScaleFactor = 1;

                        // Get all images from the first page
                        WatermarkableImageCollection images = doc.Pages[0].FindImages();

                        // Add watermark to all found images
                        foreach (WatermarkableImage image in images)
                        {
                            image.AddWatermark(watermark);
                        }

                        doc.Save();
                    }
                    //ExEnd:AddWatermarkToImagesPDF
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Adds artifact watermark to a PDF document
            /// </summary> 
            public static void AddArtifactWatermark()
            {
                try
                {
                    //ExStart:AddArtifactWatermark
                    using (PdfDocument doc = Document.Load<PdfDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        // Add text watermark
                        TextWatermark textWatermark = new TextWatermark("This is an artifact watermark", new Font("Arial", 8));
                        doc.AddArtifactWatermark(textWatermark);

                        // Add image watermark
                        //using (ImageWatermark imageWatermark = new ImageWatermark(@"D:\logo.bmp"))
                        //{
                        //    doc.AddArtifactWatermark(imageWatermark);
                        //}
                        doc.Save();
                    }
                    //ExEnd:AddArtifactWatermark
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Adds annotation watermark to a PDF document
            /// </summary> 
            public static void AddAnnotationWatermark()
            {
                try
                {
                    //ExStart:AddAnnotationWatermark
                    using (PdfDocument doc = Document.Load<PdfDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        // Add text watermark
                        TextWatermark textWatermark = new TextWatermark("This is a test watermark", new Font("Arial", 8));
                        doc.AddAnnotationWatermark(textWatermark);

                        // Add image watermark
                        using (ImageWatermark imageWatermark = new ImageWatermark(@"D:\protect.jpg"))
                        {
                            doc.AddAnnotationWatermark(imageWatermark);
                        }
                        doc.Save();
                    }
                    //ExEnd:AddAnnotationWatermark
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Adds print only annotation watermark to a PDF document
            /// </summary> 
            public static void AddPrintOnlyAnnotationWatermark()
            {
                try
                {
                    //ExStart:AddPrintOnlyAnnotationWatermark
                    using (PdfDocument doc = Document.Load<PdfDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        TextWatermark textWatermark = new TextWatermark("This is a print only test watermark. It won't appear in view mode.", new Font("Arial", 8));
                        bool isPrintOnly = true;

                        // Annotation will be printed, but not displayed in pdf viewing application
                        doc.Pages[0].AddAnnotationWatermark(textWatermark, isPrintOnly);

                        doc.Save();
                    }
                    //ExEnd:AddPrintOnlyAnnotationWatermark
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Removes watermark from a PDF document
            /// </summary> 
            public static void RemoveWatermark()
            {
                try
                {
                    //ExStart:RemoveWatermarkFromPDF
                    using (PdfDocument doc = Document.Load<PdfDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        // Initialize search criteria
                        ImageSearchCriteria imageSearchCriteria = new ImageDctHashSearchCriteria(@"D:\logo.png");
                        TextSearchCriteria textSearchCriteria = new TextSearchCriteria("Company Name");

                        PossibleWatermarkCollection possibleWatermarks = doc.Pages[0].FindWatermarks(imageSearchCriteria.Or(textSearchCriteria));

                        // Remove all found watermarks
                        for (var i = possibleWatermarks.Count - 1; i >= 0; i--)
                        {
                            possibleWatermarks.RemoveAt(i);
                        }

                        doc.Save();
                    }
                    //ExEnd:RemoveWatermarkFromPDF
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Gets information about all XObjects in a PDF document
            /// </summary> 
            public static void ExtractXObjectInformation()
            {
                try
                {
                    //ExStart:ExtractXObjectInformation
                    using (PdfDocument doc = Document.Load<PdfDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        foreach (PdfPage page in doc.Pages)
                        {
                            foreach (PdfXObject xObject in page.XObjects)
                            {
                                if (xObject.Image != null)
                                {
                                    Console.WriteLine(xObject.Image.Width);
                                    Console.WriteLine(xObject.Image.Height);
                                    Console.WriteLine(xObject.Image.GetBytes().Length);
                                }
                                Console.WriteLine(xObject.Text);
                                Console.WriteLine(xObject.X);
                                Console.WriteLine(xObject.Y);
                                Console.WriteLine(xObject.Width);
                                Console.WriteLine(xObject.Height);
                                Console.WriteLine(xObject.RotateAngle);
                            }
                        }
                    }
                    //ExEnd:ExtractXObjectInformation
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Removes XObject from a PDF document
            /// </summary> 
            public static void RemoveXObject()
            {
                try
                {
                    //ExStart:RemoveXObject
                    using (PdfDocument doc = Document.Load<PdfDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        // Remove XObject by index
                        doc.Pages[0].XObjects.RemoveAt(0);

                        // Remove XObject by reference
                        doc.Pages[0].XObjects.Remove(doc.Pages[0].XObjects[0]);

                        doc.Save();
                    }
                    //ExEnd:RemoveXObject
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Adds watermark to all images XObjects inside a PDF document
            /// </summary> 
            public static void AddWatermarkToXObjects()
            {
                try
                {
                    //ExStart:AddWatermarkToXObjects
                    using (PdfDocument doc = Document.Load<PdfDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        // Initialize image or text watermark
                        TextWatermark watermark = new TextWatermark("Protected image", new Font("Arial", 8));
                        watermark.HorizontalAlignment = HorizontalAlignment.Center;
                        watermark.VerticalAlignment = VerticalAlignment.Center;
                        watermark.RotateAngle = 45;
                        watermark.SizingType = SizingType.ScaleToParentDimensions;
                        watermark.ScaleFactor = 1;

                        foreach (PdfPage page in doc.Pages)
                        {
                            foreach (PdfXObject xObject in page.XObjects)
                            {
                                if (xObject.Image != null)
                                {
                                    // Add watermark to the image
                                    xObject.Image.AddWatermark(watermark);
                                }
                            }
                        }

                        doc.Save();
                    }
                    //ExEnd:AddWatermarkToXObjects
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Gets information about all artifacts in a PDF document
            /// </summary> 
            public static void ExtractArtifactInformation()
            {
                try
                {
                    //ExStart:ExtractArtifactInformation
                    using (PdfDocument doc = Document.Load<PdfDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        foreach (PdfPage page in doc.Pages)
                        {
                            foreach (PdfArtifact artifact in page.Artifacts)
                            {
                                Console.WriteLine(artifact.ArtifactType);
                                Console.WriteLine(artifact.ArtifactSubtype);
                                if (artifact.Image != null)
                                {
                                    Console.WriteLine(artifact.Image.Width);
                                    Console.WriteLine(artifact.Image.Height);
                                    Console.WriteLine(artifact.Image.GetBytes().Length);
                                }
                                Console.WriteLine(artifact.Text);
                                Console.WriteLine(artifact.Opacity);
                                Console.WriteLine(artifact.X);
                                Console.WriteLine(artifact.Y);
                                Console.WriteLine(artifact.Width);
                                Console.WriteLine(artifact.Height);
                                Console.WriteLine(artifact.RotateAngle);
                            }
                        }
                    }
                    //ExEnd:ExtractArtifactInformation
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Removes artifact from a PDF document
            /// </summary> 
            public static void RemoveArtifact()
            {
                try
                {
                    //ExStart:RemoveArtifact
                    using (PdfDocument doc = Document.Load<PdfDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        // Remove Artifact by index
                        doc.Pages[0].Artifacts.RemoveAt(0);

                        // Remove Artifact by reference
                        doc.Pages[0].Artifacts.Remove(doc.Pages[0].Artifacts[0]);

                        doc.Save();
                    }
                    //ExEnd:RemoveArtifact
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Adds watermark to all images Artifacts inside a PDF document
            /// </summary> 
            public static void AddWatermarkToArtifacts()
            {
                try
                {
                    //ExStart:AddWatermarkToArtifacts
                    using (PdfDocument doc = Document.Load<PdfDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        // Initialize image or text watermark
                        TextWatermark watermark = new TextWatermark("Protected image", new Font("Arial", 8));
                        watermark.HorizontalAlignment = HorizontalAlignment.Center;
                        watermark.VerticalAlignment = VerticalAlignment.Center;
                        watermark.RotateAngle = 45;
                        watermark.SizingType = SizingType.ScaleToParentDimensions;
                        watermark.ScaleFactor = 1;

                        foreach (PdfPage page in doc.Pages)
                        {
                            foreach (PdfArtifact artifact in page.Artifacts)
                            {
                                if (artifact.Image != null)
                                {
                                    // Add watermark to the image
                                    artifact.Image.AddWatermark(watermark);
                                }
                            }
                        }

                        doc.Save();
                    }
                    //ExEnd:AddWatermarkToArtifacts
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Gets information about all annotations in a PDF document
            /// </summary> 
            public static void ExtractAnnotationInformation()
            {
                try
                {
                    //ExStart:ExtractAnnotationInformation
                    using (PdfDocument doc = Document.Load<PdfDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        foreach (PdfPage page in doc.Pages)
                        {
                            foreach (PdfAnnotation annotation in page.Annotations)
                            {
                                Console.WriteLine(annotation.AnnotationType);
                                if (annotation.Image != null)
                                {
                                    Console.WriteLine(annotation.Image.Width);
                                    Console.WriteLine(annotation.Image.Height);
                                    Console.WriteLine(annotation.Image.GetBytes().Length);
                                }
                                Console.WriteLine(annotation.Text);
                                Console.WriteLine(annotation.X);
                                Console.WriteLine(annotation.Y);
                                Console.WriteLine(annotation.Width);
                                Console.WriteLine(annotation.Height);
                                Console.WriteLine(annotation.RotateAngle);
                            }
                        }
                    }
                    //ExEnd:ExtractAnnotationInformation
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Removes annotation from a PDF document
            /// </summary> 
            public static void RemoveAnnotation()
            {
                try
                {
                    //ExStart:RemoveAnnotation
                    using (PdfDocument doc = Document.Load<PdfDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        // Remove Annotation by index
                        doc.Pages[0].Annotations.RemoveAt(0);

                        // Remove Annotation by reference
                        doc.Pages[0].Annotations.Remove(doc.Pages[0].Annotations[0]);

                        doc.Save();
                    }
                    //ExEnd:RemoveAnnotation
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Adds watermark to all images Annotations inside a PDF document
            /// </summary> 
            public static void AddWatermarkToAnnotations()
            {
                try
                {
                    //ExStart:AddWatermarkToAnnotations
                    using (PdfDocument doc = Document.Load<PdfDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        // Initialize image or text watermark
                        TextWatermark watermark = new TextWatermark("Protected image", new Font("Arial", 8));
                        watermark.HorizontalAlignment = HorizontalAlignment.Center;
                        watermark.VerticalAlignment = VerticalAlignment.Center;
                        watermark.RotateAngle = 45;
                        watermark.SizingType = SizingType.ScaleToParentDimensions;
                        watermark.ScaleFactor = 1;

                        foreach (PdfPage page in doc.Pages)
                        {
                            foreach (PdfAnnotation annotation in page.Annotations)
                            {
                                if (annotation.Image != null)
                                {
                                    // Add watermark to the image
                                    annotation.Image.AddWatermark(watermark);
                                }
                            }
                        }

                        doc.Save();
                    }
                    //ExEnd:AddWatermarkToAnnotations
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Rasterize a PDF document
            /// </summary> 
            public static void RasterizePDFDocument()
            {
                try
                {
                    //ExStart:RasterizePDFDocument
                    using (PdfDocument doc = Document.Load<PdfDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        // Initialize image or text watermark
                        TextWatermark watermark = new TextWatermark("Do not copy", new Font("Arial", 8));
                        watermark.HorizontalAlignment = HorizontalAlignment.Center;
                        watermark.VerticalAlignment = VerticalAlignment.Center;
                        watermark.RotateAngle = 45;
                        watermark.SizingType = SizingType.ScaleToParentDimensions;
                        watermark.ScaleFactor = 1;
                        watermark.Opacity = 0.5;

                        // Add watermark of any type first
                        doc.AddWatermark(watermark);

                        // Rasterize all pages
                        doc.Rasterize(100, 100, PdfImageConversionFormat.Png);

                        // Content of all pages is replaced with raster images
                        doc.Save();
                    }
                    //ExEnd:RasterizePDFDocument
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Rasterize a particular page of a PDF document
            /// </summary> 
            public static void RasterizePDFDocument(int PageNumber)
            {
                try
                {
                    //ExStart:RasterizePDFDocumentWithPageNumber
                    using (PdfDocument doc = Document.Load<PdfDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        // Initialize image or text watermark
                        TextWatermark watermark = new TextWatermark("Do not copy", new Font("Arial", 8));
                        watermark.HorizontalAlignment = HorizontalAlignment.Center;
                        watermark.VerticalAlignment = VerticalAlignment.Center;
                        watermark.RotateAngle = 45;
                        watermark.SizingType = SizingType.ScaleToParentDimensions;
                        watermark.ScaleFactor = 1;
                        watermark.Opacity = 0.5;

                        // Add watermark of any type first
                        doc.Pages[0].AddWatermark(watermark);

                        // Rasterize the first page
                        doc.Pages[0].Rasterize(100, 100, PdfImageConversionFormat.Png);

                        // Content of the first page is replaced with raster image
                        doc.Save();
                    }
                    //ExEnd:RasterizePDFDocumentWithPageNumber
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Adds watermark to a PDF document specifying page margin type
            /// </summary> 
            public static void AddWatermarkWithPageMrginType()
            {
                try
                {
                    //ExStart:AddWatermarkWithPageMrginType
                    using (PdfDocument doc = Document.Load<PdfDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        var watermark = new TextWatermark("Test watermark", new Font("Arial", 42));
                        watermark.HorizontalAlignment = HorizontalAlignment.Right;
                        watermark.VerticalAlignment = VerticalAlignment.Top;
                        watermark.SizingType = SizingType.ScaleToParentDimensions;
                        watermark.ScaleFactor = 1;

                        doc.PageMarginType = PdfPageMarginType.BleedBox;
                        watermark.ConsiderParentMargins = true;
                        doc.AddWatermark(watermark);
                        doc.Save();
                    }
                    //ExEnd:AddWatermarkWithPageMrginType
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Removes XObject containing text with a particular formatting from a PDF document
            /// </summary> 
            public static void RemoveXObjectWithParticularTextFormatting()
            {
                try
                {
                    //ExStart:RemoveXObjectWithParticularTextFormatting
                    using (PdfDocument doc = Document.Load<PdfDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        foreach (PdfPage page in doc.Pages)
                        {
                            for (var i = page.XObjects.Count - 1; i >= 0; i--)
                            {
                                foreach (var fragment in page.XObjects[i].FormattedTextFragments)
                                {
                                    if (fragment.ForegroundColor == Color.Red)
                                    {
                                        page.XObjects.RemoveAt(i);
                                        break;
                                    }
                                }
                            }
                        }
                        doc.Save();
                    }
                    //ExEnd:RemoveXObjectWithParticularTextFormatting
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Removes artifacts containing text with a particular formatting from a PDF document
            /// </summary> 
            public static void RemoveArtifactsWithParticularTextFormatting()
            {
                try
                {
                    //ExStart:RemoveArtifactsWithParticularTextFormatting
                    using (PdfDocument doc = Document.Load<PdfDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        foreach (PdfPage page in doc.Pages)
                        {
                            for (var i = page.Artifacts.Count - 1; i >= 0; i--)
                            {
                                foreach (var fragment in page.Artifacts[i].FormattedTextFragments)
                                {
                                    if (fragment.Font.Size > 42)
                                    {
                                        page.Artifacts.RemoveAt(i);
                                        break;
                                    }
                                }
                            }
                        }
                        doc.Save();
                    }
                    //ExEnd:RemoveArtifactsWithParticularTextFormatting
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Removes annotations containing text with a particular formatting from a PDF document
            /// </summary> 
            public static void RemoveAnnotationsWithParticularTextFormatting()
            {
                try
                {
                    //ExStart:RemoveAnnotationsWithParticularTextFormatting
                    using (PdfDocument doc = Document.Load<PdfDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        foreach (PdfPage page in doc.Pages)
                        {
                            for (var i = page.Annotations.Count - 1; i >= 0; i--)
                            {
                                foreach (var fragment in page.Annotations[i].FormattedTextFragments)
                                {
                                    if (fragment.Font.FamilyName == "Verdana")
                                    {
                                        page.Annotations.RemoveAt(i);
                                        break;
                                    }
                                }
                            }
                        }
                        doc.Save();
                    }
                    //ExEnd:RemoveAnnotationsWithParticularTextFormatting
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }
        }
        public static class Word
        {
            // initialize file path
            //ExStart:SourceWordFilePath
            private const string FilePath = "Documents/sample.docx";
            //ExEnd:SourceWordFilePath

            /// <summary>
            /// Adds watermark to a section of Word document
            /// </summary> 
            public static void AddWatermarkToSection()
            {
                try
                {
                    //ExStart:AddWatermarkToSection
                    using (WordsDocument doc = Document.Load<WordsDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 19));

                        // Add watermark to all headers of the first section
                        doc.Sections[0].AddWatermark(watermark);

                        doc.Save();
                    }
                    //ExEnd:AddWatermarkToSection
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Adds watermark to a particular page of Word document
            /// </summary> 
            public static void AddWatermarkToParticuarPage()
            {
                try
                {
                    //ExStart:AddWatermarkToParticuarPageWord
                    using (WordsDocument doc = Document.Load<WordsDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        TextWatermark textWatermark = new TextWatermark("DRAFT", new Font("Arial", 42));

                        // Add watermark to the last page
                        doc.AddWatermark(textWatermark, doc.PageCount);
                        doc.Save();
                    }
                    //ExEnd:AddWatermarkToParticuarPageWord
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Gets properties of a section of Word document
            /// </summary> 
            public static void GetSectionProperties()
            {
                try
                {
                    //ExStart:GetSectionProperties
                    using (WordsDocument doc = Document.Load<WordsDocument>(@"D:\test.docx"))
                    {
                        Console.WriteLine(doc.Sections[0].PageSetup.Width);
                        Console.WriteLine(doc.Sections[0].PageSetup.Height);
                        Console.WriteLine(doc.Sections[0].PageSetup.TopMargin);
                        Console.WriteLine(doc.Sections[0].PageSetup.RightMargin);
                        Console.WriteLine(doc.Sections[0].PageSetup.BottomMargin);
                        Console.WriteLine(doc.Sections[0].PageSetup.LeftMargin);
                    }
                    //ExEnd:GetSectionProperties
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Links header/footer to the previous section of Word document
            /// </summary> 
            public static void LinkHeaderFooterInSection()
            {
                try
                {
                    //ExStart:LinkHeaderFooterInSection
                    using (WordsDocument doc = Document.Load<WordsDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        // Link footer for even numbered pages to corresponding footer in previous section
                        doc.Sections[1].HeadersFooters[OfficeHeaderFooterType.FooterEven].IsLinkedToPrevious = true;

                        doc.Save();
                    }
                    //ExEnd:LinkHeaderFooterInSection
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Links all header/footer to the previous section of Word document
            /// </summary> 
            public static void LinkAllHeaderFooterInSection()
            {
                try
                {
                    //ExStart:LinkAllHeaderFooterInSection
                    using (WordsDocument doc = Document.Load<WordsDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        // Link footer for even numbered pages to corresponding footer in previous section
                        doc.Sections[1].HeadersFooters[1].IsLinkedToPrevious = true;

                        doc.Save();
                    }
                    //ExEnd:LinkAllHeaderFooterInSection
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Sets different headers/footers for even/odd numbered pages and for the first page of the document
            /// </summary> 
            public static void SetDifferentFirstPageHeaderFooter()
            {
                try
                {
                    //ExStart:SetDifferentFirstPageHeaderFooter
                    using (WordsDocument doc = Document.Load<WordsDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        doc.Sections[0].PageSetup.DifferentFirstPageHeaderFooter = true;
                        doc.Sections[0].PageSetup.OddAndEvenPagesHeaderFooter = true;
                        doc.Save();
                    }
                    //ExEnd:SetDifferentFirstPageHeaderFooter
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Adds image watermark to a word document
            /// </summary> 
            public static void AddImageWatermark()
            {
                try
                {
                    //ExStart:AddImageWatermarkToWord
                    using (WordsDocument doc = Document.Load<WordsDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        using (ImageWatermark watermark = new ImageWatermark(@"D:\large.png"))
                        {
                            // Add watermark to all headers of the first section
                            doc.Sections[0].AddWatermark(watermark);
                        }

                        // Link all other headers&footers to corresponding headers&footers of the first section
                        for (int i = 1; i < doc.Sections.Count; i++)
                        {
                            doc.Sections[i].HeadersFooters.LinkToPrevious(true);
                        }

                        doc.Save();
                    }
                    //ExEnd:AddImageWatermarkToWord
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Adds watermark to all images inside a section of Word document
            /// </summary> 
            public static void AddWatermarkToImages()
            {
                try
                {
                    //ExStart:AddWatermarkToImagesWordSection
                    using (WordsDocument doc = Document.Load<WordsDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        TextWatermark watermark = new TextWatermark("Protected image", new Font("Arial", 8));
                        watermark.HorizontalAlignment = HorizontalAlignment.Center;
                        watermark.VerticalAlignment = VerticalAlignment.Center;
                        watermark.RotateAngle = 45;
                        watermark.SizingType = SizingType.ScaleToParentDimensions;
                        watermark.ScaleFactor = 1;

                        // Get all images belonging to the first section
                        WatermarkableImageCollection images = doc.Sections[0].FindImages();

                        // Add watermark to all found images
                        foreach (WatermarkableImage image in images)
                        {
                            image.AddWatermark(watermark);
                        }

                        doc.Save();
                    }
                    //ExEnd:AddWatermarkToImagesWordSection
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Adds watermark to Word document with Words Shape Settings
            /// </summary> 
            public static void AddWatermarkWithWordsShapeSettings()
            {
                try
                {
                    //ExStart:AddWatermarkWithWordsShapeSettings
                    using (WordsDocument doc = Document.Load<WordsDocument>(@"D:\test.docx"))
                    {
                        TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 19));
                        WordsShapeSettings shapeSettings = new WordsShapeSettings();

                        // Set the shape name
                        shapeSettings.Name = "Shape 1";

                        // Set the descriptive (alternative) text that will be associated with the shape
                        shapeSettings.AlternativeText = "Test watermark";

                        doc.AddWatermark(watermark, shapeSettings);

                        doc.Save();
                    }
                    //ExEnd:AddWatermarkWithWordsShapeSettings
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Adds watermark to Word document with text effects
            /// </summary> 
            public static void AddWatermarkWithTextEffects()
            {
                try
                {
                    //ExStart:AddWatermarkWithTextEffectsWord
                    using (WordsDocument doc = Document.Load<WordsDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 19));

                        WordsTextEffects effects = new WordsTextEffects();
                        effects.LineFormat.Enabled = true;
                        effects.LineFormat.Color = Color.Red;
                        effects.LineFormat.DashStyle = OfficeDashStyle.DashDotDot;
                        effects.LineFormat.LineStyle = OfficeLineStyle.Triple;
                        effects.LineFormat.Weight = 1;
                        doc.AddTextWatermark(watermark, effects);
                        doc.Save();
                    }
                    //ExEnd:AddWatermarkWithTextEffectsWord
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Adds watermark to Word document with image effects
            /// </summary> 
            public static void AddWatermarkWithImageEffects()
            {
                try
                {
                    //ExStart:AddWatermarkWithImageEffectsWord
                    using (WordsDocument doc = Document.Load<WordsDocument>(@"D:\test.docx"))
                    {
                        using (var watermark = new ImageWatermark(@"D:\logo.tif"))
                        {
                            WordsImageEffects effects = new WordsImageEffects();
                            effects.Brightness = 0.7;
                            effects.Contrast = 0.6;
                            effects.ChromaKey = Color.Red;
                            effects.BorderLineFormat.Enabled = true;
                            effects.BorderLineFormat.Weight = 1;
                            doc.AddImageWatermark(watermark, effects);
                        }
                        doc.Save();
                    }
                    //ExEnd:AddWatermarkWithImageEffectsWord
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Removes watermark from a particular section of Word document 
            /// </summary> 
            public static void RemoveWatermarkFromSection()
            {
                try
                {
                    //ExStart:RemoveWatermarkFromSection
                    using (WordsDocument doc = Document.Load<WordsDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        // Initialize search criteria
                        ImageSearchCriteria imageSearchCriteria = new ImageDctHashSearchCriteria(@"D:\logo.png");
                        TextSearchCriteria textSearchCriteria = new TextSearchCriteria("Company Name");

                        // Call FindWatermarks method for the section
                        PossibleWatermarkCollection possibleWatermarks = doc.Sections[0].FindWatermarks(textSearchCriteria.Or(imageSearchCriteria));

                        // Remove all found watermarks
                        for (var i = possibleWatermarks.Count - 1; i >= 0; i--)
                        {
                            possibleWatermarks.RemoveAt(i);
                        }

                        doc.Save();
                    }
                    //ExEnd:RemoveWatermarkFromSection
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Finds watermarks in a header/footer of Word document 
            /// </summary> 
            public static void FindWatermarkInHeaderFooter()
            {
                try
                {
                    //ExStart:FindWatermarkInHeaderFooter
                    using (WordsDocument doc = Document.Load<WordsDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        // Initialize search criteria
                        ImageSearchCriteria imageSearchCriteria = new ImageDctHashSearchCriteria(@"D:\logo.png");
                        TextSearchCriteria textSearchCriteria = new TextSearchCriteria("Company Name");

                        PossibleWatermarkCollection possibleWatermarks = doc.Sections[0]
      .HeadersFooters[OfficeHeaderFooterType.HeaderPrimary]
      .FindWatermarks(textSearchCriteria.Or(imageSearchCriteria));

                        // Remove all found watermarks
                        for (var i = possibleWatermarks.Count - 1; i >= 0; i--)
                        {
                            possibleWatermarks.RemoveAt(i);
                        }

                        doc.Save();
                    }
                    //ExEnd:FindWatermarkInHeaderFooter
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Extracts information about all the shapes is a Word document 
            /// </summary> 
            public static void GetShapesInformation()
            {
                try
                {
                    //ExStart:GetShapesInformationWord
                    using (WordsDocument doc = Document.Load<WordsDocument>(@"D:\test.docx"))
                    {
                        foreach (WordsSection section in doc.Sections)
                        {
                            foreach (WordsShape shape in section.Shapes)
                            {
                                if (shape.HeaderFooter != null)
                                {
                                    Console.WriteLine("In header/footer");
                                }

                                Console.WriteLine(shape.ShapeType);
                                Console.WriteLine(shape.Width);
                                Console.WriteLine(shape.Height);
                                Console.WriteLine(shape.IsWordArt);
                                Console.WriteLine(shape.RotateAngle);
                                Console.WriteLine(shape.AlternativeText);
                                Console.WriteLine(shape.Name);
                                Console.WriteLine(shape.X);
                                Console.WriteLine(shape.Y);
                                Console.WriteLine(shape.Text);
                                if (shape.Image != null)
                                {
                                    Console.WriteLine(shape.Image.Width);
                                    Console.WriteLine(shape.Image.Height);
                                    Console.WriteLine(shape.Image.GetBytes().Length);
                                }

                                Console.WriteLine(shape.HorizontalAlignment);
                                Console.WriteLine(shape.VerticalAlignment);
                                Console.WriteLine(shape.RelativeHorizontalPosition);
                                Console.WriteLine(shape.RelativeVerticalPosition);
                            }
                        }
                    }
                    //ExEnd:GetShapesInformationWord
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Removes shape in a Word document 
            /// </summary> 
            public static void RemoveShape()
            {
                try
                {
                    //ExStart:RemoveShapeWordDocument
                    using (WordsDocument doc = Document.Load<WordsDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        // Remove shape by index
                        doc.Sections[0].Shapes.RemoveAt(0);

                        // Remove shape by reference
                        doc.Sections[0].Shapes.Remove(doc.Sections[0].Shapes[0]);

                        doc.Save();
                    }
                    //ExEnd:RemoveShapeWordDocument
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Adds watermark to all image shapes in a Word document 
            /// </summary> 
            public static void AddWatermarkToImageShapes()
            {
                try
                {
                    //ExStart:AddWatermarkToImageShapesWordDocument
                    using (WordsDocument doc = Document.Load<WordsDocument>(@"D:\test.docx"))
                    {
                        TextWatermark watermark = new TextWatermark("Protected image", new Font("Arial", 8));
                        watermark.HorizontalAlignment = HorizontalAlignment.Center;
                        watermark.VerticalAlignment = VerticalAlignment.Center;
                        watermark.RotateAngle = 45;
                        watermark.SizingType = SizingType.ScaleToParentDimensions;
                        watermark.ScaleFactor = 1;

                        foreach (WordsSection section in doc.Sections)
                        {
                            foreach (WordsShape shape in section.Shapes)
                            {
                                // Headers&Footers usually contains only service information.
                                // So, we skip images in headers/footers, expecting that they are probably watermarks or backgrounds
                                if (shape.HeaderFooter == null &&
                                   shape.Image != null)
                                {
                                    shape.Image.AddWatermark(watermark);
                                }
                            }
                        }
                    }
                    //ExEnd:AddWatermarkToImageShapesWordDocument
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Removes all text shapes with a particular text formatting in a Word document 
            /// </summary> 
            public static void RemoveTextShapesWithParticularTextFormatting()
            {
                try
                {
                    //ExStart:RemoveTextShapesWithParticularTextFormattingWord
                    using (WordsDocument doc = Document.Load<WordsDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        foreach (WordsSection section in doc.Sections)
                        {
                            for (var i = section.Shapes.Count - 1; i >= 0; i--)
                            {
                                foreach (var fragment in section.Shapes[i].FormattedTextFragments)
                                {
                                    if (fragment.ForegroundColor == Color.Red && fragment.Font.FamilyName == "Arial")
                                    {
                                        section.Shapes.RemoveAt(i);
                                        break;
                                    }
                                }
                            }
                        }
                        doc.Save();
                    }
                    //ExEnd:RemoveTextShapesWithParticularTextFormattingWord
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Removes hyperlinks associated with a particular shape inside a Word document
            /// </summary> 
            public static void RemoveHyperlinks()
            {
                try
                {
                    //ExStart:RemoveHyperlinksWord
                    using (WordsDocument doc = Document.Load<WordsDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        // Replace hyperlink
                        doc.Sections[0].Shapes[0].Hyperlink = "https://www.groupdocs.com/";

                        // Remove hyperlink
                        doc.Sections[0].Shapes[1].Hyperlink = null;

                        doc.Save();
                    }
                    //ExEnd:RemoveHyperlinksWord
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }
        }
        public static class Excel
        {
            // initialize file path
            //ExStart:SourceExcelFilePath
            private const string FilePath = "Documents/sample.xlsx";
            //ExEnd:SourceExcelFilePath

            /// <summary>
            /// Adds watermark to Excel spreadsheet
            /// </summary> 
            public static void AddWatermark()
            {
                try
                {
                    //ExStart:AddWatermarkToExcel
                    using (CellsDocument doc = Document.Load<CellsDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        // Add text watermark
                        TextWatermark textWatermark = new TextWatermark("Test watermark", new Font("Arial", 8));
                        doc.Worksheets[0].AddWatermark(textWatermark);

                        // Add image watermark
                        using (ImageWatermark imageWatermark = new ImageWatermark(@"D:\logo.jpg"))
                        {
                            doc.Worksheets[1].AddWatermark(imageWatermark);
                        }
                        doc.Save();
                    }
                    //ExEnd:AddWatermarkToExcel
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Gets content area dimensions of Excel worksheets
            /// </summary> 
            public static void GetContentAreaDimensions()
            {
                try
                {
                    //ExStart:GetContentAreaDimensions
                    using (CellsDocument doc = Document.Load<CellsDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        // Get the size of content area
                        Console.WriteLine(doc.Worksheets[0].ContentAreaHeight);
                        Console.WriteLine(doc.Worksheets[0].ContentAreaWidth);

                        // Get the size of particular cell
                        Console.WriteLine(doc.Worksheets[0].GetColumnWidth(0));
                        Console.WriteLine(doc.Worksheets[0].GetRowHeight(0));
                    }
                    //ExEnd:GetContentAreaDimensions
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Adds watermark to all images inside an Excel worksheet
            /// </summary> 
            public static void AddWatermarkToImages()
            {
                try
                {
                    //ExStart:AddWatermarkToImagesExcelWorksheet
                    using (CellsDocument doc = Document.Load<CellsDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        TextWatermark watermark = new TextWatermark("Protected image", new Font("Arial", 8));
                        watermark.HorizontalAlignment = HorizontalAlignment.Center;
                        watermark.VerticalAlignment = VerticalAlignment.Center;
                        watermark.RotateAngle = 45;
                        watermark.SizingType = SizingType.ScaleToParentDimensions;
                        watermark.ScaleFactor = 1;

                        // Get all images from the first worksheet
                        WatermarkableImageCollection images = doc.Worksheets[0].FindImages();

                        // Add watermark to all found images
                        foreach (WatermarkableImage image in images)
                        {
                            image.AddWatermark(watermark);
                        }

                        doc.Save();
                    }
                    //ExEnd:AddWatermarkToImagesExcelWorksheet
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Adds modern word art watermark to Excel worksheet
            /// </summary> 
            public static void AddModernWordArdWatermark()
            {
                try
                {
                    //ExStart:AddModernWordArdWatermarkToExcel
                    using (CellsDocument doc = Document.Load<CellsDocument>(@"D:\test.xlsx"))
                    {
                        TextWatermark textWatermark = new TextWatermark("Test watermark", new Font("Arial", 8));
                        doc.Worksheets[0].AddModernWordArtWatermark(textWatermark);
                        doc.Save();
                    }
                    //ExEnd:AddModernWordArdWatermarkToExcel
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Adds watermark to Excel worksheet with additional shape settings
            /// </summary> 
            public static void AddWatermarkUsingCellsShapeSettings()
            {
                try
                {
                    //ExStart:AddWatermarkUsingCellsShapeSettings
                    using (CellsDocument doc = Document.Load<CellsDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        TextWatermark watermark = new TextWatermark("Test watermark", new Font("Segoe UI", 19));
                        CellsShapeSettings shapeSettings = new CellsShapeSettings();

                        // Set the shape name
                        shapeSettings.Name = "Shape 1";

                        // Set the descriptive (alternative) text that will be associated with the shape
                        shapeSettings.AlternativeText = "Test watermark";

                        // Editing of the shape in Excel is forbidden
                        shapeSettings.IsLocked = true;

                        doc.AddWatermark(watermark, shapeSettings);


                        doc.Save();
                    }
                    //ExEnd:AddWatermarkUsingCellsShapeSettings
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Adds watermark with text effects to Excel worksheet
            /// </summary> 
            public static void AddWatermarkWithTextEffects()
            {
                try
                {
                    //ExStart:AddWatermarkWithTextEffectsToExcel
                    using (CellsDocument doc = Document.Load<CellsDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        TextWatermark watermark = new TextWatermark("Test watermark", new Font("Segoe UI", 19));

                        CellsTextEffects effects = new CellsTextEffects();
                        effects.LineFormat.Enabled = true;
                        effects.LineFormat.Color = Color.Red;
                        effects.LineFormat.DashStyle = OfficeDashStyle.DashDotDot;
                        effects.LineFormat.LineStyle = OfficeLineStyle.Triple;
                        effects.LineFormat.Weight = 1;
                        doc.AddTextWatermark(watermark, effects);
                        doc.Save();
                    }
                    //ExEnd:AddWatermarkWithTextEffectsToExcel
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Adds watermark with image effects to Excel worksheet
            /// </summary> 
            public static void AddWatermarkWithImageEffects()
            {
                try
                {
                    //ExStart:AddWatermarkWithImageEffectsToExcel
                    using (CellsDocument doc = Document.Load<CellsDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        using (var watermark = new ImageWatermark(@"D:\logo.tif"))
                        {
                            CellsImageEffects effects = new CellsImageEffects();
                            effects.Brightness = 0.7;
                            effects.Contrast = 0.6;
                            effects.ChromaKey = Color.Red;
                            effects.BorderLineFormat.Enabled = true;
                            effects.BorderLineFormat.Weight = 1;
                            doc.AddImageWatermark(watermark, effects);
                        }
                        doc.Save();
                    }
                    //ExEnd:AddWatermarkWithImageEffectsToExcel
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Adds watermark as background to Excel worksheet
            /// </summary> 
            public static void AddWatermarkAsBackground()
            {
                try
                {
                    //ExStart:AddWatermarkAsBackgroundToExcel
                    using (CellsDocument doc = Document.Load<CellsDocument>(@"D:\test.xlsx"))
                    {
                        using (ImageWatermark watermark = new ImageWatermark(@"D:\logo.gif"))
                        {
                            doc.AddWatermarkAsBackground(watermark);
                        }
                        doc.Save();
                    }
                    //ExEnd:AddWatermarkAsBackgroundToExcel
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Adds watermark as background with relative size and position to Excel worksheet
            /// </summary> 
            public static void AddWatermarkAsBackgroundWithRelativeSizeAndPosition()
            {
                try
                {
                    //ExStart:AddWatermarkAsBackgroundWithRelativeSizeAndPosition
                    using (CellsDocument doc = Document.Load<CellsDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        using (ImageWatermark watermark = new ImageWatermark(@"D:\logo.gif"))
                        {
                            watermark.HorizontalAlignment = HorizontalAlignment.Center;
                            watermark.VerticalAlignment = VerticalAlignment.Center;
                            watermark.RotateAngle = 90;
                            watermark.SizingType = SizingType.ScaleToParentDimensions;
                            watermark.ScaleFactor = 0.5;
                            doc.Worksheets[0].AddWatermarkAsBackground(
                                  watermark,
                                  doc.Worksheets[0].ContentAreaWidthPx /*set background width*/,
                                  doc.Worksheets[0].ContentAreaHeightPx /*set background height*/);
                        }

                        doc.Save();
                    }
                    //ExEnd:AddWatermarkAsBackgroundWithRelativeSizeAndPosition
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Adds watermark text as background to Excel worksheet
            /// <param name="WatermarkText"></param>
            /// </summary> 
            public static void AddWatermarkAsBackground(string WatermarkText)
            {
                try
                {
                    //ExStart:AddWatermarkTextAsBackgroundToExcel
                    using (CellsDocument doc = Document.Load<CellsDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        TextWatermark watermark = new TextWatermark(WatermarkText, new Font("Segoe UI", 19));
                        watermark.HorizontalAlignment = HorizontalAlignment.Center;
                        watermark.VerticalAlignment = VerticalAlignment.Center;
                        watermark.RotateAngle = 45;
                        watermark.SizingType = SizingType.ScaleToParentDimensions;
                        watermark.ScaleFactor = 0.5;
                        watermark.Opacity = 0.5;
                        doc.Worksheets[0].AddWatermarkAsBackground(
                              watermark,
                              doc.Worksheets[0].ContentAreaWidthPx /*set background width*/,
                              doc.Worksheets[0].ContentAreaHeightPx /*set background height*/);
                        doc.Save();
                    }
                    //ExEnd:AddWatermarkTextAsBackgroundToExcel
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Adds image watermark into header/footer of Excel worksheet
            /// </summary> 
            public static void AddWatermarkIntoHeaderFooter()
            {
                try
                {
                    //ExStart:AddImageWatermarkIntoHeaderFooter
                    using (CellsDocument doc = Document.Load<CellsDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        using (var watermark = new ImageWatermark(@"D:\logo.tif"))
                        {
                            watermark.VerticalAlignment = VerticalAlignment.Top;
                            watermark.HorizontalAlignment = HorizontalAlignment.Center;
                            watermark.SizingType = SizingType.ScaleToParentDimensions;
                            watermark.ScaleFactor = 1;
                            doc.Worksheets[0].AddWatermarkIntoHeaderFooter(watermark);
                        }
                        doc.Save();
                    }
                    //ExEnd:AddImageWatermarkIntoHeaderFooter
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Adds text watermark into header/footer of Excel worksheet
            /// <param name="WatermarkText"></param>
            /// </summary> 
            public static void AddWatermarkIntoHeaderFooter(string WatermarkText)
            {
                try
                {
                    //ExStart:AddTextWatermarkIntoHeaderFooter
                    using (CellsDocument doc = Document.Load<CellsDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        TextWatermark watermark = new TextWatermark(WatermarkText, new Font("Segoe UI", 19, FontStyle.Bold));
                        watermark.ForegroundColor = Color.Red;
                        watermark.BackgroundColor = Color.Aqua;
                        watermark.VerticalAlignment = VerticalAlignment.Top;
                        watermark.HorizontalAlignment = HorizontalAlignment.Center;
                        doc.Worksheets[0].AddWatermarkIntoHeaderFooter(watermark);
                        doc.Save();
                    }
                    //ExEnd:AddTextWatermarkIntoHeaderFooter
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Removes watermark from Excel worksheet
            /// </summary> 
            public static void RemoveWatermark()
            {
                try
                {
                    //ExStart:RemoveWatermarkExcelWorksheet
                    using (CellsDocument doc = Document.Load<CellsDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        // Initialize search criteria
                        ImageSearchCriteria imageSearchCriteria = new ImageDctHashSearchCriteria(@"D:\logo.png");
                        TextSearchCriteria textSearchCriteria = new TextSearchCriteria("Company Name");

                        // Call FindWatermarks method for the worksheet
                        PossibleWatermarkCollection possibleWatermarks = doc.Worksheets[0].FindWatermarks(textSearchCriteria.Or(imageSearchCriteria));

                        // Remove all found watermarks
                        for (var i = possibleWatermarks.Count - 1; i >= 0; i--)
                        {
                            possibleWatermarks.RemoveAt(i);
                        }

                        doc.Save();
                    }
                    //ExEnd:RemoveWatermarkExcelWorksheet
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Extracts information about all the shapes is a Excel document 
            /// </summary> 
            public static void GetShapesInformation()
            {
                try
                {
                    //ExStart:GetShapesInformationExcel
                    using (CellsDocument doc = Document.Load<CellsDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        foreach (CellsWorksheet worksheet in doc.Worksheets)
                        {
                            foreach (CellsShape shape in worksheet.Shapes)
                            {
                                Console.WriteLine(shape.AutoShapeType);
                                Console.WriteLine(shape.MsoDrawingType);
                                Console.WriteLine(shape.Text);
                                if (shape.Image != null)
                                {
                                    Console.WriteLine(shape.Image.Width);
                                    Console.WriteLine(shape.Image.Height);
                                    Console.WriteLine(shape.Image.GetBytes().Length);
                                }
                                Console.WriteLine(shape.Id);
                                Console.WriteLine(shape.AlternativeText);
                                Console.WriteLine(shape.X);
                                Console.WriteLine(shape.Y);
                                Console.WriteLine(shape.Width);
                                Console.WriteLine(shape.Height);
                                Console.WriteLine(shape.RotateAngle);
                                Console.WriteLine(shape.IsWordArt);
                                Console.WriteLine(shape.Name);
                            }
                        }
                    }
                    //ExEnd:GetShapesInformationExcel
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Removes shape in an Excel worksheet 
            /// </summary> 
            public static void RemoveShape()
            {
                try
                {
                    //ExStart:RemoveShapeExcelWorksheet
                    using (CellsDocument doc = Document.Load<CellsDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        // Remove shape by index
                        doc.Worksheets[0].Shapes.RemoveAt(0);

                        // Remove shape by reference
                        doc.Worksheets[0].Shapes.Remove(doc.Worksheets[0].Shapes[0]);

                        doc.Save();
                    }
                    //ExEnd:RemoveShapeExcelWorksheet
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Adds watermark to all image shapes in a Excel document 
            /// </summary> 
            public static void AddWatermarkToImageShapes()
            {
                try
                {
                    //ExStart:AddWatermarkToImageShapesExcelDocument
                    using (CellsDocument doc = Document.Load<CellsDocument>(@"D:\test.xlsx"))
                    {
                        // Initialize image or text watermark
                        TextWatermark watermark = new TextWatermark("Protected image", new Font("Arial", 8));
                        watermark.HorizontalAlignment = HorizontalAlignment.Center;
                        watermark.VerticalAlignment = VerticalAlignment.Center;
                        watermark.RotateAngle = 45;
                        watermark.SizingType = SizingType.ScaleToParentDimensions;
                        watermark.ScaleFactor = 1;

                        foreach (CellsWorksheet worksheet in doc.Worksheets)
                        {
                            foreach (CellsShape shape in worksheet.Shapes)
                            {
                                if (shape.Image != null)
                                {
                                    // Add watermark to the image
                                    shape.Image.AddWatermark(watermark);
                                }
                            }
                        }

                        doc.Save();
                    }
                    //ExEnd:AddWatermarkToImageShapesExcelDocument
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Gets information about all worksheet backgrounds in a Excel document 
            /// </summary> 
            public static void GetInformationOfWorksheetBackgrounds()
            {
                try
                {
                    //ExStart:GetInformationOfWorksheetBackgrounds
                    using (CellsDocument doc = Document.Load<CellsDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        foreach (CellsWorksheet worksheet in doc.Worksheets)
                        {
                            if (worksheet.BackgroundImage != null)
                            {
                                Console.WriteLine(worksheet.BackgroundImage.Width);
                                Console.WriteLine(worksheet.BackgroundImage.Height);
                                Console.WriteLine(worksheet.BackgroundImage.GetBytes().Length);
                            }
                        }
                    }
                    //ExEnd:GetInformationOfWorksheetBackgrounds
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Removes background in a Excel worksheet 
            /// </summary> 
            public static void RemoveWorksheetBackground()
            {
                try
                {
                    //ExStart:RemoveWorksheetBackground
                    using (CellsDocument doc = Document.Load<CellsDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        doc.Worksheets[0].BackgroundImage = null;
                        doc.Save();
                    }
                    //ExEnd:RemoveWorksheetBackground
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Adds watermark to all background images in a Excel worksheet 
            /// </summary> 
            public static void AddWatermarkToBackgroundImages()
            {
                try
                {
                    //ExStart:AddWatermarkToBackgroundImagesExcel
                    using (CellsDocument doc = Document.Load<CellsDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        // Initialize image or text watermark
                        TextWatermark watermark = new TextWatermark("Protected image", new Font("Arial", 8));
                        watermark.HorizontalAlignment = HorizontalAlignment.Center;
                        watermark.VerticalAlignment = VerticalAlignment.Center;
                        watermark.RotateAngle = 45;
                        watermark.SizingType = SizingType.ScaleToParentDimensions;
                        watermark.ScaleFactor = 1;

                        foreach (CellsWorksheet worksheet in doc.Worksheets)
                        {
                            if (worksheet.BackgroundImage != null)
                            {
                                // Add watermark to the image
                                worksheet.BackgroundImage.AddWatermark(watermark);
                            }
                        }
                        doc.Save();
                    }
                    //ExEnd:AddWatermarkToBackgroundImagesExcel
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Gets information about all headers/footers in a Excel document 
            /// </summary> 
            public static void GetHeaderFooterInformation()
            {
                try
                {
                    //ExStart:GetHeaderFooterInformationExcel
                    using (CellsDocument doc = Document.Load<CellsDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        foreach (CellsWorksheet worksheet in doc.Worksheets)
                        {
                            foreach (CellsHeaderFooter headerFooter in worksheet.HeadersFooters)
                            {
                                Console.WriteLine(headerFooter.HeaderFooterType);
                                foreach (CellsHeaderFooterSection section in headerFooter.Sections)
                                {
                                    Console.WriteLine(section.SectionType);
                                    if (section.Image != null)
                                    {
                                        Console.WriteLine(section.Image.Width);
                                        Console.WriteLine(section.Image.Height);
                                        Console.WriteLine(section.Image.GetBytes().Length);
                                    }
                                    Console.WriteLine(section.Script);
                                }
                            }
                        }
                    }
                    //ExEnd:GetHeaderFooterInformationExcel
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Clears particular headers/footers in a Excel worksheet 
            /// </summary> 
            public static void ClearHeaderFooter()
            {
                try
                {
                    //ExStart:ClearHeaderFooterExcel
                    using (CellsDocument doc = Document.Load<CellsDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        foreach (CellsHeaderFooterSection section in doc.Worksheets[0].HeadersFooters[OfficeHeaderFooterType.HeaderPrimary].Sections)
                        {
                            section.Script = null;
                            section.Image = null;
                        }
                        doc.Save();
                    }
                    //ExEnd:ClearHeaderFooterExcel
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Clears particular section of headers/footers in a Excel worksheet 
            /// </summary> 
            public static void ClearSectionOfHeaderFooter()
            {
                try
                {
                    //ExStart:ClearSectionOfHeaderFooterExcel
                    using (CellsDocument doc = Document.Load<CellsDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        CellsHeaderFooterSection section = doc.Worksheets[0]
                           .HeadersFooters[OfficeHeaderFooterType.HeaderEven]
                           .Sections[CellsHeaderFooterSectionType.Left];
                        section.Image = null;
                        section.Script = null;

                        doc.Save();
                    }
                    //ExEnd:ClearSectionOfHeaderFooterExcel
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Adds watermark to all images of headers/footers in a Excel worksheet 
            /// </summary> 
            public static void AddWatermarkToImagesInHeaderFooter()
            {
                try
                {
                    //ExStart:AddWatermarkToImagesInHeaderFooterExcel
                    using (CellsDocument doc = Document.Load<CellsDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        // Initialize image or text watermark
                        TextWatermark watermark = new TextWatermark("Protected image", new Font("Arial", 8));
                        watermark.HorizontalAlignment = HorizontalAlignment.Center;
                        watermark.VerticalAlignment = VerticalAlignment.Center;
                        watermark.RotateAngle = 45;
                        watermark.SizingType = SizingType.ScaleToParentDimensions;
                        watermark.ScaleFactor = 1;

                        foreach (CellsWorksheet worksheet in doc.Worksheets)
                        {
                            foreach (CellsHeaderFooter headerFooter in worksheet.HeadersFooters)
                            {
                                foreach (CellsHeaderFooterSection section in headerFooter.Sections)
                                {
                                    if (section.Image != null)
                                    {
                                        // Add watermark to the image
                                        section.Image.AddWatermark(watermark);
                                    }
                                }
                            }
                        }
                    }
                    //ExEnd:AddWatermarkToImagesInHeaderFooterExcel
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Sets background image for a chart in a Excel worksheet 
            /// </summary> 
            public static void SetBackgroundImageForChart()
            {
                try
                {
                    //ExStart:SetBackgroundImageForChart
                    using (CellsDocument doc = Document.Load<CellsDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        doc.Worksheets[0].Charts[0].ImageFillFormat.BackgroundImage = new CellsWatermarkableImage(File.ReadAllBytes(@"D:\test.png"));
                        doc.Worksheets[0].Charts[0].ImageFillFormat.Transparency = 0.5;
                        doc.Worksheets[0].Charts[0].ImageFillFormat.TileAsTexture = true;
                        doc.Save();
                    }
                    //ExEnd:SetBackgroundImageForChart
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Removes all text shapes with a particular text formatting in a Excel document 
            /// </summary> 
            public static void RemoveTextShapesWithParticularTextFormatting()
            {
                try
                {
                    //ExStart:RemoveTextShapesWithParticularTextFormattingExcel
                    using (CellsDocument doc = Document.Load<CellsDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        foreach (CellsWorksheet section in doc.Worksheets)
                        {
                            for (var i = section.Shapes.Count - 1; i >= 0; i--)
                            {
                                foreach (var fragment in section.Shapes[i].FormattedTextFragments)
                                {
                                    if (fragment.ForegroundColor == Color.Red && fragment.Font.FamilyName == "Arial")
                                    {
                                        section.Shapes.RemoveAt(i);
                                        break;
                                    }
                                }
                            }
                        }
                        doc.Save();
                    }
                    //ExEnd:RemoveTextShapesWithParticularTextFormattingExcel
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Removes hyperlink associated with a particular shape or chart inside a Excel document
            /// </summary> 
            public static void RemoveHyperlinks()
            {
                try
                {
                    //ExStart:RemoveHyperlinksExcel
                    using (CellsDocument doc = Document.Load<CellsDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        // Replace hyperlink
                        doc.Worksheets[0].Charts[0].Hyperlink = "https://www.aspose.com/";
                        doc.Worksheets[0].Shapes[0].Hyperlink = "https://www.groupdocs.com/";

                        // Remove hyperlink
                        doc.Worksheets[1].Charts[0].Hyperlink = null;
                        doc.Worksheets[1].Shapes[0].Hyperlink = null;

                        doc.Save();  
                    }
                    //ExEnd:RemoveHyperlinksExcel
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }
        }
        public static class PowerPoint
        {
            // initialize file path
            //ExStart:SourcePowerPointFilePath
            private const string FilePath = "Documents/sample.pptx";
            //ExEnd:SourcePowerPointFilePath

            /// <summary>
            /// Adds watermark to a PowerPoint slide
            /// </summary> 
            public static void AddWatermark()
            {
                try
                {
                    //ExStart:AddWatermarkToPowerPointSlide
                    using (SlidesDocument doc = Document.Load<SlidesDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        // Add text watermark
                        TextWatermark textWatermark = new TextWatermark("Test watermark", new Font("Arial", 8));
                        doc.Slides[0].AddWatermark(textWatermark);

                        // Add image watermark
                        using (ImageWatermark imageWatermark = new ImageWatermark(@"D:\logo.jpg"))
                        {
                            doc.Slides[1].AddWatermark(imageWatermark);
                        }
                        doc.Save();
                    }
                    //ExEnd:AddWatermarkToPowerPointSlide
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Gets dimensions of a PowerPoint slide
            /// </summary> 
            public static void GetDimensionsOfSlide()
            {
                try
                {
                    //ExStart:GetDimensionsOfSlide
                    using (SlidesDocument doc = Document.Load<SlidesDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        Console.WriteLine(doc.SlideWidth);
                        Console.WriteLine(doc.SlideHeight);
                    }
                    //ExEnd:GetDimensionsOfSlide
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Adds watermark to all images of a PowerPoint slide
            /// </summary> 
            public static void AddWatermarkToImages()
            {
                try
                {
                    //ExStart:AddWatermarkToImagesPowerPointSlide
                    using (SlidesDocument doc = Document.Load<SlidesDocument>(@"D:\test.pptx"))
                    {
                        TextWatermark watermark = new TextWatermark("Protected image", new Font("Arial", 8));
                        watermark.HorizontalAlignment = HorizontalAlignment.Center;
                        watermark.VerticalAlignment = VerticalAlignment.Center;
                        watermark.RotateAngle = 45;
                        watermark.SizingType = SizingType.ScaleToParentDimensions;
                        watermark.ScaleFactor = 1;

                        // Get all images from the first slide
                        WatermarkableImageCollection images = doc.Slides[0].FindImages();

                        // Add watermark to all found images
                        foreach (WatermarkableImage image in images)
                        {
                            image.AddWatermark(watermark);
                        }

                        doc.Save();
                    }
                    //ExEnd:AddWatermarkToImagesPowerPointSlide
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Adds watermark to all slide types of PowerPoint document
            /// </summary> 
            public static void AddWatermarkToAllSlideTypes()
            {
                try
                {
                    //ExStart:AddWatermarkToAllSlideTypes
                    using (SlidesDocument doc = Document.Load<SlidesDocument>(@"D:\test.pptx"))
                    {
                        TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 8));

                        // Add watermark to all master slides
                        foreach (SlidesMasterSlide slide in doc.MasterSlides)
                        {
                            slide.AddWatermark(watermark);
                        }

                        // Add watermark to all layout slides
                        if (doc.LayoutSlides != null)
                        {
                            foreach (SlidesLayoutSlide slide in doc.LayoutSlides)
                            {
                                slide.AddWatermark(watermark);
                            }
                        }

                        // Add watermark to all notes slides
                        foreach (SlidesSlide slide in doc.Slides)
                        {
                            if (slide.NotesSlide != null)
                            {
                                slide.NotesSlide.AddWatermark(watermark);
                            }
                        }

                        // Add watermark to handout master
                        if (doc.MasterHandoutSlide != null)
                        {
                            doc.MasterHandoutSlide.AddWatermark(watermark);
                        }

                        // Add watermark to notes master
                        if (doc.MasterNotesSlide != null)
                        {
                            doc.MasterNotesSlide.AddWatermark(watermark);
                        }
                        doc.Save();
                    }
                    //ExEnd:AddWatermarkToAllSlideTypes
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Adds watermark to a PowerPoint slide with Slides Shape Settings
            /// </summary> 
            public static void AddWatermarkWithSlidesShapeSettings()
            {
                try
                {
                    //ExStart:AddWatermarkWithSlidesShapeSettings
                    using (SlidesDocument doc = Document.Load<SlidesDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 19));
                        watermark.IsBackground = true;
                        SlidesShapeSettings shapeSettings = new SlidesShapeSettings();

                        // Set the shape name
                        shapeSettings.Name = "Shape 1";

                        // Set the descriptive (alternative) text that will be associated with the shape
                        shapeSettings.AlternativeText = "Test watermark";

                        // Editing of the shape in PowerPoint is forbidden
                        shapeSettings.IsLocked = true;

                        doc.AddWatermark(watermark, shapeSettings);

                        doc.Save();
                    }
                    //ExEnd:AddWatermarkWithSlidesShapeSettings
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Adds watermark with text effects to a PowerPoint slide
            /// </summary> 
            public static void AddWatermarkWithTextEffects()
            {
                try
                {
                    //ExStart:AddWatermarkWithTextEffectsPowerPointSlide
                    using (SlidesDocument doc = Document.Load<SlidesDocument>(@"D:\test.pptx"))
                    {
                        TextWatermark watermark = new TextWatermark("Test watermark", new Font("Segoe UI", 19));

                        SlidesTextEffects effects = new SlidesTextEffects();
                        effects.LineFormat.Enabled = true;
                        effects.LineFormat.Color = Color.Red;
                        effects.LineFormat.DashStyle = OfficeDashStyle.DashDotDot;
                        effects.LineFormat.LineStyle = OfficeLineStyle.Triple;
                        effects.LineFormat.Weight = 1;
                        doc.AddTextWatermark(watermark, effects);
                        doc.Save();
                    }
                    //ExEnd:AddWatermarkWithTextEffectsPowerPointSlide
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Adds watermark with image effects to a PowerPoint slide
            /// </summary> 
            public static void AddWatermarkWithImageEffects()
            {
                try
                {
                    //ExStart:AddWatermarkWithImageEffectsPowerPointSlide
                    using (SlidesDocument doc = Document.Load<SlidesDocument>(@"D:\test.pptx"))
                    {
                        using (var watermark = new ImageWatermark(@"D:\logo.png"))
                        {
                            SlidesImageEffects effects = new SlidesImageEffects();
                            effects.Brightness = 0.7;
                            effects.Contrast = 0.6;
                            effects.ChromaKey = Color.Red;
                            effects.BorderLineFormat.Enabled = true;
                            effects.BorderLineFormat.Weight = 1;
                            doc.AddImageWatermark(watermark, effects);
                        }
                        doc.Save();
                    }
                    //ExEnd:AddWatermarkWithImageEffectsPowerPointSlide
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Removes watermark from PowerPoint slide
            /// </summary> 
            public static void RemoveWatermark()
            {
                try
                {
                    //ExStart:RemoveWatermarkPowerPoint
                    using (SlidesDocument doc = Document.Load<SlidesDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        // Initialize search criteria
                        ImageSearchCriteria imageSearchCriteria = new ImageDctHashSearchCriteria(@"D:\logo.png");
                        TextSearchCriteria textSearchCriteria = new TextSearchCriteria("Company Name");

                        // Call FindWatermarks method for the slide
                        PossibleWatermarkCollection possibleWatermarks = doc.Slides[0].FindWatermarks(textSearchCriteria.Or(imageSearchCriteria));

                        // Remove all found watermarks
                        for (var i = possibleWatermarks.Count - 1; i >= 0; i--)
                        {
                            possibleWatermarks.RemoveAt(i);
                        }

                        doc.Save();
                    }
                    //ExEnd:RemoveWatermarkPowerPoint
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Extracts information about all the shapes in PowerPoint slide 
            /// </summary> 
            public static void GetShapesInformation()
            {
                try
                {
                    //ExStart:GetShapesInformationPowerPoint
                    using (SlidesDocument doc = Document.Load<SlidesDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        foreach (SlidesSlide slide in doc.Slides)
                        {
                            foreach (SlidesShape shape in slide.Shapes)
                            {
                                if (shape.Image != null)
                                {
                                    Console.WriteLine(shape.Image.Width);
                                    Console.WriteLine(shape.Image.Height);
                                    Console.WriteLine(shape.Image.GetBytes().Length);
                                }
                                Console.WriteLine(shape.Name);
                                Console.WriteLine(shape.AlternativeText);
                                Console.WriteLine(shape.X);
                                Console.WriteLine(shape.Y);
                                Console.WriteLine(shape.Width);
                                Console.WriteLine(shape.Height);
                                Console.WriteLine(shape.RotateAngle);
                                Console.WriteLine(shape.Text);
                                Console.WriteLine(shape.Id);
                                Console.WriteLine(shape.ShapeType);
                                Console.WriteLine(shape.ZOrderPosition);
                            }
                        }
                    }
                    //ExEnd:GetShapesInformationPowerPoint
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Remove shape from PowerPoint slide
            /// </summary> 
            public static void RemoveShape()
            {
                try
                {
                    //ExStart:RemoveShapePowerPoint
                    using (SlidesDocument doc = Document.Load<SlidesDocument>(@"D:\test.pptx"))
                    {
                        // Remove shape by index
                        doc.Slides[0].Shapes.RemoveAt(0);

                        // Remove shape by reference
                        doc.Slides[0].Shapes.Remove(doc.Slides[0].Shapes[0]);

                        doc.Save();
                    }
                    //ExEnd:RemoveShapePowerPoint
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Adds watermark to all image shapes in a PowerPoint document 
            /// </summary> 
            public static void AddWatermarkToImageShapes()
            {
                try
                {
                    //ExStart:AddWatermarkToImageShapesPowerPointDocument
                    using (SlidesDocument doc = Document.Load<SlidesDocument>(@"D:\test.pptx"))
                    {
                        // Initialize image or text watermark
                        TextWatermark watermark = new TextWatermark("Protected image", new Font("Arial", 8));
                        watermark.HorizontalAlignment = HorizontalAlignment.Center;
                        watermark.VerticalAlignment = VerticalAlignment.Center;
                        watermark.RotateAngle = 45;
                        watermark.SizingType = SizingType.ScaleToParentDimensions;
                        watermark.IsBackground = true;
                        watermark.ScaleFactor = 1;

                        foreach (SlidesSlide slide in doc.Slides)
                        {
                            foreach (SlidesShape shape in slide.Shapes)
                            {
                                if (shape.Image != null)
                                {
                                    // Add watermark to the image
                                    shape.Image.AddWatermark(watermark);
                                }
                            }
                        }

                        doc.Save();
                    }
                    //ExEnd:AddWatermarkToImageShapesPowerPointDocument
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Gets information of all slide backgrounds of a PowerPoint document 
            /// </summary> 
            public static void GetInformationOfSlideBackgrounds()
            {
                try
                {
                    //ExStart:GetInformationOfSlideBackgroundsPowerPointDocument
                    using (SlidesDocument doc = Document.Load<SlidesDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        foreach (SlidesSlide slide in doc.Slides)
                        {
                            if (slide.BackgroundImage != null)
                            {
                                Console.WriteLine(slide.BackgroundImage.Width);
                                Console.WriteLine(slide.BackgroundImage.Height);
                                Console.WriteLine(slide.BackgroundImage.GetBytes().Length);
                            }
                        }
                    }
                    //ExEnd:GetInformationOfSlideBackgroundsPowerPointDocument
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Removes background of a PowerPoint slide 
            /// </summary> 
            public static void RemoveBackground()
            {
                try
                {
                    //ExStart:RemoveBackgroundPowerPointSlide
                    using (SlidesDocument doc = Document.Load<SlidesDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        doc.Slides[0].BackgroundImage = null;
                    }
                    //ExEnd:RemoveBackgroundPowerPointSlide
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Adds watermark to all background images of a PowerPoint slide 
            /// </summary> 
            public static void AddWatermarkToAllBackgroundImages()
            {
                try
                {
                    //ExStart:AddWatermarkToAllBackgroundImagesPowerPointSlide
                    using (SlidesDocument doc = Document.Load<SlidesDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        // Initialize image or text watermark
                        TextWatermark watermark = new TextWatermark("Protected image", new Font("Arial", 8));
                        watermark.HorizontalAlignment = HorizontalAlignment.Center;
                        watermark.VerticalAlignment = VerticalAlignment.Center;
                        watermark.RotateAngle = 45;
                        watermark.SizingType = SizingType.ScaleToParentDimensions;
                        watermark.ScaleFactor = 1;

                        foreach (SlidesSlide slide in doc.Slides)
                        {
                            if (slide.BackgroundImage != null)
                            {
                                // Add watermark to the image
                                slide.BackgroundImage.AddWatermark(watermark);
                            }
                        }

                        doc.Save();
                    }
                    //ExEnd:AddWatermarkToAllBackgroundImagesPowerPointSlide
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Sets tiled semitransparent image background for a particular slide.
            /// </summary> 
            public static void SetTiledSemitransparentBackground()
            {
                try
                {
                    //ExStart:SetTiledSemitransparentBackground
                    using (SlidesDocument doc = Document.Load<SlidesDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        SlidesSlide slide = doc.Slides[0];
                        slide.ImageFillFormat.BackgroundImage = new SlidesWatermarkableImage(File.ReadAllBytes(@"D:\background.png"));
                        slide.ImageFillFormat.TileAsTexture = true;
                        slide.ImageFillFormat.Transparency = 0.5;
                        doc.Save();
                    }
                    //ExEnd:SetTiledSemitransparentBackground
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Sets background image for a chart in a PowerPoint presentation
            /// </summary> 
            public static void SetBackgroundImageForChart()
            {
                try
                {
                    //ExStart:SetBackgroundImageForChartPowerPoint
                    using (SlidesDocument doc = Document.Load<SlidesDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        doc.Slides[0].Charts[0].ImageFillFormat.BackgroundImage = new SlidesWatermarkableImage(File.ReadAllBytes(@"D:\test.png"));
                        doc.Slides[0].Charts[0].ImageFillFormat.Transparency = 0.5;
                        doc.Slides[0].Charts[0].ImageFillFormat.TileAsTexture = true;
                        doc.Save();
                    }
                    //ExEnd:SetBackgroundImageForChartPowerPoint
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Removes all text shapes with a particular text formatting in a PowerPoint document 
            /// </summary> 
            public static void RemoveTextShapesWithParticularTextFormatting()
            {
                try
                {
                    //ExStart:RemoveTextShapesWithParticularTextFormattingPowerPoint
                    using (SlidesDocument doc = Document.Load<SlidesDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        foreach (SlidesSlide slide in doc.Slides)
                        {
                            for (var i = slide.Shapes.Count - 1; i >= 0; i--)
                            {
                                foreach (var fragment in slide.Shapes[i].FormattedTextFragments)
                                {
                                    if (fragment.ForegroundColor == Color.Red && fragment.Font.FamilyName == "Arial")
                                    {
                                        slide.Shapes.RemoveAt(i);
                                        break;
                                    }
                                }
                            }
                        }
                        doc.Save();
                    }
                    //ExEnd:RemoveTextShapesWithParticularTextFormattingPowerPoint
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Removes hyperlink associated with a particular shape or chart inside a PowerPoint document
            /// </summary> 
            public static void RemoveHyperlinks()
            {
                try
                {
                    //ExStart:RemoveHyperlinksPowerPoint
                    using (SlidesDocument doc = Document.Load<SlidesDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        // Replace hyperlink
                        doc.Slides[0].Charts[0].SetHyperlink(SlidesHyperlinkActionType.MouseClick, "https://www.aspose.com/");
                        doc.Slides[0].Shapes[0].SetHyperlink(SlidesHyperlinkActionType.MouseClick,"https://www.groupdocs.com/");

                        // Remove hyperlink
                        doc.Slides[1].Charts[0].SetHyperlink(SlidesHyperlinkActionType.MouseClick,null);
                        doc.Slides[1].Shapes[0].SetHyperlink(SlidesHyperlinkActionType.MouseClick, null);

                        doc.Save();
                    }
                    //ExEnd:RemoveHyperlinksPowerPoint
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Replaces hyperlinks that are activated on mouse over
            /// </summary> 
            public static void ReplaceMouseOverHyperlinks()
            {
                try
                {
                    //ExStart:ReplaceMouseOverHyperlinks
                    using (SlidesDocument doc = Document.Load<SlidesDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        foreach (var slide in doc.Slides)
                        {
                            string oldUrl = "http://aspose.com/";

                            // Assign null to remove hyperlink
                            string newUrl = "http://groupdocs.com/";

                            // Replace hyperlinks in shapes
                            foreach (var shape in slide.Shapes)
                            {
                                ReplaceHyperlink(shape, SlidesHyperlinkActionType.MouseOver, oldUrl, newUrl);
                                ReplaceHyperlink(shape, SlidesHyperlinkActionType.MouseClick, oldUrl, newUrl);

                                // Replace hyperlinks in text fragments
                                foreach (var fragment in shape.FormattedTextFragments)
                                {
                                    ReplaceHyperlink((ISlidesHyperlinkContainer)fragment, SlidesHyperlinkActionType.MouseClick, oldUrl, newUrl);
                                    ReplaceHyperlink((ISlidesHyperlinkContainer)fragment, SlidesHyperlinkActionType.MouseOver, oldUrl, newUrl);
                                }
                            }

                            // Replace hyperlinks in charts
                            foreach (var chart in slide.Charts)
                            {
                                ReplaceHyperlink(chart, SlidesHyperlinkActionType.MouseOver, oldUrl, newUrl);
                                ReplaceHyperlink(chart, SlidesHyperlinkActionType.MouseClick, oldUrl, newUrl);
                            }
                        }

                        // Save changes
                        doc.Save();
                    }
                    //ExEnd:ReplaceMouseOverHyperlinks
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            private static void ReplaceHyperlink(ISlidesHyperlinkContainer hyperlinkContainer, SlidesHyperlinkActionType hyperlinkActionType, string oldUrl, string newUrl)
            {
                if (hyperlinkContainer.GetHyperlink(hyperlinkActionType) == oldUrl)
                {
                    hyperlinkContainer.SetHyperlink(hyperlinkActionType, newUrl);
                }
            }

            /// <summary>
            /// Removes hyperlinks of all types using FindWatermarks method
            /// </summary> 
            public static void RemoveHyperlinksUsingFindWatermark()
            {
                try
                {
                    //ExStart:RemoveHyperlinksUsingFindWatermark
                    using (SlidesDocument doc = Document.Load<SlidesDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        doc.SearchableObjects.SlidesSearchableObjects = SlidesSearchableObjects.Hyperlinks;

                        // Find all hyperlinks
                        var watermarks = doc.FindWatermarks();

                        // Remove found watermarks
                        watermarks.Clear();

                        // Save changes
                        doc.Save();
                    }
                    //ExEnd:RemoveHyperlinksUsingFindWatermark
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

        }
        public static class Visio
        {
            // initialize file path
            //ExStart:SourceVisioFilePath
            private const string FilePath = "Documents/sample.vsdx";
            //ExEnd:SourceVisioFilePath

            /// <summary>
            /// Adds watermark to all pages of a particular type 
            /// </summary> 
            public static void AddWatermarkToAllPagesOfParticularType()
            {
                try
                {
                    //ExStart:AddWatermarkToAllPagesOfParticularType
                    using (DiagramDocument doc = Document.Load<DiagramDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        // Initialize text watermark
                        TextWatermark textWatermark = new TextWatermark("Test watermark 1", new Font("Calibri", 19));

                        // Add text watermark to all background pages
                        doc.AddWatermark(textWatermark, DiagramWatermarkPlacementType.BackgroundPages);

                        // Initialize image watermark
                        using (ImageWatermark imageWatermark = new ImageWatermark(@"D:\logo.jpg"))
                        {
                            // Add image watermark to all background pages
                            doc.AddWatermark(imageWatermark, DiagramWatermarkPlacementType.ForegroundPages);
                        }
                        doc.Save();
                    }
                    //ExEnd:AddWatermarkToAllPagesOfParticularType
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Adds watermark to separate newly created backround pages 
            /// </summary> 
            public static void AddWatermarkToSeparateBackgroundPage()
            {
                try
                {
                    //ExStart:AddWatermarkToSeparateBackgroundPage
                    using (DiagramDocument doc = Document.Load<DiagramDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        // Initialize watermark of any supported type
                        TextWatermark textWatermark = new TextWatermark("Test watermark 1", new Font("Calibri", 19));

                        // Create separate background for each page where it is not set. Add watermark to it.
                        doc.AddWatermark(textWatermark, DiagramWatermarkPlacementType.SeparateBackgrounds);

                        doc.Save();
                    }
                    //ExEnd:AddWatermarkToSeparateBackgroundPage
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Adds watermark to a particular page
            /// </summary> 
            public static void AddWatermarkToParticularPage()
            {
                try
                {
                    //ExStart:AddWatermarkToParticularPage
                    using (DiagramDocument doc = Document.Load<DiagramDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        // Add text watermark
                        TextWatermark textWatermark = new TextWatermark("Test watermark", new Font("Calibri", 19));
                        doc.Pages[0].AddWatermark(textWatermark);

                        // Add image watermark
                        using (ImageWatermark imageWatermark = new ImageWatermark(@"D:\logo.jpg"))
                        {
                            doc.Pages[1].AddWatermark(imageWatermark);
                        }
                        doc.Save();
                    }
                    //ExEnd:AddWatermarkToParticularPage
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Gets information about the pages
            /// </summary> 
            public static void GetPagesInformation()
            {
                try
                {
                    //ExStart:GetPagesInformationVisio
                    using (DiagramDocument doc = Document.Load<DiagramDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        foreach (DiagramPage page in doc.Pages)
                        {
                            Console.WriteLine(page.Width);
                            Console.WriteLine(page.Height);
                            Console.WriteLine(page.LeftMargin);
                            Console.WriteLine(page.RightMargin);
                            Console.WriteLine(page.TopMargin);
                            Console.WriteLine(page.BottomMargin);
                            Console.WriteLine(page.Name);
                            Console.WriteLine(page.IsBackground);
                            Console.WriteLine(page.IsVisible);
                            if (page.BackgroundPage != null)
                            {
                                Console.WriteLine(page.BackgroundPage.Name);
                            }
                        }
                    }
                    //ExEnd:GetPagesInformationVisio
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Adds watermark to all images of a particular page
            /// </summary> 
            public static void AddWatermarkToImages()
            {
                try
                {
                    //ExStart:AddWatermarkToImagesVisio
                    using (DiagramDocument doc = Document.Load<DiagramDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        TextWatermark watermark = new TextWatermark("Protected image", new Font("Arial", 8));
                        watermark.HorizontalAlignment = HorizontalAlignment.Center;
                        watermark.VerticalAlignment = VerticalAlignment.Center;
                        watermark.RotateAngle = 45;
                        watermark.SizingType = SizingType.ScaleToParentDimensions;
                        watermark.ScaleFactor = 1;

                        // Get all images from the first slide
                        WatermarkableImageCollection images = doc.Pages[0].FindImages();

                        // Add watermark to all found images
                        foreach (WatermarkableImage image in images)
                        {
                            image.AddWatermark(watermark);
                        }

                        doc.Save();
                    }
                    //ExEnd:AddWatermarkToImagesVisio
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Locks the watermark shape to prevent editing in MS Visio
            /// </summary> 
            public static void LockWatermarkShape()
            {
                try
                {
                    //ExStart:LockWatermarkShape
                    using (DiagramDocument doc = Document.Load<DiagramDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 19));

                        // Editing of the shape in Visio is forbidden
                        doc.AddWatermark(watermark, new DiagramShapeSettings { IsLocked = true });

                        doc.Save();
                    }
                    //ExEnd:LockWatermarkShape
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Removes watermark from a particular page
            /// </summary> 
            public static void RemoveWatermark()
            {
                try
                {
                    //ExStart:RemoveWatermarkVisio
                    using (DiagramDocument doc = Document.Load<DiagramDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        // Initialize search criteria
                        ImageSearchCriteria imageSearchCriteria = new ImageDctHashSearchCriteria(@"D:\logo.png");
                        TextSearchCriteria textSearchCriteria = new TextSearchCriteria("Company Name");

                        // Call FindWatermarks method for the first page
                        PossibleWatermarkCollection possibleWatermarks = doc.Pages[0].FindWatermarks(textSearchCriteria.Or(imageSearchCriteria));

                        // Remove all found watermarks
                        possibleWatermarks.Clear();

                        doc.Save();
                    }
                    //ExEnd:RemoveWatermarkVisio
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Extracts information about the shapes
            /// </summary> 
            public static void GetShapesInformation()
            {
                try
                {
                    //ExStart:GetShapesInformationVisio
                    using (DiagramDocument doc = Document.Load<DiagramDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        foreach (DiagramPage page in doc.Pages)
                        {
                            foreach (DiagramShape shape in page.Shapes)
                            {
                                if (shape.Image != null)
                                {
                                    Console.WriteLine(shape.Image.Width);
                                    Console.WriteLine(shape.Image.Height);
                                    Console.WriteLine(shape.Image.GetBytes().Length);
                                }
                                Console.WriteLine(shape.Name);
                                Console.WriteLine(shape.X);
                                Console.WriteLine(shape.Y);
                                Console.WriteLine(shape.Width);
                                Console.WriteLine(shape.Height);
                                Console.WriteLine(shape.RotateAngle);
                                Console.WriteLine(shape.Text);
                                Console.WriteLine(shape.Id);
                            }
                        }
                    }
                    //ExEnd:GetShapesInformationVisio
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Removes a particular shape
            /// </summary> 
            public static void RemoveShape()
            {
                try
                {
                    //ExStart:RemoveShapeVisio
                    using (DiagramDocument doc = Document.Load<DiagramDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        // Remove shape by index
                        doc.Pages[0].Shapes.RemoveAt(0);

                        // Remove shape by reference
                        doc.Pages[0].Shapes.Remove(doc.Pages[0].Shapes[0]);

                        doc.Save();
                    }
                    //ExEnd:RemoveShapeVisio
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Extracts information about all the headers&footers
            /// </summary> 
            public static void GetHeaderFooterInformation()
            {
                try
                {
                    //ExStart:GetHeaderFooterInformationVisio
                    using (DiagramDocument doc = Document.Load<DiagramDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        // Get header&footer font settings
                        Console.WriteLine(doc.HeaderFooter.Font.FamilyName);
                        Console.WriteLine(doc.HeaderFooter.Font.Size);
                        Console.WriteLine(doc.HeaderFooter.Font.Bold);
                        Console.WriteLine(doc.HeaderFooter.Font.Italic);
                        Console.WriteLine(doc.HeaderFooter.Font.Underline);
                        Console.WriteLine(doc.HeaderFooter.Font.Strikeout);

                        // Get text contained in headers&footers
                        Console.WriteLine(doc.HeaderFooter.HeaderLeft);
                        Console.WriteLine(doc.HeaderFooter.HeaderCenter);
                        Console.WriteLine(doc.HeaderFooter.HeaderRight);
                        Console.WriteLine(doc.HeaderFooter.FooterLeft);
                        Console.WriteLine(doc.HeaderFooter.FooterCenter);
                        Console.WriteLine(doc.HeaderFooter.FooterRight);

                        // Get text color
                        Console.WriteLine(doc.HeaderFooter.TextColor.ToArgb());

                        // Get header&footer margins
                        Console.WriteLine(doc.HeaderFooter.FooterMargin);
                        Console.WriteLine(doc.HeaderFooter.HeaderMargin);
                    }
                    //ExEnd:GetHeaderFooterInformationVisio
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Removes or replaces particular header&footer
            /// </summary> 
            public static void RemoveOrReplaceHeaderFooter()
            {
                try
                {
                    //ExStart:RemoveOrReplaceHeaderFooter
                    using (DiagramDocument doc = Document.Load<DiagramDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        // Remove header
                        doc.HeaderFooter.HeaderCenter = null;

                        // Replace footer
                        doc.HeaderFooter.FooterCenter = "Footer center";
                        doc.HeaderFooter.Font.Size = 19;
                        doc.HeaderFooter.Font.FamilyName = "Calibri";
                        doc.HeaderFooter.TextColor = Color.Red;

                        doc.Save();
                    }
                    //ExEnd:RemoveOrReplaceHeaderFooter
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Removes all text shapes with a particular text formatting in a Visio document 
            /// </summary> 
            public static void RemoveTextShapesWithParticularTextFormatting()
            {
                try
                {
                    //ExStart:RemoveTextShapesWithParticularTextFormattingVisio
                    using (DiagramDocument doc = Document.Load<DiagramDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        foreach (DiagramPage page in doc.Pages)
                        {
                            for (var i = page.Shapes.Count - 1; i >= 0; i--)
                            {
                                foreach (var fragment in page.Shapes[i].FormattedTextFragments)
                                {
                                    if (fragment.ForegroundColor == Color.Red && fragment.Font.FamilyName == "Arial")
                                    {
                                        page.Shapes.RemoveAt(i);
                                        break;
                                    }
                                }
                            }
                        }
                        doc.Save();
                    }
                    //ExEnd:RemoveTextShapesWithParticularTextFormattingVisio
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            /// <summary>
            /// Removes hyperlinks associated with a particular shape inside a Visio document
            /// </summary> 
            public static void RemoveHyperlinks()
            {
                try
                {
                    //ExStart:RemoveHyperlinksVisio
                    using (DiagramDocument doc = Document.Load<DiagramDocument>(Utilities.MapSourceFilePath(FilePath)))
                    {
                        DiagramShape shape = doc.Pages[0].Shapes[0];
                        for (int i = shape.Hyperlinks.Count - 1; i >= 0; i--)
                        {
                            if (shape.Hyperlinks[i].Address.Contains("http://someurl.com"))
                            {
                                shape.Hyperlinks.RemoveAt(i);
                            }
                        }

                        doc.Save();
                    }
                    //ExEnd:RemoveHyperlinksVisio
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }
        }
    }
}
