using GroupDocs.Watermark.Options.WordProcessing;
using GroupDocs.Watermark.Watermarks;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing
{
    /// <summary>
    /// This example shows how to lock watermark in particular pages.
    /// </summary>
    public static class WordProcessingAddLockedWatermarkToParticularPages
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(WordProcessingAddLockedWatermarkToParticularPages).Name}\n");

            string documentPath = Constants.SampleDocx;
            string outputFileName = Path.Combine(Constants.GetOutputDirectoryPath(), Path.GetFileName(documentPath));

            var loadOptions = new WordProcessingLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                TextWatermark watermark = new TextWatermark("Watermark text", new Font("Arial", 19));
                watermark.ForegroundColor = Color.Red;

                WordProcessingWatermarkPagesOptions options = new WordProcessingWatermarkPagesOptions();
                options.PageNumbers = new int[] { 1, 3 };
                options.IsLocked = true;
                options.LockType = WordProcessingLockType.AllowOnlyComments;

                // To protect with password
                //options.Password = "7654321";

                watermarker.Add(watermark, options);

                watermarker.Save(outputFileName);
            }
        }

    }
}
