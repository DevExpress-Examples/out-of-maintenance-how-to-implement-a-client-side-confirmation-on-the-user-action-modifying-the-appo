<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128547077/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1534)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
<!-- default file list end -->
# How to implement a client-side confirmation on the user action modifying the appointment
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e1534/)**
<!-- run online end -->


<p>This example demonstrates how drag-n-dropping and resizing appointment actions can be confirmed using client-side scripting technique. The ASPxScheduler client-side events AppointmentDrop and AppointmentResize are handled to show a dialog window  prompting the end-user to apply changes. If "OK" button is clicked, the <strong>Apply</strong> method of the ASPxClientAppointmentOperation object that is passed to the displayed popup control, is executed. Otherwise, it calls the <strong>Cancel</strong> method. The <strong>Apply</strong> method raises the callback and accomplishes the appointment modification. The Cancel method leaves the appointment intact.<br />
Note the use of the temporary property <i><strong>cpOperation</strong></i> to hold the ASPxClientAppointmentOperation object obtained in the event handler.</p>

<br/>


