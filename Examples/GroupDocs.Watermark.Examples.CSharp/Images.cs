using GroupDocs.Watermark.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Watermark.Examples.CSharp
{
    public static class Images
    {
        // initialize file path
        //ExStart:SourceImageFilePath
        private const string FilePath = "Images/sample.jpg";
        //ExEnd:SourceImageFilePath

        /// <summary>
        /// Adds watermark to an image
        /// </summary> 
        public static void AddWatermark()
        {
            try
            {
                //ExStart:AddWatermarkToImage
                using (MultiframeImageDocument doc = Document.Load<MultiframeImageDocument>(FilePath))
                {
                    // Initialize text or image watermark
                    TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 19));

                    // Add watermark to the first frame
                    doc.Frames[0].AddWatermark(watermark);

                    doc.Save();
                }
                //ExEnd:AddWatermarkToImage
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

    }
}
