<%@ Page Title="Create Script" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="CreateJob.aspx.cs" Inherits="DisputeTracking.CreateJob" %>

<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript" src="Scripts/jobs/jobs.js"></script>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <i class="material-icons" style="font-size: 24px;">playlist_add</i>&nbsp;<span class="page-header">Create Script</span>
    <span style="float: right; margin-right: 15px; background-color: #fefefe; border-radius: 8px; padding: 8px; box-shadow: 2px 2px 2px gray; border-left: 5px solid #8dc63f; opacity: 0.9;">&nbsp;<i class="material-icons" style="font-size: 24px;">announcement</i>&nbsp;&nbsp;Give your Script a <b>description</b> and a <b>schedule</b>, you will be able to <b>Add Steps</b> later.</span>
    <asp:Table ID="tableJob" runat="server" BorderStyle="None" GridLines="None">
    <asp:TableRow>
    <asp:TableCell>
        <asp:Label runat="server" ID="lblDescription" Text="Description"></asp:Label>
    </asp:TableCell>
    <asp:TableCell>
        <asp:TextBox runat="server" ID="txtDescription" Width="300"></asp:TextBox>
    </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
    <asp:TableCell>
        <asp:Label runat="server" ID="lblSheduleType" Text="Schedule type"></asp:Label>
    </asp:TableCell>
    <asp:TableCell>
        <asp:DropDownList runat="server" ID="dropListScheduleTypes"></asp:DropDownList>
   </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
    <asp:TableCell>
    </asp:TableCell>
    <asp:TableCell>
        <asp:Label runat="server" ID="lblOccurs" Text="Occurs every day "></asp:Label>
        <asp:Panel runat="server" ID="panelWeekDays" Style="display: none">
          <asp:CheckBoxList runat="server" ID="chkWeekDays">
            <asp:ListItem Text=" Monday" Value="1"></asp:ListItem>
            <asp:ListItem Text=" Tuesday" Value="2"></asp:ListItem>
            <asp:ListItem Text=" Wednesday" Value="3"></asp:ListItem>
            <asp:ListItem Text=" Thursday" Value="4"></asp:ListItem>
            <asp:ListItem Text=" Friday" Value="5"></asp:ListItem>
            <asp:ListItem Text=" Saturday" Value="6"></asp:ListItem>
            <asp:ListItem Text=" Sunday" Value="7"></asp:ListItem>
          </asp:CheckBoxList>
        </asp:Panel>
        <br />
        <asp:Label runat="server" ID="lblAt" Text="at"></asp:Label> <MKB:TimeSelector ID="timeOccurs" runat="server" SelectedTimeFormat="TwentyFour"></MKB:TimeSelector>
    </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
    <asp:TableCell BorderColor="White">
    </asp:TableCell>
    <asp:TableCell HorizontalAlign="Right" BorderColor="White">
      <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click" Font-Bold="True" />&nbsp;&nbsp;
      <asp:Button ID="btnCancel" runat="server" Text="Cancel" PostBackUrl="~/Default.aspx" CssClass="cancel-button" />
    </asp:TableCell>
    </asp:TableRow>
    </asp:Table>
    <br />
    <br />
</asp:Content>
