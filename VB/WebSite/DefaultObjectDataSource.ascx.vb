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

        Dim events_Renamed As CustomEventList = GetCustomEvents()
        e.ObjectInstance = New CustomEventDataSource(events_Renamed)
    End Sub
    Protected Function GetCustomEvents() As CustomEventList

        Dim events_Renamed As CustomEventList = TryCast(Session(SessionName), CustomEventList)
        If events_Renamed IsNot Nothing Then
            Return events_Renamed
        End If

        events_Renamed = New CustomEventList()
        Session(SessionName) = events_Renamed
        Return events_Renamed
    End Function
    Public Sub Clear()

        Dim events_Renamed As New CustomEventList()
        Session(SessionName) = events_Renamed
    End Sub
End Class
