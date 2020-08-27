<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v15.2" Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>
<%@ Register Assembly="DevExpress.XtraScheduler.v15.2.Core, Version=15.2.20.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraScheduler" TagPrefix="cc1" %>
<%@ Register Assembly="DevExpress.Web.v15.2" Namespace="DevExpress.Web" TagPrefix="dxe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <script type="text/javascript">
        function onAppointmentDrop(s, e) {
            e.handled = true;
            scheduler.cpOperation = e.operation;
            confirmAppointmentDragDialog.Show();
        }
        function onBtnOkClick(s, e) {
            confirmAppointmentDragDialog.Hide();
            scheduler.cpOperation.Apply();
        }
        function onBtnCancelClick(s, e) {
            confirmAppointmentDragDialog.Hide();
            scheduler.cpOperation.Cancel();
        }
        function onAppointmentResize(s, e) {
            e.handled = true;
            scheduler.cpOperation = e.operation;
            confirmAppointmentDragDialog.Show();
        }
    </script>

    <form id="form1" runat="server">
        <div>
            <dxwschs:ASPxScheduler ID="scheduler" runat="server" GroupType="Resource" ClientInstanceName="scheduler"
                AppointmentDataSourceID="objectDataSourceAppointments" ResourceDataSourceID="objectDataSourceResources">
                <ClientSideEvents AppointmentDrop="onAppointmentDrop" AppointmentResize="onAppointmentResize"></ClientSideEvents>
                <Storage>
                    <Appointments AutoRetrieveId="true">
                        <Mappings AppointmentId="Id" Start="StartTime" End="EndTime" Subject="Subject" AllDay="AllDay"
                            Description="Description" Label="Label" Location="Location" RecurrenceInfo="RecurrenceInfo"
                            ReminderInfo="ReminderInfo" Status="Status" Type="EventType" ResourceId="ResourceId" />
                    </Appointments>
                    <Resources ColorSaving="Color">
                        <Mappings ResourceId="ResourceId" Caption="Caption" Color="Color" />
                    </Resources>
                </Storage>
                <Views>
                    <DayView Enabled="true" ShowWorkTimeOnly="true"></DayView>
                    <WeekView Enabled="false"></WeekView>
                    <WorkWeekView Enabled="false"></WorkWeekView>
                    <FullWeekView Enabled="false"></FullWeekView>
                    <MonthView Enabled="false"></MonthView>
                    <TimelineView Enabled="true"></TimelineView>
                </Views>
            </dxwschs:ASPxScheduler>
            <dxe:ASPxPopupControl ID="ASPxPopupControl1" runat="server" ClientInstanceName="confirmAppointmentDragDialog" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" HeaderText="Confirmation dialog" Modal="true" CloseAction="None" ShowCloseButton="false">
                <ContentCollection>
                    <dxe:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                        <dxe:ASPxLabel runat="server" ID="label1" Text="Are you sure?"></dxe:ASPxLabel>
                        <br />
                        <br />
                        <table>
                            <tr>
                                <td>
                                    <dxe:ASPxButton ID="ASPxButton1" runat="server" Text="Yes" Width="79px" AutoPostBack="false">
                                        <ClientSideEvents Click="function(s,e) { onBtnOkClick(); }" />
                                    </dxe:ASPxButton>
                                </td>
                                <td>
                                    <dxe:ASPxButton ID="ASPxButton2" runat="server" Text="No" Width="79px" AutoPostBack="false">
                                        <ClientSideEvents Click="function(s,e) { onBtnCancelClick(); }" />
                                    </dxe:ASPxButton>
                                </td>
                            </tr>
                        </table>
                    </dxe:PopupControlContentControl>
                </ContentCollection>
            </dxe:ASPxPopupControl>
            <asp:ObjectDataSource runat="server" ID="objectDataSourceAppointments" DataObjectTypeName="CustomAppointment"
                DeleteMethod="DeleteCustomAppointment"
                InsertMethod="InsertCustomAppointment"
                SelectMethod="GetCustomAppointmentsList" TypeName="AppiontmentDataSourceHelper" UpdateMethod="UpdateCustomAppointment" />
            <asp:ObjectDataSource runat="server" ID="objectDataSourceResources" 
                SelectMethod="GetCustomResources" TypeName="ResourceDataSourceHelper" />

        </div>
    </form>
</body>
</html>