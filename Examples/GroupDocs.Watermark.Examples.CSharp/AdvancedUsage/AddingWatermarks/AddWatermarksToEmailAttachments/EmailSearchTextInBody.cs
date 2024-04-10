using GroupDocs.Watermark.Options.Email;
using GroupDocs.Watermark.Search;
using GroupDocs.Watermark.Search.Objects;
using GroupDocs.Watermark.Search.SearchCriteria;
using System.IO;
using System;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToEmailAttachments
{
    /// <summary>
    /// This example shows how to search for a text in the subject as well as in the body of the email message.
    /// </summary>
    public static class EmailSearchTextInBody
    {
        public static void Run()
        {
            Console.WriteLine($"[Example Advanced Usage] # {typeof(EmailSearchTextInBody).Name}\n");

            string documentPath = Constants.InMessageMsg;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Path.GetFileName(documentPath));

            var loadOptions = new EmailLoadOptions();
            using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
            {
                SearchCriteria criteria = new TextSearchCriteria("test", false);

                // Specify search locations
                watermarker.SearchableObjects.EmailSearchableObjects = EmailSearchableObjects.Subject | EmailSearchableObjects.HtmlBody | EmailSearchableObjects.PlainTextBody;

                // Note, search is performed only if you pass TextSearchCriteria instance to FindWatermarks method
                PossibleWatermarkCollection watermarks = watermarker.Search(criteria);

                // Remove found text fragments
                watermarks.Clear();

                // Save changes
                watermarker.Save(outputFileName);
            }
        }
    }
}
