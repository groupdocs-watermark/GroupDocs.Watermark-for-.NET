---
id: searching-watermarks
url: watermark/net/searching-watermarks
title: Searching watermarks
weight: 3
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
## Searching possible watermarks

GroupDocs.Watermark API allows you to search the possible watermarks placed in any document. You can also search the watermarks that are added using some third-party tool. The API provides [Search](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/watermarker/methods/search) method to search watermarks in a whole document or in any part of the document. Following code snippet shows how to find and get all possible watermarks in a document.

**AdvancedUsage.SearchAndRemoveWatermarks.SearchWatermark**

```csharp
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf))
{
    PossibleWatermarkCollection possibleWatermarks = watermarker.Search();
    foreach (PossibleWatermark possibleWatermark in possibleWatermarks)
    {
        if (possibleWatermark.ImageData != null)
        {
            Console.WriteLine(possibleWatermark.ImageData.Length);
        }

        Console.WriteLine(possibleWatermark.Text);
        Console.WriteLine(possibleWatermark.X);
        Console.WriteLine(possibleWatermark.Y);
        Console.WriteLine(possibleWatermark.RotateAngle);
        Console.WriteLine(possibleWatermark.Width);
        Console.WriteLine(possibleWatermark.Height);
    }
}
```

## Search criteria

Usually, large documents may contain too many objects which can be considered as watermarks. Parameterless overload of [Search](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/watermarker/methods/search) method returns only some of them, e.g. backgrounds or floating objects which could have been added during document post-processing. You can use [search criteria](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.search.searchcriteria/) to find objects with some specific parameters.

### Text search criteria

Following code snippet shows how to search for the watermarks that meet a particular [text criterion](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.search.searchcriteria/textsearchcriteria).

**AdvancedUsage.SearchAndRemoveWatermarks.SearchWatermarkWithSearchString**

```csharp
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf))
{
    // Search by exact string
    TextSearchCriteria textSearchCriteria = new TextSearchCriteria("Â© 2017");

    // Find all possible watermarks containing some specific text
    PossibleWatermarkCollection possibleWatermarks = watermarker.Search(textSearchCriteria);

    Console.WriteLine("Found {0} possible watermark(s)", possibleWatermarks.Count);
}
```

### Regular expression search criteria  

Regular expressions are also supported by [TextSearchCriteria](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.search.searchcriteria/textsearchcriteria). The below sample code uses a regular expression to search for watermarks.

**AdvancedUsage.SearchAndRemoveWatermarks.SearchWatermarkWithRegularExpression**

```csharp
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf))
{
    Regex regex = new Regex(@"^Â© \d{4}$");

    // Search by regular expression
    TextSearchCriteria textSearchCriteria = new TextSearchCriteria(regex);

    // Find possible watermarks using regular expression
    PossibleWatermarkCollection possibleWatermarks = watermarker.Search(textSearchCriteria);

    Console.WriteLine("Found {0} possible watermark(s).", possibleWatermarks.Count);
}
```

{{< alert style="info" >}}What happens when the user is passing TextSearchCriteria instance to the method?1. It searches fragments of document's main text which match regular expression (or contain exact search string)2. It checks text of other objects (shapes, XObjects, annotations etc.) if they match regular expression (or contain exact search string){{< /alert >}}{{< alert style="warning" >}}Search in the main text of a document is performed only if you pass TextSearchCriteria instance to Search method.{{< /alert >}}

### Image search criteria

Sometimes a document can contain image watermarks, and it's necessary to find them using sample picture. For example, you may want to find all possible image watermarks that are similar to a company logo. Following sample code searches for image watermarks that resemble with a particular image using.

**AdvancedUsage.SearchAndRemoveWatermarks.SearchImageWatermark**

```csharp
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf))
{
    // Initialize criteria with the image
    ImageSearchCriteria imageSearchCriteria = new ImageDctHashSearchCriteria(Constants.WatermarkJpg);

    //Set maximum allowed difference between images
    imageSearchCriteria.MaxDifference = 0.9;

    PossibleWatermarkCollection possibleWatermarks = watermarker.Search(imageSearchCriteria);

    Console.WriteLine("Found {0} possible watermark(s).", possibleWatermarks.Count);
}
```

[MaxDifference ](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.search.searchcriteria/imagesearchcriteria/properties/maxdifference) property is used to set maximum allowed difference between sample image and possible watermark. The value should be between 0 and 1. The value 0 means that only identical images will be found.

Using of [ImageDctHashSearchCriteria](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.search.searchcriteria/imagedcthashsearchcriteria) is the most efficient way to find image watermark by a sample. This criterion uses DCT (Discrete Cosine Transform) based perceptual hash for image similarity comparison. But there are other image search criteria that are based on other algorithms:

*   [ImageColorHistogramSearchCriteria](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.search.searchcriteria/imagecolorhistogramsearchcriteria) uses image color histograms for calculating image similarity. This criterion is invariant to rotation, scaling, and translation of the image.
*   [ImageThumbnailSearchCriteria](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.search.searchcriteria/imagethumbnailsearchcriteria) uses image binarized thumbnail for calculating image similarity. This criterion is invariant to rotation, scaling and insignificant changes of the color palette.

### Combined search criteria

GroupDocs.Watermark API also allows you to search watermarks by a combination ([And](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.search.searchcriteria/andsearchcriteria), [Or](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.search.searchcriteria/orsearchcriteria), [Not](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.search.searchcriteria/notsearchcriteria)) of different search criteria. Following sample code shows how to search watermark with the combination of different search criteria.

**AdvancedUsage.SearchAndRemoveWatermarks.SearchWatermarkWithCombinedSearch**

```csharp
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf))
{
    ImageSearchCriteria imageSearchCriteria = new ImageDctHashSearchCriteria(Constants.LogoPng);
    imageSearchCriteria.MaxDifference = 0.9;

    TextSearchCriteria textSearchCriteria = new TextSearchCriteria("Company Name");

    RotateAngleSearchCriteria rotateAngleSearchCriteria = new RotateAngleSearchCriteria(30, 60);

    SearchCriteria combinedSearchCriteria = imageSearchCriteria.Or(textSearchCriteria).And(rotateAngleSearchCriteria);

    PossibleWatermarkCollection possibleWatermarks = watermarker.Search(combinedSearchCriteria);

    Console.WriteLine("Found {0} possible watermark(s).", possibleWatermarks.Count);
}
```

### Text formatting search criteria

GroupDocs.Watermark also enables you to search the watermarks on the basis of some particular text formatting. You can provide a search criterion containing font name, size, color etc and the API will find the watermarks with matching properties. Following code snippet shows how to search watermark with a particular [text formatting](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.search.searchcriteria/textformattingsearchcriteria).

**AdvancedUsage.SearchAndRemoveWatermarks.SearchWatermarkWithParticularTextFormatting**

```csharp
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf))
{
    TextFormattingSearchCriteria criteria = new TextFormattingSearchCriteria();
    criteria.ForegroundColorRange = new ColorRange();
    criteria.ForegroundColorRange.MinHue = -5;
    criteria.ForegroundColorRange.MaxHue = 10;
    criteria.ForegroundColorRange.MinBrightness = 0.01f;
    criteria.ForegroundColorRange.MaxBrightness = 0.99f;
    criteria.BackgroundColorRange = new ColorRange();
    criteria.BackgroundColorRange.IsEmpty = true;
    criteria.FontName = "Arial";
    criteria.MinFontSize = 19;
    criteria.MaxFontSize = 42;
    criteria.FontBold = true;

    PossibleWatermarkCollection watermarks = watermarker.Search(criteria);

    // The code for working with found watermarks goes here.
    Console.WriteLine("Found {0} possible watermark(s).", watermarks.Count);
}
```

## Searching watermarks in particular objects

This feature allows you to specify which objects should be included in watermark search. Restricting searchable objects, you can significantly increase search performance. Following sample code shows how to set [searchable objects](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/watermarkersettings/properties/searchableobjects) globally (for all documents that will be created after that).

**AdvancedUsage.SearchAndRemoveWatermarks.SearchWatermarkInParticularObjectsAllInstances**

```csharp
WatermarkerSettings settings = new WatermarkerSettings();
settings.SearchableObjects = new SearchableObjects
                             {
                                 WordProcessingSearchableObjects = WordProcessingSearchableObjects.Hyperlinks | WordProcessingSearchableObjects.Text,
                                 SpreadsheetSearchableObjects = SpreadsheetSearchableObjects.HeadersFooters,
                                 PresentationSearchableObjects = PresentationSearchableObjects.SlidesBackgrounds | PresentationSearchableObjects.Shapes,
                                 DiagramSearchableObjects = DiagramSearchableObjects.None,
                                 PdfSearchableObjects = PdfSearchableObjects.All
                             };
string[] files = { Constants.InDocumentDocx, Constants.InSpreadsheetXlsx, Constants.InPresentationPptx,
                   Constants.InDiagramVsdx, Constants.InDocumentPdf };
foreach (string file in files)
{
    using (Watermarker watermarker = new Watermarker(file, settings))
    {
        PossibleWatermarkCollection watermarks = watermarker.Search();

        // The code for working with found watermarks goes here.
        Console.WriteLine("In {0} found {1} possible watermark(s).", Path.GetFileName(file), watermarks.Count);
    }
}
```

### Searching for hyperlink watermarks  

You can also set [searchable objects](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/watermarker/properties/searchableobjects) for a particular [Watermarker](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/watermarker) instance as shown in the sample code below.

**AdvancedUsage.SearchAndRemoveWatermarks.SearchWatermarkInParticularObjectsForParticularDocument**

```csharp
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf))
{
    // Search for hyperlinks only.
    watermarker.SearchableObjects.PdfSearchableObjects = PdfSearchableObjects.Hyperlinks;
    PossibleWatermarkCollection watermarks = watermarker.Search();

    // The code for working with found watermarks goes here.
    Console.WriteLine("Found {0} hyperlink watermark(s).", watermarks.Count);
}
```

## Searching text watermark skipping unreadable characters

This feature allows finding text watermark even if it contains unreadable characters between the letters. The following code sample shows how to [skip unreadable characters](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.search.searchcriteria/textsearchcriteria/properties/skipunreadablecharacters) when searching for the watermark.

**AdvancedUsage.SearchAndRemoveWatermarks.SearchTextWatermarkSkippingUnreadableCharacters**

```csharp
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf))
{
    string watermarkText = "Company name";
    TextSearchCriteria criterion = new TextSearchCriteria(watermarkText);

    // Enable skipping of unreadable characters
    criterion.SkipUnreadableCharacters = true;
    PossibleWatermarkCollection result = watermarker.Search(criterion);

    // ...
    Console.WriteLine("Found {0} possible watermark(s).", result.Count);
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
