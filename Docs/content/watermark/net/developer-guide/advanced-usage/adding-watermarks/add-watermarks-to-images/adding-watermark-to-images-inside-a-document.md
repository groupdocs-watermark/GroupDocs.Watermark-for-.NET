---
id: adding-watermark-to-images-inside-a-document
url: watermark/net/adding-watermark-to-images-inside-a-document
title: Adding watermark to images inside a document
weight: 1
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
The most of the document formats allow you to place images inside a document. If you want to add watermark to images inside a document then it can be possible using GroupDocs.Watermark. Following are the steps to add watermark to the images of any document.

1.  Load the document 
2.  Create and initialize watermark object 
3.  Set watermark properties 
4.  [Find](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/watermarker/methods/getimages) images in the document
5.  [Add](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.image/watermarkableimage/methods/add) watermark to all found images
6.  Save the document

**AdvancedUsage.AddingWatermarks.AddWatermarksToImages.AddWatermarkToImagesInsideDocument**

```csharp
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf))
{
    // Initialize text watermark
    TextWatermark textWatermark = new TextWatermark("Protected image", new Font("Arial", 8));
    textWatermark.HorizontalAlignment = HorizontalAlignment.Center;
    textWatermark.VerticalAlignment = VerticalAlignment.Center;
    textWatermark.RotateAngle = 45;
    textWatermark.SizingType = SizingType.ScaleToParentDimensions;
    textWatermark.ScaleFactor = 1;

    // Initialize image watermark
    using (ImageWatermark imageWatermark = new ImageWatermark(Constants.ProtectJpg))
    {
        imageWatermark.HorizontalAlignment = HorizontalAlignment.Center;
        imageWatermark.VerticalAlignment = VerticalAlignment.Center;
        imageWatermark.RotateAngle = -45;
        imageWatermark.SizingType = SizingType.ScaleToParentDimensions;
        imageWatermark.ScaleFactor = 1;

        // Find all images in a document
        WatermarkableImageCollection images = watermarker.GetImages();
        for (int i = 0; i < images.Count; i++)
        {
            if (images[i].Width > 100 && images[i].Height > 100)
            {
                if (i % 2 == 0)
                {
                    images[i].Add(textWatermark);
                }
                else
                {
                    images[i].Add(imageWatermark);
                }
            }
        }
    }

    watermarker.Save(Constants.OutDocumentPdf);
}
```

## More resources

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Watermark for .NET examples](https://github.com/groupdocs-watermark/GroupDocs.Watermark-for-.NET)
    
*   [GroupDocs.Watermark for Java examples](https://github.com/groupdocs-watermark/GroupDocs.Watermark-for-Java)
    

### Free online document watermarking App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to add watermark to PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Watermarking App](https://products.groupdocs.app/watermark).
