Imports GroupDocs.Watermark.Search
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading.Tasks

Namespace GroupDocs.Watermark.Examples.VBasic
    Public NotInheritable Class WatermarkOperations
        Private Sub New()
        End Sub
        ' initialize file paths
        'ExStart:SourceDocumentFilesPath
        Private Const PngFilePath As String = "Images/sample.JPG"
        Private Const DocFilePath As String = "Documents/sample.docx"
        Private Const PptFilePath As String = "Documents/sample.pptx"
        Private Const XlsFilePath As String = "Documents/sample.xlsx"
        'ExEnd:SourceDocumentFilesPath

#Region "Adding Watermark"
        ''' <summary>
        ''' Adds text watermark to a supported document
        ''' </summary> 
        Public Shared Sub AddTextWatermark()
            Try
                'ExStart:AddTextWatermark
                Using doc As Document = Document.Load(Utilities.MapSourceFilePath(PngFilePath))
                    ' Initialize the font to be used for watermark
                    Dim font As New Font("Arial", 19, FontStyle.Bold Or FontStyle.Italic)

                    Dim watermark As New TextWatermark("Test watermark", font)

                    ' Set watermark properties
                    watermark.ForegroundColor = Color.Red
                    watermark.BackgroundColor = Color.Blue
                    watermark.TextAlignment = TextAlignment.Right
                    watermark.Opacity = 0.5

                    doc.AddWatermark(watermark)

                    doc.Save()
                End Using
                'ExEnd:AddTextWatermark
            Catch exp As Exception
                Console.Write(exp.Message)
            End Try
        End Sub

        ''' <summary>
        ''' Adds image watermark to a supported document
        ''' </summary> 
        Public Shared Sub AddImageWatermark()
            Try
                'ExStart:AddImageWatermark
                Using doc As Document = Document.Load(Utilities.MapSourceFilePath(PptFilePath))
                    ' Use path to the image as constructor parameter
                    Using watermark As New ImageWatermark("D:\watermark.jpg")
                        ' Add watermark to the document
                        doc.AddWatermark(watermark)

                        doc.Save()
                    End Using
                End Using
                'ExEnd:AddImageWatermark
            Catch exp As Exception
                Console.Write(exp.Message)
            End Try
        End Sub

        ''' <summary>
        ''' Adds image watermark using stream to a supported document
        ''' </summary> 
        Public Shared Sub AddImageWatermarkUsingStream()
            Try
                'ExStart:AddImageWatermarkUsingStream
                Using watermarkStream As Stream = File.OpenRead("D:\watermark.jpg")
                    Using doc As Document = Document.Load(Utilities.MapSourceFilePath(PngFilePath))
                        ' Use stream containing an image as constructor parameter
                        Using watermark As New ImageWatermark(watermarkStream)
                            ' Add watermark to the document
                            doc.AddWatermark(watermark)

                            doc.Save()
                        End Using
                    End Using
                End Using
                'ExEnd:AddImageWatermarkUsingStream
            Catch exp As Exception
                Console.Write(exp.Message)
            End Try
        End Sub

        ''' <summary>
        ''' Adds watermark to an absolute position
        ''' </summary> 
        Public Shared Sub AddWatermarkToAbsolutePosition()
            Try
                'ExStart:AddWatermarkToAbsolutePosition
                Using doc As Document = Document.Load(Utilities.MapSourceFilePath(DocFilePath))
                    Dim font As New Font("Times New Roman", 8)
                    Dim watermark As New TextWatermark("Test watermark", font)

                    ' Set watermark coordinates
                    watermark.X = 10
                    watermark.Y = 20

                    ' Set watermark size
                    watermark.Width = 100
                    watermark.Height = 40

                    doc.AddWatermark(watermark)
                    doc.Save()
                End Using
                'ExEnd:AddWatermarkToAbsolutePosition
            Catch exp As Exception
                Console.Write(exp.Message)
            End Try
        End Sub

        ''' <summary>
        ''' Adds watermark to relative position
        ''' </summary> 
        Public Shared Sub AddWatermarkToRelativePosition()
            Try
                'ExStart:AddWatermarkToRelativePosition
                Using doc As Document = Document.Load(Utilities.MapSourceFilePath(XlsFilePath))
                    Dim font As New Font("Calibri", 12)
                    Dim watermark As New TextWatermark("Test watermark", font)
                    watermark.HorizontalAlignment = HorizontalAlignment.Right
                    watermark.VerticalAlignment = VerticalAlignment.Bottom

                    ' Set absolute margins. Values are measured in document units.
                    watermark.Margins.Right = 10
                    watermark.Margins.Bottom = 5

                    doc.AddWatermark(watermark)
                    doc.Save()
                End Using
                'ExEnd:AddWatermarkToRelativePosition
            Catch exp As Exception
                Console.Write(exp.Message)
            End Try
        End Sub

        ''' <summary>
        ''' Adds watermark with a particular margin type
        ''' </summary> 
        Public Shared Sub AddWatermarkWithMarginType()
            Try
                'ExStart:AddWatermarkWithMarginType
                Using doc As Document = Document.Load(Utilities.MapSourceFilePath(XlsFilePath))
                    Dim font As New Font("Calibri", 12)
                    Dim watermark As New TextWatermark("Test watermark", font)
                    watermark.HorizontalAlignment = HorizontalAlignment.Right
                    watermark.VerticalAlignment = VerticalAlignment.Bottom

                    ' Set relative margins. Margin value will be interpreted as a portion of appropriate parent dimension.
                    ' If this type is chosen, margin value must be between 0.0 and 1.0.
                    watermark.Margins.MarginType = MarginType.RelativeToParentDimensions
                    watermark.Margins.Right = 0.1
                    watermark.Margins.Bottom = 0.2

                    doc.AddWatermark(watermark)
                    doc.Save()
                End Using
                'ExEnd:AddWatermarkWithMarginType
            Catch exp As Exception
                Console.Write(exp.Message)
            End Try
        End Sub

        ''' <summary>
        ''' Adds watermark according to the parent margins
        ''' </summary> 
        Public Shared Sub AddWatermarkWithParentMargin()
            Try
                'ExStart:AddWatermarkWithParentMargin
                Using doc As Document = Document.Load(Utilities.MapSourceFilePath(DocFilePath))
                    Dim watermark = New TextWatermark("Test watermark", New Font("Arial", 42))
                    watermark.HorizontalAlignment = HorizontalAlignment.Right
                    watermark.VerticalAlignment = VerticalAlignment.Top
                    watermark.SizingType = SizingType.ScaleToParentDimensions
                    watermark.ScaleFactor = 1
                    watermark.RotateAngle = 45
                    watermark.ForegroundColor = Color.Red
                    watermark.BackgroundColor = Color.Aqua

                    ' Add watermark considering parent margins
                    watermark.ConsiderParentMargins = True
                    doc.AddWatermark(watermark)
                    doc.Save()
                    'ExEnd:AddWatermarkWithParentMargin
                End Using
            Catch exp As Exception
                Console.Write(exp.Message)
            End Try
        End Sub

        ''' <summary>
        ''' Adds watermark with a particular size type
        ''' </summary> 
        Public Shared Sub AddWatermarkWithSizeType()
            Try
                'ExStart:AddWatermarkWithSizeType
                Using doc As Document = Document.Load(Utilities.MapSourceFilePath(PngFilePath))
                    Dim font As New Font("Calibri", 12)
                    Dim watermark As New TextWatermark("This is a test watermark", font)

                    ' Set sizing type
                    watermark.SizingType = SizingType.ScaleToParentDimensions

                    ' Set watermark scale
                    watermark.ScaleFactor = 0.5

                    doc.AddWatermark(watermark)
                    doc.Save()
                End Using
                'ExEnd:AddWatermarkWithSizeType
            Catch exp As Exception
                Console.Write(exp.Message)
            End Try
        End Sub

        ''' <summary>
        ''' Adds watermark with rotation angle
        ''' <param name="RotationAngle">Rotation angle</param>
        ''' </summary> 
        Public Shared Sub AddTextWatermark(RotationAngle As Integer)
            Try
                'ExStart:AddTextWatermarkWithRotationAngle
                Using doc As Document = Document.Load(Utilities.MapSourceFilePath(DocFilePath))
                    Dim font As New Font("Calibri", 8)
                    Dim watermark As New TextWatermark("Test watermark", font)
                    watermark.HorizontalAlignment = HorizontalAlignment.Right
                    watermark.VerticalAlignment = VerticalAlignment.Top
                    watermark.SizingType = SizingType.ScaleToParentDimensions
                    watermark.ScaleFactor = 0.5

                    ' Set rotation angle
                    watermark.RotateAngle = 45

                    doc.AddWatermark(watermark)
                    doc.Save()
                End Using
                'ExEnd:AddTextWatermarkWithRotationAngle
            Catch exp As Exception
                Console.Write(exp.Message)
            End Try
        End Sub

        ''' <summary>
        ''' Adds watermark to the images inside a document
        ''' </summary> 
        Public Shared Sub AddWatermarkToImages()
            Try
                'ExStart:AddWatermarkToImages
                Using doc As Document = Document.Load(Utilities.MapSourceFilePath(PptFilePath))
                    ' Initialize text watermark
                    Dim textWatermark As New TextWatermark("Protected image", New Font("Arial", 8))
                    textWatermark.HorizontalAlignment = HorizontalAlignment.Center
                    textWatermark.VerticalAlignment = VerticalAlignment.Center
                    textWatermark.RotateAngle = 45
                    textWatermark.SizingType = SizingType.ScaleToParentDimensions
                    textWatermark.ScaleFactor = 1

                    ' Initialize image watermark
                    Using imageWatermark As New ImageWatermark("D:\protect.jpg")
                        imageWatermark.HorizontalAlignment = HorizontalAlignment.Center
                        imageWatermark.VerticalAlignment = VerticalAlignment.Center
                        imageWatermark.RotateAngle = -45
                        imageWatermark.SizingType = SizingType.ScaleToParentDimensions
                        imageWatermark.ScaleFactor = 1

                        ' Find all images in a document
                        Dim images As WatermarkableImageCollection = doc.FindImages()

                        For i As Integer = 0 To images.Count - 1
                            If images(i).Width > 100 AndAlso images(i).Height > 100 Then
                                If i Mod 2 = 0 Then
                                    images(i).AddWatermark(textWatermark)
                                Else
                                    images(i).AddWatermark(imageWatermark)
                                End If
                            End If
                        Next
                    End Using
                    doc.Save()
                End Using
                'ExEnd:AddWatermarkToImages
            Catch exp As Exception
                Console.Write(exp.Message)
            End Try
        End Sub
#End Region

#Region "Searching and Removing Watermark"
        ''' <summary>
        ''' Searches for watermark in a document
        ''' </summary> 
        Public Shared Sub SearchWatermark()
            Try
                'ExStart:SearchWatermark
                Using doc As Document = Document.Load(Utilities.MapSourceFilePath(DocFilePath))
                    Dim possibleWatermarks As PossibleWatermarkCollection = doc.FindWatermarks()
                    For Each possibleWatermark As PossibleWatermark In possibleWatermarks
                        If possibleWatermark.ImageData IsNot Nothing Then
                            Console.WriteLine(possibleWatermark.ImageData.Length)
                        End If
                        Console.WriteLine(possibleWatermark.Text)
                        Console.WriteLine(possibleWatermark.X)
                        Console.WriteLine(possibleWatermark.Y)
                        Console.WriteLine(possibleWatermark.RotateAngle)
                        Console.WriteLine(possibleWatermark.Width)
                        Console.WriteLine(possibleWatermark.Height)
                    Next
                End Using
                'ExEnd:SearchWatermark
            Catch exp As Exception
                Console.Write(exp.Message)
            End Try
        End Sub

        ''' <summary>
        ''' Searches for watermark with a particular text
        ''' <param name="SearchString">Search String</param>
        ''' </summary> 
        Public Shared Sub SearchWatermark(SearchString As String)
            Try
                'ExStart:SearchWatermarkWithSearchString
                Using doc As Document = Document.Load(Utilities.MapSourceFilePath(PptFilePath))
                    ' Search by exact string
                    Dim textSearchCriteria As New TextSearchCriteria("© 2017")

                    ' Find all possible watermarks containing some specific text

                    ' ...
                    Dim possibleWatermarks As PossibleWatermarkCollection = doc.FindWatermarks(textSearchCriteria)
                End Using
                'ExEnd:SearchWatermarkWithSearchString
            Catch exp As Exception
                Console.Write(exp.Message)
            End Try
        End Sub

        ''' <summary>
        ''' Searches for watermark with a regular expression
        ''' <param name="RegularExpression">Regular Expression</param>
        ''' </summary> 
        Public Shared Sub SearchWatermark(RegularExpression As Regex)
            Try
                'ExStart:SearchWatermarkWithRegularExpression
                Using doc As Document = Document.Load(Utilities.MapSourceFilePath(DocFilePath))
                    Dim regex As New Regex("^© \d{4}$")

                    ' Search by regular expression
                    Dim textSearchCriteria As New TextSearchCriteria(regex)

                    ' Find possible watermarks using regular expression

                    ' ...
                    Dim possibleWatermarks As PossibleWatermarkCollection = doc.FindWatermarks(textSearchCriteria)
                End Using
                'ExEnd:SearchWatermarkWithRegularExpression
            Catch exp As Exception
                Console.Write(exp.Message)
            End Try
        End Sub

        ''' <summary>
        ''' Searches for image watermark
        ''' </summary> 
        Public Shared Sub SearchImageWatermark()
            Try
                'ExStart:SearchImageWatermark
                Using doc As Document = Document.Load(Utilities.MapSourceFilePath(PptFilePath))
                    ' Initialize criteria with the image
                    Dim imageSearchCriteria As ImageSearchCriteria = New ImageDctHashSearchCriteria("D:\watermark.jpg")

                    'Set maximum allowed difference between images
                    imageSearchCriteria.MaxDifference = 0.9


                    ' ...
                    Dim possibleWatermarks As PossibleWatermarkCollection = doc.FindWatermarks(imageSearchCriteria)
                End Using
                'ExEnd:SearchImageWatermark
            Catch exp As Exception
                Console.Write(exp.Message)
            End Try
        End Sub

        ''' <summary>
        ''' Searches for watermark with combination of different search criterias
        ''' </summary> 
        Public Shared Sub SearchWatermarkWithCombinedSearch()
            Try
                'ExStart:SearchWatermarkWithCombinedSearch
                Using doc As Document = Document.Load(Utilities.MapSourceFilePath(DocFilePath))
                    Dim imageSearchCriteria As ImageSearchCriteria = New ImageDctHashSearchCriteria("D:\logo.png")
                    imageSearchCriteria.MaxDifference = 0.9

                    Dim textSearchCriteria As New TextSearchCriteria("Company Name")

                    Dim rotateAngleSearchCriteria As New RotateAngleSearchCriteria(30, 60)

                    Dim combinedSearchCriteria As SearchCriteria = imageSearchCriteria.[Or](textSearchCriteria).[And](rotateAngleSearchCriteria)

                    ' ...
                    Dim possibleWatermarks As PossibleWatermarkCollection = doc.FindWatermarks(combinedSearchCriteria)
                End Using
                'ExEnd:SearchWatermarkWithCombinedSearch
            Catch exp As Exception
                Console.Write(exp.Message)
            End Try
        End Sub

        ''' <summary>
        ''' Removes watermark
        ''' </summary> 
        Public Shared Sub RemoveWatermark()
            Try
                'ExStart:RemoveWatermark
                Using doc As Document = Document.Load(Utilities.MapSourceFilePath(XlsFilePath))
                    Dim possibleWatermarks As PossibleWatermarkCollection = doc.FindWatermarks()

                    ' Remove possible watermark at the specified index from the document.
                    possibleWatermarks.RemoveAt(0)

                    ' Remove specified possible watermark from the document.
                    possibleWatermarks.Remove(possibleWatermarks(0))

                    doc.Save()
                End Using
                'ExEnd:RemoveWatermark
            Catch exp As Exception
                Console.Write(exp.Message)
            End Try
        End Sub
#End Region
    End Class
End Namespace
