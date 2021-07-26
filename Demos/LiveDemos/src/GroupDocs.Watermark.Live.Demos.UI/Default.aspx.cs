using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Globalization;
using GroupDocs.Watermark.Live.Demos.UI.Models;
using GroupDocs.Watermark.Live.Demos.UI.Config;
using GroupDocs.Watermark.Live.Demos.UI.Helpers;

namespace GroupDocs.Watermark.Live.Demos.UI
{
	public partial class Default : BasePage
	{
		public string fileFormat = "";
		protected void Page_Load(object sender, EventArgs e)
		{
			rfvWatermark.ErrorMessage = Resources["WatermarkTextMessage"];
			if (!IsPostBack)
			{
				if (Session["emailTo"] != null)
				{
					emailTo.Value = Session["emailTo"].ToString();
				}
				btnAddWatermark.Text = string.Format(Resources["btnAddWatermark"], Resources["WatermarkAddText"]);

				// Set page settings based on from and top selection
				PageSettings();
				txtWatermark.Attributes.Add("placeholder", Resources["AddWatermarkTextPlaceholder"]);

				rfvEmail.ErrorMessage = revValidateEmail.ErrorMessage = Resources["ValidateEmailMessage"];
				rfvFile.ErrorMessage = Resources["SelectorDropFileMessage"];
			}

		}

		protected void btnSend_Click(object sender, EventArgs e)
		{
			if (IsValid)
			{
				try
				{
					if ((emailTo.Value != "") && (downloadUrl.Value != ""))
					{
						string url = HttpUtility.UrlDecode(downloadUrl.Value);
						string emailBody = EmailManager.PopulateBody("", Resources["DownloadFileLinkTitle"], url, "", Resources["WatermarkSubpageHeading"], Resources["WatermarkAddedSuccessMessage"]);
						EmailManager.SendEmail(emailTo.Value, Configuration.FromEmailAddress, Resources["WatermarkEmailTitle"], emailBody, "");
					}

					hSendDownloadLink.InnerHtml = Resources["SendEmailToDownloadLink"];
					hSendDownloadLink.Attributes.Add("class", "alert alert-success");
				}
				catch (Exception ex)
				{

					hSendDownloadLink.InnerHtml = "Error: " + ex.Message;
					hSendDownloadLink.Attributes.Add("class", "alert alert-danger");
				}
				finally
				{
					ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "ShowfileSendEmail()", true);
				}
			}
			ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "ShowfileSendEmail()", true);

		}

		private void SetFileTypeAllowedExtensions()
		{
			string validationExpression = "";
			string validFileExtensions = "";

			Page.MetaDescription = "Free online text watermarking. Format watermark text and add watermark to your document, download the updated file instantly.";
			Page.Title = "Free Online Watermark App - GroupDocs.App";
            
			validationExpression = Resources["WatermarkValidationExpression"];
			validFileExtensions = GetValidFileExtensions(validationExpression);
            
			ValidateFileType.ValidationExpression = @"(.*?)(" + validationExpression + "|" + validationExpression.ToUpper() + ")$";
			ValidateFileType.ErrorMessage = Resources["InvalidFileExtension"] + " " + validFileExtensions;
			aPoweredBy.InnerText = "GroupDocs.Watermark";
			aPoweredBy.HRef = "https://products.GroupDocs.com/watermark";
		}

		private string TitleCase(string value)
		{
			return new CultureInfo("en-US", false).TextInfo.ToTitleCase(value);
		}
		private string GetValidFileExtensions(string validationExpression)
		{
			string validFileExtensions = validationExpression.Replace(".", "").Replace("|", ", ").ToUpper();

			int index = validFileExtensions.LastIndexOf(",");
			if (index != -1)
			{
				string substr = validFileExtensions.Substring(index);
				string str = substr.Replace(",", " or");
				validFileExtensions = validFileExtensions.Replace(substr, str);
			}

			return validFileExtensions;
		}
		private void PageSettings()
		{
			SetFileTypeAllowedExtensions();
		}

		protected void btnAddWatermark_Click(object sender, EventArgs e)
		{
            Configuration.GroupDocsAppsAPIBasePath = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/";
            Configuration.FileDownloadLink = Configuration.GroupDocsAppsAPIBasePath + "DownloadFile.aspx";

            if (Page.IsValid)
			{
				pMessage.Attributes.Remove("class");
				pMessage.InnerHtml = "";

				hSendDownloadLink.Attributes.Remove("class");
				hSendDownloadLink.InnerHtml = "";

				// Check if File is available.
				if (UploadFile.PostedFile != null && UploadFile.PostedFile.ContentLength > 0)
				{
					string fn = UploadFile.PostedFile.FileName;
					try
					{
						string SaveLocation = Configuration.AssetPath + fn;

						UploadFile.PostedFile.SaveAs(SaveLocation);
						//}
						//System.Threading.Thread.Sleep(8000);

						var isFileUploaded = FileManager.UploadFile(SaveLocation, emailTo.Value);
						if ((isFileUploaded != null) && (isFileUploaded.FileName.Trim() != ""))
						{
							Dictionary<string, string> apiParams = new Dictionary<string, string>();
							Response response = null;

							apiParams.Add("watermarkText", txtWatermark.Value);
							apiParams.Add("watermarkColor", pickcolor.Value.Replace("#", ""));
							apiParams.Add("fontFamily", ddlFontFamily.SelectedItem.Value);
							apiParams.Add("fontStyle", ddlFontStyle.SelectedItem.Value);
							apiParams.Add("fontSize", ddlFontSize.SelectedItem.Value);

							response = GroupDocsWatermarkApiHelper.AddTextWatermark(isFileUploaded.FileName, isFileUploaded.FolderId, emailTo.Value, apiParams);

							if (response == null)
							{
								throw new Exception(Resources["APIResponseTime"]);
							}
							else if (response.StatusCode == 200)
							{
								string url = Configuration.FileDownloadLink + "?FileName=" + response.FileName + "&Time=" + DateTime.Now.ToString();
								litDownloadNow.Text = "<a target=\"_blank\" href=\"" + url + "\" class=\"btn btn-success btn-lg\">" + Resources["DownLoadNow"] + " <i class=\"fa fa-download\"></i></a>";
								downloadUrl.Value = HttpUtility.UrlEncode(url);

								ConvertPlaceHolder.Visible = false;
								DownloadPlaceHolder.Visible = true;

							}
							else
							{
								pMessage.Visible = true;
								pMessage.InnerHtml = response.Status;
								pMessage.Attributes.Add("class", "alert alert-danger");
							}
						}
					}
					catch (Exception ex)
					{
						pMessage.Visible = true;
						pMessage.InnerHtml = "Error: " + ex.Message;
						pMessage.Attributes.Add("class", "alert alert-danger");
					}
				}
				else
				{
					pMessage.Visible = true;
					pMessage.InnerHtml = Resources["FileSelectMessage"];
					pMessage.Attributes.Add("class", "alert alert-danger");
				}
			}
		}
	}
}