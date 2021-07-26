<%@ Page Title="" Language="C#" MetaDescription="Add text watermark to any format, pdf,doc,docx,dot,dotx,docm,dotm,rtf,xls,xlsx,xlt,xltx,xlsm,xltm,ppt,pptx,pps,ppsx,potx,pptm,ppsm,potm,odt,vsdx,vstx,vssx,vsdm,vssm,vstm,vdx,vsx,vtx,png,bmp,gif,jpg,jpeg,tif,tiff,jp2,webp,eml,msg,emlx,oft" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GroupDocs.Watermark.Live.Demos.UI.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>

			<div class="container-fluid GroupDocsApps">
				<div class="container">
					<div class="row">
						<div class="col-md-12 pt-5 pb-5">
							<h1 id="hheading" runat="server">Free Online Watermark App</h1>
							<h4 id="hdescription" runat="server">Add text watermark to your document online from anywhere</h4>
							<div class="form">
								<asp:PlaceHolder ID="ConvertPlaceHolder" runat="server">
									<div class="uploadfile">
										<div class="filedropdown">
											<div class="filedrop">
												<label class="dz-message needsclick"><% = Resources["DropOrUploadFile"] %></label>
												<input type="file" name="UploadFile" id="UploadFile" runat="server" class="uploadfileinput" />
												<asp:RegularExpressionValidator ID="ValidateFileType" ValidationExpression="([a-zA-Z0-9\s)\s(\s_\\.\-:])+(.doc|.docx|.dot|.dotx|.rtf)$"
													ControlToValidate="UploadFile" runat="server" ForeColor="Red"
													Display="Dynamic" />
												<asp:RequiredFieldValidator ID="rfvFile" SetFocusOnError="true" ValidationGroup="uploadFile" runat="server"
													ErrorMessage="*" ControlToValidate="UploadFile" Display="Dynamic"
													ForeColor="Red"></asp:RequiredFieldValidator>
												<asp:HiddenField ID="hdnFileExtensionMessage" runat="server" />
												<div class="fileupload">
													<span class="filename">
														<a href="#">
															<label for="uploadfileinput" id="lblFilename" class="custom-file-upload"></label>
														</a>
													</span>
												</div>
											</div>
											<div class="watermark" style="margin-bottom: 0px;" id="dvAddWatermark" runat="server">
												<textarea id="txtWatermark" runat="server" class="form-control" aria-describedby="basic-addon2"></textarea>
												<br />
												<asp:RequiredFieldValidator ID="rfvWatermark" EnableClientScript="true" runat="server"
													ControlToValidate="txtWatermark" Display="Dynamic"
													ValidationGroup="uploadFile"></asp:RequiredFieldValidator>


											</div>
											<div class="colorpicker" style="padding-bottom: 10px;">
												<div class="form-inline">
													<div class="color-wrapper">
														<input type="text" name="custom_color" placeholder="#99FF66" value="#99FF66" clientidmode="Static" id="pickcolor" class="call-picker" runat="server" />
														<div class="color-holder call-picker"></div>
														<div class="color-picker" id="color-picker" style="display: none"></div>

														&nbsp;
					 <asp:DropDownList CssClass="form-control" ID="ddlFontFamily" runat="server">
						 <asp:ListItem Selected="True" Value="Arial"> Arial </asp:ListItem>
						 <asp:ListItem Value="Times New Roman">Times New Roman</asp:ListItem>
						 <asp:ListItem Value="Courier">Courier</asp:ListItem>
						 <asp:ListItem Value="Verdana">Verdana</asp:ListItem>
						 <asp:ListItem Value="Helvetica">Helvetica</asp:ListItem>
						 <asp:ListItem Value="Georgia">Georgia</asp:ListItem>
						 <asp:ListItem Value="Comic Sans MS">Comic Sans MS</asp:ListItem>
						 <asp:ListItem Value="Trebuchet MS">Trebuchet MS</asp:ListItem>
						 <asp:ListItem Value="Sans Serif">Sans Serif</asp:ListItem>
					 </asp:DropDownList>
														&nbsp;
						<asp:DropDownList CssClass="form-control" ID="ddlFontStyle" runat="server">
							<asp:ListItem Selected="True" Value="Regular">Regular</asp:ListItem>
							<asp:ListItem Value="Bold">Bold</asp:ListItem>
							<asp:ListItem Value="Italic">Italic</asp:ListItem>
							<asp:ListItem Value="Underline">Underline</asp:ListItem>
							<asp:ListItem Value="Strikeout">Strikeout</asp:ListItem>
						</asp:DropDownList>
														&nbsp;
					 <asp:DropDownList CssClass="form-control" ID="ddlFontSize" runat="server">
						 <asp:ListItem Selected="True" Value="8"> 8 </asp:ListItem>
						 <asp:ListItem Value="9">9</asp:ListItem>
						 <asp:ListItem Value="10">10</asp:ListItem>
						 <asp:ListItem Value="11">11</asp:ListItem>
						 <asp:ListItem Value="12">12</asp:ListItem>
						 <asp:ListItem Value="13">13</asp:ListItem>
						 <asp:ListItem Value="14">14</asp:ListItem>
						 <asp:ListItem Value="15">15</asp:ListItem>
						 <asp:ListItem Value="16">16</asp:ListItem>
						 <asp:ListItem Value="17">17</asp:ListItem>
						 <asp:ListItem Value="18">18</asp:ListItem>
						 <asp:ListItem Value="19">19</asp:ListItem>
						 <asp:ListItem Value="20">20</asp:ListItem>
					 </asp:DropDownList>
													</div>
												</div>

											</div>
											<div>
												<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
													<ProgressTemplate>
														<div>
															<img height="59px" width="59px" alt="Please wait..." src="../../img/loader.gif" />
														</div>
													</ProgressTemplate>
												</asp:UpdateProgress>
											</div>
											<p runat="server" id="pMessage"></p>
											<div class="saveas">
												<%--<em>Save as</em>
												<div class="btn-group saveformat">
													<asp:DropDownList ID="ddlTo" CssClass="btn" runat="server">
													</asp:DropDownList>
												</div>--%>
											</div>
											<div class="convertbtn">
												<asp:Button runat="server" ID="btnAddWatermark" class="btn btn-success btn-lg" Text="CONVERT NOW" OnClick="btnAddWatermark_Click" />
											</div>

										</div>
									</div>
								</asp:PlaceHolder>

								<asp:PlaceHolder ID="DownloadPlaceHolder" runat="server" Visible="false">
									<div class="filesendemail">

										<div class="filesuccess">
											<label class="dz-message needsclick"><%=Resources["WatermarkAddedSuccessMessage"]%></label>
											<span class="downloadbtn convertbtn">
												<asp:Literal ID="litDownloadNow" runat="server"></asp:Literal>
											</span>
											<div class="clearfix">&nbsp;</div>
											<a href="/" class="btn btn-link refresh-c"><%=Resources["AddWatermkinAnotherFile"]%> <i class="fa-refresh fa "></i></a>
                                            <a class="btn btn-link" target="_blank" href="https://products.groupdocs.cloud/watermark/family">Cloud API &nbsp;<i class="fa-cloud fa"></i></a>
										</div>
										<p runat="server" id="hSendDownloadLink" style="width: 65%; position: relative; margin: 50px auto 30px;"></p>
										<p><%=Resources["SendTo"]%> </p>
										<p>

											<asp:RequiredFieldValidator ID="rfvEmail" runat="server"
												ErrorMessage="*" ControlToValidate="emailTo" Display="Dynamic"
												ValidationGroup="ValidateEmail" ForeColor="Red"></asp:RequiredFieldValidator>

											<asp:RegularExpressionValidator ID="revValidateEmail"
												runat="server" Display="Dynamic"
												ValidationGroup="ValidateEmail" ControlToValidate="emailTo"
												CssClass="requiredFieldValidateStyle"
												ForeColor="Red"
												ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
											</asp:RegularExpressionValidator>

										</p>
										<div class="col-5 sendemail">
											<div class="input-group input-group-lg">
												<input type="email" id="emailTo" name="emailTo" class="form-control" placeholder="email@domain.com" runat="server" />
												<input type="hidden" id="downloadUrl" name="downloadUrl" runat="server" />
												<span class="input-group-btn">
													<asp:LinkButton class="btn btn-success" type="button" ID="btnSend" ValidationGroup="ValidateEmail" runat="server" OnClick="btnSend_Click" Text="<i class='fa fa-envelope-o fa'></i>" />
												</span>
											</div>
										</div>
										<br />
										<asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
											<ProgressTemplate>
												<div>
													<img height="59px" width="59px" alt="Please wait..." src="../../img/loader.gif" />
												</div>
											</ProgressTemplate>
										</asp:UpdateProgress>
										<p runat="server" id="pMessage2"></p>
									</div>
								</asp:PlaceHolder>


							</div>

						</div>
					</div>
				</div>
			</div>
			<div class="col-md-12 pt-5 bg-gray tc" style="padding-bottom: 0px!important;" id="dvAllFormats" runat="server">
				<div class="container">
					<div class="col-md-12 pull-left">
						<h2 class="h2title">GroupDocs.Watermark App</h2>
						<p>GroupDocs.Watermark App Supported Document Formats</p>
						<div class="diagram1 d2 d1-net">
							<div class="d1-row">
								<div class="d1-col d1-left">
									<header>Microsoft Office and Visio Formats</header>
									<ul>
										<li><strong>Word:</strong> DOC, DOCX, DOT, DOTX, DOCM, DOTM, RTF</li>
										<li><strong>Excel:</strong> XLS, XLSX, XLT, XLTX, XLSM, XLTM</li>
										<li><strong>PowerPoint:</strong> PPT, PPTX, PPS, PPSX, POTX, PPTM, PPSM, POTM</li>
										<li><strong>Visio:</strong> VSDX, VSTX, VSSX, VSDM, VSSM, VSTM, VDX, VSX, VTX</li>

									</ul>
								</div>
								<!--/left-->
								<div class="d1-col d1-right">
									<header>PDF and Image documents</header>
									<ul>
										<li><strong>Portable Document Format:</strong> PDF</li>
										<li><strong>Open Document:</strong> ODT</li>
										<li><strong>Email:</strong> EML, MSG, EMLX, OFT</li>
										<li><strong>Images:</strong> PNG, BMP, GIF, JPG, JPEG, JP2, TIF, TIFF, WebP</li>
									</ul>
								</div>
								<!--/right-->
							</div>
							<!--/row-->
							<div class="d1-logo">
								<img src="../img/groupdocs-watermark-net.png" alt=".NET Files Watermark API"><header>GroupDocs.Watermark</header>
								<footer><small>App</small></footer>
							</div>
							<!--/logo-->
						</div>
					</div>
				</div>
			</div>

			<div class="col-md-12 pull-left d-flex d-wrap bg-gray appfeaturesectionlist" id="dvFormatSection" runat="server" visible="false">
				<div class="col-md-6 cardbox tc col-md-offset-3 b6">
					<h3 runat="server" id="hExtension1"></h3>
					<p runat="server" id="hExtension1Description"></p>
				</div>
			</div>

			<!-- HowTo Section -->
			<div class="col-md-12 tl bg-darkgray howtolist">
				<div class="container tl dflex">
					<div class="col-md-4 howtosectiongfx">
						<img src="/img/howto.png">
					</div>
					<div class="howtosection col-md-8">
						<div>
							<h4><i class="fa fa-question-circle "></i>&nbsp;<b>How to add watermark in <%=fileFormat  %>document using GroupDocs Watermark App</b></h4>
							<ul>
								<li>Click inside the file drop area to upload a <%=fileFormat  %>file or drag & drop a <%=fileFormat  %>file.</li>
								<li>Add watermark text and select font, color and size.</li>
								<li>Click "Add Watermark".</li>
								<li>Download updated document with watermark added.</li>
							</ul>
						</div>
					</div>
				</div>
			</div>

			<div class="col-md-12 pt-5 app-features-section">
				<div class="container tc pt-5">
					<div class="col-md-4">
						<div class="imgcircle fasteasy">
							<img src="../../img/fast-easy.png" />
						</div>
						<h4><%= string.Format( Resources["WatermarkFeature1"], "Add Text Watermark") %></h4>
						<p><%= Resources["AddWatermarkFeature1Description"] %></p>
					</div>

					<div class="col-md-4">
						<div class="imgcircle anywhere">
							<img src="../../img/anywhere.png" />
						</div>
						<h4>Add Text Watermark from Anywhere</h4>
						<p><%= Resources["Feature2Description"] %>.</p>
					</div>

					<div class="col-md-4">
						<div class="imgcircle quality">
							<img src="../../img/quality.png" />
						</div>
						<h4><%= Resources["WatermarkFeature3"] %></h4>
						<p><%= Resources["PoweredBy"] %> <a runat="server" target="_blank" id="aPoweredBy"></a><%= Resources["Feature3Description"] %>.</p>
					</div>
				</div>
			</div>

			<script type="text/javascript">
				window.onsubmit = function () {
					if (Page_IsValid) {

						var updateProgress = $find("<%= UpdateProgress1.ClientID %>");
						if (updateProgress) {
							window.setTimeout(function () {
								updateProgress.set_visible(true);
								document.getElementById('<%= pMessage.ClientID %>').style.display = 'none';
							}, 100);
						}

						var updateProgress2 = $find("<%= UpdateProgress2.ClientID %>");
						if (updateProgress2) {
							window.setTimeout(function () {
								updateProgress2.set_visible(true);
								document.getElementById('<%= pMessage2.ClientID %>').style.display = 'none';
							}, 100);
						}
					}
				}
			</script>
			<script>
				$(document).ready(function () {
					bindEvents();
				});

				Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function (evt, args) {
					bindEvents();
				});

				function bindEvents() {
					$('.fileupload').hide();
					$('#<%= UploadFile.ClientID %>').change(function () {
						$('.fileupload').hide();
						var file = document.getElementById('<%= UploadFile.ClientID %>').files[0].name;
						$('#lblFilename').text(file);
						$('.fileupload').show();
						document.getElementById('<%= pMessage.ClientID %>').style.display = 'none';
					});

					if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {

						var swiper = new Swiper('.swiper-container', {
							slidesPerView: 5,
							spaceBetween: 20,
							// init: false,
							pagination: {
								el: '.swiper-pagination',
								clickable: true,
							},
							navigation: {
								nextEl: '.swiper-button-next',
								prevEl: '.swiper-button-prev',
							},
							breakpoints: {
								868: {
									slidesPerView: 4,
									spaceBetween: 20,
								},
								668: {
									slidesPerView: 2,
									spaceBetween: 0,
								}
							}
						});
					}
				}
			</script>
		</ContentTemplate>
		<Triggers>
			<asp:PostBackTrigger ControlID="btnAddWatermark" />
		</Triggers>
	</asp:UpdatePanel>
	<link rel="stylesheet" href="../css/colorpicker.css" type="text/css" />
	<script src="../js/colorpicker.js"></script>
</asp:Content>
