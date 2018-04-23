<%@ Page Language="vb" AutoEventWireup="true"  CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v15.2" Namespace="DevExpress.Web.ASPxScheduler"
    TagPrefix="dxwschs" %>
<%@ Register Assembly="DevExpress.XtraScheduler.v15.2.Core, Version=15.2.0.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4"
    Namespace="DevExpress.XtraScheduler" TagPrefix="cc1" %>
<%@ Register Src="~/DefaultObjectDataSource.ascx" TagName="ObjectDataSource" TagPrefix="demo" %>
<%@ Register Assembly="DevExpress.Web.v15.2" Namespace="DevExpress.Web"
    TagPrefix="dxpc" %>
<%@ Register Assembly="DevExpress.Web.v15.2" Namespace="DevExpress.Web"    TagPrefix="dxe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <demo:ObjectDataSource runat="server" ID="objectDataSource" SessionName="test" />
        <dxwschs:ASPxScheduler ID="ASPxScheduler1" runat="server" ClientInstanceName="scheduler">
            <ClientSideEvents AppointmentDrop="function(s,e) { OnAppointmentDrop(s, e); }" AppointmentResize="function(s,e) { OnAppointmentResize(s, e); }"></ClientSideEvents>
        </dxwschs:ASPxScheduler>
        <dxpc:ASPxPopupControl ID="ASPxPopupControl1" runat="server" ClientInstanceName="confirmAppointmentDragDialog" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" HeaderText="Confirmation dialog" Modal="true" CloseAction="None" ShowCloseButton="false">
        <ContentCollection>
            <dxpc:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                <dxe:ASPxLabel runat="server" ID="label1" Text="Are you sure?"></dxe:ASPxLabel>
                <br />
                <br />
                <table>
                    <tr>           
                        <td>
                            <dxe:ASPxButton ID="ASPxButton1" runat="server" Text="Yes" Width="79px" AutoPostBack="false">
                                <ClientSideEvents Click="function(s,e) { OnBtnOkClick(); }" />
                            </dxe:ASPxButton>
                        </td>
                        <td>
                            <dxe:ASPxButton ID="ASPxButton2" runat="server" Text="No" Width="79px" AutoPostBack="false">
                                <ClientSideEvents Click="function(s,e) { OnBtnCancelClick(); }" />
                            </dxe:ASPxButton>
                        </td>
                    </tr>   
                </table>
            </dxpc:PopupControlContentControl>
        </ContentCollection>
    </dxpc:ASPxPopupControl>
        <script type="text/javascript">
        function OnAppointmentDrop(s, e) {
            e.handled = true;
            scheduler.cpOperation = e.operation;
            confirmAppointmentDragDialog.Show();
        }
        function OnBtnOkClick(s, e) {
            confirmAppointmentDragDialog.Hide();
            scheduler.cpOperation.Apply();
        }
        function OnBtnCancelClick(s, e) {
            confirmAppointmentDragDialog.Hide();
            scheduler.cpOperation.Cancel();
        }
        function OnAppointmentResize(s, e) {
            e.handled = true;
            scheduler.cpOperation = e.operation;
            confirmAppointmentDragDialog.Show();
        }
    </script>
    </div>
    </form>
</body>
</html>