# Document Watermark API

GroupDocs.Watermark is an on-premise library to [add text & image watermarks to documents](https://products.groupdocs.com/watermark/net) of different formats. It also provides an easy way to search and remove previously added watermarks (including watermarks added by third-party tools). Supported file formats include Microsoft Word, PowerPoint, Excel & PDF documenst as well as images such as BMP, PNG, GIF, TIFF, JPEG, and many more.

<p align="center">

  <a title="Download complete GroupDocs.Watermark for .NET source code" href="https://github.com/groupdocs-watermark/GroupDocs.Watermark-for-.NET/archive/api-v2.zip">
	<img src="https://raw.github.com/AsposeExamples/java-examples-dashboard/master/images/downloadZip-Button-Large.png" />
  </a>
</p>

Directory | Description
--------- | -----------
[Examples](https://github.com/groupdocs-watermark/GroupDocs.Watermark-for-.NET/tree/master/Examples)  | C# examples and sample files that will help you learn how to use product features. 
[Showcases](https://github.com/groupdocs-watermark/GroupDocs.Watermark-for-.NET/tree/master/Showcases)  | The open source UI-based project that can help integrate GroupDocs.Watermark API in front end applications. 
[Plugins](https://github.com/groupdocs-watermark/GroupDocs.Watermark-for-.NET/tree/master/Plugins)  | Contains Visual Studio plugins related to GroupDocs.Watermark.

## Watermark Features

- Add text & image watermark to [40+ document formats](https://docs.groupdocs.com/watermark/net/supported-document-formats/).
- Search and remove text and image watermarks.
- Search watermarks in particular objects.
- Apply watermark to images embedded in documents.
- Extract information of watermark objects.
- Perform PDF document rasterization.
- Fetch document's basic information.
- Search watermarks by formatting (font, color etc.).
- Set background image for charts in Excel & PowerPoint files.

## Supported Formats for Watermarking

**Microsoft Word:** DOC, DOT, DOCX, DOCM, DOTX, DOTM, RTF\
**Microsoft Excel:** XLSX, XLSM, XLTM, XLT, XLTX, XLS\
**Microsoft PowerPoint:** PPTX, PPTM, PPSX, PPSM, POTX, POTM, PPT, PPS\
**Microsoft Visio:** VSD, VDX, VSDX, VSTX, VSS, VSSX, VSDM, VSSM, VSTM, VTX, VSX\
**OpenOffice:** ODT\
**Email:** EML, EMLX, OFT, MSG\
**Fixed Layout:** PDF\
**Image:** BMP, GIF, JPG/JPEG/JPE, JP2, PNG, TIFF, WEBP

## Develop & Deploy GroupDocs.Watermark Anywhere

**Microsoft Windows:** Microsoft Windows Desktop & Server (x86, x64), Windows Azure\
**macOS:** Mac OS X\
**Linux:** Ubuntu, OpenSUSE, CentOS, and others\
**Development Environments:** Microsoft Visual Studio, Xamarin.Android, Xamarin.IOS, Xamarin.Mac, MonoDevelop, JetBrains Rider\
**Supported Frameworks:** .NET Framework 2.0 or higher, Mono Framework 2.6.7 or higher, .NET Standard 2.0, .NET Core 2.0 & 2.1

## Get Started with GroupDocs.Watermark for .NET

Are you ready to give GroupDocs.Watermark for .NET a try? Simply execute `Install-Package GroupDocs.Watermark` from Package Manager Console in Visual Studio to fetch & reference GroupDocs.Watermark assembly in your project. If you already have GroupDocs.Watermark for .Net and want to upgrade it, please execute `Update-Package GroupDocs.Watermark` to get the latest version.

## Add Watermark to Images on a PDF Page

```csharp
PdfLoadOptions loadOptions = new PdfLoadOptions();
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf, loadOptions))
{
    // initialize image or text watermark
    TextWatermark watermark = new TextWatermark("Protected image", new Font("Arial", 8));
    watermark.HorizontalAlignment = HorizontalAlignment.Center;
    watermark.VerticalAlignment = VerticalAlignment.Center;
    watermark.RotateAngle = 45;
    watermark.SizingType = SizingType.ScaleToParentDimensions;
    watermark.ScaleFactor = 1;

    PdfContent pdfContent = watermarker.GetContent<PdfContent>();

    // get all images from the first page
    WatermarkableImageCollection images = pdfContent.Pages[0].FindImages();

    // add watermark to all found images
    foreach (WatermarkableImage image in images)
    {
        image.Add(watermark);
    }

    watermarker.Save(Constants.OutDocumentPdf);
}
```

## Search for Watermarks in a PDF using Regular Expression

```csharp
// Constants.InDocumentPdf is an absolute or relative path to your document. Ex: @"C:\Docs\document.pdf"
using (Watermarker watermarker = new Watermarker(Constants.InDocumentPdf))
{
    Regex regex = new Regex(@"^Â© \d{4}$");

    // search by regular expression
    TextSearchCriteria textSearchCriteria = new TextSearchCriteria(regex);

    // find possible watermarks using regular expression
    PossibleWatermarkCollection possibleWatermarks = watermarker.Search(textSearchCriteria);

    Console.WriteLine("Found {0} possible watermark(s).", possibleWatermarks.Count);
}
```

[Home](https://www.groupdocs.com/) | [Product Page](https://products.groupdocs.com/watermark/net) | [Documentation](https://docs.groupdocs.com/watermark/net/) | [Demo](https://products.groupdocs.app/watermark/family) | [API Reference](https://apireference.groupdocs.com/watermark/net) | [Examples](https://github.com/groupdocs-watermark/GroupDocs.Watermark-for-.NET) | [Blog](https://blog.groupdocs.com/category/watermark/) | [Search](https://search.groupdocs.com/) | [Free Support](https://forum.groupdocs.com/c/watermark) | [Temporary License](https://purchase.groupdocs.com/temporary-license)
