---
id: adding-image-watermarks
url: watermark/net/adding-image-watermarks
title: Adding image watermarks
weight: 1
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
GroupDocs.Watermar API supports adding the following image file types as image watermark:

*   Bmp;
*   Png;
*   Gif;
*   Jpeg.

## Add image watermark from local file

Following code snippet shows how to add [ImageWatermark](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.watermarks/imagewatermark) to a document. If the document consists of multiple parts (pages, worksheets, slides, frames etc), the watermark will be added to all of them.

**AdvancedUsage.AddingImageWatermarks.AddImageWatermark**

```csharp
// Constants.InPresentationPptx is an absolute or relative path to your document. Ex: @"C:\Docs\presentation.pptx"
using (Watermarker watermarker = new Watermarker(Constants.InPresentationPptx))
{
    // Use path to the image as constructor parameter
    using (ImageWatermark watermark = new ImageWatermark(Constants.WatermarkJpg))
    {
        // Add watermark to the document
        watermarker.Add(watermark);

        watermarker.Save(Constants.OutPresentationPptx);
    }
}
```

## Add image watermark from stream  

You can also use a stream of the image to initialize [ImageWatermark](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.watermarks/imagewatermark) instance as shown in below example.

**AdvancedUsage.AddingImageWatermarks.AddImageWatermarkUsingStream**

```csharp
// Constants.WatermarkJpg is an absolute or relative path to your document. Ex: @"C:\Docs\watermark.jpg"
using (Stream watermarkStream = File.OpenRead(Constants.WatermarkJpg))
{
    using (Watermarker watermarker = new Watermarker(Constants.InImagePng))
    {
        // Use stream containing an image as constructor parameter
        using (ImageWatermark watermark = new ImageWatermark(watermarkStream))
        {
            // Add watermark to the document
            watermarker.Add(watermark);

            watermarker.Save(Constants.OutImagePng);
        }
    }
}
```

{{< alert style="warning" >}}ImageWatermark class implements IDisposable interface. Therefore, it is necessary to call Dispose method when you are done working with the watermark. Alternatively, you can use using statement.{{< /alert >}}

For the advanced use of image watermark properties please check the following article about text watermarks, however same techniques will work for image watermark as well:

*   [Adding image watermarks]({{< ref "watermark/net/developer-guide/advanced-usage/adding-watermarks/adding-image-watermarks.md" >}})

## More resources

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Watermark for .NET examples](https://github.com/groupdocs-watermark/GroupDocs.Watermark-for-.NET)
    
*   [GroupDocs.Watermark for Java examples](https://github.com/groupdocs-watermark/GroupDocs.Watermark-for-Java)
    

### Free online document watermarking App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to add watermark to PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Watermarking App](https://products.groupdocs.app/watermark).
