# GroupDocs.Watermark Examples - Protect Documents with Watermarks

**Document security** made simple with comprehensive watermarking solutions. This repository contains practical examples demonstrating how to **add watermark**, **create watermark**, **remove watermark**, and implement **invisible watermarking for documents** using GroupDocs.Watermark for .NET.

## 🔐 Document Security & Content Protection Features

**Protect documents with watermarks** across 40+ file formats with enterprise-grade **content protection with watermarking** capabilities:

- **Custom watermark** creation with personalized text and images
- **Customize watermark** appearance, positioning, and transparency
- **Custom fonts** support for branded watermarking solutions
- **Watermark automation for enterprise** workflows
- Advanced search and removal capabilities
- **Invisible watermarking for documents** with steganographic techniques

## 📁 Repository Structure

| Directory | Description |
|-----------|-------------|
| [Examples](https://github.com/groupdocs-watermark/GroupDocs.Watermark-for-.NET/tree/master/Examples) | Complete C# examples showing **how to watermark files** and implement document security |
| [LiveDemos](https://github.com/groupdocs-watermark/GroupDocs.Watermark-for-.NET/tree/master/Demos/LiveDemos) | UI-based applications demonstrating **watermark in** real-world scenarios |

## 🚀 Quick Start - How to Watermark Documents

### Add Watermark to Documents

Learn **how to watermark** your documents with this simple example:

```csharp
using GroupDocs.Watermark;
using GroupDocs.Watermark.Common;
using GroupDocs.Watermark.Watermarks;

// Specify an absolute or relative path to your document.
using (Watermarker watermarker = new Watermarker("C:\\Docs\\contract.docx"))
{
    // Specify the desired text and font for the watermark
    TextWatermark watermark = new TextWatermark("Contract Draft", 
        new Font("Arial", 60, FontStyle.Bold));
    // Specify font color and text opacity, rotation and alignments
    watermark.ForegroundColor = Color.DarkGreen;
    watermark.Opacity = 0.5;
    watermark.HorizontalAlignment = HorizontalAlignment.Center;
    watermark.VerticalAlignment = VerticalAlignment.Center;
    // Apply the watermark
    watermarker.Add(watermark);
    // Save the resulting document
    watermarker.Save("C:\\Docs\\watermarked-contract.docx");
}
```

### Remove Watermark from Documents

**How to remove watermark from a document** - multiple approaches available:

```csharp
using GroupDocs.Watermark;
using GroupDocs.Watermark.Search.SearchCriteria;
using GroupDocs.Watermark.Search;

using (Watermarker watermarker = new Watermarker("C:\\Docs\\watermarked-sample.docx"))
{
    // Search watermark matching a particular text
    TextSearchCriteria searchCriteria = new TextSearchCriteria("Contract Draft", false);
    PossibleWatermarkCollection possibleWatermarks = watermarker.Search(searchCriteria);    
    // Clear all found watermarks
    possibleWatermarks.Clear();
    // Save document
    watermarker.Save("C:\\Docs\\clean-sample.docx");
}
```

## 📋 Watermarking Examples by Use Case

### Basic Watermarking Operations
- **How to watermark in** PDF documents
- **Create watermark** with custom fonts and styling
- **Add watermark** to multiple pages simultaneously
- **Customize watermark** transparency and rotation

### Advanced Document Security
- **Removing watermark from** third-party tools
- **Delete watermark from** specific document areas
- **Can you remove watermark from** password-protected files
- **How to remove watermarks in** batch processing

### Enterprise Solutions
- **Watermark automation for enterprise** document workflows
- **Content protection with watermarking** for sensitive documents
- **Document security** compliance implementations
- **Customized product** branding solutions

## 🎯 Supported File Formats

**How to watermark files** across multiple formats:

**Documents:** PDF, DOC, DOCX, XLS, XLSX, PPT, PPTX, RTF  
**Images:** PNG, JPG, BMP, TIFF, GIF, WEBP  
**Email:** EML, MSG, EMLX  
**Other:** Visio files (VSD, VSDX), OpenOffice (ODT)

## 🔧 Installation & Setup

Install via NuGet Package Manager:
```
Install-Package GroupDocs.Watermark
```

Or update existing installation:
```
Update-Package GroupDocs.Watermark
```

## 🌟 Advanced Features

- **Invisible watermarking for documents** with steganographic embedding  
- Search watermarks by formatting properties (font, color, size)
- **Document security** with password protection integration
- Batch processing for **watermark automation for enterprise**
- **Custom watermark** templates for consistent branding
- **Tiling watermarks** across entire document pages for comprehensive coverage

## 📖 Documentation & Resources

- [Complete API Documentation](https://docs.groupdocs.com/watermark/net/)
- [Live Demo - **How to Watermark** Online](https://products.groupdocs.app/watermark/family)
- [API Reference Guide](https://apireference.groupdocs.com/watermark/net)
- [Developer Blog](https://blog.groupdocs.com/category/watermark/)

## 🤝 Support & Community

- [Free Support Forum](https://forum.groupdocs.com/c/watermark) - Get help with **how to remove watermark from free** community
- [Search Documentation](https://docs.groupdocs.com/watermark/net/) - Find specific **watermark in** solutions
- [Temporary License](https://purchase.groupdocs.com/temporary-license) - Test full features

## 🏷️ Tags

`document-security` `watermarking` `content-protection` `pdf-watermark` `document-watermark` `remove-watermark` `add-watermark` `custom-watermark` `enterprise-security` `watermark-automation`

---

**Start protecting your documents today!** Clone this repository to explore comprehensive examples of **how to watermark a** document, implement **document security**, and leverage **watermark automation for enterprise** solutions.
