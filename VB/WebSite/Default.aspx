<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Xpo.v10.1.Web, Version=10.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Xpo" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxCallback" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>How to change row font after changing the focused row in the same manner used in Outlook</title>

	<script type="text/javascript">
		function OnFocusedRowChanged(s, e) {       
			e.processOnServer = true;
		}
	</script>

</head>
<body>
	<form id="form1" runat="server">
		<div>
			<dx:ASPxButton ID="ASPxButton1" runat="server" Text="Mark All Messages Unread" AutoPostBack="False">
				<ClientSideEvents Click="function(s, e) {
					grid.PerformCallback('Unread');
				}" />
			</dx:ASPxButton>
			<dx:ASPxGridView ID="grid" ClientInstanceName="grid" runat="server" AutoGenerateColumns="False"
				EnableRowsCache="false" DataSourceID="xpoDS" KeyFieldName="Oid" OnHtmlRowPrepared="grid_HtmlRowPrepared"
				OnCustomCallback="grid_CustomCallback" OnFocusedRowChanged="grid_FocusedRowChanged">
				<Columns>
					<dx:GridViewDataTextColumn FieldName="Oid" ReadOnly="True" VisibleIndex="0" SortIndex="0"
						SortOrder="Ascending">
					</dx:GridViewDataTextColumn>
					<dx:GridViewDataTextColumn FieldName="Title" VisibleIndex="1">
					</dx:GridViewDataTextColumn>
					<dx:GridViewDataTextColumn FieldName="Message" VisibleIndex="2">
					</dx:GridViewDataTextColumn>
					<dx:GridViewDataCheckColumn FieldName="IsRead" VisibleIndex="3" Visible="false">
					</dx:GridViewDataCheckColumn>
				</Columns>
				<SettingsBehavior AllowFocusedRow="True" />
				<ClientSideEvents FocusedRowChanged="OnFocusedRowChanged" />
				<SettingsLoadingPanel Mode="Disabled" />
			</dx:ASPxGridView>
			<dx:XpoDataSource ID="xpoDS" runat="server" TypeName="MyObject">
			</dx:XpoDataSource>
		</div>
	</form>
</body>
</html>