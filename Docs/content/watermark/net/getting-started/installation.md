---
id: installation
url: watermark/net/installation
title: Installation
weight: 4
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
## Install from NuGet

NuGet is the easiest way to download and install GroupDocs.Watermark for .NET. Following are the couple of ways to install GroupDocs.Watermark for .NET in your project using NuGet.

### Install via package manager GUI

Follow these steps to reference GroupDocs.Watermark using Package Manager GUI:

*   Open your solution/project in Visual Studio.
*   Click **Tools -> NuGet Package Manager -> Manage NuGet Packages for Solution**. You can also access the same option through the Solution Explorer. Right-click the solution or project and select **Manage NuGet Packages** from the context menu
*   Select **Browse** tab and type "GroupDocs.Watermark" in the search text box.
*   Click the **Install** button to install the latest version of the API into your project as shown in the following screenshot.

![](watermark/net/images/installation.png)

### Using package panager console

You can follow the steps below to reference GroupDocs.Watermark using the Package Manager Console:

*   Open your solution/project in Visual Studio.
*   Select **Tools -> NuGet Package Manager -> Package Manager Console** from the menu to open package manager console.
*   Type the command "Install-Package GroupDocs.Watermark" and press enter to install the latest release into your application.
*   After successful installation, GroupDocs.Watermark will be referenced in your application.

![](watermark/net/images/installation_1.png)
 

## Install from official GroupDocs website

You can follow the steps below to reference GroupDocs.Watermark for .NET downloaded from official website [Downloads section](https://downloads.groupdocs.com/watermark/net):

1.  Unpack zip archive or follow MSI install wizard instructions.
2.  In the Solution Explorer, expand the project node you want to add a reference to.
3.  Right-click the **References** node for the project and select **Add Reference** from the menu.
4.  In the Add Reference dialog box, select the **.NET** tab (it's usually selected by default).
5.  If you have used MSI installer to install GroupDocs.Watermark, you will see GroupDocs.Watermark in the top pane. Select it and then click the **Select** button.
6.  If you have downloaded and unpacked the DLL only, click the **Browse** button and locate the GroupDocs.Watermark.dll file.   
    You have referenced GroupDocs.Watermark and it should appear in the **SelectedComponents** pane of the dialog box.
7.  Click **OK**.
8.  GroupDocs.Watermark reference appears under the **References** node of the project.

Note that .NET Standard 2.0 version has external references:

| Package | Version |
| --- | --- |
| System.Drawing.Common | 4.7.0 |
| System.Text.Encoding.CodePages | 4.7.0 |
| SkiaSharp | 1.68.1 |
