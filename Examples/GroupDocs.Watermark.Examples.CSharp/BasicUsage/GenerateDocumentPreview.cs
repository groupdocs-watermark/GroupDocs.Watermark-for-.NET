using System.IO;
using GroupDocs.Watermark.Options;

namespace GroupDocs.Watermark.Examples.CSharp.BasicUsage
{
    public static class GenerateDocumentPreview
    {
        public static void Run()
        {
            // Constants.InDiagramVsdx is an absolute or relative path to your document. Ex: @"C:\Docs\diagram.vsdx"
            using (Watermarker watermarker = new Watermarker(Constants.InDiagramVsdx))
            {
                CreatePageStream createPageStreamDelegate = delegate(int number)
                {
                    string previewImageFileName = Path.Combine(Constants.OutputPath, string.Format("page{0}.png", number));
                    return File.OpenWrite(previewImageFileName);
                };

                ReleasePageStream releasePageStreamDelegate = delegate(int number, Stream stream)
                {
                    stream.Close();
                };

                PreviewOptions previewOptions = new PreviewOptions(createPageStreamDelegate, releasePageStreamDelegate)
                {
                    PreviewFormat = PreviewOptions.PreviewFormats.PNG,
                    PageNumbers = new []{1, 2}
                };
                
                watermarker.GeneratePreview(previewOptions);
            }
        }
    }
}
