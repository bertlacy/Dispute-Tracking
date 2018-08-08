<%@ Page Title="Add new step" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="AddStep.aspx.cs" Inherits="DisputeTracking.AddStep" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript" src="Scripts/jobs/jobs.js"></script>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <i class="material-icons" style="font-size: 24px;">playlist_add</i>&nbsp;<span class="page-header">Add New Step</span>
    <span style="float: right; margin-right: 15px; background-color: #fefefe; border-radius: 8px; padding: 8px; box-shadow: 2px 2px 2px gray; border-left: 5px solid #8dc63f; opacity: 0.9;">
        &nbsp;<i class="material-icons" style="font-size: 24px;">announcement</i>
        &nbsp;&nbsp;Click <b>Save</b> to add this <b>Step</b> to your Script.  You can <b>add more</b> by coming back to this page.
    </span>
    
    <asp:Table ID="tableJob" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="lblDescription" Text="Description"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="txtDescription" Width="300" TabIndex="1"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="lblStepType" Text="Type"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList runat="server" ID="dropListStepTypes" TabIndex="2"></asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="lblCommand" Text="Command"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="txtCommand" Width="700" TabIndex="3"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell BorderColor="White">
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Right" BorderColor="White">
                <asp:Button runat="server" ID="btnAddStep" Text=" Add " OnClick="btnAddStep_Click" Font-Bold="True" TabIndex="4" />&nbsp;&nbsp;
                <asp:Button runat="server" ID="btnCancel" Text="Cancel" OnClick="btnCancel_Click" TabIndex="5" CssClass="cancel-button" />
                <br />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <br />
</asp:Content>
