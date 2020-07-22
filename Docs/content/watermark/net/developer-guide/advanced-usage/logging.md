---
id: logging
url: watermark/net/logging
title: Logging
weight: 8
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
[ILogger](https://apireference.groupdocs.com/watermark/net/groupdocs.watermark.options/ilogger) interface is used to receive the information about errors, warnings and events which occur during watermarking. [ILogger](https://apireference.groupdocs.com/watermark/net/groupdocs.watermark.options/ilogger) interface has the following members:

| Member | Description |
| --- | --- |
| [Error(string, Exception)](https://apireference.groupdocs.com/watermark/net/groupdocs.watermark.options/ilogger/methods/error) | Logs an error that occurred during watermarking. |
| [Warning(string)](https://apireference.groupdocs.com/watermark/net/groupdocs.watermark.options/ilogger/methods/warning) | Logs a warning that occurred during watermarking. |
| [Trace(string)](https://apireference.groupdocs.com/watermark/net/groupdocs.watermark.options/ilogger/methods/trace) | Logs an event occurred during watermarking. |

Here are the steps to receive the information via [ILogger](https://apireference.groupdocs.com/watermark/net/groupdocs.watermark.options/ilogger) interface:

*   Implement the class with [ILogger](https://apireference.groupdocs.com/watermark/net/groupdocs.watermark.options/ilogger) interface implementation;
*   Instantiate [Watermarker](https://apireference-qa.groupdocs.com/watermark/net/groupdocs.watermark/watermarker) object with [WatermarkerSettings](https://apireference-qa.groupdocs.com/watermark/net/groupdocs.watermark/watermarkersettings) object.

The following example shows how to receive the information via [ILogger](https://apireference.groupdocs.com/watermark/net/groupdocs.watermark.options/ilogger) interface.

```csharp
try
{
    // Create an instance of Logger class
    Logger logger = new Logger();

    WatermarkerSettings watermarkerSettings = new WatermarkerSettings();
    watermarkerSettings.Logger = logger;

    LoadOptions loadOptions = new LoadOptions();
    loadOptions.Password = "InvalidPassword";
    string filePath = Constants.InProtectedDocumentDocx;
    using (Watermarker watermarker = new Watermarker(filePath, loadOptions, watermarkerSettings))
    {
        // use watermarker methods to manage watermarks in the document
        TextWatermark watermark = new TextWatermark("Test watermark", new Font("Arial", 12));
        watermarker.Add(watermark);
        watermarker.Save(Constants.OutProtectedDocumentDocx);
    }
}
catch (InvalidPasswordException)
{
    ; // Ignore the exception
}

private class Logger : ILogger
{
    public void Error(string message, Exception exception)
    {
        // Print error message
        Console.WriteLine("Error: " + message);
    }
    public void Trace(string message)
    {
        // Print event message
        Console.WriteLine("Event: " + message);
    }
    public void Warning(string message)
    {
        // Print warning message
        Console.WriteLine("Warning: " + message);
    }
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
