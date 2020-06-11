---
id: net-standard-2-0-api-limitations
url: watermark/net/net-standard-2-0-api-limitations
title: .NET Standard 2.0 API Limitations
weight: 1
description: ""
keywords: 
productName: GroupDocs.Watermark for .NET
hideChildren: False
---
## Limitations

1.  Because of the lack of Windows fonts in target OS (Android, macOS, Linux, etc), fonts used in documents are substituted with available fonts, this might lead to inaccurate document layout when rendering the document to PNG, JPG, and PDF.
2.  If GroupDocs.Watermark for .NET Standard is intended to be used in a Linux environment, an additional NuGet package should be referenced to make it work correctly with graphics: [SkiaSharp.NativeAssets.Linux](https://www.nuget.org/packages/SkiaSharp.NativeAssets.Linux) for Ubuntu (it also should work on most Debian-based Linux distributions) or [Goelze.SkiaSharp.NativeAssets.AlpineLinux](https://www.nuget.org/packages/Goelze.SkiaSharp.NativeAssets.AlpineLinux) for Alpine Linux.

## Recommendations 

When using GroupDocs.Watermark in a non-Windows environment in order to improve rendering results we do recommend installing the following packages :

1.  libgdiplus - is the Mono library that provides a GDI+-compatible API on non-Windows operating systems.
2.  libc6-dev - package contains the symlinks, headers, and object files needed to compile and link programs which use the standard C library.
3.  ttf-mscorefonts-installer - package with Microsoft compatible fonts.

To install packages on Debian-based Linux distributions use [apt-get](https://wiki.debian.org/apt-get)utility:

1.  sudo apt-get install libgdiplus
    
2.  sudo apt-get install libc6-dev
    
3.  sudo apt-get install ttf-mscorefonts-installer
