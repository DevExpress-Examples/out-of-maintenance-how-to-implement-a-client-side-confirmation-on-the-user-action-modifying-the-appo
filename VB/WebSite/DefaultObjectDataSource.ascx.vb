Imports Microsoft.VisualBasic
Imports System
Imports System.Web.UI.WebControls
Imports DevExpress.Web.ASPxScheduler

Partial Public Class DefaultObjectDataSource
	Inherits System.Web.UI.UserControl
	Private sessionName_Renamed As String = "CustomEvents"

	Public ReadOnly Property AppointmentDataSource() As ObjectDataSource
		Get
			Return objAppointmentDataSource
		End Get
	End Property
	Public Property SessionName() As String
		Get
			Return sessionName_Renamed
		End Get
		Set(ByVal value As String)
			sessionName_Renamed = value
		End Set
	End Property

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Public Sub AttachTo(ByVal control As ASPxScheduler)
		control.AppointmentDataSource = Me.AppointmentDataSource
		control.DataBind()
	End Sub
	Protected Sub appointmentsDataSource_ObjectCreated(ByVal sender As Object, ByVal e As ObjectDataSourceEventArgs)
		Dim events As CustomEventList = GetCustomEvents()
		e.ObjectInstance = New CustomEventDataSource(events)
	End Sub
	Protected Function GetCustomEvents() As CustomEventList
		Dim events As CustomEventList = TryCast(Session(SessionName), CustomEventList)
		If events IsNot Nothing Then
			Return events
		End If

		events = New CustomEventList()
		Session(SessionName) = events
		Return events
	End Function
	Public Sub Clear()
		Dim events As New CustomEventList()
		Session(SessionName) = events
	End Sub
End Class
