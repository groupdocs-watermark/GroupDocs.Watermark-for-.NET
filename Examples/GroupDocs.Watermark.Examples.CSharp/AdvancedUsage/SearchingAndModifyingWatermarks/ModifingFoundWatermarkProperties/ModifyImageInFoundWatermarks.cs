using System;
using System.IO;
using GroupDocs.Watermark.Search;
using GroupDocs.Watermark.Search.SearchCriteria;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.SearchingAndModifyingWatermarks.ModifingFoundWatermarkProperties
{
    /// <summary>
    /// This example shows how to replace the image of the found watermarks.
    /// </summary>
    public static class ModifyImageInFoundWatermarks
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(ModifyImageInFoundWatermarks).Name}\n");

            string documentPath = Constants.InDocumentPdf;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            byte[] imageData = File.ReadAllBytes(Constants.ImagePng);

            using (Watermarker watermarker = new Watermarker(documentPath))
            {
                // Search watermark matching a particular image
                SearchCriteria searchCriteria = new ImageDctHashSearchCriteria(Constants.LogoBmp);
                PossibleWatermarkCollection watermarks = watermarker.Search(searchCriteria);
                foreach (PossibleWatermark watermark in watermarks)
                {
                    try
                    {
                        // Replace image
                        watermark.ImageData = imageData;
                    }
                    catch (Exception e)
                    {
                        // Found entity may not support image replacment
                        // Passed image can have inappropriate format
                        // Process such cases here
                    }
                }

                // Save document
                watermarker.Save(outputFileName);
            }
        }
    }
}
