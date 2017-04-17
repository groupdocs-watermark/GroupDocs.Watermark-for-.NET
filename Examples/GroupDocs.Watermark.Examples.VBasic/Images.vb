Imports GroupDocs.Watermark.Images
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace GroupDocs.Watermark.Examples.VBasic
    Public NotInheritable Class Images
        Private Sub New()
        End Sub
        ' initialize file path
        'ExStart:SourceImageFilePath
        Private Const FilePath As String = "Images/sample.jpg"
        'ExEnd:SourceImageFilePath

        ''' <summary>
        ''' Adds watermark to an image
        ''' </summary> 
        Public Shared Sub AddWatermark()
            Try
                'ExStart:AddWatermarkToImage
                Using doc As MultiframeImageDocument = Document.Load(Of MultiframeImageDocument)(FilePath)
                    ' Initialize text or image watermark
                    Dim watermark As New TextWatermark("Test watermark", New Font("Arial", 19))

                    ' Add watermark to the first frame
                    doc.Frames(0).AddWatermark(watermark)

                    doc.Save()
                End Using
                'ExEnd:AddWatermarkToImage
            Catch exp As Exception
                Console.Write(exp.Message)
            End Try
        End Sub

    End Class
End Namespace

