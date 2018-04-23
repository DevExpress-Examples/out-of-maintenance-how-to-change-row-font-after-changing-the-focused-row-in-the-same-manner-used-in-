Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo

Public Class MyObject
	Inherits XPObject
	Public Sub New()
		MyBase.New()
	End Sub

	Public Sub New(ByVal session As Session)
		MyBase.New(session)
	End Sub

	Public Overrides Sub AfterConstruction()
		MyBase.AfterConstruction()
	End Sub

	Protected _Title As String
	Public Property Title() As String
		Get
			Return _Title
		End Get
		Set(ByVal value As String)
			SetPropertyValue(Of String)("Title", _Title, value)
		End Set
	End Property

	Protected _Message As String
	Public Property Message() As String
		Get
			Return _Message
		End Get
		Set(ByVal value As String)
			SetPropertyValue(Of String)("Message", _Message, value)
		End Set
	End Property

	Private _IsRead As Boolean
	Public Property IsRead() As Boolean
		Get
			Return _IsRead
		End Get
		Set(ByVal value As Boolean)
			SetPropertyValue("IsRead", _IsRead, value)
		End Set
	End Property
End Class

