// Copyright (c) Aspose 2002-2016. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace GroupDocsWatermarkVisualStudioPlugin.Core
{
    public class GroupDocsComponents
    {
        public static Dictionary<String, GroupDocsComponent> list = new Dictionary<string, GroupDocsComponent>();
        public GroupDocsComponents()
        {
            list.Clear();

            GroupDocsComponent groupdocsWatermark = new GroupDocsComponent();
            groupdocsWatermark.set_downloadUrl("");
            groupdocsWatermark.set_downloadFileName("groupdocs.Watermark.zip");
            groupdocsWatermark.set_name(Constants.GROUPDOCS_COMPONENT);
            groupdocsWatermark.set_remoteExamplesRepository("https://github.com/groupdocs-watermark/GroupDocs.Watermark-for-.NET.git");
            list.Add(Constants.GROUPDOCS_COMPONENT, groupdocsWatermark);
        }
    }
}
