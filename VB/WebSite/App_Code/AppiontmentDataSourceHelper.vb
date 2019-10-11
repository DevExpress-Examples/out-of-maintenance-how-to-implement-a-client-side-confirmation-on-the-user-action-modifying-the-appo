Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

''' <summary>
''' Summary description for AppiontmentDataSourceHelper
''' </summary>
Public Class AppiontmentDataSourceHelper
	Public Sub New()
	End Sub

	Public Shared Function GetCustomAppointmentsList() As List(Of CustomAppointment)
		If System.Web.HttpContext.Current.Session("CustomAppointmentsList") Is Nothing Then
			Dim appts As New List(Of CustomAppointment)()
			Dim resourcesList As List(Of CustomResource) = ResourceDataSourceHelper.GetCustomResources()
			Dim uniqueID As Integer = 0
			For Each resource In resourcesList
'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
'ORIGINAL LINE: appts.Add(new CustomAppointment() { Id = uniqueID++, AllDay = false, Description = "Some Test Description", StartTime = DateTime.Now.@Date.AddHours(12 + resource.ResourceId), EndTime = DateTime.Now.@Date.AddHours(15 + resource.ResourceId), EventType = 0, Label = 2, ResourceId = resource.ResourceId, Status = 3, Subject = "Meeting" });
				appts.Add(New CustomAppointment() With {
					.Id = uniqueID,
					.AllDay = False,
					.Description = "Some Test Description",
					.StartTime = Date.Now.Date.AddHours(12 + resource.ResourceId),
					.EndTime = Date.Now.Date.AddHours(15 + resource.ResourceId),
					.EventType = 0,
					.Label = 2,
					.ResourceId = resource.ResourceId,
					.Status = 3,
					.Subject = "Meeting"
				})
				uniqueID += 1
			Next resource

			System.Web.HttpContext.Current.Session("CustomAppointmentsList") = appts
		End If
		Return TryCast(System.Web.HttpContext.Current.Session("CustomAppointmentsList"), List(Of CustomAppointment))
	End Function

	Public Shared Function InsertCustomAppointment(ByVal newCustomAppointment As CustomAppointment) As Object
		Dim CustomAppointments As List(Of CustomAppointment) = GetCustomAppointmentsList()

		Dim lastCustomAppointmentID As Integer = If(CustomAppointments.Count = 0, 0, CustomAppointments.OrderBy(Function(c) c.Id).Last().Id)
		newCustomAppointment.Id = lastCustomAppointmentID + 1

		CustomAppointments.Add(newCustomAppointment)
		Return newCustomAppointment.Id
	End Function

	Public Shared Sub DeleteCustomAppointment(ByVal deletedCustomAppointment As CustomAppointment)
		Dim CustomAppointments As List(Of CustomAppointment) = GetCustomAppointmentsList()

		Dim currentCustomAppointment As CustomAppointment = CustomAppointments.FirstOrDefault(Function(c) c.Id.Equals(deletedCustomAppointment.Id))
		If currentCustomAppointment IsNot Nothing Then
			CustomAppointments.Remove(currentCustomAppointment)
		End If
	End Sub

	Public Shared Sub UpdateCustomAppointment(ByVal updatedCustomAppointment As CustomAppointment)
		Dim CustomAppointments As List(Of CustomAppointment) = GetCustomAppointmentsList()

		Dim currentCustomAppointment As CustomAppointment = CustomAppointments.FirstOrDefault(Function(c) c.Id.Equals(updatedCustomAppointment.Id))
		currentCustomAppointment.AllDay = updatedCustomAppointment.AllDay
		currentCustomAppointment.Description = updatedCustomAppointment.Description
		currentCustomAppointment.EndTime = updatedCustomAppointment.EndTime
		currentCustomAppointment.EventType = updatedCustomAppointment.EventType
		currentCustomAppointment.Label = updatedCustomAppointment.Label
		currentCustomAppointment.Location = updatedCustomAppointment.Location
		currentCustomAppointment.RecurrenceInfo = updatedCustomAppointment.RecurrenceInfo
		currentCustomAppointment.ReminderInfo = updatedCustomAppointment.ReminderInfo
		currentCustomAppointment.ResourceId = updatedCustomAppointment.ResourceId
		currentCustomAppointment.StartTime = updatedCustomAppointment.StartTime
		currentCustomAppointment.Status = updatedCustomAppointment.Status
		currentCustomAppointment.Subject = updatedCustomAppointment.Subject
	End Sub

End Class


Public Class CustomAppointment
	Public Property StartTime() As Date
	Public Property EndTime() As Date
	Public Property Subject() As String
	Public Property Status() As Integer
	Public Property Description() As String
	Public Property Label() As Integer
	Public Property Location() As String
	Public Property AllDay() As Boolean
	Public Property EventType() As Integer
	Public Property RecurrenceInfo() As String
	Public Property ReminderInfo() As String
	Public Property Id() As Integer
	Public Property ResourceId() As Object
End Class