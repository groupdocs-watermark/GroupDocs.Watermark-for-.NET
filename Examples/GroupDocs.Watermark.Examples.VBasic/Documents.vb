Imports GroupDocs.Watermark.Office
Imports GroupDocs.Watermark.Office.Cells
Imports GroupDocs.Watermark.Office.Slides
Imports GroupDocs.Watermark.Office.Words
Imports GroupDocs.Watermark.Pdf
Imports GroupDocs.Watermark.Search
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace GroupDocs.Watermark.Examples.VBasic
    Public NotInheritable Class Documents
        Private Sub New()
        End Sub
        Public NotInheritable Class PDF
            Private Sub New()
            End Sub
            ' initialize file path
            'ExStart:SourcePDFFilePath
            Private Const FilePath As String = "Documents/sample.pdf"
            'ExEnd:SourcePDFFilePath

            ''' <summary>
            ''' Adds watermark to a PDF document
            ''' </summary> 
            Public Shared Sub AddWatermark()
                Try
                    'ExStart:AddWatermarkToPDF
                    Using doc As PdfDocument = Document.Load(Of PdfDocument)(Utilities.MapSourceFilePath(FilePath))
                        ' Add text watermark
                        Dim textWatermark As New TextWatermark("This is a test watermark", New Font("Arial", 8))
                        doc.Pages(0).AddWatermark(textWatermark)

                        ' Add image watermark
                        Using imageWatermark As New ImageWatermark("D:\protect.jpg")
                            doc.Pages(1).AddWatermark(imageWatermark)
                        End Using
                        doc.Save()
                    End Using
                    'ExEnd:AddWatermarkToPDF
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Gets dimensions of a PDF document
            ''' </summary> 
            Public Shared Sub GetDimensions()
                Try
                    'ExStart:GetDimensionsPDF
                    Using doc As PdfDocument = Document.Load(Of PdfDocument)(Utilities.MapSourceFilePath(FilePath))
                        Console.WriteLine(doc.Pages(0).Width)
                        Console.WriteLine(doc.Pages(0).Height)
                    End Using
                    'ExEnd:GetDimensionsPDF
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Adds watermark to all images inside a PDF document
            ''' </summary> 
            Public Shared Sub AddWatermarkToImages()
                Try
                    'ExStart:AddWatermarkToImagesPDF
                    Using doc As PdfDocument = Document.Load(Of PdfDocument)(Utilities.MapSourceFilePath(FilePath))
                        ' Initialize image or text watermark
                        Dim watermark As New TextWatermark("Protected image", New Font("Arial", 8))
                        watermark.HorizontalAlignment = HorizontalAlignment.Center
                        watermark.VerticalAlignment = VerticalAlignment.Center
                        watermark.RotateAngle = 45
                        watermark.SizingType = SizingType.ScaleToParentDimensions
                        watermark.ScaleFactor = 1

                        ' Get all images from the first page
                        Dim images As WatermarkableImageCollection = doc.Pages(0).FindImages()

                        ' Add watermark to all found images
                        For Each image As WatermarkableImage In images
                            image.AddWatermark(watermark)
                        Next

                        doc.Save()
                    End Using
                    'ExEnd:AddWatermarkToImagesPDF
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Adds artifact watermark to a PDF document
            ''' </summary> 
            Public Shared Sub AddArtifactWatermark()
                Try
                    'ExStart:AddArtifactWatermark
                    Using doc As PdfDocument = Document.Load(Of PdfDocument)(Utilities.MapSourceFilePath(FilePath))
                        ' Add text watermark
                        Dim textWatermark As New TextWatermark("This is an artifact watermark", New Font("Arial", 8))
                        doc.AddArtifactWatermark(textWatermark)

                        ' Add image watermark
                        'using (ImageWatermark imageWatermark = new ImageWatermark(@"D:\logo.bmp"))
                        '{
                        '    doc.AddArtifactWatermark(imageWatermark);
                        '}
                        doc.Save()
                    End Using
                    'ExEnd:AddArtifactWatermark
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Adds annotation watermark to a PDF document
            ''' </summary> 
            Public Shared Sub AddAnnotationWatermark()
                Try
                    'ExStart:AddAnnotationWatermark
                    Using doc As PdfDocument = Document.Load(Of PdfDocument)(Utilities.MapSourceFilePath(FilePath))
                        ' Add text watermark
                        Dim textWatermark As New TextWatermark("This is a test watermark", New Font("Arial", 8))
                        doc.AddAnnotationWatermark(textWatermark)

                        ' Add image watermark
                        Using imageWatermark As New ImageWatermark("D:\protect.jpg")
                            doc.AddAnnotationWatermark(imageWatermark)
                        End Using
                        doc.Save()
                    End Using
                    'ExEnd:AddAnnotationWatermark
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Adds print only annotation watermark to a PDF document
            ''' </summary> 
            Public Shared Sub AddPrintOnlyAnnotationWatermark()
                Try
                    'ExStart:AddPrintOnlyAnnotationWatermark
                    Using doc As PdfDocument = Document.Load(Of PdfDocument)(Utilities.MapSourceFilePath(FilePath))
                        Dim textWatermark As New TextWatermark("This is a print only test watermark. It won't appear in view mode.", New Font("Arial", 8))
                        Dim isPrintOnly As Boolean = True

                        ' Annotation will be printed, but not displayed in pdf viewing application
                        doc.Pages(0).AddAnnotationWatermark(textWatermark, isPrintOnly)

                        doc.Save()
                    End Using
                    'ExEnd:AddPrintOnlyAnnotationWatermark
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Removes watermark from a PDF document
            ''' </summary> 
            Public Shared Sub RemoveWatermark()
                Try
                    'ExStart:RemoveWatermarkFromPDF
                    Using doc As PdfDocument = Document.Load(Of PdfDocument)(Utilities.MapSourceFilePath(FilePath))
                        ' Initialize search criteria
                        Dim imageSearchCriteria As ImageSearchCriteria = New ImageDctHashSearchCriteria("D:\logo.png")
                        Dim textSearchCriteria As New TextSearchCriteria("Company Name")

                        Dim possibleWatermarks As PossibleWatermarkCollection = doc.Pages(0).FindWatermarks(imageSearchCriteria.[Or](textSearchCriteria))

                        ' Remove all found watermarks
                        For i As Object = possibleWatermarks.Count - 1 To 0 Step -1
                            possibleWatermarks.RemoveAt(i)
                        Next

                        doc.Save()
                    End Using
                    'ExEnd:RemoveWatermarkFromPDF
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Gets information about all XObjects in a PDF document
            ''' </summary> 
            Public Shared Sub ExtractXObjectInformation()
                Try
                    'ExStart:ExtractXObjectInformation
                    Using doc As PdfDocument = Document.Load(Of PdfDocument)(Utilities.MapSourceFilePath(FilePath))
                        For Each page As PdfPage In doc.Pages
                            For Each xObject As PdfXObject In page.XObjects
                                If xObject.Image IsNot Nothing Then
                                    Console.WriteLine(xObject.Image.Width)
                                    Console.WriteLine(xObject.Image.Height)
                                    Console.WriteLine(xObject.Image.GetBytes().Length)
                                End If
                                Console.WriteLine(xObject.Text)
                                Console.WriteLine(xObject.X)
                                Console.WriteLine(xObject.Y)
                                Console.WriteLine(xObject.Width)
                                Console.WriteLine(xObject.Height)
                                Console.WriteLine(xObject.RotateAngle)
                            Next
                        Next
                    End Using
                    'ExEnd:ExtractXObjectInformation
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Removes XObject from a PDF document
            ''' </summary> 
            Public Shared Sub RemoveXObject()
                Try
                    'ExStart:RemoveXObject
                    Using doc As PdfDocument = Document.Load(Of PdfDocument)(Utilities.MapSourceFilePath(FilePath))
                        ' Remove XObject by index
                        doc.Pages(0).XObjects.RemoveAt(0)

                        ' Remove XObject by reference
                        doc.Pages(0).XObjects.Remove(doc.Pages(0).XObjects(0))

                        doc.Save()
                    End Using
                    'ExEnd:RemoveXObject
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Adds watermark to all images XObjects inside a PDF document
            ''' </summary> 
            Public Shared Sub AddWatermarkToXObjects()
                Try
                    'ExStart:AddWatermarkToXObjects
                    Using doc As PdfDocument = Document.Load(Of PdfDocument)(Utilities.MapSourceFilePath(FilePath))
                        ' Initialize image or text watermark
                        Dim watermark As New TextWatermark("Protected image", New Font("Arial", 8))
                        watermark.HorizontalAlignment = HorizontalAlignment.Center
                        watermark.VerticalAlignment = VerticalAlignment.Center
                        watermark.RotateAngle = 45
                        watermark.SizingType = SizingType.ScaleToParentDimensions
                        watermark.ScaleFactor = 1

                        For Each page As PdfPage In doc.Pages
                            For Each xObject As PdfXObject In page.XObjects
                                If xObject.Image IsNot Nothing Then
                                    ' Add watermark to the image
                                    xObject.Image.AddWatermark(watermark)
                                End If
                            Next
                        Next

                        doc.Save()
                    End Using
                    'ExEnd:AddWatermarkToXObjects
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Gets information about all artifacts in a PDF document
            ''' </summary> 
            Public Shared Sub ExtractArtifactInformation()
                Try
                    'ExStart:ExtractArtifactInformation
                    Using doc As PdfDocument = Document.Load(Of PdfDocument)(Utilities.MapSourceFilePath(FilePath))
                        For Each page As PdfPage In doc.Pages
                            For Each artifact As PdfArtifact In page.Artifacts
                                Console.WriteLine(artifact.ArtifactType)
                                Console.WriteLine(artifact.ArtifactSubtype)
                                If artifact.Image IsNot Nothing Then
                                    Console.WriteLine(artifact.Image.Width)
                                    Console.WriteLine(artifact.Image.Height)
                                    Console.WriteLine(artifact.Image.GetBytes().Length)
                                End If
                                Console.WriteLine(artifact.Text)
                                Console.WriteLine(artifact.Opacity)
                                Console.WriteLine(artifact.X)
                                Console.WriteLine(artifact.Y)
                                Console.WriteLine(artifact.Width)
                                Console.WriteLine(artifact.Height)
                                Console.WriteLine(artifact.RotateAngle)
                            Next
                        Next
                    End Using
                    'ExEnd:ExtractArtifactInformation
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Removes artifact from a PDF document
            ''' </summary> 
            Public Shared Sub RemoveArtifact()
                Try
                    'ExStart:RemoveArtifact
                    Using doc As PdfDocument = Document.Load(Of PdfDocument)(Utilities.MapSourceFilePath(FilePath))
                        ' Remove Artifact by index
                        doc.Pages(0).Artifacts.RemoveAt(0)

                        ' Remove Artifact by reference
                        doc.Pages(0).Artifacts.Remove(doc.Pages(0).Artifacts(0))

                        doc.Save()
                        'ExEnd:RemoveArtifact
                    End Using
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Adds watermark to all images Artifacts inside a PDF document
            ''' </summary> 
            Public Shared Sub AddWatermarkToArtifacts()
                Try
                    'ExStart:AddWatermarkToArtifacts
                    Using doc As PdfDocument = Document.Load(Of PdfDocument)(Utilities.MapSourceFilePath(FilePath))
                        ' Initialize image or text watermark
                        Dim watermark As New TextWatermark("Protected image", New Font("Arial", 8))
                        watermark.HorizontalAlignment = HorizontalAlignment.Center
                        watermark.VerticalAlignment = VerticalAlignment.Center
                        watermark.RotateAngle = 45
                        watermark.SizingType = SizingType.ScaleToParentDimensions
                        watermark.ScaleFactor = 1

                        For Each page As PdfPage In doc.Pages
                            For Each artifact As PdfArtifact In page.Artifacts
                                If artifact.Image IsNot Nothing Then
                                    ' Add watermark to the image
                                    artifact.Image.AddWatermark(watermark)
                                End If
                            Next
                        Next

                        doc.Save()
                    End Using
                    'ExEnd:AddWatermarkToArtifacts
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Gets information about all annotations in a PDF document
            ''' </summary> 
            Public Shared Sub ExtractAnnotationInformation()
                Try
                    'ExStart:ExtractAnnotationInformation
                    Using doc As PdfDocument = Document.Load(Of PdfDocument)(Utilities.MapSourceFilePath(FilePath))
                        For Each page As PdfPage In doc.Pages
                            For Each annotation As PdfAnnotation In page.Annotations
                                Console.WriteLine(annotation.AnnotationType)
                                If annotation.Image IsNot Nothing Then
                                    Console.WriteLine(annotation.Image.Width)
                                    Console.WriteLine(annotation.Image.Height)
                                    Console.WriteLine(annotation.Image.GetBytes().Length)
                                End If
                                Console.WriteLine(annotation.Text)
                                Console.WriteLine(annotation.X)
                                Console.WriteLine(annotation.Y)
                                Console.WriteLine(annotation.Width)
                                Console.WriteLine(annotation.Height)
                                Console.WriteLine(annotation.RotateAngle)
                            Next
                        Next
                    End Using
                    'ExEnd:ExtractAnnotationInformation
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Removes annotation from a PDF document
            ''' </summary> 
            Public Shared Sub RemoveAnnotation()
                Try
                    'ExStart:RemoveAnnotation
                    Using doc As PdfDocument = Document.Load(Of PdfDocument)(Utilities.MapSourceFilePath(FilePath))
                        ' Remove Annotation by index
                        doc.Pages(0).Annotations.RemoveAt(0)

                        ' Remove Annotation by reference
                        doc.Pages(0).Annotations.Remove(doc.Pages(0).Annotations(0))

                        doc.Save()
                    End Using
                    'ExEnd:RemoveAnnotation
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Adds watermark to all images Annotations inside a PDF document
            ''' </summary> 
            Public Shared Sub AddWatermarkToAnnotations()
                Try
                    'ExStart:AddWatermarkToAnnotations
                    Using doc As PdfDocument = Document.Load(Of PdfDocument)(Utilities.MapSourceFilePath(FilePath))
                        ' Initialize image or text watermark
                        Dim watermark As New TextWatermark("Protected image", New Font("Arial", 8))
                        watermark.HorizontalAlignment = HorizontalAlignment.Center
                        watermark.VerticalAlignment = VerticalAlignment.Center
                        watermark.RotateAngle = 45
                        watermark.SizingType = SizingType.ScaleToParentDimensions
                        watermark.ScaleFactor = 1

                        For Each page As PdfPage In doc.Pages
                            For Each annotation As PdfAnnotation In page.Annotations
                                If annotation.Image IsNot Nothing Then
                                    ' Add watermark to the image
                                    annotation.Image.AddWatermark(watermark)
                                End If
                            Next
                        Next

                        doc.Save()
                    End Using
                    'ExEnd:AddWatermarkToAnnotations
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Rasterize a PDF document
            ''' </summary> 
            Public Shared Sub RasterizePDFDocument()
                Try
                    'ExStart:RasterizePDFDocument
                    Using doc As PdfDocument = Document.Load(Of PdfDocument)(Utilities.MapSourceFilePath(FilePath))
                        ' Initialize image or text watermark
                        Dim watermark As New TextWatermark("Do not copy", New Font("Arial", 8))
                        watermark.HorizontalAlignment = HorizontalAlignment.Center
                        watermark.VerticalAlignment = VerticalAlignment.Center
                        watermark.RotateAngle = 45
                        watermark.SizingType = SizingType.ScaleToParentDimensions
                        watermark.ScaleFactor = 1
                        watermark.Opacity = 0.5

                        ' Add watermark of any type first
                        doc.AddWatermark(watermark)

                        ' Rasterize all pages
                        doc.Rasterize(100, 100, PdfImageConversionFormat.Png)

                        ' Content of all pages is replaced with raster images
                        doc.Save()
                    End Using
                    'ExEnd:RasterizePDFDocument
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Rasterize a particular page of a PDF document
            ''' </summary> 
            Public Shared Sub RasterizePDFDocument(PageNumber As Integer)
                Try
                    'ExStart:RasterizePDFDocumentWithPageNumber
                    Using doc As PdfDocument = Document.Load(Of PdfDocument)(Utilities.MapSourceFilePath(FilePath))
                        ' Initialize image or text watermark
                        Dim watermark As New TextWatermark("Do not copy", New Font("Arial", 8))
                        watermark.HorizontalAlignment = HorizontalAlignment.Center
                        watermark.VerticalAlignment = VerticalAlignment.Center
                        watermark.RotateAngle = 45
                        watermark.SizingType = SizingType.ScaleToParentDimensions
                        watermark.ScaleFactor = 1
                        watermark.Opacity = 0.5

                        ' Add watermark of any type first
                        doc.Pages(0).AddWatermark(watermark)

                        ' Rasterize the first page
                        doc.Pages(0).Rasterize(100, 100, PdfImageConversionFormat.Png)

                        ' Content of the first page is replaced with raster image
                        doc.Save()
                    End Using
                    'ExEnd:RasterizePDFDocumentWithPageNumber
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub
        End Class
        Public NotInheritable Class Word
            Private Sub New()
            End Sub
            ' initialize file path
            'ExStart:SourceWordFilePath
            Private Const FilePath As String = "Documents/sample.docx"
            'ExEnd:SourceWordFilePath

            ''' <summary>
            ''' Adds watermark to a section of Word document
            ''' </summary> 
            Public Shared Sub AddWatermarkToSection()
                Try
                    'ExStart:AddWatermarkToSection
                    Using doc As WordsDocument = Document.Load(Of WordsDocument)(Utilities.MapSourceFilePath(FilePath))
                        Dim watermark As New TextWatermark("Test watermark", New Font("Arial", 19))

                        ' Add watermark to all headers of the first section
                        doc.Sections(0).AddWatermark(watermark)

                        doc.Save()
                    End Using
                    'ExEnd:AddWatermarkToSection
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Gets properties of a section of Word document
            ''' </summary> 
            Public Shared Sub GetSectionProperties()
                Try
                    'ExStart:GetSectionProperties
                    Using doc As WordsDocument = Document.Load(Of WordsDocument)("D:\test.docx")
                        Console.WriteLine(doc.Sections(0).PageSetup.Width)
                        Console.WriteLine(doc.Sections(0).PageSetup.Height)
                        Console.WriteLine(doc.Sections(0).PageSetup.TopMargin)
                        Console.WriteLine(doc.Sections(0).PageSetup.RightMargin)
                        Console.WriteLine(doc.Sections(0).PageSetup.BottomMargin)
                        Console.WriteLine(doc.Sections(0).PageSetup.LeftMargin)
                    End Using
                    'ExEnd:GetSectionProperties
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Links header/footer to the previous section of Word document
            ''' </summary> 
            Public Shared Sub LinkHeaderFooterInSection()
                Try
                    'ExStart:LinkHeaderFooterInSection
                    Using doc As WordsDocument = Document.Load(Of WordsDocument)(Utilities.MapSourceFilePath(FilePath))
                        ' Link footer for even numbered pages to corresponding footer in previous section
                        doc.Sections(1).HeadersFooters(OfficeHeaderFooterType.FooterEven).IsLinkedToPrevious = True

                        doc.Save()
                    End Using
                    'ExEnd:LinkHeaderFooterInSection
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Links all header/footer to the previous section of Word document
            ''' </summary> 
            Public Shared Sub LinkAllHeaderFooterInSection()
                Try
                    'ExStart:LinkAllHeaderFooterInSection
                    Using doc As WordsDocument = Document.Load(Of WordsDocument)(Utilities.MapSourceFilePath(FilePath))
                        ' Link footer for even numbered pages to corresponding footer in previous section
                        doc.Sections(1).HeadersFooters(1).IsLinkedToPrevious = True

                        doc.Save()
                    End Using
                    'ExEnd:LinkAllHeaderFooterInSection
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Adds image watermark to a word document
            ''' </summary> 
            Public Shared Sub AddImageWatermark()
                Try
                    'ExStart:AddImageWatermarkToWord
                    Using doc As WordsDocument = Document.Load(Of WordsDocument)(Utilities.MapSourceFilePath(FilePath))
                        Using watermark As New ImageWatermark("D:\large.png")
                            ' Add watermark to all headers of the first section
                            doc.Sections(0).AddWatermark(watermark)
                        End Using

                        ' Link all other headers&footers to corresponding headers&footers of the first section
                        For i As Integer = 1 To doc.Sections.Count - 1
                            doc.Sections(i).HeadersFooters.LinkToPrevious(True)
                        Next

                        doc.Save()
                    End Using
                    'ExEnd:AddImageWatermarkToWord
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Adds watermark to all images inside a section of Word document
            ''' </summary> 
            Public Shared Sub AddWatermarkToImages()
                Try
                    'ExStart:AddWatermarkToImagesWordSection
                    Using doc As WordsDocument = Document.Load(Of WordsDocument)(Utilities.MapSourceFilePath(FilePath))
                        Dim watermark As New TextWatermark("Protected image", New Font("Arial", 8))
                        watermark.HorizontalAlignment = HorizontalAlignment.Center
                        watermark.VerticalAlignment = VerticalAlignment.Center
                        watermark.RotateAngle = 45
                        watermark.SizingType = SizingType.ScaleToParentDimensions
                        watermark.ScaleFactor = 1

                        ' Get all images belonging to the first section
                        Dim images As WatermarkableImageCollection = doc.Sections(0).FindImages()

                        ' Add watermark to all found images
                        For Each image As WatermarkableImage In images
                            image.AddWatermark(watermark)
                        Next

                        doc.Save()
                    End Using
                    'ExEnd:AddWatermarkToImagesWordSection
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Adds watermark to Word document with Words Shape Settings
            ''' </summary> 
            Public Shared Sub AddWatermarkWithWordsShapeSettings()
                Try
                    'ExStart:AddWatermarkWithWordsShapeSettings
                    Using doc As WordsDocument = Document.Load(Of WordsDocument)("D:\test.docx")
                        Dim watermark As New TextWatermark("Test watermark", New Font("Arial", 19))
                        Dim shapeSettings As New WordsShapeSettings()

                        ' Set the shape name
                        shapeSettings.Name = "Shape 1"

                        ' Set the descriptive (alternative) text that will be associated with the shape
                        shapeSettings.AlternativeText = "Test watermark"

                        doc.AddWatermark(watermark, shapeSettings)

                        doc.Save()
                    End Using
                    'ExEnd:AddWatermarkWithWordsShapeSettings
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Adds watermark to Word document with text effects
            ''' </summary> 
            Public Shared Sub AddWatermarkWithTextEffects()
                Try
                    'ExStart:AddWatermarkWithTextEffectsWord
                    Using doc As WordsDocument = Document.Load(Of WordsDocument)(Utilities.MapSourceFilePath(FilePath))
                        Dim watermark As New TextWatermark("Test watermark", New Font("Arial", 19))

                        Dim effects As New WordsTextEffects()
                        effects.LineFormat.Enabled = True
                        effects.LineFormat.Color = Color.Red
                        effects.LineFormat.DashStyle = OfficeDashStyle.DashDotDot
                        effects.LineFormat.LineStyle = OfficeLineStyle.Triple
                        effects.LineFormat.Weight = 1
                        doc.AddTextWatermark(watermark, effects)
                        doc.Save()
                    End Using
                    'ExEnd:AddWatermarkWithTextEffectsWord
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Adds watermark to Word document with image effects
            ''' </summary> 
            Public Shared Sub AddWatermarkWithImageEffects()
                Try
                    'ExStart:AddWatermarkWithImageEffectsWord
                    Using doc As WordsDocument = Document.Load(Of WordsDocument)("D:\test.docx")
                        Using watermark = New ImageWatermark("D:\logo.tif")
                            Dim effects As New WordsImageEffects()
                            effects.Brightness = 0.7
                            effects.Contrast = 0.6
                            effects.ChromaKey = Color.Red
                            effects.BorderLineFormat.Enabled = True
                            effects.BorderLineFormat.Weight = 1
                            doc.AddImageWatermark(watermark, effects)
                        End Using
                        doc.Save()
                    End Using
                    'ExEnd:AddWatermarkWithImageEffectsWord
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Removes watermark from a particular section of Word document 
            ''' </summary> 
            Public Shared Sub RemoveWatermarkFromSection()
                Try
                    'ExStart:RemoveWatermarkFromSection
                    Using doc As WordsDocument = Document.Load(Of WordsDocument)(Utilities.MapSourceFilePath(FilePath))
                        ' Initialize search criteria
                        Dim imageSearchCriteria As ImageSearchCriteria = New ImageDctHashSearchCriteria("D:\logo.png")
                        Dim textSearchCriteria As New TextSearchCriteria("Company Name")

                        ' Call FindWatermarks method for the section
                        Dim possibleWatermarks As PossibleWatermarkCollection = doc.Sections(0).FindWatermarks(textSearchCriteria.[Or](imageSearchCriteria))

                        ' Remove all found watermarks
                        For i As Object = possibleWatermarks.Count - 1 To 0 Step -1
                            possibleWatermarks.RemoveAt(i)
                        Next

                        doc.Save()
                    End Using
                    'ExEnd:RemoveWatermarkFromSection
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Finds watermarks in a header/footer of Word document 
            ''' </summary> 
            Public Shared Sub FindWatermarkInHeaderFooter()
                Try
                    'ExStart:FindWatermarkInHeaderFooter
                    Using doc As WordsDocument = Document.Load(Of WordsDocument)(Utilities.MapSourceFilePath(FilePath))
                        ' Initialize search criteria
                        Dim imageSearchCriteria As ImageSearchCriteria = New ImageDctHashSearchCriteria("D:\logo.png")
                        Dim textSearchCriteria As New TextSearchCriteria("Company Name")

                        Dim possibleWatermarks As PossibleWatermarkCollection = doc.Sections(0).HeadersFooters(OfficeHeaderFooterType.HeaderPrimary).FindWatermarks(textSearchCriteria.[Or](imageSearchCriteria))

                        ' Remove all found watermarks
                        For i As Object = possibleWatermarks.Count - 1 To 0 Step -1
                            possibleWatermarks.RemoveAt(i)
                        Next

                        doc.Save()
                    End Using
                    'ExEnd:FindWatermarkInHeaderFooter
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Extracts information about all the shapes is a Word document 
            ''' </summary> 
            Public Shared Sub GetShapesInformation()
                Try
                    'ExStart:GetShapesInformationWord
                    Using doc As WordsDocument = Document.Load(Of WordsDocument)("D:\test.docx")
                        For Each section As WordsSection In doc.Sections
                            For Each shape As WordsShape In section.Shapes
                                If shape.HeaderFooter IsNot Nothing Then
                                    Console.WriteLine("In header/footer")
                                End If

                                Console.WriteLine(shape.ShapeType)
                                Console.WriteLine(shape.Width)
                                Console.WriteLine(shape.Height)
                                Console.WriteLine(shape.IsWordArt)
                                Console.WriteLine(shape.RotateAngle)
                                Console.WriteLine(shape.AlternativeText)
                                Console.WriteLine(shape.Name)
                                Console.WriteLine(shape.X)
                                Console.WriteLine(shape.Y)
                                Console.WriteLine(shape.Text)
                                If shape.Image IsNot Nothing Then
                                    Console.WriteLine(shape.Image.Width)
                                    Console.WriteLine(shape.Image.Height)
                                    Console.WriteLine(shape.Image.GetBytes().Length)
                                End If

                                Console.WriteLine(shape.HorizontalAlignment)
                                Console.WriteLine(shape.VerticalAlignment)
                                Console.WriteLine(shape.RelativeHorizontalPosition)
                                Console.WriteLine(shape.RelativeVerticalPosition)
                            Next
                        Next
                    End Using
                    'ExEnd:GetShapesInformationWord
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Removes shape in a Word document 
            ''' </summary> 
            Public Shared Sub RemoveShape()
                Try
                    'ExStart:RemoveShapeWordDocument
                    Using doc As WordsDocument = Document.Load(Of WordsDocument)(Utilities.MapSourceFilePath(FilePath))
                        ' Remove shape by index
                        doc.Sections(0).Shapes.RemoveAt(0)

                        ' Remove shape by reference
                        doc.Sections(0).Shapes.Remove(doc.Sections(0).Shapes(0))

                        doc.Save()
                    End Using
                    'ExEnd:RemoveShapeWordDocument
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Adds watermark to all image shapes in a Word document 
            ''' </summary> 
            Public Shared Sub AddWatermarkToImageShapes()
                Try
                    'ExStart:AddWatermarkToImageShapesWordDocument
                    Using doc As WordsDocument = Document.Load(Of WordsDocument)("D:\test.docx")
                        Dim watermark As New TextWatermark("Protected image", New Font("Arial", 8))
                        watermark.HorizontalAlignment = HorizontalAlignment.Center
                        watermark.VerticalAlignment = VerticalAlignment.Center
                        watermark.RotateAngle = 45
                        watermark.SizingType = SizingType.ScaleToParentDimensions
                        watermark.ScaleFactor = 1

                        For Each section As WordsSection In doc.Sections
                            For Each shape As WordsShape In section.Shapes
                                ' Headers&Footers usually contains only service information.
                                ' So, we skip images in headers/footers, expecting that they are probably watermarks or backgrounds
                                If shape.HeaderFooter Is Nothing AndAlso shape.Image IsNot Nothing Then
                                    shape.Image.AddWatermark(watermark)
                                End If
                            Next
                        Next
                    End Using
                    'ExEnd:AddWatermarkToImageShapesWordDocument
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub
        End Class
        Public NotInheritable Class Excel
            Private Sub New()
            End Sub
            ' initialize file path
            'ExStart:SourceExcelFilePath
            Private Const FilePath As String = "Documents/sample.xlsx"
            'ExEnd:SourceExcelFilePath

            ''' <summary>
            ''' Adds watermark to Excel spreadsheet
            ''' </summary> 
            Public Shared Sub AddWatermark()
                Try
                    'ExStart:AddWatermarkToExcel
                    Using doc As CellsDocument = Document.Load(Of CellsDocument)(Utilities.MapSourceFilePath(FilePath))
                        ' Add text watermark
                        Dim textWatermark As New TextWatermark("Test watermark", New Font("Arial", 8))
                        doc.Worksheets(0).AddWatermark(textWatermark)

                        ' Add image watermark
                        Using imageWatermark As New ImageWatermark("D:\logo.jpg")
                            doc.Worksheets(1).AddWatermark(imageWatermark)
                        End Using
                        doc.Save()
                    End Using
                    'ExEnd:AddWatermarkToExcel
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Gets content area dimensions of Excel worksheets
            ''' </summary> 
            Public Shared Sub GetContentAreaDimensions()
                Try
                    'ExStart:GetContentAreaDimensions
                    Using doc As CellsDocument = Document.Load(Of CellsDocument)(Utilities.MapSourceFilePath(FilePath))
                        ' Get the size of content area
                        Console.WriteLine(doc.Worksheets(0).ContentAreaHeight)
                        Console.WriteLine(doc.Worksheets(0).ContentAreaWidth)

                        ' Get the size of particular cell
                        Console.WriteLine(doc.Worksheets(0).GetColumnWidth(0))
                        Console.WriteLine(doc.Worksheets(0).GetRowHeight(0))
                    End Using
                    'ExEnd:GetContentAreaDimensions
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Adds watermark to all images inside an Excel worksheet
            ''' </summary> 
            Public Shared Sub AddWatermarkToImages()
                Try
                    'ExStart:AddWatermarkToImagesExcelWorksheet
                    Using doc As CellsDocument = Document.Load(Of CellsDocument)(Utilities.MapSourceFilePath(FilePath))
                        Dim watermark As New TextWatermark("Protected image", New Font("Arial", 8))
                        watermark.HorizontalAlignment = HorizontalAlignment.Center
                        watermark.VerticalAlignment = VerticalAlignment.Center
                        watermark.RotateAngle = 45
                        watermark.SizingType = SizingType.ScaleToParentDimensions
                        watermark.ScaleFactor = 1

                        ' Get all images from the first worksheet
                        Dim images As WatermarkableImageCollection = doc.Worksheets(0).FindImages()

                        ' Add watermark to all found images
                        For Each image As WatermarkableImage In images
                            image.AddWatermark(watermark)
                        Next

                        doc.Save()
                    End Using
                    'ExEnd:AddWatermarkToImagesExcelWorksheet
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Adds modern word art watermark to Excel worksheet
            ''' </summary> 
            Public Shared Sub AddModernWordArdWatermark()
                Try
                    'ExStart:AddModernWordArdWatermarkToExcel
                    Using doc As CellsDocument = Document.Load(Of CellsDocument)("D:\test.xlsx")
                        Dim textWatermark As New TextWatermark("Test watermark", New Font("Arial", 8))
                        doc.Worksheets(0).AddModernWordArtWatermark(textWatermark)
                        doc.Save()
                    End Using
                    'ExEnd:AddModernWordArdWatermarkToExcel
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Adds watermark to Excel worksheet with additional shape settings
            ''' </summary> 
            Public Shared Sub AddWatermarkUsingCellsShapeSettings()
                Try
                    'ExStart:AddWatermarkUsingCellsShapeSettings
                    Using doc As CellsDocument = Document.Load(Of CellsDocument)(Utilities.MapSourceFilePath(FilePath))
                        Dim watermark As New TextWatermark("Test watermark", New Font("Segoe UI", 19))
                        Dim shapeSettings As New CellsShapeSettings()

                        ' Set the shape name
                        shapeSettings.Name = "Shape 1"

                        ' Set the descriptive (alternative) text that will be associated with the shape
                        shapeSettings.AlternativeText = "Test watermark"

                        ' Editing of the shape in Excel is forbidden
                        shapeSettings.IsLocked = True

                        doc.AddWatermark(watermark, shapeSettings)


                        doc.Save()
                    End Using
                    'ExEnd:AddWatermarkUsingCellsShapeSettings
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Adds watermark with text effects to Excel worksheet
            ''' </summary> 
            Public Shared Sub AddWatermarkWithTextEffects()
                Try
                    'ExStart:AddWatermarkWithTextEffectsToExcel
                    Using doc As CellsDocument = Document.Load(Of CellsDocument)(Utilities.MapSourceFilePath(FilePath))
                        Dim watermark As New TextWatermark("Test watermark", New Font("Segoe UI", 19))

                        Dim effects As New CellsTextEffects()
                        effects.LineFormat.Enabled = True
                        effects.LineFormat.Color = Color.Red
                        effects.LineFormat.DashStyle = OfficeDashStyle.DashDotDot
                        effects.LineFormat.LineStyle = OfficeLineStyle.Triple
                        effects.LineFormat.Weight = 1
                        doc.AddTextWatermark(watermark, effects)
                        doc.Save()
                    End Using
                    'ExEnd:AddWatermarkWithTextEffectsToExcel
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Adds watermark with image effects to Excel worksheet
            ''' </summary> 
            Public Shared Sub AddWatermarkWithImageEffects()
                Try
                    'ExStart:AddWatermarkWithImageEffectsToExcel
                    Using doc As CellsDocument = Document.Load(Of CellsDocument)(Utilities.MapSourceFilePath(FilePath))
                        Using watermark = New ImageWatermark("D:\logo.tif")
                            Dim effects As New CellsImageEffects()
                            effects.Brightness = 0.7
                            effects.Contrast = 0.6
                            effects.ChromaKey = Color.Red
                            effects.BorderLineFormat.Enabled = True
                            effects.BorderLineFormat.Weight = 1
                            doc.AddImageWatermark(watermark, effects)
                        End Using
                        doc.Save()
                    End Using
                    'ExEnd:AddWatermarkWithImageEffectsToExcel
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Adds watermark as background to Excel worksheet
            ''' </summary> 
            Public Shared Sub AddWatermarkAsBackground()
                Try
                    'ExStart:AddWatermarkAsBackgroundToExcel
                    Using doc As CellsDocument = Document.Load(Of CellsDocument)("D:\test.xlsx")
                        Using watermark As New ImageWatermark("D:\logo.gif")
                            doc.AddWatermarkAsBackground(watermark)
                        End Using
                        doc.Save()
                    End Using
                    'ExEnd:AddWatermarkAsBackgroundToExcel
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub


            ''' <summary>
            ''' Adds watermark as background with relative size and position to Excel worksheet
            ''' </summary> 
            Public Shared Sub AddWatermarkAsBackgroundWithRelativeSizeAndPosition()
                Try
                    'ExStart:AddWatermarkAsBackgroundWithRelativeSizeAndPosition
                    Using doc As CellsDocument = Document.Load(Of CellsDocument)(Utilities.MapSourceFilePath(FilePath))
                        Using watermark As New ImageWatermark("D:\logo.gif")
                            watermark.HorizontalAlignment = HorizontalAlignment.Center
                            watermark.VerticalAlignment = VerticalAlignment.Center
                            watermark.RotateAngle = 90
                            watermark.SizingType = SizingType.ScaleToParentDimensions
                            watermark.ScaleFactor = 0.5
                            'set background width
                            'set background height
                            doc.Worksheets(0).AddWatermarkAsBackground(watermark, doc.Worksheets(0).ContentAreaWidthPx, doc.Worksheets(0).ContentAreaHeightPx)
                        End Using

                        doc.Save()
                    End Using
                    'ExEnd:AddWatermarkAsBackgroundWithRelativeSizeAndPosition
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Adds watermark text as background to Excel worksheet
            ''' <param name="WatermarkText"></param>
            ''' </summary> 
            Public Shared Sub AddWatermarkAsBackground(WatermarkText As String)
                Try
                    'ExStart:AddWatermarkTextAsBackgroundToExcel
                    Using doc As CellsDocument = Document.Load(Of CellsDocument)(Utilities.MapSourceFilePath(FilePath))
                        Dim watermark As New TextWatermark(WatermarkText, New Font("Segoe UI", 19))
                        watermark.HorizontalAlignment = HorizontalAlignment.Center
                        watermark.VerticalAlignment = VerticalAlignment.Center
                        watermark.RotateAngle = 45
                        watermark.SizingType = SizingType.ScaleToParentDimensions
                        watermark.ScaleFactor = 0.5
                        watermark.Opacity = 0.5
                        'set background width
                        'set background height
                        doc.Worksheets(0).AddWatermarkAsBackground(watermark, doc.Worksheets(0).ContentAreaWidthPx, doc.Worksheets(0).ContentAreaHeightPx)
                        doc.Save()
                    End Using
                    'ExEnd:AddWatermarkTextAsBackgroundToExcel
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Adds image watermark into header/footer of Excel worksheet
            ''' </summary> 
            Public Shared Sub AddWatermarkIntoHeaderFooter()
                Try
                    'ExStart:AddImageWatermarkIntoHeaderFooter
                    Using doc As CellsDocument = Document.Load(Of CellsDocument)(Utilities.MapSourceFilePath(FilePath))
                        Using watermark = New ImageWatermark("D:\logo.tif")
                            watermark.VerticalAlignment = VerticalAlignment.Top
                            watermark.HorizontalAlignment = HorizontalAlignment.Center
                            watermark.SizingType = SizingType.ScaleToParentDimensions
                            watermark.ScaleFactor = 1
                            doc.Worksheets(0).AddWatermarkIntoHeaderFooter(watermark)
                        End Using
                        doc.Save()
                    End Using
                    'ExEnd:AddImageWatermarkIntoHeaderFooter
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Adds text watermark into header/footer of Excel worksheet
            ''' <param name="WatermarkText"></param>
            ''' </summary> 
            Public Shared Sub AddWatermarkIntoHeaderFooter(WatermarkText As String)
                Try
                    'ExStart:AddTextWatermarkIntoHeaderFooter
                    Using doc As CellsDocument = Document.Load(Of CellsDocument)(Utilities.MapSourceFilePath(FilePath))
                        Dim watermark As New TextWatermark(WatermarkText, New Font("Segoe UI", 19, FontStyle.Bold))
                        watermark.ForegroundColor = Color.Red
                        watermark.BackgroundColor = Color.Aqua
                        watermark.VerticalAlignment = VerticalAlignment.Top
                        watermark.HorizontalAlignment = HorizontalAlignment.Center
                        doc.Worksheets(0).AddWatermarkIntoHeaderFooter(watermark)
                        doc.Save()
                    End Using
                    'ExEnd:AddTextWatermarkIntoHeaderFooter
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Removes watermark from Excel worksheet
            ''' </summary> 
            Public Shared Sub RemoveWatermark()
                Try
                    'ExStart:RemoveWatermarkExcelWorksheet
                    Using doc As CellsDocument = Document.Load(Of CellsDocument)(Utilities.MapSourceFilePath(FilePath))
                        ' Initialize search criteria
                        Dim imageSearchCriteria As ImageSearchCriteria = New ImageDctHashSearchCriteria("D:\logo.png")
                        Dim textSearchCriteria As New TextSearchCriteria("Company Name")

                        ' Call FindWatermarks method for the worksheet
                        Dim possibleWatermarks As PossibleWatermarkCollection = doc.Worksheets(0).FindWatermarks(textSearchCriteria.[Or](imageSearchCriteria))

                        ' Remove all found watermarks
                        For i As Object = possibleWatermarks.Count - 1 To 0 Step -1
                            possibleWatermarks.RemoveAt(i)
                        Next

                        doc.Save()
                    End Using
                    'ExEnd:RemoveWatermarkExcelWorksheet
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Extracts information about all the shapes is a Excel document 
            ''' </summary> 
            Public Shared Sub GetShapesInformation()
                Try
                    'ExStart:GetShapesInformationExcel
                    Using doc As CellsDocument = Document.Load(Of CellsDocument)(Utilities.MapSourceFilePath(FilePath))
                        For Each worksheet As CellsWorksheet In doc.Worksheets
                            For Each shape As CellsShape In worksheet.Shapes
                                Console.WriteLine(shape.AutoShapeType)
                                Console.WriteLine(shape.MsoDrawingType)
                                Console.WriteLine(shape.Text)
                                If shape.Image IsNot Nothing Then
                                    Console.WriteLine(shape.Image.Width)
                                    Console.WriteLine(shape.Image.Height)
                                    Console.WriteLine(shape.Image.GetBytes().Length)
                                End If
                                Console.WriteLine(shape.Id)
                                Console.WriteLine(shape.AlternativeText)
                                Console.WriteLine(shape.X)
                                Console.WriteLine(shape.Y)
                                Console.WriteLine(shape.Width)
                                Console.WriteLine(shape.Height)
                                Console.WriteLine(shape.RotateAngle)
                                Console.WriteLine(shape.IsWordArt)
                                Console.WriteLine(shape.Name)
                            Next
                        Next
                    End Using
                    'ExEnd:GetShapesInformationExcel
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Removes shape in an Excel worksheet 
            ''' </summary> 
            Public Shared Sub RemoveShape()
                Try
                    'ExStart:RemoveShapeExcelWorksheet
                    Using doc As CellsDocument = Document.Load(Of CellsDocument)(Utilities.MapSourceFilePath(FilePath))
                        ' Remove shape by index
                        doc.Worksheets(0).Shapes.RemoveAt(0)

                        ' Remove shape by reference
                        doc.Worksheets(0).Shapes.Remove(doc.Worksheets(0).Shapes(0))

                        doc.Save()
                    End Using
                    'ExEnd:RemoveShapeExcelWorksheet
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Adds watermark to all image shapes in a Excel document 
            ''' </summary> 
            Public Shared Sub AddWatermarkToImageShapes()
                Try
                    'ExStart:AddWatermarkToImageShapesExcelDocument
                    Using doc As CellsDocument = Document.Load(Of CellsDocument)("D:\test.xlsx")
                        ' Initialize image or text watermark
                        Dim watermark As New TextWatermark("Protected image", New Font("Arial", 8))
                        watermark.HorizontalAlignment = HorizontalAlignment.Center
                        watermark.VerticalAlignment = VerticalAlignment.Center
                        watermark.RotateAngle = 45
                        watermark.SizingType = SizingType.ScaleToParentDimensions
                        watermark.ScaleFactor = 1

                        For Each worksheet As CellsWorksheet In doc.Worksheets
                            For Each shape As CellsShape In worksheet.Shapes
                                If shape.Image IsNot Nothing Then
                                    ' Add watermark to the image
                                    shape.Image.AddWatermark(watermark)
                                End If
                            Next
                        Next

                        doc.Save()
                    End Using
                    'ExEnd:AddWatermarkToImageShapesExcelDocument
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Gets information about all worksheet backgrounds in a Excel document 
            ''' </summary> 
            Public Shared Sub GetInformationOfWorksheetBackgrounds()
                Try
                    'ExStart:GetInformationOfWorksheetBackgrounds
                    Using doc As CellsDocument = Document.Load(Of CellsDocument)(Utilities.MapSourceFilePath(FilePath))
                        For Each worksheet As CellsWorksheet In doc.Worksheets
                            If worksheet.BackgroundImage IsNot Nothing Then
                                Console.WriteLine(worksheet.BackgroundImage.Width)
                                Console.WriteLine(worksheet.BackgroundImage.Height)
                                Console.WriteLine(worksheet.BackgroundImage.GetBytes().Length)
                            End If
                        Next
                    End Using
                    'ExEnd:GetInformationOfWorksheetBackgrounds
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Removes background in a Excel worksheet 
            ''' </summary> 
            Public Shared Sub RemoveWorksheetBackground()
                Try
                    'ExStart:RemoveWorksheetBackground
                    Using doc As CellsDocument = Document.Load(Of CellsDocument)(Utilities.MapSourceFilePath(FilePath))
                        doc.Worksheets(0).BackgroundImage = Nothing
                        doc.Save()
                    End Using
                    'ExEnd:RemoveWorksheetBackground
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Adds watermark to all background images in a Excel worksheet 
            ''' </summary> 
            Public Shared Sub AddWatermarkToBackgroundImages()
                Try
                    'ExStart:AddWatermarkToBackgroundImagesExcel
                    Using doc As CellsDocument = Document.Load(Of CellsDocument)(Utilities.MapSourceFilePath(FilePath))
                        ' Initialize image or text watermark
                        Dim watermark As New TextWatermark("Protected image", New Font("Arial", 8))
                        watermark.HorizontalAlignment = HorizontalAlignment.Center
                        watermark.VerticalAlignment = VerticalAlignment.Center
                        watermark.RotateAngle = 45
                        watermark.SizingType = SizingType.ScaleToParentDimensions
                        watermark.ScaleFactor = 1

                        For Each worksheet As CellsWorksheet In doc.Worksheets
                            If worksheet.BackgroundImage IsNot Nothing Then
                                ' Add watermark to the image
                                worksheet.BackgroundImage.AddWatermark(watermark)
                            End If
                        Next
                        doc.Save()
                    End Using
                    'ExEnd:AddWatermarkToBackgroundImagesExcel
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Gets information about all headers/footers in a Excel document 
            ''' </summary> 
            Public Shared Sub GetHeaderFooterInformation()
                Try
                    'ExStart:GetHeaderFooterInformationExcel
                    Using doc As CellsDocument = Document.Load(Of CellsDocument)(Utilities.MapSourceFilePath(FilePath))
                        For Each worksheet As CellsWorksheet In doc.Worksheets
                            For Each headerFooter As CellsHeaderFooter In worksheet.HeadersFooters
                                Console.WriteLine(headerFooter.HeaderFooterType)
                                For Each section As CellsHeaderFooterSection In headerFooter.Sections
                                    Console.WriteLine(section.SectionType)
                                    If section.Image IsNot Nothing Then
                                        Console.WriteLine(section.Image.Width)
                                        Console.WriteLine(section.Image.Height)
                                        Console.WriteLine(section.Image.GetBytes().Length)
                                    End If
                                    Console.WriteLine(section.Script)
                                Next
                            Next
                        Next
                    End Using
                    'ExEnd:GetHeaderFooterInformationExcel
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Clears particular headers/footers in a Excel worksheet 
            ''' </summary> 
            Public Shared Sub ClearHeaderFooter()
                Try
                    'ExStart:ClearHeaderFooterExcel
                    Using doc As CellsDocument = Document.Load(Of CellsDocument)(Utilities.MapSourceFilePath(FilePath))
                        For Each section As CellsHeaderFooterSection In doc.Worksheets(0).HeadersFooters(OfficeHeaderFooterType.HeaderPrimary).Sections
                            section.Script = Nothing
                            section.Image = Nothing
                        Next
                        doc.Save()
                    End Using
                    'ExEnd:ClearHeaderFooterExcel
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Clears particular section of headers/footers in a Excel worksheet 
            ''' </summary> 
            Public Shared Sub ClearSectionOfHeaderFooter()
                Try
                    'ExStart:ClearSectionOfHeaderFooterExcel
                    Using doc As CellsDocument = Document.Load(Of CellsDocument)(Utilities.MapSourceFilePath(FilePath))
                        Dim section As CellsHeaderFooterSection = doc.Worksheets(0).HeadersFooters(OfficeHeaderFooterType.HeaderEven).Sections(CellsHeaderFooterSectionType.Left)
                        section.Image = Nothing
                        section.Script = Nothing

                        doc.Save()
                    End Using
                    'ExEnd:ClearSectionOfHeaderFooterExcel
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Adds watermark to all images of headers/footers in a Excel worksheet 
            ''' </summary> 
            Public Shared Sub AddWatermarkToImagesInHeaderFooter()
                Try
                    'ExStart:AddWatermarkToImagesInHeaderFooterExcel
                    Using doc As CellsDocument = Document.Load(Of CellsDocument)(Utilities.MapSourceFilePath(FilePath))
                        ' Initialize image or text watermark
                        Dim watermark As New TextWatermark("Protected image", New Font("Arial", 8))
                        watermark.HorizontalAlignment = HorizontalAlignment.Center
                        watermark.VerticalAlignment = VerticalAlignment.Center
                        watermark.RotateAngle = 45
                        watermark.SizingType = SizingType.ScaleToParentDimensions
                        watermark.ScaleFactor = 1

                        For Each worksheet As CellsWorksheet In doc.Worksheets
                            For Each headerFooter As CellsHeaderFooter In worksheet.HeadersFooters
                                For Each section As CellsHeaderFooterSection In headerFooter.Sections
                                    If section.Image IsNot Nothing Then
                                        ' Add watermark to the image
                                        section.Image.AddWatermark(watermark)
                                    End If
                                Next
                            Next
                        Next
                    End Using
                    'ExEnd:AddWatermarkToImagesInHeaderFooterExcel
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

        End Class
        Public NotInheritable Class PowerPoint
            Private Sub New()
            End Sub
            ' initialize file path
            'ExStart:SourcePowerPointFilePath
            Private Const FilePath As String = "Documents/sample.pptx"
            'ExEnd:SourcePowerPointFilePath

            ''' <summary>
            ''' Adds watermark to a PowerPoint slide
            ''' </summary> 
            Public Shared Sub AddWatermark()
                Try
                    'ExStart:AddWatermarkToPowerPointSlide
                    Using doc As SlidesDocument = Document.Load(Of SlidesDocument)(Utilities.MapSourceFilePath(FilePath))
                        ' Add text watermark
                        Dim textWatermark As New TextWatermark("Test watermark", New Font("Arial", 8))
                        doc.Slides(0).AddWatermark(textWatermark)

                        ' Add image watermark
                        Using imageWatermark As New ImageWatermark("D:\logo.jpg")
                            doc.Slides(1).AddWatermark(imageWatermark)
                        End Using
                        doc.Save()
                    End Using
                    'ExEnd:AddWatermarkToPowerPointSlide
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Gets dimensions of a PowerPoint slide
            ''' </summary> 
            Public Shared Sub GetDimensionsOfSlide()
                Try
                    'ExStart:GetDimensionsOfSlide
                    Using doc As SlidesDocument = Document.Load(Of SlidesDocument)(Utilities.MapSourceFilePath(FilePath))
                        Console.WriteLine(doc.SlideWidth)
                        Console.WriteLine(doc.SlideHeight)
                    End Using
                    'ExEnd:GetDimensionsOfSlide
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Adds watermark to all images of a PowerPoint slide
            ''' </summary> 
            Public Shared Sub AddWatermarkToImages()
                Try
                    'ExStart:AddWatermarkToImagesPowerPointSlide
                    Using doc As SlidesDocument = Document.Load(Of SlidesDocument)("D:\test.pptx")
                        Dim watermark As New TextWatermark("Protected image", New Font("Arial", 8))
                        watermark.HorizontalAlignment = HorizontalAlignment.Center
                        watermark.VerticalAlignment = VerticalAlignment.Center
                        watermark.RotateAngle = 45
                        watermark.SizingType = SizingType.ScaleToParentDimensions
                        watermark.ScaleFactor = 1

                        ' Get all images from the first slide
                        Dim images As WatermarkableImageCollection = doc.Slides(0).FindImages()

                        ' Add watermark to all found images
                        For Each image As WatermarkableImage In images
                            image.AddWatermark(watermark)
                        Next

                        doc.Save()
                    End Using
                    'ExEnd:AddWatermarkToImagesPowerPointSlide
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Adds watermark to all slide types of PowerPoint document
            ''' </summary> 
            Public Shared Sub AddWatermarkToAllSlideTypes()
                Try
                    'ExStart:AddWatermarkToAllSlideTypes
                    Using doc As SlidesDocument = Document.Load(Of SlidesDocument)("D:\test.pptx")
                        Dim watermark As New TextWatermark("Test watermark", New Font("Arial", 8))

                        ' Add watermark to all master slides
                        For Each slide As SlidesMasterSlide In doc.MasterSlides
                            slide.AddWatermark(watermark)
                        Next

                        ' Add watermark to all layout slides
                        If doc.LayoutSlides IsNot Nothing Then
                            For Each slide As SlidesLayoutSlide In doc.LayoutSlides
                                slide.AddWatermark(watermark)
                            Next
                        End If

                        ' Add watermark to all notes slides
                        For Each slide As SlidesSlide In doc.Slides
                            If slide.NotesSlide IsNot Nothing Then
                                slide.NotesSlide.AddWatermark(watermark)
                            End If
                        Next

                        ' Add watermark to handout master
                        If doc.MasterHandoutSlide IsNot Nothing Then
                            doc.MasterHandoutSlide.AddWatermark(watermark)
                        End If

                        ' Add watermark to notes master
                        If doc.MasterNotesSlide IsNot Nothing Then
                            doc.MasterNotesSlide.AddWatermark(watermark)
                        End If
                        doc.Save()
                    End Using
                    'ExEnd:AddWatermarkToAllSlideTypes
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Adds watermark to a PowerPoint slide with Slides Shape Settings
            ''' </summary> 
            Public Shared Sub AddWatermarkWithSlidesShapeSettings()
                Try
                    'ExStart:AddWatermarkWithSlidesShapeSettings
                    Using doc As SlidesDocument = Document.Load(Of SlidesDocument)(Utilities.MapSourceFilePath(FilePath))
                        Dim watermark As New TextWatermark("Test watermark", New Font("Arial", 19))
                        watermark.IsBackground = True
                        Dim shapeSettings As New SlidesShapeSettings()

                        ' Set the shape name
                        shapeSettings.Name = "Shape 1"

                        ' Set the descriptive (alternative) text that will be associated with the shape
                        shapeSettings.AlternativeText = "Test watermark"

                        ' Editing of the shape in PowerPoint is forbidden
                        shapeSettings.IsLocked = True

                        doc.AddWatermark(watermark, shapeSettings)

                        doc.Save()
                    End Using
                    'ExEnd:AddWatermarkWithSlidesShapeSettings
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Adds watermark with text effects to a PowerPoint slide
            ''' </summary> 
            Public Shared Sub AddWatermarkWithTextEffects()
                Try
                    'ExStart:AddWatermarkWithTextEffectsPowerPointSlide
                    Using doc As SlidesDocument = Document.Load(Of SlidesDocument)("D:\test.pptx")
                        Dim watermark As New TextWatermark("Test watermark", New Font("Segoe UI", 19))

                        Dim effects As New SlidesTextEffects()
                        effects.LineFormat.Enabled = True
                        effects.LineFormat.Color = Color.Red
                        effects.LineFormat.DashStyle = OfficeDashStyle.DashDotDot
                        effects.LineFormat.LineStyle = OfficeLineStyle.Triple
                        effects.LineFormat.Weight = 1
                        doc.AddTextWatermark(watermark, effects)
                        doc.Save()
                    End Using
                    'ExEnd:AddWatermarkWithTextEffectsPowerPointSlide
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Adds watermark with image effects to a PowerPoint slide
            ''' </summary> 
            Public Shared Sub AddWatermarkWithImageEffects()
                Try
                    'ExStart:AddWatermarkWithImageEffectsPowerPointSlide
                    Using doc As SlidesDocument = Document.Load(Of SlidesDocument)("D:\test.pptx")
                        Using watermark = New ImageWatermark("D:\logo.png")
                            Dim effects As New SlidesImageEffects()
                            effects.Brightness = 0.7
                            effects.Contrast = 0.6
                            effects.ChromaKey = Color.Red
                            effects.BorderLineFormat.Enabled = True
                            effects.BorderLineFormat.Weight = 1
                            doc.AddImageWatermark(watermark, effects)
                        End Using
                        doc.Save()
                    End Using
                    'ExEnd:AddWatermarkWithImageEffectsPowerPointSlide
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub


            ''' <summary>
            ''' Removes watermark from PowerPoint slide
            ''' </summary> 
            Public Shared Sub RemoveWatermark()
                Try
                    'ExStart:RemoveWatermarkPowerPoint
                    Using doc As SlidesDocument = Document.Load(Of SlidesDocument)(Utilities.MapSourceFilePath(FilePath))
                        ' Initialize search criteria
                        Dim imageSearchCriteria As ImageSearchCriteria = New ImageDctHashSearchCriteria("D:\logo.png")
                        Dim textSearchCriteria As New TextSearchCriteria("Company Name")

                        ' Call FindWatermarks method for the slide
                        Dim possibleWatermarks As PossibleWatermarkCollection = doc.Slides(0).FindWatermarks(textSearchCriteria.[Or](imageSearchCriteria))

                        ' Remove all found watermarks
                        For i As Object = possibleWatermarks.Count - 1 To 0 Step -1
                            possibleWatermarks.RemoveAt(i)
                        Next

                        doc.Save()
                    End Using
                    'ExEnd:RemoveWatermarkPowerPoint
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Extracts information about all the shapes in PowerPoint slide 
            ''' </summary> 
            Public Shared Sub GetShapesInformation()
                Try
                    'ExStart:GetShapesInformationPowerPoint
                    Using doc As SlidesDocument = Document.Load(Of SlidesDocument)(Utilities.MapSourceFilePath(FilePath))
                        For Each slide As SlidesSlide In doc.Slides
                            For Each shape As SlidesShape In slide.Shapes
                                If shape.Image IsNot Nothing Then
                                    Console.WriteLine(shape.Image.Width)
                                    Console.WriteLine(shape.Image.Height)
                                    Console.WriteLine(shape.Image.GetBytes().Length)
                                End If
                                Console.WriteLine(shape.Name)
                                Console.WriteLine(shape.AlternativeText)
                                Console.WriteLine(shape.X)
                                Console.WriteLine(shape.Y)
                                Console.WriteLine(shape.Width)
                                Console.WriteLine(shape.Height)
                                Console.WriteLine(shape.RotateAngle)
                                Console.WriteLine(shape.Text)
                                Console.WriteLine(shape.Id)
                                Console.WriteLine(shape.ShapeType)
                                Console.WriteLine(shape.ZOrderPosition)
                            Next
                        Next
                    End Using
                    'ExEnd:GetShapesInformationPowerPoint
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Remove shape from PowerPoint slide
            ''' </summary> 
            Public Shared Sub RemoveShape()
                Try
                    'ExStart:RemoveShapePowerPoint
                    Using doc As SlidesDocument = Document.Load(Of SlidesDocument)("D:\test.pptx")
                        ' Remove shape by index
                        doc.Slides(0).Shapes.RemoveAt(0)

                        ' Remove shape by reference
                        doc.Slides(0).Shapes.Remove(doc.Slides(0).Shapes(0))

                        doc.Save()
                    End Using
                    'ExEnd:RemoveShapePowerPoint
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Adds watermark to all image shapes in a PowerPoint document 
            ''' </summary> 
            Public Shared Sub AddWatermarkToImageShapes()
                Try
                    'ExStart:AddWatermarkToImageShapesPowerPointDocument
                    Using doc As SlidesDocument = Document.Load(Of SlidesDocument)("D:\test.pptx")
                        ' Initialize image or text watermark
                        Dim watermark As New TextWatermark("Protected image", New Font("Arial", 8))
                        watermark.HorizontalAlignment = HorizontalAlignment.Center
                        watermark.VerticalAlignment = VerticalAlignment.Center
                        watermark.RotateAngle = 45
                        watermark.SizingType = SizingType.ScaleToParentDimensions
                        watermark.IsBackground = True
                        watermark.ScaleFactor = 1

                        For Each slide As SlidesSlide In doc.Slides
                            For Each shape As SlidesShape In slide.Shapes
                                If shape.Image IsNot Nothing Then
                                    ' Add watermark to the image
                                    shape.Image.AddWatermark(watermark)
                                End If
                            Next
                        Next

                        doc.Save()
                    End Using
                    'ExEnd:AddWatermarkToImageShapesPowerPointDocument
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Gets information of all slide backgrounds of a PowerPoint document 
            ''' </summary> 
            Public Shared Sub GetInformationOfSlideBackgrounds()
                Try
                    'ExStart:GetInformationOfSlideBackgroundsPowerPointDocument
                    Using doc As SlidesDocument = Document.Load(Of SlidesDocument)(Utilities.MapSourceFilePath(FilePath))
                        For Each slide As SlidesSlide In doc.Slides
                            If slide.BackgroundImage IsNot Nothing Then
                                Console.WriteLine(slide.BackgroundImage.Width)
                                Console.WriteLine(slide.BackgroundImage.Height)
                                Console.WriteLine(slide.BackgroundImage.GetBytes().Length)
                            End If
                        Next
                    End Using
                    'ExEnd:GetInformationOfSlideBackgroundsPowerPointDocument
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Removes background of a PowerPoint slide 
            ''' </summary> 
            Public Shared Sub RemoveBackground()
                Try
                    'ExStart:RemoveBackgroundPowerPointSlide
                    Using doc As SlidesDocument = Document.Load(Of SlidesDocument)(Utilities.MapSourceFilePath(FilePath))
                        doc.Slides(0).BackgroundImage = Nothing
                    End Using
                    'ExEnd:RemoveBackgroundPowerPointSlide
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub

            ''' <summary>
            ''' Adds watermark to all background images of a PowerPoint slide 
            ''' </summary> 
            Public Shared Sub AddWatermarkToAllBackgroundImages()
                Try
                    'ExStart:AddWatermarkToAllBackgroundImagesPowerPointSlide
                    Using doc As SlidesDocument = Document.Load(Of SlidesDocument)(Utilities.MapSourceFilePath(FilePath))
                        ' Initialize image or text watermark
                        Dim watermark As New TextWatermark("Protected image", New Font("Arial", 8))
                        watermark.HorizontalAlignment = HorizontalAlignment.Center
                        watermark.VerticalAlignment = VerticalAlignment.Center
                        watermark.RotateAngle = 45
                        watermark.SizingType = SizingType.ScaleToParentDimensions
                        watermark.ScaleFactor = 1

                        For Each slide As SlidesSlide In doc.Slides
                            If slide.BackgroundImage IsNot Nothing Then
                                ' Add watermark to the image
                                slide.AddWatermark(watermark)
                            End If
                        Next

                        doc.Save()
                    End Using
                    'ExEnd:AddWatermarkToAllBackgroundImagesPowerPointSlide
                Catch exp As Exception
                    Console.Write(exp.Message)
                End Try
            End Sub
        End Class
    End Class
End Namespace

