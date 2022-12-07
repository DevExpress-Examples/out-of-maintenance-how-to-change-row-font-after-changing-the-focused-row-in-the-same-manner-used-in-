Option Infer On

Imports System
Imports DevExpress.Web
Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            Session.Clear()
        End If

        grid.DataSource = DataHelper.Data
        grid.DataBind()
    End Sub

    Protected Sub grid_HtmlRowPrepared(ByVal sender As Object, ByVal e As ASPxGridViewTableRowEventArgs)
        Dim isRead As Boolean = Convert.ToBoolean(grid.GetRowValues(e.VisibleIndex, "IsRead"))
        e.Row.Font.Bold = Not isRead
    End Sub
    Protected Sub grid_CustomCallback(ByVal sender As Object, ByVal e As ASPxGridViewCustomCallbackEventArgs)
        If e.Parameters = "Unread" Then
            DataHelper.MakeAllUnread()
        End If
    End Sub
    Protected Sub grid_FocusedRowChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim index = If(grid.FocusedRowIndex <> -1, grid.FocusedRowIndex, 0)

        Dim id_Renamed = Convert.ToInt32(grid.GetRowValues(index, "Oid"))
        DataHelper.MarkAsRead(id_Renamed)
    End Sub
End Class
