<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallback" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How to change row font after changing the focused row in the same manner used in Outlook</title>
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
                EnableRowsCache="false" KeyFieldName="Oid" OnHtmlRowPrepared="grid_HtmlRowPrepared"
                OnCustomCallback="grid_CustomCallback" OnFocusedRowChanged="grid_FocusedRowChanged" >
				<SettingsDataSecurity AllowDelete="false" AllowEdit="false" AllowInsert="false"/>
				<SettingsBehavior AllowSort="false" ProcessFocusedRowChangedOnServer="true" AllowFocusedRow="true"/>
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
                <SettingsLoadingPanel Mode="Disabled" />
            </dx:ASPxGridView>
        </div>
    </form>
</body>
</html>
