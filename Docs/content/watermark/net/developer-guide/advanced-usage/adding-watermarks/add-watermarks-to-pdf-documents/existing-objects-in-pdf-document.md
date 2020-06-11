---
id: existing-objects-in-pdf-document
url: watermark/net/existing-objects-in-pdf-document
title: Existing objects in PDF document
weight: 2
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
## Removing watermark from a particular page

Removing watermark from a particular page of PDF document using GroupDocs.Watermark consists of following steps.

1.  Load the document 
2.  Create and initialize Image/text search criteria 
3.  Find watermarks
4.  Remove watermarks
5.  Save the document

Following code sample removes watermarks from a particular page.

**AdvancedUsage.AddingWatermarks.AddWatermarksToPdf.PdfRemoveWatermark**

```csharp
PdfLoadOptions loadOptions = new PdfLoadOptions();
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
{
    // Initialize search criteria
    ImageSearchCriteria imageSearchCriteria = new ImageDctHashSearchCriteria(Constants.LogoPng);
    TextSearchCriteria textSearchCriteria = new TextSearchCriteria("Company Name");

    PdfContent pdfContent = watermarker.GetContent<PdfContent>();
    PossibleWatermarkCollection possibleWatermarks = pdfContent.Pages[0].Search(imageSearchCriteria.Or(textSearchCriteria));

    // Remove all found watermarks
    for (int i = possibleWatermarks.Count - 1; i >= 0; i--)
    {
        possibleWatermarks.RemoveAt(i);
    }

    watermarker.Save(Constants.OutDocumentPdf);
}
```

[*Search*](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.watermarker/search/methods/1)method searches watermarks of all mentioned types, but in some cases, it's necessary to analyze only one class of PDF entities. The following articles specifically deal with different types of the watermark objects in a PDF document.

## Working with XObjects

#### Extracting information about all XObjects in PDF document

Using GroupDocs.Watermark for .NET, you can extract information about all the [XObjects](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.pdf/pdfxobject) in a PDF document. Following code sample performs this functionality.

**AdvancedUsage.AddingWatermarks.AddWatermarksToPdf.PdfExtractXObjectInformation**

```csharp
PdfLoadOptions loadOptions = new PdfLoadOptions();
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
{
    PdfContent pdfContent = watermarker.GetContent<PdfContent>();
    foreach (PdfPage page in pdfContent.Pages)
    {
        foreach (PdfXObject xObject in page.XObjects)
        {
            if (xObject.Image != null)
            {
                Console.WriteLine(xObject.Image.Width);
                Console.WriteLine(xObject.Image.Height);
                Console.WriteLine(xObject.Image.GetBytes().Length);
            }

            Console.WriteLine(xObject.Text);
            Console.WriteLine(xObject.X);
            Console.WriteLine(xObject.Y);
            Console.WriteLine(xObject.Width);
            Console.WriteLine(xObject.Height);
            Console.WriteLine(xObject.RotateAngle);
        }
    }
}
```

### Removing a particular XObject

You can also remove an XObject from a page using GroupDocs.Watermark. Following code sample removes an XObject from a particular page.

**AdvancedUsage.AddingWatermarks.AddWatermarksToPdf.PdfRemoveXObject**

```csharp
PdfLoadOptions loadOptions = new PdfLoadOptions();
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
{
    PdfContent pdfContent = watermarker.GetContent<PdfContent>();

    // Remove XObject by index
    pdfContent.Pages[0].XObjects.RemoveAt(0);

    // Remove XObject by reference
    pdfContent.Pages[0].XObjects.Remove(pdfContent.Pages[0].XObjects[0]);

    watermarker.Save(Constants.OutDocumentPdf);
}
```

### Removing XObjects containing text with particular text formatting

You can also find and remove all XObjects containing [text with a particular formatting](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.pdf/pdfshape/properties/formattedtextfragments) from a PDF document as shown in the below code sample.

**AdvancedUsage.AddingWatermarks.AddWatermarksToPdf.PdfRemoveXObjectWithParticularTextFormatting**

```csharp
PdfLoadOptions loadOptions = new PdfLoadOptions();
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
{
    PdfContent pdfContent = watermarker.GetContent<PdfContent>();
    foreach (PdfPage page in pdfContent.Pages)
    {
        for (int i = page.XObjects.Count - 1; i >= 0; i--)
        {
            foreach (FormattedTextFragment fragment in page.XObjects[i].FormattedTextFragments)
            {
                if (fragment.ForegroundColor == Color.Red)
                {
                    page.XObjects.RemoveAt(i);
                    break;
                }
            }
        }
    }

    watermarker.Save(Constants.OutDocumentPdf);
}
```

### Adding watermark to all image XObjects

GroupDocs.Watermark API allows you to add watermark to all [image](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.pdf/pdfshape/properties/image) XObjects in a PDF document. Following code sample serves this purpose.

**AdvancedUsage.AddingWatermarks.AddWatermarksToPdf.PdfAddWatermarkToXObjects**

```csharp
PdfLoadOptions loadOptions = new PdfLoadOptions();
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
{
    PdfContent pdfContent = watermarker.GetContent<PdfContent>();

    // Initialize image or text watermark
    TextWatermark watermark = new TextWatermark("Protected image", new Font("Arial", 8));
    watermark.HorizontalAlignment = HorizontalAlignment.Center;
    watermark.VerticalAlignment = VerticalAlignment.Center;
    watermark.RotateAngle = 45;
    watermark.SizingType = SizingType.ScaleToParentDimensions;
    watermark.ScaleFactor = 1;

    foreach (PdfPage page in pdfContent.Pages)
    {
        foreach (PdfXObject xObject in page.XObjects)
        {
            if (xObject.Image != null)
            {
                // Add watermark to the image
                xObject.Image.Add(watermark);
            }
        }
    }

    watermarker.Save(Constants.OutDocumentPdf);
}
```

### Replacing text for particular XObjects

GroupDocs.Watermark allows you to edit and replace the text of the particular XObject. You can also replace XObject's [text](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.pdf/pdfshape/properties/text) with formatting as shown in the below code samples.

#### Replacing text

**AdvancedUsage.AddingWatermarks.AddWatermarksToPdf.PdfReplaceTextForParticularXObject**

```csharp
PdfLoadOptions loadOptions = new PdfLoadOptions();
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
{
    PdfContent pdfContent = watermarker.GetContent<PdfContent>();
    foreach (PdfXObject xObject in pdfContent.Pages[0].XObjects)
    {
        // Replace text
        if (xObject.Text.Contains("Test"))
        {
            xObject.Text = "Passed";
        }
    }

    // Save document
    watermarker.Save(Constants.OutDocumentPdf);
}
```

#### Replacing text with formatting

**AdvancedUsage.AddWatermarksToPdf.ReplaceTextForParticularXObjectWithFormatting**

```csharp
PdfLoadOptions loadOptions = new PdfLoadOptions();
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
{
    PdfContent pdfContent = watermarker.GetContent<PdfContent>();
    foreach (PdfXObject xObject in pdfContent.Pages[0].XObjects)
    {
        // Replace text
        if (xObject.Text.Contains("Test"))
        {
            xObject.FormattedTextFragments.Clear();
            xObject.FormattedTextFragments.Add("Passed", new Font("Calibri", 19, FontStyle.Bold), Color.Red, Color.Aqua);
        }
    }

    // Save document
    watermarker.Save(Constants.OutDocumentPdf);
}
```

### Replacing image for particular XObjects

Using GroupDocs.Watermark, you can also replace the image of a particular XObject. GroupDocs.Watermark allows you to loop through all the [XObjects](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.pdf/pdfpage/properties/xobjects) of a particular page and you can replace the [image](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.pdf/pdfshape/properties/image) of particular XObjects using some condition as shown in the below code sample.

**AdvancedUsage.AddingWatermarks.AddWatermarksToPdf.PdfReplaceImageForParticularXObject**

```csharp
PdfLoadOptions loadOptions = new PdfLoadOptions();
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
{
    PdfContent pdfContent = watermarker.GetContent<PdfContent>();

    // Replace image
    foreach (PdfXObject xObject in pdfContent.Pages[0].XObjects)
    {
        if (xObject.Image != null)
        {
            xObject.Image = new PdfWatermarkableImage(File.ReadAllBytes(Constants.TestPng));
        }
    }

    // Save document
    watermarker.Save(Constants.OutDocumentPdf);
}
```

### Working with artifacts

#### Extracting information about all artifacts in PDF document

GroupDocs.Watermark enables you to extract the information about the [artifacts](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.pdf/pdfpage/properties/artifacts) in a PDF document as shown in the below code sample.

**AdvancedUsage.AddingWatermarks.AddWatermarksToPdf.PdfExtractArtifactInformation**

```csharp
PdfLoadOptions loadOptions = new PdfLoadOptions();
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
{
    PdfContent pdfContent = watermarker.GetContent<PdfContent>();
    foreach (PdfPage page in pdfContent.Pages)
    {
        foreach (PdfArtifact artifact in page.Artifacts)
        {
            Console.WriteLine(artifact.ArtifactType);
            Console.WriteLine(artifact.ArtifactSubtype);
            if (artifact.Image != null)
            {
                Console.WriteLine(artifact.Image.Width);
                Console.WriteLine(artifact.Image.Height);
                Console.WriteLine(artifact.Image.GetBytes().Length);
            }

            Console.WriteLine(artifact.Text);
            Console.WriteLine(artifact.Opacity);
            Console.WriteLine(artifact.X);
            Console.WriteLine(artifact.Y);
            Console.WriteLine(artifact.Width);
            Console.WriteLine(artifact.Height);
            Console.WriteLine(artifact.RotateAngle);
        }
    }
}
```

#### Removing a particular artifact

Following code sample shows how to remove an [artifact](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.pdf/pdfartifact) from a particular page of the PDF document.

**AdvancedUsage.AddingWatermarks.AddWatermarksToPdf.PdfRemoveArtifact**

```csharp
PdfLoadOptions loadOptions = new PdfLoadOptions();
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
{
    PdfContent pdfContent = watermarker.GetContent<PdfContent>();

    // Remove Artifact by index
    pdfContent.Pages[0].Artifacts.RemoveAt(0);

    // Remove Artifact by reference
    pdfContent.Pages[0].Artifacts.Remove(pdfContent.Pages[0].Artifacts[0]);

    watermarker.Save(Constants.OutDocumentPdf);
}
```

#### Removing artifacts containing text with particular text formatting

You can also find and remove all artifacts containing [text with a particular formatting](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.pdf/pdfshape/properties/formattedtextfragments) from a PDF document as shown in the below code sample.

**AdvancedUsage.AddingWatermarks.AddWatermarksToPdf.PdfRemoveArtifactsWithParticularTextFormatting**

```csharp
PdfLoadOptions loadOptions = new PdfLoadOptions();
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
{
    PdfContent pdfContent = watermarker.GetContent<PdfContent>();
    foreach (PdfPage page in pdfContent.Pages)
    {
        for (int i = page.Artifacts.Count - 1; i >= 0; i--)
        {
            foreach (FormattedTextFragment fragment in page.Artifacts[i].FormattedTextFragments)
            {
                if (fragment.Font.Size > 42)
                {
                    page.Artifacts.RemoveAt(i);
                    break;
                }
            }
        }
    }

    watermarker.Save(Constants.OutDocumentPdf);
}
```

#### Adding watermark to all image artifacts

GroupDocs.Watermark API also provides the feature of adding watermark to all image artifacts in a PDF document. Following code sample adds watermark to all [image](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.pdf/pdfshape/properties/image) artifacts.

**AdvancedUsage.AddingWatermarks.AddWatermarksToPdf.PdfAddWatermarkToImageArtifacts**

```csharp
PdfLoadOptions loadOptions = new PdfLoadOptions();
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
{
    PdfContent pdfContent = watermarker.GetContent<PdfContent>();

    // Initialize image or text watermark
    TextWatermark watermark = new TextWatermark("Protected image", new Font("Arial", 8));
    watermark.HorizontalAlignment = HorizontalAlignment.Center;
    watermark.VerticalAlignment = VerticalAlignment.Center;
    watermark.RotateAngle = 45;
    watermark.SizingType = SizingType.ScaleToParentDimensions;
    watermark.ScaleFactor = 1;

    foreach (PdfPage page in pdfContent.Pages)
    {
        foreach (PdfArtifact artifact in page.Artifacts)
        {
            if (artifact.Image != null)
            {
                // Add watermark to the image
                artifact.Image.Add(watermark);
            }
        }
    }

    watermarker.Save(Constants.OutDocumentPdf);
}
```

#### Replacing text for particular artifacts

GroupDocs.Watermark allows you to edit and replace the [text](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.pdf/pdfartifact/properties/text) of the particular artifacts. You can also replace artifact's [text with formatting](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.pdf/pdfshape/properties/formattedtextfragments) as shown in the below code samples.

##### Replacing text

**AdvancedUsage.AddingWatermarks.AddWatermarksToPdf.PdfReplaceTextForParticularArtifact**

```csharp
PdfLoadOptions loadOptions = new PdfLoadOptions();
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
{
    PdfContent pdfContent = watermarker.GetContent<PdfContent>();
    foreach (PdfArtifact artifact in pdfContent.Pages[0].Artifacts)
    {
        // Replace text
        if (artifact.Text.Contains("Test"))
        {
            artifact.Text = "Passed";
        }
    }

    // Save document
    watermarker.Save(Constants.OutDocumentPdf);
}
```

##### Replacing text with formatting

**AdvancedUsage.AddingWatermarks.AddWatermarksToPdf.PdfReplaceTextForParticularArtifactWithFormatting**

```csharp
PdfLoadOptions loadOptions = new PdfLoadOptions();
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
{
    PdfContent pdfContent = watermarker.GetContent<PdfContent>();
    foreach (PdfArtifact artifact in pdfContent.Pages[0].Artifacts)
    {
        // Replace text
        if (artifact.Text.Contains("Test"))
        {
            artifact.FormattedTextFragments.Clear();
            artifact.FormattedTextFragments.Add("Passed", new Font("Calibri", 19, FontStyle.Bold), Color.Red, Color.Aqua);
        }
    }

    // Save document
    watermarker.Save(Constants.OutDocumentPdf);
}
```

#### Replacing image for particular artifacts

Using GroupDocs.Watermark, you can also replace the image of a particular artifact. GroupDocs.Watermark allows you to loop through all the [artifacts](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.pdf/pdfpage/properties/artifacts) of a particular page and you can replace the [image](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.pdf/pdfshape/properties/image) of particular artifacts using some condition as shown in the below code sample.

**AdvancedUsage.AddingWatermarks.AddWatermarksToPdf.PdfReplaceImageForParticularArtifact**

```csharp
PdfLoadOptions loadOptions = new PdfLoadOptions();
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
{
    PdfContent pdfContent = watermarker.GetContent<PdfContent>();

    // Replace image
    foreach (PdfArtifact artifact in pdfContent.Pages[0].Artifacts)
    {
        if (artifact.Image != null)
        {
            artifact.Image = new PdfWatermarkableImage(File.ReadAllBytes(Constants.TestPng));
        }
    }

    // Save document
    watermarker.Save(Constants.OutDocumentPdf);
}
```

### Working with annotations

#### Extracting information about all annotations in PDF document

You can also extract information about all the [annotations](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.pdf/pdfpage/properties/annotations) in a PDF document using GroupDocs.Watermark as shown in below code sample.

**AdvancedUsage.AddingWatermarks.AddWatermarksToPdf.PdfExtractAnnotationInformation**

```csharp
PdfLoadOptions loadOptions = new PdfLoadOptions();
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
{
    PdfContent pdfContent = watermarker.GetContent<PdfContent>();
    foreach (PdfPage page in pdfContent.Pages)
    {
        foreach (PdfAnnotation annotation in page.Annotations)
        {
            Console.WriteLine(annotation.AnnotationType);
            if (annotation.Image != null)
            {
                Console.WriteLine(annotation.Image.Width);
                Console.WriteLine(annotation.Image.Height);
                Console.WriteLine(annotation.Image.GetBytes().Length);
            }

            Console.WriteLine(annotation.Text);
            Console.WriteLine(annotation.X);
            Console.WriteLine(annotation.Y);
            Console.WriteLine(annotation.Width);
            Console.WriteLine(annotation.Height);
            Console.WriteLine(annotation.RotateAngle);
        }
    }
}
```

#### Removing a particular annotation

Following code sample can be used to remove a particular [annotation](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.pdf/pdfannotation) from a PDF document.

**AdvancedUsage.AddingWatermarks.AddWatermarksToPdf.PdfRemoveAnnotation**

```csharp
PdfLoadOptions loadOptions = new PdfLoadOptions();
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
{
    PdfContent pdfContent = watermarker.GetContent<PdfContent>();

    // Remove Annotation by index
    pdfContent.Pages[0].Annotations.RemoveAt(0);

    // Remove Annotation by reference
    pdfContent.Pages[0].Annotations.Remove(pdfContent.Pages[0].Annotations[0]);

    watermarker.Save(Constants.OutDocumentPdf);
}
```

#### Removing annotations containing text with particular text formatting

You can also find and remove all annotations containing [text with a particular formatting](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.pdf/pdfshape/properties/formattedtextfragments) from a PDF document as shown in the below code sample.

**AdvancedUsage.AddingWatermarks.AddWatermarksToPdf.PdfRemoveAnnotationsWithParticularTextFormatting**

```csharp
PdfLoadOptions loadOptions = new PdfLoadOptions();
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
{
    PdfContent pdfContent = watermarker.GetContent<PdfContent>();
    foreach (PdfPage page in pdfContent.Pages)
    {
        for (int i = page.Annotations.Count - 1; i >= 0; i--)
        {
            foreach (FormattedTextFragment fragment in page.Annotations[i].FormattedTextFragments)
            {
                if (fragment.Font.FamilyName == "Verdana")
                {
                    page.Annotations.RemoveAt(i);
                    break;
                }
            }
        }
    }

    watermarker.Save(Constants.OutDocumentPdf);
}
```

#### Adding watermark to all image annotations 

Similar to the other types, the watermark can be added to [image](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.pdf/pdfshape/properties/image) annotations in PDF documents as shown in the below code sample.

**AdvancedUsage.AddingWatermarks.AddWatermarksToPdf.PdfAddWatermarkToAnnotationImages**

```csharp
PdfLoadOptions loadOptions = new PdfLoadOptions();
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
{
    PdfContent pdfContent = watermarker.GetContent<PdfContent>();

    // Initialize image or text watermark
    TextWatermark watermark = new TextWatermark("Protected image", new Font("Arial", 8));
    watermark.HorizontalAlignment = HorizontalAlignment.Center;
    watermark.VerticalAlignment = VerticalAlignment.Center;
    watermark.RotateAngle = 45;
    watermark.SizingType = SizingType.ScaleToParentDimensions;
    watermark.ScaleFactor = 1;

    foreach (PdfPage page in pdfContent.Pages)
    {
        foreach (PdfAnnotation annotation in page.Annotations)
        {
            if (annotation.Image != null)
            {
                // Add watermark to the image
                annotation.Image.Add(watermark);
            }
        }
    }

    watermarker.Save(Constants.OutDocumentPdf);
}
```

#### Replacing text for particular annotations

GroupDocs.Watermark allows you to edit and replace the [text](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.pdf/pdfshape/properties/text) of the particular annotations. You can also replace annotation's [text with formatting](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.pdf/pdfshape/properties/formattedtextfragments) as shown in the below code samples.

##### Replacing text

**AdvancedUsage.AddingWatermarks.AddWatermarksToPdf.PdfReplaceTextForParticularAnnotation**

```csharp
PdfLoadOptions loadOptions = new PdfLoadOptions();
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
{
    PdfContent pdfContent = watermarker.GetContent<PdfContent>();
    foreach (PdfAnnotation annotation in pdfContent.Pages[0].Annotations)
    {
        // Replace text 
        if (annotation.Text.Contains("Test"))
        {
            annotation.Text = "Passed";
        }
    }

    // Save document
    watermarker.Save(Constants.OutDocumentPdf);
}
```

##### Replacing text with formatting

**AdvancedUsage.AddingWatermarks.AddWatermarksToPdf.PdfReplaceTextForParticularAnnotationWithFormatting**

```csharp
PdfLoadOptions loadOptions = new PdfLoadOptions();
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
{
    PdfContent pdfContent = watermarker.GetContent<PdfContent>();
    foreach (PdfAnnotation annotation in pdfContent.Pages[0].Annotations)
    {
        // Replace text
        if (annotation.Text.Contains("Test"))
        {
            annotation.FormattedTextFragments.Clear();
            annotation.FormattedTextFragments.Add("Passed", new Font("Calibri", 19, FontStyle.Bold), Color.Red, Color.Aqua);
        }
    }

    // Save document
    watermarker.Save(Constants.OutDocumentPdf);
}
```

#### Replacing image for particular annotations

Using GroupDocs.Watermark, you can also replace the image of a particular annotation. GroupDocs.Watermark allows you to loop through all the annotations of a particular page and you can replace the [image](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.contents.pdf/pdfshape/properties/image) of particular annotations using some condition as shown in the below code sample.

**AdvancedUsage.AddingWatermarks.AddWatermarksToPdf.PdfReplaceImageForParticularAnnotation**

```csharp
PdfLoadOptions loadOptions = new PdfLoadOptions();
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
{
    PdfContent pdfContent = watermarker.GetContent<PdfContent>();

    // Replace image
    foreach (PdfAnnotation annotation in pdfContent.Pages[0].Annotations)
    {
        if (annotation.Image != null)
        {
            annotation.Image = new PdfWatermarkableImage(File.ReadAllBytes(Constants.TestPng));
        }
    }

    // Save document
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
