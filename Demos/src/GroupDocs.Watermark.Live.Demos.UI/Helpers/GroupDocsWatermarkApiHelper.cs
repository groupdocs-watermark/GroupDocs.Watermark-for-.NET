using GroupDocs.Watermark.Live.Demos.UI.Models;
using System.Collections.Generic;

namespace GroupDocs.Watermark.Live.Demos.UI.Helpers
{
	public class GroupDocsWatermarkApiHelper : ApiHelperBase
	{
		private static Response CallGroupDocsAPI(string product, string apiName, string fileName, string folderName, string userEmail, Dictionary<string, string> apiParams)
		{
			return CallGroupDocsAppsAPI(product, apiName, fileName, folderName, userEmail, apiParams);
		}
		public static Response AddTextWatermark( string fileName, string folderName, string userEmail, Dictionary<string, string> apiParams)
		{
			
			return CallGroupDocsAPI("GroupDocsWatermark", "AddTextWatermark", fileName, folderName, userEmail, apiParams);
			
		}

	}
}