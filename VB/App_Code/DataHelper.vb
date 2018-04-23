Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Public NotInheritable Class DataHelper

    Private Sub New()
    End Sub

    Private Shared ReadOnly Property _data() As List(Of Model)
        Get
            If HttpContext.Current.Session("data") Is Nothing Then
                HttpContext.Current.Session("data") = GenerateData()
            End If

            Return DirectCast(HttpContext.Current.Session("data"), List(Of Model))
        End Get
    End Property
    Public Shared ReadOnly Property Data() As List(Of Model)
        Get
            Return _data
        End Get
    End Property
    Private Shared Function GenerateData() As List(Of Model)
        Dim list = Enumerable.Range(0, 10).Select(Function(x) New Model With { _
            .Oid = x, _
            .IsRead = If(x <> 3 AndAlso x <> 5, False, True), _
            .Title = "Title" & x, _
            .Message = "Message" & x _
        }).ToList()
        Return list
    End Function
    Public Shared Sub MakeAllUnread()
        For Each item In Data
            item.IsRead = False
        Next item
    End Sub
    Public Shared Sub MarkAsRead(ByVal ID As Integer)
        Data.Find(Function(x) x.Oid = ID).IsRead = True
    End Sub
End Class