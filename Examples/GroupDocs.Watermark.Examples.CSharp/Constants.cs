using System.IO;
using System.Runtime.CompilerServices;

namespace GroupDocs.Watermark.Examples.CSharp
{
    public static class Constants
    {
#if NETCOREAPP3_1_OR_GREATER
        public static string ResourcesPath = @"..\..\..\..\Resources\";
#else
        public static string ResourcesPath = @"..\..\..\Resources\";
#endif

        public static readonly string LicenseFilePath = Path.Combine(ResourcesPath, "GroupDocs.Watermark.NET.lic");

        public static readonly string DocumentsPath = Path.Combine(ResourcesPath, @"SampleFiles\Documents");
        public static readonly string ImagesPath = Path.Combine(ResourcesPath, @"SampleFiles\Images");
        public static readonly string FontsPath = Path.Combine(ResourcesPath, @"SampleFiles\Fonts");
        public static readonly string OutputPath = Path.Combine(ResourcesPath, @"SampleFiles\Output");

        public static readonly string InDiagramVsdx = Path.Combine(DocumentsPath, "diagram.vsdx");
        public static readonly string InDocumentDocx = Path.Combine(DocumentsPath, "document.docx");
        public static readonly string InDocumentPdf = Path.Combine(DocumentsPath, "document.pdf");
        public static readonly string SamplePdf = Path.Combine(DocumentsPath, "sample.pdf");
        public static readonly string InImagePng = Path.Combine(DocumentsPath, "image.png");
        public static readonly string InImageTiff = Path.Combine(DocumentsPath, "image.tiff");
        public static readonly string InInputVsdx = Path.Combine(DocumentsPath, "input.vsdx");
        public static readonly string InMessageMsg = Path.Combine(DocumentsPath, "test.msg");
        public static readonly string InSampleMsg = Path.Combine(DocumentsPath, "empty.msg");
        public static readonly string InPresentationPptx = Path.Combine(DocumentsPath, "document.pptx");
        public static readonly string SamplePptx = Path.Combine(DocumentsPath, "sample.pptx");
        public static readonly string InProtectedDocumentDocx = Path.Combine(DocumentsPath, "protected-document.docx");
        public static readonly string SampleDocx = Path.Combine(DocumentsPath, "sample.docx");
        public static readonly string InSourceDocx = Path.Combine(DocumentsPath, "source.docx");
        public static readonly string InSpreadsheetXlsx = Path.Combine(DocumentsPath, "document.xlsx");
        public static readonly string SampleXlsx = Path.Combine(DocumentsPath, "sample.xlsx");
        public static readonly string InTestDoc = Path.Combine(DocumentsPath, "test.doc");
        public static readonly string InTestDocx = Path.Combine(DocumentsPath, "test.docx");

        public static readonly string AttachmentPng = Path.Combine(ImagesPath, "attachment.png");
        public static readonly string BackgroundPng = Path.Combine(ImagesPath, "background.png");
        public static readonly string DocumentPreviewPng = Path.Combine(ImagesPath, "document_preview.png");
        public static readonly string ImagePng = Path.Combine(ImagesPath, "image.png");
        public static readonly string LargePng = Path.Combine(ImagesPath, "large.png");
        public static readonly string LogoBmp = Path.Combine(ImagesPath, "logo.bmp");
        public static readonly string LogoGif = Path.Combine(ImagesPath, "logo.gif");
        public static readonly string LogoJpg = Path.Combine(ImagesPath, "logo.jpg");
        public static readonly string LogoPng = Path.Combine(ImagesPath, "protected_logo_small.png");
        public static readonly string ProtectJpg = Path.Combine(ImagesPath, "protect.jpg");
        public static readonly string SampleJpg = Path.Combine(ImagesPath, "sample.jpg");
        public static readonly string TestPng = Path.Combine(ImagesPath, "test.png");
        public static readonly string WatermarkJpg = Path.Combine(ImagesPath, "watermark.jpg");

        public static string GetOutputDirectoryPath([CallerFilePath] string callerFilePath = null, string nameChildFolder = null)
        {
            string outputDirectory = Path.Combine(OutputPath, Path.GetFileNameWithoutExtension(callerFilePath));

            if (nameChildFolder != null) outputDirectory = Path.Combine(outputDirectory, nameChildFolder);

            if (!Directory.Exists(outputDirectory))
                Directory.CreateDirectory(outputDirectory);

            string path = Path.GetFullPath(outputDirectory);
            return path;
        }
    }
}
