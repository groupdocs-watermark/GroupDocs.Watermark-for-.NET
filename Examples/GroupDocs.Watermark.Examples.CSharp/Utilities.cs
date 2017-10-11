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
    public static class Utilities
    {
        //ExStart:CommonProperties
        private const string SourceFolderPath = "../../../Data/";
        public const string licensePath = "E:/GroupDocs/Licenses/GroupDocs.Total.lic";
        //ExEnd:CommonProperties

        //ExStart:MapSourceFilePath
        /// <summary>
        /// Maps source file path
        /// </summary>
        /// <param name="SourceFileName">Source File Name</param>
        /// <returns>Returns complete path of source file</returns>
        public static string MapSourceFilePath(string SourceFileName)
        {
            try
            {
                return SourceFolderPath + SourceFileName;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
                return exp.Message;
            }
        }
        //ExEnd:MapSourceFilePath

        /// <summary>
        /// Set product's license 
        /// </summary>
        public static void ApplyLicense()
        {
            try
            {
                //ExStart:ApplyLicence
                using (FileStream fileStream = new FileStream(licensePath, FileMode.Open, FileAccess.Read))
                {
                    License lic = new License();
                    lic.SetLicense(fileStream);
                }
                //ExEnd:ApplyLicence
            }
            catch (System.Exception exc)
            { 
                Console.Write(exc.Message); 
            }
        }

        /// <summary>
        /// Set metered license 
        /// </summary>
        public static void ApplyMeteredLicense()
        {
            try
            {
                //ExStart:ApplyMeteredLicense
                string publicKey = "[Your Dynabic.Metered public key]";
                string privateKey = "[Your Dynabic.Metered private key]";

                Metered metered = new Metered();
                metered.SetMeteredKey(publicKey, privateKey);
                // Use the library in licensed mode
                //ExEnd:ApplyMeteredLicense
            }
            catch (System.Exception exc)
            {
                Console.Write(exc.Message);
            }
        }

        /// <summary>
        /// Gets document information
        /// </summary> 
        public static void GetDocumentInformation()
        {
            try
            {
                //ExStart:GetDocumentInformation
                DocumentInfo documentInfo = Document.GetInfo(@"C:\test.ppt");
                Console.WriteLine(documentInfo.FileFormat);
                Console.WriteLine(documentInfo.IsEncrypted);
                //ExEnd:GetDocumentInformation
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        /// <summary>
        /// Loads password protected document
        /// </summary> 
        public static void LoadPasswordProtectedDocument()
        {
            try
            {
                //ExStart:LoadPasswordProtectedDocument
                // Use LoadOptions instance to pass the password
                LoadOptions loadOptions = new LoadOptions();
                loadOptions.Password = "123";
                using (Document doc = Document.Load(@"C:\test.docx", loadOptions))
                {

                }
                //ExEnd:LoadPasswordProtectedDocument
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        /// <summary>
        /// Saves document
        /// </summary> 
        public static void SaveDocument()
        {
            try
            {
                //ExStart:SaveDocument
                using (Stream stream = new MemoryStream())
                {
                    using (Document doc = Document.Load(@"C:\test.doc"))
                    {
                        // watermarking goes here
                        // ...

                        // Saves the document to the underlying source (stream or file)
                        doc.Save();

                        // Saves the document to the specified location
                        doc.Save(@"C:\result.doc");

                        // Saves the document to the specified stream
                        doc.Save(stream);
                    }
                }
                //ExEnd:SaveDocument
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        #region Business Cases
        /// <summary>
        /// Adds watermark to all the documents in a folder 
        /// </summary>
        public static void AddWatermarkToAllDocumentsInFolder()
        {
            try 
            {
                //ExStart:AddWatermarkToAllDocumentsInFolder
                var inputFolder = SourceFolderPath;
                var outputFolder = SourceFolderPath + "/output";

                var files = Directory.GetFiles(inputFolder);

                var font = new Font("Arial", 8, FontStyle.Bold);
                var watermark = new TextWatermark("CONFIDENTIAL", font);
                watermark.HorizontalAlignment = HorizontalAlignment.Center;
                watermark.VerticalAlignment = VerticalAlignment.Center;
                watermark.RotateAngle = -45;
                watermark.SizingType = SizingType.ScaleToParentDimensions;
                watermark.ScaleFactor = 0.8;
                watermark.Opacity = 0.5;
                watermark.ForegroundColor = Color.Red;

                foreach (var file in files)
                {
                    try
                    {
                        using (var doc = Document.Load(file))
                        {
                            doc.AddWatermark(watermark);
                            doc.Save(Path.Combine(outputFolder, Path.GetFileName(file)));
                        }
                    }
                    catch (UnsupportedFileTypeException)
                    {
                        Console.WriteLine("File format is not supported. File = {0}", Path.GetFileName(file));
                    }
                }
                //ExEnd:AddWatermarkToAllDocumentsInFolder
            }
            catch(Exception exp)
            {

            }

        }
        /// <summary>
        /// Removes old company logo added as watermark from all the documents in a folder 
        /// </summary>
        public static void RemoveCompanyLogoWatermarkFromDocuments()
        {
            try
            {
                //ExStart:RemoveCompanyLogoWatermarkFromDocuments
                var inputFolder = SourceFolderPath;
                var outputFolder = SourceFolderPath + "/output";
                var logo = @"D:\logo.png";

                var files = Directory.GetFiles(inputFolder);

                ImageSearchCriteria imageSearchCriteria = new ImageDctHashSearchCriteria(logo);
                var regex = new Regex(@"^Company\sName$", RegexOptions.IgnoreCase);
                TextSearchCriteria textSearchCriteria = new TextSearchCriteria(regex);
                foreach (var file in files)
                {
                    try
                    {
                        using (var doc = Document.Load(file))
                        {
                            var watermarks = doc.FindWatermarks(textSearchCriteria.Or(imageSearchCriteria));
                            watermarks.Clear();
                            doc.Save(Path.Combine(outputFolder, Path.GetFileName(file)));
                        }
                    }
                    catch (UnsupportedFileTypeException)
                    {
                        Console.WriteLine("File format is not supported. File = {0}", Path.GetFileName(file));
                    }
                }
                //ExEnd:RemoveCompanyLogoWatermarkFromDocuments
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }

        }
        #endregion
    }
}
