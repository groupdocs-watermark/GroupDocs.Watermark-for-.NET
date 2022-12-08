// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>

using GroupDocs.Watermark.Options.WordProcessing;
using GroupDocs.Watermark.Watermarks;

namespace GroupDocs.Watermark.Examples.CSharp.AdvancedUsage.AddingWatermarks.AddWatermarksToWordProcessing
{
    /// <summary>
    /// This example shows how to lock watermark in particular pages.
    /// </summary>
    public static class WordProcessingAddLockedWatermarkToParticularPages
    {
        public static void Run()
        {
            WordProcessingLoadOptions loadOptions = new WordProcessingLoadOptions();
            // Constants.InDocumentDocx is an absolute or relative path to your document. Ex: @"C:\Docs\document.docx"
            using (Watermarker watermarker = new Watermarker(Constants.InDocumentDocx, loadOptions))
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

                watermarker.Save(Constants.OutDocumentDocx);
            }
        }

    }
}
