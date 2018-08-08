<%@ Page Title="Edit step" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="EditStep.aspx.cs" Inherits="DisputeTracking.EditStep" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript" src="Scripts/jobs/jobs.js"></script>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <i class="material-icons" style="font-size: 24px;">build</i>&nbsp;<span class="page-header">Edit Step</span>
    <asp:Table ID="tableJob" runat="server">
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
                <asp:Label runat="server" ID="lblStepType" Text="Type"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList runat="server" ID="dropListStepTypes"></asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="lblCommand" Text="Command"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="txtCommand" Width="700"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell BorderColor="White">
            </asp:TableCell>
        <asp:TableCell HorizontalAlign="Right" BorderColor="White">
            <asp:Button runat="server" ID="btnEditStep" Text=" Save " OnClick="btnEditStep_Click" />&nbsp;&nbsp;
            <asp:Button runat="server" ID="btnCancel" Text="Cancel" OnClick="btnCancel_Click" CssClass="cancel-button" />
        </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <br />
</asp:Content>
