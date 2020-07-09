---
id: add-watermarks-to-presentation-documents
url: watermark/net/add-watermarks-to-presentation-documents
title: Add watermarks to presentation documents
weight: 7
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
## Adding watermark to a particular slide

Using GroupDocs.Watermark, you can add watermark to a particular slide of a PowerPoint presentation in a simplified way. Adding watermark to a particular PowerPoint slide using GroupDocs.Watermark consists of following steps.

1.  Load the document
2.  Create and initialize watermark object
3.  Set watermark properties
4.  Setting [SlideIndex](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.presentation/presentationwatermarkslideoptions/properties/slideindex) of [PresentationWatermarkSlideOptions](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.presentation/presentationwatermarkslideoptions)
5.  Add watermark to the document
6.  Save the document

Following code shows how to add [TextWatermark](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.watermarks/textwatermark) to the first slide and [ImageWatermark](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.watermarks/imagewatermark) to the second slide.

**AdvancedUsage.AddingWatermarks.AddWatermarksToPresentations.PresentationAddWatermarkToSlide**

```csharp
PresentationLoadOptions loadOptions = new PresentationLoadOptions();
// Constants.InPresentationPptx is an absolute or relative path to your document. Ex: @"C:\Docs\presentation.pptx"
using (Watermarker watermarker = new Watermarker(Constants.InPresentationPptx, loadOptions))
{
    // Add text watermark to the first slide
    TextWatermark textWatermark = new TextWatermark("Test watermark", new Font("Arial", 8));
    PresentationWatermarkSlideOptions textWatermarkOptions = new PresentationWatermarkSlideOptions();
    textWatermarkOptions.SlideIndex = 0;
    watermarker.Add(textWatermark, textWatermarkOptions);

    // Add image watermark to the second slide
    using (ImageWatermark imageWatermark = new ImageWatermark(Constants.LogoJpg))
    {
        PresentationWatermarkSlideOptions imageWatermarkOptions = new PresentationWatermarkSlideOptions();
        imageWatermarkOptions.SlideIndex = 1;
        watermarker.Add(imageWatermark, imageWatermarkOptions);
    }

    watermarker.Save(Constants.OutPresentationPptx);
}
```

## Protecting watermark using unreadable characters

This feature allows strengthening the protection of text watermark. Using unreadable characters in the watermark text forbids the modification using Find and Replace dialog. The following code sample shows how to include unreadable characters in watermark text using properties [IsLocked](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.presentation/presentationwatermarkbaseslideoptions/properties/islocked) and [ProtectWithUnreadableCharacters](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.presentation/presentationwatermarkbaseslideoptions/properties/protectwithunreadablecharacters) of [PresentationWatermarkSlideOptions](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.presentation/presentationwatermarkslideoptions).

**AdvancedUsage.AddingWatermarks.AddWatermarksToPresentations.PresentationProtectWatermarkUsingUnreadableCharacters**

```csharp
PresentationLoadOptions loadOptions = new PresentationLoadOptions();
// Constants.InPresentationPptx is an absolute or relative path to your document. Ex: @"C:\Docs\presentation.pptx"
using (Watermarker watermarker = new Watermarker(Constants.InPresentationPptx, loadOptions))
{
    TextWatermark watermark = new TextWatermark("Watermark text", new Font("Arial", 19));
    PresentationWatermarkSlideOptions options = new PresentationWatermarkSlideOptions();
    options.IsLocked = true;
    options.ProtectWithUnreadableCharacters = true;

    // Add watermark
    watermarker.Add(watermark, options);

    // Save document
    watermarker.Save(Constants.OutPresentationPptx);
}
```

## Getting slide dimensions

If for some reasons you want to use absolute sizing and positioning, you may also need to get the [width](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.presentation/presentationcontent/properties/slidewidth) and [height](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.presentation/presentationcontent/properties/slideheight) of the slide. Use below code to get the dimensions of a particular slide.

**AdvancedUsage.AddingWatermarks.AddWatermarksToPresentations.PresentationGetSlideDimensions**

```csharp
PresentationLoadOptions loadOptions = new PresentationLoadOptions();
// Constants.InPresentationPptx is an absolute or relative path to your document. Ex: @"C:\Docs\presentation.pptx"
using (Watermarker watermarker = new Watermarker(Constants.InPresentationPptx, loadOptions))
{
    PresentationContent content = watermarker.GetContent<PresentationContent>();
    Console.WriteLine(content.SlideWidth);
    Console.WriteLine(content.SlideHeight);
}
```

## Add watermark to all images inside a particular slide

GroupDocs.Watermark allows you to add watermark to the images inside a particular PowerPoint slide using *[Add](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.image/watermarkableimage/methods/add)* method as shown in below example.

**AdvancedUsage.AddingWatermarks.AddWatermarksToPresentations.PresentationAddWatermarkToSlideImages**

```csharp
PresentationLoadOptions loadOptions = new PresentationLoadOptions();
// Constants.InPresentationPptx is an absolute or relative path to your document. Ex: @"C:\Docs\presentation.pptx"
using (Watermarker watermarker = new Watermarker(Constants.InPresentationPptx, loadOptions))
{
    TextWatermark watermark = new TextWatermark("Protected image", new Font("Arial", 8));
    watermark.HorizontalAlignment = HorizontalAlignment.Center;
    watermark.VerticalAlignment = VerticalAlignment.Center;
    watermark.RotateAngle = 45;
    watermark.SizingType = SizingType.ScaleToParentDimensions;
    watermark.ScaleFactor = 1;

    // Get all images from the first slide
    PresentationContent content = watermarker.GetContent<PresentationContent>();
    WatermarkableImageCollection images = content.Slides[0].FindImages();

    // Add watermark to all found images
    foreach (WatermarkableImage image in images)
    {
        image.Add(watermark);
    }

    watermarker.Save(Constants.OutPresentationPptx);
}
```

## Working with masters, layouts, and notes

GroupDocs.Watermark enables you to access all types of the service slides in a PowerPoint presentation. Following properties of [PresentationContent](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.presentation/presentationcontent) allows access to the coresponding slide types using the API

*   [MasterSlides](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.presentation/presentationcontent/properties/masterslides)
*   [LayoutSlides](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.presentation/presentationcontent/properties/layoutslides)
*   [MasterHandoutSlide](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.presentation/presentationcontent/properties/masterhandoutslide)
*   [MasterNotesSlide](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.presentation/presentationcontent/properties/masternotesslide)
*   [NoteSlide](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.presentation/presentationslide/properties/notesslide) (the property of [PresentationSlide](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.presentation/presentationslide))

Following code shows how to access each type of the slides in a PowerPoint presentation.

**AdvancedUsage.AddingWatermarks.AddWatermarksToPresentations.PresentationAddWatermarkToAllSlideTypes**

```csharp
PresentationLoadOptions loadOptions = new PresentationLoadOptions();
// Constants.InPresentationPptx is an absolute or relative path to your document. Ex: @"C:\Docs\presentation.pptx"
using (Watermarker watermarker = new Watermarker(Constants.InPresentationPptx, loadOptions))
{
    TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 8));
    PresentationContent content = watermarker.GetContent<PresentationContent>();

    // Add watermark to all master slides
    PresentationWatermarkMasterSlideOptions masterSlideOptions = new PresentationWatermarkMasterSlideOptions();
    masterSlideOptions.MasterSlideIndex = -1;
    watermarker.Add(watermark, masterSlideOptions);

    // Add watermark to all layout slides
    if (content.LayoutSlides != null)
    {
        PresentationWatermarkLayoutSlideOptions layoutSlideOptions = new PresentationWatermarkLayoutSlideOptions();
        layoutSlideOptions.LayoutSlideIndex = -1;
        watermarker.Add(watermark, masterSlideOptions);
    }

    // Add watermark to all notes slides
    for (int i = 0; i < content.Slides.Count; i++)
    {
        if (content.Slides[i].NotesSlide != null)
        {
            PresentationWatermarkNoteSlideOptions noteSlideOptions = new PresentationWatermarkNoteSlideOptions();
            noteSlideOptions.SlideIndex = i;
            watermarker.Add(watermark, noteSlideOptions);
        }
    }

    // Add watermark to handout master
    if (content.MasterHandoutSlide != null)
    {
        PresentationWatermarkMasterHandoutSlideOptions handoutSlideOptions = new PresentationWatermarkMasterHandoutSlideOptions();
        watermarker.Add(watermark, handoutSlideOptions);
    }

    // Add watermark to notes master
    if (content.MasterNotesSlide != null)
    {
        PresentationWatermarkMasterNotesSlideOptions masterNotesSlideOptions = new PresentationWatermarkMasterNotesSlideOptions();
        watermarker.Add(watermark, masterNotesSlideOptions);
    }

    watermarker.Save(Constants.OutPresentationPptx);
}
```

## What is watermark in PowerPoint

When you're calling [Add](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/watermarker/methods/add) method of [Watermarker](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/watermarker) class with loaded presentation document, simple shape is added to a PowerPoint document. GroupDocs.Watermark provides some additional options when adding a shape watermark. Use [PresentationWatermarkBaseSlideOptions](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.presentation/presentationwatermarkbaseslideoptions) descendant classes to set these options as shown in below example.

**AdvancedUsage.AddingWatermarks.AddWatermarksToPresentations.PresentationAddWatermarkWithSlidesShapeSettings**

```csharp
PresentationLoadOptions loadOptions = new PresentationLoadOptions();
// Constants.InPresentationPptx is an absolute or relative path to your document. Ex: @"C:\Docs\presentation.pptx"
using (Watermarker watermarker = new Watermarker(Constants.InPresentationPptx, loadOptions))
{
    TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 19));
    watermark.IsBackground = true;

    PresentationWatermarkSlideOptions options = new PresentationWatermarkSlideOptions();

    // Set the shape name
    options.Name = "Shape 1";

    // Set the descriptive (alternative) text that will be associated with the shape
    options.AlternativeText = "Test watermark";

    // Editing of the shape in PowerPoint is forbidden
    options.IsLocked = true;

    watermarker.Add(watermark, options);
    watermarker.Save(Constants.OutPresentationPptx);
}
```

### Applying text effects 

You can also apply [text effects](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.presentation/presentationtexteffects) when adding shape watermark to a PowerPoint slide.

**AdvancedUsage.AddingWatermarks.AddWatermarksToPresentations.PresentationAddWatermarkWithTextEffects**

```csharp
PresentationLoadOptions loadOptions = new PresentationLoadOptions();
// Constants.InPresentationPptx is an absolute or relative path to your document. Ex: @"C:\Docs\presentation.pptx"
using (Watermarker watermarker = new Watermarker(Constants.InPresentationPptx, loadOptions))
{
    TextWatermark watermark = new TextWatermark("Test watermark", new Font("Segoe UI", 19));

    PresentationTextEffects effects = new PresentationTextEffects();
    effects.LineFormat.Enabled = true;
    effects.LineFormat.Color = Color.Red;
    effects.LineFormat.DashStyle = OfficeDashStyle.DashDotDot;
    effects.LineFormat.LineStyle = OfficeLineStyle.Triple;
    effects.LineFormat.Weight = 1;

    PresentationWatermarkSlideOptions options = new PresentationWatermarkSlideOptions();
    options.Effects = effects;

    watermarker.Add(watermark, options);
    watermarker.Save(Constants.OutPresentationPptx);
}
```

{{< alert style="warning" >}}Line format settings are not supported for Ppt presentations at this moment.{{< /alert >}}

### Applying image effects 

The API also allows you to apply [image effects](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.options.presentation/presentationimageeffects) to the shape watermark using below code.

**AdvancedUsage.AddingWatermarks.AddWatermarksToPresentations.PresentationAddWatermarkWithImageEffects**

```csharp
PresentationLoadOptions loadOptions = new PresentationLoadOptions();
// Constants.InPresentationPptx is an absolute or relative path to your document. Ex: @"C:\Docs\presentation.pptx"
using (Watermarker watermarker = new Watermarker(Constants.InPresentationPptx, loadOptions))
{
    using (ImageWatermark watermark = new ImageWatermark(Constants.LogoPng))
    {
        PresentationImageEffects effects = new PresentationImageEffects();
        effects.Brightness = 0.7;
        effects.Contrast = 0.6;
        effects.ChromaKey = Color.Red;
        effects.BorderLineFormat.Enabled = true;
        effects.BorderLineFormat.Weight = 1;

        PresentationWatermarkSlideOptions options = new PresentationWatermarkSlideOptions();
        options.Effects = effects;

        watermarker.Add(watermark, options);
    }

    watermarker.Save(Constants.OutPresentationPptx);
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
