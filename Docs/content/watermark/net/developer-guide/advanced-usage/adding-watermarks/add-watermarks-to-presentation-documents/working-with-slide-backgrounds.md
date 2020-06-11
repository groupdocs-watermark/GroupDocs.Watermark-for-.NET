---
id: working-with-slide-backgrounds
url: watermark/net/working-with-slide-backgrounds
title: Working with slide backgrounds
weight: 1
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
## Extracting information about all slide backgrounds

The API allows you to extract information about all the slide backgrounds in a PowerPoint document as shown in the following code sample using property [BackgroundImage](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.presentation/presentationimagefillformat/properties/backgroundimage) of [PresentationSlide.ImageFillFormat](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.presentation/presentationbaseslide/properties/imagefillformat).

**AdvancedUsage.AddingWatermarks.AddWatermarksToPresentations.PresentationGetSlideBackgroundsInformation**

```csharp
PresentationLoadOptions loadOptions = new PresentationLoadOptions();
// Constants.InPresentationPptx is an absolute or relative path to your document. Ex: @"C:\Docs\presentation.pptx"
using (Watermarker watermarker = new Watermarker(Constants.InPresentationPptx, loadOptions))
{
    PresentationContent content = watermarker.GetContent<PresentationContent>();
    foreach (PresentationSlide slide in content.Slides)
    {
        if (slide.ImageFillFormat.BackgroundImage != null)
        {
            Console.WriteLine(slide.ImageFillFormat.BackgroundImage.Width);
            Console.WriteLine(slide.ImageFillFormat.BackgroundImage.Height);
            Console.WriteLine(slide.ImageFillFormat.BackgroundImage.GetBytes().Length);
        }
    }
}
```

## Removing a particular background

Following code sample shows how to remove the background image of a particular slide setting the property [BackgroundImage](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.presentation/presentationimagefillformat/properties/backgroundimage) to null.

**AdvancedUsage.AddingWatermarks.AddWatermarksToPresentations.PresentationRemoveSlideBackground**

```csharp
PresentationLoadOptions loadOptions = new PresentationLoadOptions();
// Constants.InPresentationPptx is an absolute or relative path to your document. Ex: @"C:\Docs\presentation.pptx"
using (Watermarker watermarker = new Watermarker(Constants.InPresentationPptx, loadOptions))
{
    PresentationContent content = watermarker.GetContent<PresentationContent>();
    content.Slides[0].ImageFillFormat.BackgroundImage = null;

    watermarker.Save(Constants.OutPresentationPptx);
}
```

## Adding watermark to all background images

Using GroupDocs.Watermark, you can also [add](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.image/watermarkableimage/methods/add) watermark to the background images that belong to a PowerPoint document as shown in the following code sample.

**AdvancedUsage.AddingWatermarks.AddWatermarksToPresentations.PresentationAddWatermarkToSlideBackgroundImages**

```csharp
PresentationLoadOptions loadOptions = new PresentationLoadOptions();
// Constants.InPresentationPptx is an absolute or relative path to your document. Ex: @"C:\Docs\presentation.pptx"
using (Watermarker watermarker = new Watermarker(Constants.InPresentationPptx, loadOptions))
{
    // Initialize image or text watermark
    TextWatermark watermark = new TextWatermark("Protected image", new Font("Arial", 8));
    watermark.HorizontalAlignment = HorizontalAlignment.Center;
    watermark.VerticalAlignment = VerticalAlignment.Center;
    watermark.RotateAngle = 45;
    watermark.SizingType = SizingType.ScaleToParentDimensions;
    watermark.ScaleFactor = 1;

    PresentationContent content = watermarker.GetContent<PresentationContent>();
    foreach (PresentationSlide slide in content.Slides)
    {
        if (slide.ImageFillFormat.BackgroundImage != null)
        {
            // Add watermark to the image
            slide.ImageFillFormat.BackgroundImage.Add(watermark);
        }
    }

    watermarker.Save(Constants.OutPresentationPptx);
}
```

## Additional settings for slide background image

GroupDocs.Watermark for .NET also provides the feature that allows you to [tile](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.presentation/presentationimagefillformat/properties/tileastexture) the picture across slide's background. You can also make the image [semi-transparent](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.presentation/presentationimagefillformat/properties/transparency). Following code sample serves this purpose.

**AdvancedUsage.AddingWatermarks.AddWatermarksToPresentations.PresentationSetTiledSemitransparentBackground**

```csharp
PresentationLoadOptions loadOptions = new PresentationLoadOptions();
// Constants.InPresentationPptx is an absolute or relative path to your document. Ex: @"C:\Docs\presentation.pptx"
using (Watermarker watermarker = new Watermarker(Constants.InPresentationPptx, loadOptions))
{
    PresentationContent content = watermarker.GetContent<PresentationContent>();
    PresentationSlide slide = content.Slides[0];
    slide.ImageFillFormat.BackgroundImage = new PresentationWatermarkableImage(File.ReadAllBytes(Constants.BackgroundPng));
    slide.ImageFillFormat.TileAsTexture = true;
    slide.ImageFillFormat.Transparency = 0.5;

    watermarker.Save(Constants.OutPresentationPptx);
}
```

## Settings background image for charts

GroupDocs.Watermark for .NET also allows you to set the background image for a chart inside PowerPoint document using [Charts](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.presentation/presentationbaseslide/properties/charts) property. You can use following code sample to achieve this functionality.

**AdvancedUsage.AddingWatermarks.AddWatermarksToPresentations.PresentationSetBackgroundImageForChart**

```csharp
PresentationLoadOptions loadOptions = new PresentationLoadOptions();
// Constants.InPresentationPptx is an absolute or relative path to your document. Ex: @"C:\Docs\presentation.pptx"
using (Watermarker watermarker = new Watermarker(Constants.InPresentationPptx, loadOptions))
{
    PresentationContent content = watermarker.GetContent<PresentationContent>();
    content.Slides[0].Charts[0].ImageFillFormat.BackgroundImage = new PresentationWatermarkableImage(File.ReadAllBytes(Constants.TestPng));
    content.Slides[0].Charts[0].ImageFillFormat.Transparency = 0.5;
    content.Slides[0].Charts[0].ImageFillFormat.TileAsTexture = true;

    watermarker.Save(Constants.OutPresentationPptx);
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
