Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Web.ASPxCallback
Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Xpo

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Private session As Session = XpoHelper.GetNewSession()

	Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
		xpoDS.Session = session
	End Sub

	Protected Sub grid_HtmlRowPrepared(ByVal sender As Object, ByVal e As ASPxGridViewTableRowEventArgs)
		Dim isRead As Boolean = Convert.ToBoolean(grid.GetRowValues(e.VisibleIndex, "IsRead"))
		e.Row.Font.Bold = Not isRead
	End Sub
	Protected Sub grid_CustomCallback(ByVal sender As Object, ByVal e As ASPxGridViewCustomCallbackEventArgs)
		If e.Parameters = "Unread" Then
			Dim obj As MyObject = Nothing
			For i As Integer = 0 To grid.VisibleRowCount - 1
				obj = TryCast(grid.GetRow(i), MyObject)
				obj.IsRead = False
				obj.Save()
			Next i

		End If
	End Sub
	Protected Sub grid_FocusedRowChanged(ByVal sender As Object, ByVal e As EventArgs)
		Dim obj As MyObject = Nothing
		If grid.FocusedRowIndex = -1 Then
			obj = TryCast(grid.GetRow(0), MyObject)
		Else
			obj = TryCast(grid.GetRow(grid.FocusedRowIndex), MyObject)
		End If

		obj.IsRead = True
		obj.Save()
	End Sub
End Class
