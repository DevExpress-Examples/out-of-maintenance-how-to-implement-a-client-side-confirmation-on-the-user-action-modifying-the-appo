Imports Microsoft.VisualBasic
Imports System
Imports System.Data.OleDb
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.XtraScheduler
Imports DevExpress.Web.ASPxScheduler
Imports DevExpress.Web.ASPxScheduler.Internal

''' <summary>
''' Summary description for DataHelper
''' </summary>
Public NotInheritable Class DataHelper
	Private Sub New()
	End Sub
	Public Shared Sub SetupDefaultMappings(ByVal control As ASPxScheduler)
		SetupDefaultMappingsSiteMode(control)

	End Sub
	'
	Public Shared Sub SetupCustomEventsMappings(ByVal control As ASPxScheduler)
		SetupDefaultMappingsSiteMode(control)
	End Sub
	Private Shared Sub SetupDefaultMappingsSiteMode(ByVal control As ASPxScheduler)
		Dim storage As ASPxSchedulerStorage = control.Storage
		storage.BeginUpdate()
		Try
			Dim resourceMappings As ASPxResourceMappingInfo = storage.Resources.Mappings
			resourceMappings.ResourceId = "Id"
			resourceMappings.Caption = "Caption"

			Dim appointmentMappings As ASPxAppointmentMappingInfo = storage.Appointments.Mappings
			appointmentMappings.AppointmentId = "Id"
			appointmentMappings.Start = "StartTime"
			appointmentMappings.End = "EndTime"
			appointmentMappings.Subject = "Subject"
			appointmentMappings.AllDay = "AllDay"
			appointmentMappings.Description = "Description"
			appointmentMappings.Label = "Label"
			appointmentMappings.Location = "Location"
			appointmentMappings.RecurrenceInfo = "RecurrenceInfo"
			appointmentMappings.ReminderInfo = "ReminderInfo"
			appointmentMappings.ResourceId = "OwnerId"
			appointmentMappings.Status = "Status"
			appointmentMappings.Type = "EventType"
		Finally
			storage.EndUpdate()
		End Try
	End Sub
	Public Shared Sub ProvideRowInsertion(ByVal control As ASPxScheduler, ByVal dataSource As DataSourceControl)
		Dim objectDataSource As ObjectDataSource = TryCast(dataSource, ObjectDataSource)
		If objectDataSource IsNot Nothing Then
			Dim provider As New ObjectDataSourceRowInsertionProvider()
			provider.ProvideRowInsertion(control, objectDataSource)
		End If
	End Sub
End Class
Public Class ObjectDataSourceRowInsertionProvider

	Public Sub ProvideRowInsertion(ByVal control As ASPxScheduler, ByVal dataSource As ObjectDataSource)
		AddHandler control.AppointmentInserting, AddressOf ControlOnAppointmentInserting
	End Sub
	Protected Sub ControlOnAppointmentInserting(ByVal sender As Object, ByVal e As PersistentObjectCancelEventArgs)
		Dim storage As ASPxSchedulerStorage = CType(sender, ASPxSchedulerStorage)
		Dim apt As Appointment = CType(e.Object, Appointment)
		storage.SetAppointmentId(apt, "a" & apt.GetHashCode())
	End Sub
End Class

