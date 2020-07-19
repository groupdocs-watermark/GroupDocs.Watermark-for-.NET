using System.Web.Http;
using System.Threading.Tasks;
using GroupDocs.Watermark.Live.Demos.UI.Models;
using System;
using GroupDocs.Watermark.Legacy;

namespace GroupDocs.Watermark.Live.Demos.UI.Controllers
{
	public class GroupDocsWatermarkController : ApiControllerBase
	{
		private async Task<Response> ProcessTask(string fileName, string folderName, string outFileExtension, bool createZip, string userEmail, ActionDelegate action)
		{
			//GroupDocs.Watermark.Live.Demos.UI.Models.License.SetGroupDocsWatermarkLicense();
			return await Process("GroupDocsWatermarkController", fileName, folderName, outFileExtension, createZip, action);

		}
		[HttpGet]
		[ActionName("AddTextWatermark")]
		public async Task<Response> AddTextWatermark(string fileName, string folderName, string watermarkText, string fontSize, string fontFamily, string fontStyle, string userEmail, string watermarkColor)
		{
			string outputType = GetoutFileExtension(fileName, folderName);
			return await ProcessTask(fileName, folderName, outputType, false, userEmail, delegate (string inFilePath, string outPath, string zipOutFolder)
		  {
			  // Initialize the font to be used for watermark
			  Font font = new Font(fontFamily, int.Parse(fontSize), (FontStyle)Enum.Parse(typeof(FontStyle), fontStyle)); //FontStyle.Bold | FontStyle.Italic);


			  TextWatermark watermark = new TextWatermark(watermarkText, font);

			  if (watermarkColor != "")
			  {
				  if (!watermarkColor.StartsWith("#"))
				  {
					  watermarkColor = "#" + watermarkColor;
				  }
				  System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml(watermarkColor);
				  watermark.ForegroundColor = Color.FromArgb(color.R, color.G, color.B);
			  }
			  else
			  {
				  watermark.ForegroundColor = Color.Blue;
			  }
			  watermark.HorizontalAlignment = HorizontalAlignment.Right;
			  watermark.VerticalAlignment = VerticalAlignment.Top;
			  watermark.SizingType = SizingType.ScaleToParentDimensions;
			  watermark.ScaleFactor = 1;
			  watermark.RotateAngle = 45;

			  using (Document doc = Document.Load(inFilePath))
			  {
				  doc.AddWatermark(watermark);
				  doc.Save(outPath);
			  }
		  });
		}
	}
}