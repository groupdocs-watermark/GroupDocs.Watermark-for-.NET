using System;
using System.Collections.Generic;
using GroupDocs.Watermark.Common;

namespace GroupDocs.Watermark.Examples.CSharp.BasicUsage
{
    public static class GetSupportedFileFormats
    {
        /// <summary>
        /// This example shows how to print all the supported file types.
        /// </summary>
        public static void Run()
        {
            Console.WriteLine($"[Example Basic Usage] # {typeof(GetSupportedFileFormats).Name}\n");

            IEnumerable<FileType> supportedFileTypes = FileType.GetSupportedFileTypes();
            foreach (FileType fileType in supportedFileTypes)
            {
                Console.WriteLine(fileType);
            }
        }
    }
}
