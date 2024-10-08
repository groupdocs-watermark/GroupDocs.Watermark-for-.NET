﻿using System;
using System.IO;
using GroupDocs.Watermark.Options;

namespace GroupDocs.Watermark.Examples.CSharp.BasicUsage
{
    public static class GenerateDocumentPreview
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Basic Usage] # {typeof(GenerateDocumentPreview).Name}");

            string documentPath = Constants.InDiagramVsdx;
            string outputDirectory = Constants.GetOutputDirectoryPath();

            using (Watermarker watermarker = new Watermarker(documentPath))
            {
                CreatePageStream createPageStreamDelegate = delegate(int number)
                {
                    string previewImageFileName = Path.Combine(outputDirectory, string.Format("page{0}.png", number));
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

            Console.WriteLine($"Preview generated successfully.\nCheck output in {outputDirectory}\n");
        }
    }
}
