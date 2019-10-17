// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2019 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToEmailAttachments
{
    using Options.Email;
    using Search;
    using Search.Objects;
    using Search.SearchCriteria;

    /// <summary>
    /// This example shows how to search for a text in the subject as well as in the body of the email message.
    /// </summary>
    public static class EmailSearchTextInBody
    {
        public static void Run()
        {
            EmailLoadOptions loadOptions = new EmailLoadOptions();
            // Constants.InMessageMsg is an absolute or relative path to your document. Ex: @"C:\Docs\message.msg"
            using (Watermarker watermarker = new Watermarker(Constants.InMessageMsg, loadOptions))
            {
                SearchCriteria criteria = new TextSearchCriteria("test", false);

                // Specify search locations
                watermarker.SearchableObjects.EmailSearchableObjects = EmailSearchableObjects.Subject | EmailSearchableObjects.HtmlBody | EmailSearchableObjects.PlainTextBody;

                // Note, search is performed only if you pass TextSearchCriteria instance to FindWatermarks method
                PossibleWatermarkCollection watermarks = watermarker.Search(criteria);

                // Remove found text fragments
                watermarks.Clear();

                // Save changes
                watermarker.Save(Constants.OutMessageMsg);
            }
        }
    }
}