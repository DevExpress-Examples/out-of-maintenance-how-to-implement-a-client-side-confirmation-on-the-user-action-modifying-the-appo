<%@ Control Language="vb" AutoEventWireup="true" CodeFile="DefaultObjectDataSource.ascx.vb" Inherits="DefaultObjectDataSource" %>
<asp:ObjectDataSource ID="objAppointmentDataSource" runat="server" DataObjectTypeName="CustomEvent" DeleteMethod="DeleteMethodHandler" SelectMethod="SelectMethodHandler" TypeName="CustomEventDataSource" InsertMethod="InsertMethodHandler" OnObjectCreated="appointmentsDataSource_ObjectCreated" UpdateMethod="UpdateMethodHandler">
</asp:ObjectDataSource>