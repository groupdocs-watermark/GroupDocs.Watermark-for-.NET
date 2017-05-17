Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports GroupDocs.Watermark.Search
Imports System.Text.RegularExpressions

Namespace GroupDocs.Watermark.Examples.VBasic
    Public NotInheritable Class Utilities
        Private Sub New()
        End Sub
        'ExStart:CommonProperties
        Private Const SourceFolderPath As String = "../../../Data/"
        Public Const licensePath As String = "D:/license/GroupDocs.Total.lic"
        'ExEnd:CommonProperties

        ''' <summary>
        ''' Maps source file path
        ''' </summary>
        ''' <param name="SourceFileName">Source File Name</param>
        ''' <returns>Returns complete path of source file</returns>
        Public Shared Function MapSourceFilePath(SourceFileName As String) As String
            Try
                Return SourceFolderPath & SourceFileName
            Catch exp As Exception
                Console.WriteLine(exp.Message)
                Return exp.Message
            End Try
        End Function

        ''' <summary>
        ''' Set product's license 
        ''' </summary>
        Public Shared Sub ApplyLicense()
            Try
                'ExStart:ApplyLicence
                Using fileStream As New FileStream(licensePath, FileMode.Open, FileAccess.Read)
                    Dim lic As New License()
                    lic.SetLicense(fileStream)
                End Using
                'ExEnd:ApplyLicence
            Catch exc As System.Exception
                Console.Write(exc.Message)
            End Try
        End Sub

        ''' <summary>
        ''' Gets document information
        ''' </summary> 
        Public Shared Sub GetDocumentInformation()
            Try
                'ExStart:GetDocumentInformation
                Dim documentInfo As DocumentInfo = Document.GetInfo("C:\test.ppt")
                Console.WriteLine(documentInfo.FileFormat)
                Console.WriteLine(documentInfo.IsEncrypted)
                'ExEnd:GetDocumentInformation
            Catch exp As Exception
                Console.Write(exp.Message)
            End Try
        End Sub

        ''' <summary>
        ''' Loads password protected document
        ''' </summary> 
        Public Shared Sub LoadPasswordProtectedDocument()
            Try
                'ExStart:LoadPasswordProtectedDocument
                ' Use LoadOptions instance to pass the password
                Dim loadOptions As New LoadOptions()
                loadOptions.Password = "123"

                Using doc As Document = Document.Load("C:\test.docx", loadOptions)
                End Using
                'ExEnd:LoadPasswordProtectedDocument
            Catch exp As Exception
                Console.Write(exp.Message)
            End Try
        End Sub

        ''' <summary>
        ''' Saves document
        ''' </summary> 
        Public Shared Sub SaveDocument()
            Try
                'ExStart:SaveDocument
                Using stream As Stream = New MemoryStream()
                    Using doc As Document = Document.Load("C:\test.doc")
                        ' watermarking goes here
                        ' ...

                        ' Saves the document to the underlying source (stream or file)
                        doc.Save()

                        ' Saves the document to the specified location
                        doc.Save("C:\result.doc")

                        ' Saves the document to the specified stream
                        doc.Save(stream)
                    End Using
                End Using
                'ExEnd:SaveDocument
            Catch exp As Exception
                Console.Write(exp.Message)
            End Try
        End Sub

#Region "Business Cases"
        ''' <summary>
        ''' Adds watermark to all the documents in a folder 
        ''' </summary>
        Public Shared Sub AddWatermarkToAllDocumentsInFolder()
            Try
                'ExStart:AddWatermarkToAllDocumentsInFolder
                Dim inputFolder = SourceFolderPath
                Dim outputFolder = SourceFolderPath + "/output"

                Dim files = Directory.GetFiles(inputFolder)

                Dim font = New Font("Arial", 8, FontStyle.Bold)
                Dim watermark = New TextWatermark("CONFIDENTIAL", font)
                watermark.HorizontalAlignment = HorizontalAlignment.Center
                watermark.VerticalAlignment = VerticalAlignment.Center
                watermark.RotateAngle = -45
                watermark.SizingType = SizingType.ScaleToParentDimensions
                watermark.ScaleFactor = 0.8
                watermark.Opacity = 0.5
                watermark.ForegroundColor = Color.Red

                For Each file As Object In files
                    Try
                        Using doc = Document.Load(file)
                            doc.AddWatermark(watermark)
                            doc.Save(Path.Combine(outputFolder, Path.GetFileName(file)))
                        End Using
                    Catch generatedExceptionName As UnsupportedFileTypeException
                        Console.WriteLine("File format is not supported. File = {0}", Path.GetFileName(file))
                    End Try
                Next
                'ExEnd:AddWatermarkToAllDocumentsInFolder
            Catch exp As Exception
            End Try

        End Sub
        ''' <summary>
        ''' Removes old company logo added as watermark from all the documents in a folder 
        ''' </summary>
        Public Shared Sub RemoveCompanyLogoWatermarkFromDocuments()
            Try
                'ExStart:RemoveCompanyLogoWatermarkFromDocuments
                Dim inputFolder = SourceFolderPath
                Dim outputFolder = SourceFolderPath + "/output"
                Dim logo = "D:\logo.png"

                Dim files = Directory.GetFiles(inputFolder)

                Dim imageSearchCriteria As ImageSearchCriteria = New ImageDctHashSearchCriteria(logo)
                Dim regex = New Regex("^Company\sName$", RegexOptions.IgnoreCase)
                Dim textSearchCriteria As New TextSearchCriteria(regex)
                For Each file As Object In files
                    Try
                        Using doc = Document.Load(file)
                            Dim watermarks = doc.FindWatermarks(textSearchCriteria.[Or](imageSearchCriteria))
                            watermarks.Clear()
                            doc.Save(Path.Combine(outputFolder, Path.GetFileName(file)))
                        End Using
                    Catch generatedExceptionName As UnsupportedFileTypeException
                        Console.WriteLine("File format is not supported. File = {0}", Path.GetFileName(file))
                    End Try
                Next
                'ExEnd:RemoveCompanyLogoWatermarkFromDocuments
            Catch exp As Exception
                Console.Write(exp.Message)
            End Try

        End Sub
#End Region

    End Class
End Namespace

