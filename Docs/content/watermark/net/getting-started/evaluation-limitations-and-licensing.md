---
id: evaluation-limitations-and-licensing
url: watermark/net/evaluation-limitations-and-licensing
title: Evaluation Limitations and Licensing
weight: 5
description: " "
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
{{< alert style="info" >}}You can use GroupDocs.Watermark without the license. The usage and functionalities are pretty much same as the licensed one but you will face few limitations while using the non-licensed API.{{< /alert >}}

# Evaluation Version Limitations

You can easily download GroupDocs.Watermark for evaluation. The evaluation download is the same as the purchased download. The evaluation version simply becomes licensed when you add a few lines of code to apply the license. You will face following limitations while using the API without the license.  

| API Feature | Limitation |
| --- | --- |
| Document loading | Only 10 documents can be loaded per application run.    |
| Watermark search/removing | Removing/replacing of document parts is not allowed in evaluation mode.  |
| Watermark adding | Only 1 watermark can be added to a document per editing session.  |
| Document saving | Evaluation warning watermark will be added to a document.  |

## Licensing

The license file contains details such as the product name, number of developers it is licensed to, subscription expiry date and so on. It contains the digital signature, so don't modify the file. Even inadvertent addition of an extra line break into the file will invalidate it. You need to set a license before utilizing GroupDocs.Watermark API if you want to avoid its evaluation limitations.   
The license can be loaded from a file or stream object. The easiest way to set a license is to put the license file in the same folder as the GroupDocs.Watermark.dll file and specify the file name, without a path, as shown in the examples below.

### Setting license from file

The code below will explain how to [set](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark.license/setlicense/methods/1) product [license](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/license) from a file.

```csharp
// For complete examples and data files, please go to https://github.com/groupdocs-watermark/GroupDocs.Watermark-for-.NET
//initialize License
License lic = new License();

//Set license
lic.SetLicense("GroupDocs.Watermark.lic");
```

### Setting license from stream

The following example shows how to [load](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/license/methods/setlicense) a [license](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/license) from a stream.

```csharp
// For complete examples and data files, please go to https://github.com/groupdocs-watermark/GroupDocs.Watermark-for-.NET
using (FileStream fileStream = new FileStream("GroupDocs.Watermark.lic", FileMode.Open, FileAccess.Read))
{
    License lic = new License();
    lic.SetLicense(fileStream);
}
```

{{< alert style="info" >}}Calling License.SetLicense multiple times is not harmful but simply wastes processor time. If you are developing a Windows Forms or console application, call License.SetLicense in your startup code, before using GroupDocs.Watermark classes. When developing an ASP.NET application, you can call License.SetLicense from the Global.asax.cs (Global.asax.vb) file in the Application_Start protected method. It is called once when the application starts. Do not call License.SetLicense from within Page_Load methods since it means the license will be loaded every time a web page is loaded.{{< /alert >}}

### Setting metered license

You can also set [Metered](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/metered) license as an alternative to license file. It is a new licensing mechanism that will be used along with existing licensing method. It is useful for the customers who want to be billed based on the usage of the API features. For more details, please refer to [Metered Licensing FAQ](https://purchase.groupdocs.com/faqs/licensing/metered) section.

Here are the simple steps to use the `[Metered](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/metered)` class.

1.  Create an instance of `[Metered](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/metered)` class.
2.  Pass public & private keys to [S`etMeteredKey`](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/metered/methods/setmeteredkey) method.
3.  Do processing (perform task).
4.  Call method [G`etConsumptionQuantity`](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/metered/methods/getconsumptionquantity) of the [`Metered`](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/metered) class.
5.  It will return the amount/quantity of API requests that you have consumed so far.
6.  Call method [G`etConsumptionCredit`](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/metered/methods/getconsumptioncredit) of the [`Metered`](https://apireference.groupdocs.com/net/watermark/groupdocs.watermark/metered) class.
7.  It will return the credit that you have consumed so far.

  
Following is the sample code demonstrating how to use Metered class.

```csharp
// For complete examples and data files, please go to https://github.com/groupdocs-watermark/GroupDocs.Watermark-for-.NET
string PublicKey = ""; // Your public license key
string PrivateKey = ""; // Your private license key

Metered metered = new Metered();
metered.SetMeteredKey(PublicKey, PrivateKey);

// Get amount (MB) consumed
decimal amountConsumed = Metered.GetConsumptionQuantity();
Console.WriteLine("Amount (MB) consumed: " + amountConsumed);
 
// Get count of credits consumed
decimal creditsConsumed = Metered.GetConsumptionCredit();
Console.WriteLine("Credits consumed: " + creditsConsumed);
```
