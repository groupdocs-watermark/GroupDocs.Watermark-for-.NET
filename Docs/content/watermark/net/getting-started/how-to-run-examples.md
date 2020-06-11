---
id: how-to-run-examples
url: watermark/net/how-to-run-examples
title: How to Run Examples
weight: 6
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
{{< alert style="warning" >}}Before running an example make sure that GroupDocs.Watermark has been installed successfully.{{< /alert >}}

We offer multiple solutions on how you can run GroupDocs.Watermark examples, by building your own or using our examples out-of-the-box.

Please choose one from the following list:


## Build project from scratch

*   Open Visual Studio and go to **File** -> **New **\->** Project**.
*   Select appropriate project type - Console App, ASP.NET Web Application etc.
*   Install **GroupDocs.Watermark for .NET **from Nuget or official GroupDocs website following this [guide]({{< ref "watermark/net/getting-started/how-to-run-examples.md" >}}).
*   Code your first application with **GroupDocs.Watermark for .NET **like this
    
    ```csharp
    string documentPath = "doc.pdf"; // NOTE: Put here actual path for your document
    PdfLoadOptions loadOptions = new PdfLoadOptions();
    using (Watermarker watermarker = new Watermarker(documentPath, loadOptions))
    {
        TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 36, FontStyle.Bold | FontStyle.Italic));
        PdfXObjectWatermarkOptions options = new PdfXObjectWatermarkOptions();
        options.PageIndex = 0;
    
        watermarker.Add(watermark, options);
        watermarker.Save("watermarked.pdf");
    }
    ```
    
*   Build and Run your project. 
*   Watermarked document will appear in the working directory* as watermarked.pdf.*

## Run examples

The complete examples package of **GroupDocs.Watermark** is hosted on [GitHub](https://github.com/groupdocs-watermark/GroupDocs.Watermark-for-.NET). You can either download the ZIP file from [here](https://github.com/groupdocs-watermark/GroupDocs.Watermark-for-.NET/archive/master.zip) or clone the repository of GitHub using your favourite git client.  
In case you download the ZIP file, extract the folders on your local disk. The extracted files and folders will look like following image:

![](watermark/net/images/how-to-run-examples.jpg)

In extracted files and folders, you can find CSharp solution file. The project is created in **Microsoft Visual Studio 2019**. The **Resources **folder contains all the sample document and image files used in the examples.  
To run the examples, open the solution file in Visual Studio and build the project. To add missing references of **GroupDocs.Watermark** see [Installation](https://wiki.lisbon.dynabic.com/display/watermark/Installation). All the functions are called from **RunExamples.cs**.   
Un-comment the function you want to run and comment the rest.

![](watermark/net/images/how-to-run-examples_1.png)

## Contribute

If you like to add or improve an example, we encourage you to contribute to the project. All examples in this repository are open source and can be freely used in your own applications.  
To contribute, you can fork the repository, edit the code and create a pull request. We will review the changes and include it in the repository if found helpful.
