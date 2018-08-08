<%@ Page Title="Edit Script" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="EditJob.aspx.cs" Inherits="DisputeTracking.EditJob" %>

<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript" src="Scripts/jobs/jobs.js"></script>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <i class="material-icons" style="font-size: 24px;">build</i>&nbsp;<span class="page-header">Edit Script</span>
    <span style="float: right; margin-right: 15px; background-color: #fefefe; border-radius: 8px; padding: 10px; box-shadow: 3px 3px 3px #c3c3c3; border-left: 5px solid #7fbf3f;"><i class="material-icons" style="font-size: 24px;">announcement</i>&nbsp;&nbsp;Did you know that you can add <b>multiple steps</b> to each Script by clicking <b>Add Step</b> below?</span>
    <asp:Table ID="tableJob" runat="server" BorderStyle="none" GridLines="none">
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
                <asp:DropDownList runat="server" ID="dropListScheduleTypes" OnInit="dropListScheduleTypes_Init" CssClass="ScheduleType"></asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
            </asp:TableCell>
            <asp:TableCell ID="WeekDaysPanel">
                <asp:Label runat="server" ID="lblOccurs" Text="Occurs every day"></asp:Label>
                <asp:Panel runat="server" ID="panelWeekDays" ToolTip="Select the days for the Script to run">
                  <asp:CheckBoxList runat="server" ID="chkWeekDays">
                    <asp:ListItem Text="Monday" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Tuesday" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Wednesday" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Thursday" Value="4"></asp:ListItem>
                    <asp:ListItem Text="Friday" Value="5"></asp:ListItem>
                    <asp:ListItem Text="Saturday" Value="6"></asp:ListItem>
                    <asp:ListItem Text="Sunday" Value="7"></asp:ListItem>
                  </asp:CheckBoxList>
                </asp:Panel>
                <br />
                <asp:Label runat="server" ID="lblAt" Text="at"></asp:Label>
                <MKB:TimeSelector ID="timeOccurs" runat="server" SelectedTimeFormat="TwentyFour">
                </MKB:TimeSelector>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell BorderColor="White">
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Right" BorderColor="White">
                <asp:Button ID="btnEdit" runat="server" Text=" Save " OnClick="btnEdit_Click" Font-Bold="True" />&nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" PostBackUrl="~/Default.aspx" CssClass="cancel-button" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

<i class="material-icons" style="font-size: 32px;">playlist_play</i>&nbsp;<span class="page-header">Steps in Script</span>
    <asp:GridView ID="gridSteps" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" EnableModelValidation="True" ForeColor="#333333" 
            GridLines="None" Width="100%">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ID" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="description" HeaderText="DESCRIPTION" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="type" HeaderText="TYPE" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="command" HeaderText="COMMAND TO RUN" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="exec_order" HeaderText="EXECUTION ORDER" ItemStyle-HorizontalAlign="Center" />
            <asp:TemplateField HeaderText="ACTIONS" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Button ID="btnEdit" runat="server" onclick="btnEdit_Click1" Text=" Edit " CssClass="edit-buttons" />&nbsp;
                    <asp:Button ID="btnRemove" runat="server" onclick="btnRemove_Click" Text="Remove" CssClass="remove-button" OnClientClick="return confirm('Are you sure you want to remove this step?')" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    </asp:GridView>
    <br />
    <asp:Button runat="server" ID="btnAddStep" Text="Add Step" OnClick="btnAddStep_Click" Font-Bold="True" ToolTip="Click here to add multiple steps to this Script." />
    <br />
    <br />
</asp:Content>
