<!-- default file list -->
*Files to look at*:

* [CustomEvents.cs](./CS/WebSite/App_Code/CustomEvents.cs) (VB: [CustomEvents.vb](./VB/WebSite/App_Code/CustomEvents.vb))
* [CustomResources.cs](./CS/WebSite/App_Code/CustomResources.cs) (VB: [CustomResources.vb](./VB/WebSite/App_Code/CustomResources.vb))
* [DataHelper.cs](./CS/WebSite/App_Code/DataHelper.cs) (VB: [DataHelper.vb](./VB/WebSite/App_Code/DataHelper.vb))
* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [DefaultObjectDataSource.ascx](./CS/WebSite/DefaultObjectDataSource.ascx) (VB: [DefaultObjectDataSource.ascx.vb](./VB/WebSite/DefaultObjectDataSource.ascx.vb))
* [DefaultObjectDataSource.ascx.cs](./CS/WebSite/DefaultObjectDataSource.ascx.cs) (VB: [DefaultObjectDataSource.ascx.vb](./VB/WebSite/DefaultObjectDataSource.ascx.vb))
<!-- default file list end -->
# How to implement a client-side confirmation on the user action modifying the appointment


<p>This example demonstrates how drag-n-dropping and resizing appointment actions can be confirmed using client-side scripting technique. The ASPxScheduler client-side events AppointmentDrop and AppointmentResize are handled to show a dialog window  prompting the end-user to apply changes. If "OK" button is clicked, the <strong>Apply</strong> method of the ASPxClientAppointmentOperation object that is passed to the displayed popup control, is executed. Otherwise, it calls the <strong>Cancel</strong> method. The <strong>Apply</strong> method raises the callback and accomplishes the appointment modification. The Cancel method leaves the appointment intact.<br />
Note the use of the temporary property <i><strong>cpOperation</strong></i> to hold the ASPxClientAppointmentOperation object obtained in the event handler.</p>

<br/>


