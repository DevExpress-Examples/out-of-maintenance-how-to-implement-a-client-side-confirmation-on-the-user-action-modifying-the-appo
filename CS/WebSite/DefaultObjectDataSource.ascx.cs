using System;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxScheduler;

public partial class DefaultObjectDataSource : System.Web.UI.UserControl {
	string sessionName = "CustomEvents";

	public ObjectDataSource AppointmentDataSource { get { return objAppointmentDataSource; } }
	public string SessionName { get { return sessionName; } set { sessionName = value; } }

	protected void Page_Load(object sender, EventArgs e) {

	}
	public void AttachTo(ASPxScheduler control) {
		control.AppointmentDataSource = this.AppointmentDataSource;
		control.DataBind();
	}
	protected void appointmentsDataSource_ObjectCreated(object sender, ObjectDataSourceEventArgs e) {
		CustomEventList events = GetCustomEvents();
		e.ObjectInstance = new CustomEventDataSource(events);
	}
	protected CustomEventList GetCustomEvents() {
		CustomEventList events = Session[SessionName] as CustomEventList;
		if (events != null)
			return events;

		events = new CustomEventList();
		Session[SessionName] = events;
		return events;
	}
	public void Clear() {
		CustomEventList events = new CustomEventList();
		Session[SessionName] = events;
	}
}
