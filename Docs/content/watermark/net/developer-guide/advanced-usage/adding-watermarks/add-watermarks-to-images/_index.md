---
id: add-watermarks-to-images
url: watermark/net/add-watermarks-to-images
title: Add watermarks to images
weight: 5
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
## Adding watermark to multi-framed image 

When you are working with an animated gif or multi-frame tiff images, you may want to add watermark to some particular frame(s) using the property [FrameIndex](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.image/multiframeimagewatermarkoptions/properties/frameindex) of [TiffImageWatermarkOptions](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.image/tiffimagewatermarkoptions) or [GifImageWatermarkOptions](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.image/gifimagewatermarkoptions).

**AdvancedUsage.AddingWatermarks.AddWatermarksToImages.AddWatermarkToImage**

```csharp
TiffImageLoadOptions loadOptions = new TiffImageLoadOptions();
// Constants.InImageTiff is an absolute or relative path to your document. Ex: @"C:\Docs\image.tiff"
using (Watermarker watermarker = new Watermarker(Constants.InImageTiff, loadOptions))
{
    // Initialize text or image watermark
    TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 19));

    // Add watermark to the first frame
    TiffImageWatermarkOptions options = new TiffImageWatermarkOptions();
    options.FrameIndex = 0;

    watermarker.Add(watermark, options);
    watermarker.Save(Constants.OutImageTiff);
}
```

## Advanced use cases

## More resources

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Watermark for .NET examples](https://github.com/groupdocs-watermark/GroupDocs.Watermark-for-.NET)
    
*   [GroupDocs.Watermark for Java examples](https://github.com/groupdocs-watermark/GroupDocs.Watermark-for-Java)
    

### Free online document watermarking App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to add watermark to PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Watermarking App](https://products.groupdocs.app/watermark).
