using System;
using System.Data.OleDb;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.XtraScheduler;
using DevExpress.Web.ASPxScheduler;
using DevExpress.Web.ASPxScheduler.Internal;

/// <summary>
/// Summary description for DataHelper
/// </summary>
public static class DataHelper {
	public static void SetupDefaultMappings(ASPxScheduler control) {
		SetupDefaultMappingsSiteMode(control);

	}
	//
	public static void SetupCustomEventsMappings(ASPxScheduler control) {
		SetupDefaultMappingsSiteMode(control);
	}
	private static void SetupDefaultMappingsSiteMode(ASPxScheduler control) {
		ASPxSchedulerStorage storage = control.Storage;
		storage.BeginUpdate();
		try {
			ASPxResourceMappingInfo resourceMappings = storage.Resources.Mappings;
			resourceMappings.ResourceId = "Id";
			resourceMappings.Caption = "Caption";

			ASPxAppointmentMappingInfo appointmentMappings = storage.Appointments.Mappings;
			appointmentMappings.AppointmentId = "Id";
			appointmentMappings.Start = "StartTime";
			appointmentMappings.End = "EndTime";
			appointmentMappings.Subject = "Subject";
			appointmentMappings.AllDay = "AllDay";
			appointmentMappings.Description = "Description";
			appointmentMappings.Label = "Label";
			appointmentMappings.Location = "Location";
			appointmentMappings.RecurrenceInfo = "RecurrenceInfo";
			appointmentMappings.ReminderInfo = "ReminderInfo";
			appointmentMappings.ResourceId = "OwnerId";
			appointmentMappings.Status = "Status";
			appointmentMappings.Type = "EventType";
		}
		finally {
			storage.EndUpdate();
		}
	}
	public static void ProvideRowInsertion(ASPxScheduler control, DataSourceControl dataSource) {
		ObjectDataSource objectDataSource = dataSource as ObjectDataSource;
		if (objectDataSource != null) {
			ObjectDataSourceRowInsertionProvider provider = new ObjectDataSourceRowInsertionProvider();
			provider.ProvideRowInsertion(control, objectDataSource);
		}
	}
}
public class ObjectDataSourceRowInsertionProvider {

	public void ProvideRowInsertion(ASPxScheduler control, ObjectDataSource dataSource) {
		control.AppointmentInserting += new PersistentObjectCancelEventHandler(ControlOnAppointmentInserting);		
	}
	protected void ControlOnAppointmentInserting(object sender, PersistentObjectCancelEventArgs e) {
		ASPxSchedulerStorage storage = (ASPxSchedulerStorage)sender;
		Appointment apt = (Appointment)e.Object;
		storage.SetAppointmentId(apt, "a" + apt.GetHashCode());
	}	
}

