<%@ Page Title="Dispute Tracking Tool" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DisputeTracking._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
   
   <!-- LightBox -->
	<link href="lightbox/src/css/lightbox.css" rel="stylesheet" type="text/css" />

</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="SearchContainer" style="width: 100%;">
        <%--<div class="welcome-box">
            <span class="page-header">&nbsp;&nbsp;&nbsp;Welcome Robert</span>
            <p>
                &nbsp;<b>&bull;</b>&nbsp;With this tool you can...&nbsp;&nbsp;For help on how to use this tool, 
                click <a id="myBtn" style="cursor: pointer;">here</a>.
            </p>
            <br />
        </div>--%>
        
        <div style="background-color: transparent; padding: 2px; box-shadow: 3px 3px 9px rgba(0,0,0,0.3); ">

            <i class="material-icons" style="font-size: 32px;">search</i>&nbsp;<span class="page-header">Enter Search Criteria</span>

            <div style="float: right; margin-right: 50px; margin-top: 5px;" title="Select the type of records to display...">

                <i class="material-icons" style="font-size: 28px; vertical-align: bottom;">touch_app</i>

                <span style="box-shadow: none;">
                    <asp:RadioButton id="rbIn" runat="server" GroupName="region" ForeColor="#66FF66" OnCheckedChanged="rbIn_CheckedChanged" AutoPostBack="true" Checked="True" CssClass="radio-buttons rbOrder"></asp:RadioButton>
                    Order Level&nbsp;
                    <asp:RadioButton id="rbOut" ForeColor="#66FF66" runat="server" GroupName="region" AutoPostBack="true" OnCheckedChanged="rbOut_CheckedChanged" CssClass="radio-buttons rbAccount"></asp:RadioButton>
                    &nbsp;Account Level
                </span>
            </div>
                
            <center>
                <!-- DATE PICKERS -->
                <%--<asp:Calendar runat="server" ID="DatePickerSubmit" Visible="false" OnSelectionChanged="DatePickerSubmit_SelectionChanged" />
                <asp:Calendar runat="server" ID="DatePickerInstall" Visible="false" OnSelectionChanged="DatePickerInstall_SelectionChanged" />
                <asp:Calendar runat="server" ID="DatePickerSale" Visible="false" OnSelectionChanged="DatePickerSale_SelectionChanged" />--%>
            </center>

            <asp:Panel ID="OrderUpdatePanel" runat="server" Visible="true">
              
                    <table id="tableOrderLevel" class="tableOrderLevel">
                        <tr>
                            <td style="white-space:nowrap; vertical-align:top;"><asp:Label runat="server" ID="lblOrder" Text="ORDER" class="search-labels" />&nbsp;<asp:TextBox ID="tbOrder" runat="server" CssClass="search-boxes right new-textbox" Text=""></asp:TextBox></td>
                            <td style="white-space:nowrap; vertical-align:top;"><asp:Label runat="server" ID="lblBANBTN" Text="BAN/BTN" class="search-labels" />&nbsp;<asp:TextBox ID="tbBANBTN" runat="server" CssClass="search-boxes right  new-textbox" Text=""></asp:TextBox></td>
                        </tr>                              
                        <tr>                               
                            <td style="white-space:nowrap; vertical-align:top;"><asp:Label runat="server" ID="lblCustomerName" Text="CUSTOMER NAME" class="search-labels" />&nbsp;<asp:TextBox ID="tbCustomerName" runat="server" CssClass="search-boxes right new-textbox" Text=""></asp:TextBox></td>
                            <td style="white-space:nowrap; vertical-align:top;"><asp:Label runat="server" ID="lblDisputeID" Text="DISPUTE LINE ID" class="search-labels" />&nbsp;<asp:TextBox ID="tbDisputeID" runat="server" CssClass="search-boxes right new-textbox" Text=""></asp:TextBox></td>
                        </tr>
                
                        <tr>
                            <td style="white-space:nowrap; vertical-align:top;"><asp:Label runat="server" ID="lblPartnerID" Text="PARTNER ID" class="search-labels" />&nbsp;<asp:DropDownList ID="PartnerDropDown" runat="server" CssClass="drop-downs partner-id" Width="150px"></asp:DropDownList></td>
                            <td style="white-space:nowrap; vertical-align:top;"><asp:Label runat="server" ID="lblPartnerName" Text="PARTNER NAME" class="search-labels" />&nbsp;<asp:DropDownList ID="PartnerNameDropDown" runat="server" CssClass="drop-downs" Width="150px"></asp:DropDownList></td>
                            <td style="white-space:nowrap; vertical-align:top;"><asp:Label runat="server" ID="lblOwnerID" Text="ANALYST" class="search-labels" />&nbsp;<asp:DropDownList ID="OwnerDropDown" runat="server" CssClass="drop-downs" Width="175px"></asp:DropDownList></td>
                            <td style="white-space:nowrap; vertical-align:top;"><asp:Label runat="server" ID="lblStatusDD" Text="STATUS" class="search-labels" />&nbsp;<asp:DropDownList ID="StatusDropDown" runat="server" CssClass="drop-downs" Width="75px"></asp:DropDownList></td>
                        </tr>
                    </table>
              
            </asp:Panel>

            <asp:Panel ID="AccountUpdatePanel" runat="server">
               
                    <table id="tableAccountLevel" class="tableAccountLevel">
                        <tr>
                            <td style="white-space:nowrap; vertical-align:top;"><asp:Label runat="server" ID="lblAccount" Text="ACCOUNT" class="search-labels" />&nbsp;<asp:TextBox ID="tbAccount" runat="server" CssClass="search-boxes right new-textbox" Text=""></asp:TextBox></td>
                            <td style="white-space:nowrap; vertical-align:top;"><asp:Label runat="server" ID="lblCustomerNameAcct" Text="CUSTOMER NAME" class="search-labels" />&nbsp;<asp:TextBox ID="tbCustomerNameAcct" runat="server" CssClass="search-boxes right new-textbox" Text=""></asp:TextBox></td>
                            <td style="white-space:nowrap; vertical-align:top;"><asp:Label runat="server" ID="lblDisputeIDAcct" Text="DISPUTE LINE ID" class="search-labels" />&nbsp;<asp:TextBox ID="tbDisputeIDAcct" runat="server" CssClass="search-boxes right new-textbox" Text=""></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="white-space:nowrap; vertical-align:top;"><asp:Label runat="server" ID="lblSubmitDateAcct" Text="SUBMIT DATE" class="search-labels" />&nbsp;<asp:TextBox ID="tbSubmitDateAcct" runat="server" CssClass="search-boxes right new-textbox" Text="" ToolTip="Date Format: YYYY-MM-DD or YYYY-MM-DD|YYYY-MM-DD"></asp:TextBox></td>
                            <td style="white-space:nowrap; vertical-align:top;"><asp:Label runat="server" ID="lblSaleDateAcct" Text="SALE DATE" class="search-labels" />&nbsp;<asp:TextBox ID="tbSaleDateAcct" runat="server" CssClass="search-boxes right new-textbox" Text="" ToolTip="Date Format: YYYY-MM-DD or YYYY-MM-DD|YYYY-MM-DD"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="white-space:nowrap; vertical-align:top;"><asp:Label runat="server" ID="lblPartnerIDDDAcct" Text="PARTNER ID" class="search-labels" />&nbsp;<asp:DropDownList ID="DDPartnerIDAcct" runat="server" CssClass="drop-downs partner-id" Width="150px"></asp:DropDownList></td>
                            <td style="white-space:nowrap; vertical-align:top;"><asp:Label runat="server" ID="lblPartnerNameDDAcct" Text="PARTNER NAME" class="search-labels" />&nbsp;<asp:DropDownList ID="DDPartnerNameAcct" runat="server" CssClass="drop-downs" Width="150px"></asp:DropDownList></td>
                            <td style="white-space:nowrap; vertical-align:top;"><asp:Label runat="server" ID="lblOwnerIDDDAcct" Text="ANALYST" class="search-labels" />&nbsp;<asp:DropDownList ID="DDOwnerIDAcct" runat="server" CssClass="drop-downs" Width="175px"></asp:DropDownList></td>
                            <td style="white-space:nowrap; vertical-align:top;"><asp:Label runat="server" ID="lblStatusDDAcct" Text="STATUS" class="search-labels" />&nbsp;<asp:DropDownList ID="DDStatusAcct" runat="server" CssClass="drop-downs" Width="75px"></asp:DropDownList></td>
                        </tr>
                    </table>
                
            </asp:Panel>
            

        </div>
        <br />
        <asp:Button ID="btnSearch" CssClass="search-button" runat="server" Text=" Search " OnClick="btnSearch_Click" PostBackUrl="" TabIndex="1" />&nbsp;&nbsp;<asp:Button ID="btnCancel" runat="server" Text=" Clear " OnClick="btnClear_Click" PostBackUrl="~/Default.aspx" TabIndex="2" CssClass="cancel-button" /><asp:Button ID="btnRefresh" runat="server" Text=" Refresh " OnClick="btnRefresh_Click" TabIndex="3" CssClass="run-button right" />
        <center><asp:Label ID="ErrorMessage" runat="server" Text="" CssClass="error-message" Font-Bold="True" /></center>
        
        <asp:Panel ID="GridPanel" Visible="false" runat="server">

            <div style="margin-top: -20px;">
            
                <center><span class="page-header">Search Count </span><asp:Label ID="lblSearchCount" runat="server" Text="" CssClass="search-count" Font-Bold="True" /></center>

                <i class="material-icons" style="font-size: 32px;">playlist_play</i>&nbsp;<span class="page-header" style="margin-bottom: 10px;">Search Result</span>

                <div style="box-shadow: 3px 3px 9px rgba(0,0,0,0.3);">
                    <asp:GridView ID="DisputesGrid" runat="server" CssClass="disputes-grid CellPadding="4" EnableModelValidation="True" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Width="100%" HeaderStyle-Wrap="false" AllowPaging="False" AllowSorting="True" Font-Size="8pt">
                        <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="DISPUTE ACTIONS" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Button ID="btnEdit" runat="server" Text="EDIT" CssClass="edit-button" onclick="btnEdit_Click" />
                                        <asp:Button ID="Button1" runat="server" Text="VIEW" CssClass="edit-button" onclick="btnEdit_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Dispute_Ref_ID" HeaderText="ID" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="id-border" />
                                <asp:BoundField DataField="SO_NO" HeaderText="ORDER" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="AccountID" HeaderText="ACCOUNT ID" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="PartnerID" HeaderText="PARTNER ID" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="Partner_Name" HeaderText="PARTNER NAME" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="Customer_Name" HeaderText="CUSTOMER NAME" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="Accounttype_Comp" HeaderText="TYPE" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="Status" HeaderText="STATUS" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="SubmitDT" HeaderText="SUBMIT DT" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:d}" />
                                <%--<asp:BoundField DataField="Days_Open" HeaderText="AGE" ItemStyle-HorizontalAlign="Center" />--%>
                                <asp:BoundField DataField="DisputeDesc" HeaderText="DISPUTE DESCRIPTION" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="Comment" HeaderText="COMMENT" ItemStyle-HorizontalAlign="Left" />
                            </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                </div>
            </div>
        </asp:Panel>

        <center>
            <br />
            <!-- Open Dashboard -->
            View this Levels <a id="opener" class="dashboard-link" style="cursor: pointer;">stats</a>.&nbsp;&nbsp;For advanced search tips &amp; help on how to use this tool, click <a id="myBtn" style="cursor: pointer;">here</a>.  
            <br />
            <asp:Label ID="TestLabel" runat="server" Text="" ForeColor="IndianRed" CssClass="test-message" />
        </center>

        <!-- Help File Modal -->
        <div id="myModal" class="modal">

          <!-- Modal content -->
            <div class="modal-content">
                <div class="modal-header">
                  <span class="close">&times;</span>
                    <h1>
                        <span style="text-shadow: 3px 1px 2px #333; margin-bottom: 10px; font-size: 1.5em; color: #fff; font-family: 'Google Sans', Cursive; font-weight: 500;">&nbsp;Dispute&nbsp;Tracking&nbsp;Tool&nbsp;&bull;&nbsp;Help File&nbsp;</span>
                        
                    </h1>
                </div>
                <div class="modal-body">
                    <i class="material-icons" style="font-size: 32px; margin-top: 10px; position: absolute;">school</i><h2 style="margin-left: 40px;">How to use this tool</h2>
                    <div  style="background-color: transparent; padding: 2px; box-shadow: 3px 3px 9px rgba(0,0,0,0.3); margin-right: 10px;">
                        <p>The Dispute Tracking Tool provides the end user with the ability to <b>Search</b>, <b>View</b> and <b>Edit</b> existing Disputes.  To get started, select either <b>Order Level</b> or <b>Account Level</b> records to view 
                            and then enter <b>at least one value</b> to Search on.  Once the results are displayed, you can click on either <b>Edit</b> or <b>View</b> to update and/or view the selected Disputes attributes.
                        </p>
                        <p><b>TIP - </b>multiple Search values can be entered by seperating each value with a <b>pipe delimeter</b> '|'.  If used in a field, like 'Order' or 'Account', the application will 
                            return search results for each value seperated by the pipe delimeter.  If used on a field designated as a date, like 'Submit Date', the application will convert the dates to 
                            a 'BETWEEN' SQL statement.  So, '1/1/2018|1/31/2018' will be converted to 'BETWEEN 1/1/2018 AND 1/31/2018'.  More detailed examples with screen shots can be found below: 
                        </p>
                    </div>
                    <br />

                    <a class="accordion" style="font-weight: bold; text-transform: uppercase;">Example - Basic Search</a>
                    <div class="panel">
                        <%--<a class="code-copy-click" onclick="copyFunction('p1')" onmouseout="copiedFunction()"><i class="material-icons code-copy" style="font-size: 12px; float: right; margin-right: 10px; margin-top: 10px;">file_copy</i></a>--%>
                        <p id="p1">
                            To perform a basic search, just enter or select a value from one of the drop-downs and hit enter, like below:
                            <asp:Image runat="server" CssClass="basic-search-image" ImageUrl="~/Help/BasicSearch.jpg" ImageAlign="Middle" />
                            <a href="~/Help/BasicSearch.jpg" data-lightbox="~/Help/BasicSearch.jpg"><img class="zoom" src="~/Help/BasicSearchThumb.jpg" style="border-radius: 5px; box-shadow: 2px 2px 6px white; margin: 5px;" /></a>
                        </p>
                    </div>
                    <br />

                    <a class="accordion" style="font-weight: bold; text-transform: uppercase;">Example - Search with Multiple Values (Pipe Delimited)</a>
                    <div class="panel">
                        <%--<a class="code-copy-click" onclick="copyFunction()" onmouseout="copiedFunction()"><i class="material-icons code-copy" style="font-size: 12px; float: right; margin-right: 10px; margin-top: 10px;">file_copy</i></a>--%>
                        <p id="p2">
                            <%--<code id="code2" class="sql">Database.Schema.Stored_Procedure_Name <span style="color: #2abfea;">@parameter</span> = <span style="color: #880000;">'Parameter Value'</span></code>--%>
                        </p>
                    </div>
                    <br />

                    <a class="accordion" style="font-weight: bold; text-transform: uppercase;">Example - Search with Multiple Date Values (Pipe Delimited)</a>
                    <div class="panel">
                        <%--<a class="code-copy-click" onclick="copyFunction()" onmouseout="copiedFunction()"><i class="material-icons code-copy" style="font-size: 12px; float: right; margin-right: 10px; margin-top: 10px;">file_copy</i></a>--%>
                        <p id="p4">
                            <%--<code id="code4" class="sql" style="overflow: auto;"><b>EXEC</b> msdb.dbo.sp_send_dbmail <span style="color: #2abfea;">@recipients</span> = <span style="color: #880000;">'robert.lacy@centurylink.com'</span>, <span style="color: #2abfea;">@subject</span> = <span style="color: #880000;">'Script Complete'</span>, <span style="color: #2abfea;">@body</span> = <span style="color: #880000;">'The Example Script has Completed Successfully!'</span></code>--%>
                        </p>
                    </div>
                    <br />

                    <a class="accordion" style="font-weight: bold; text-transform: uppercase;">Example - Bulk Update</a>
                    <div class="panel">
                        <%--<a class="code-copy-click" onclick="copyFunction()" onmouseout="copiedFunction()"><i class="material-icons code-copy" style="font-size: 12px; float: right; margin-right: 10px; margin-top: 10px;">file_copy</i></a>--%>
                        <p id="p3">
                            <%--<code id="code2" class="sql">Database.Schema.Stored_Procedure_Name <span style="color: #2abfea;">@parameter</span> = <span style="color: #880000;">'Parameter Value'</span></code>--%>
                        </p>
                    </div>
                    <br />
                    <br />

                </div>
                <br /><br />
                <div class="modal-footer">
                    <center>
                        <b style="text-shadow: 1px 1px 1px rgba(0, 0, 0, 0.5); font-family: 'Google Sans', 'Helvetica Neue', Arial, Cursive;">CONFIDENTIAL</b>
                    </center>
                </div>
            </div>
        </div>
        <br />

        <!-- Quick Analysis -->
        <div id="dialog" title="Quick Analysis" style="color: #757575; font-family: 'Google Sans'; background-color: #fff; width: 500px;">
            <p>Displaying current Dispute counts for selected Level going back seven months from today...</p>
            <i class="material-icons" style="font-size: 45px; margin-top: 10px; position: absolute;">insert_chart</i>
            <center>
                <table id="QuickAnalysis" style="box-shadow: 3px 3px 9px rgba(0,0,0,0.2); padding: 4px; width: 98%;">
                    <tr>
                        <td style="font-weight: 100; font-family: 'Google Sans', Cursive; font-size: 24px; text-align: center;">&nbsp;OPEN&nbsp;</td><td style="font-weight: 100; font-family: 'Google Sans', Cursive; font-size: 24px; text-align: center;">CLOSED</td>
                    </tr>
                    <tr>
                        <td><center><asp:Label ID="lblDaysOpen" runat="server" CssClass="days-open" /></center></td><td><center><asp:Label ID="lblDaysClosed" runat="server" CssClass="days-closed" /></center></td>
                    </tr>
                    <tr></tr>
                    <tr>
                        <td style="font-size: 14px; text-align: right; padding-left: 2px;"><span style="font-size: 14px; font-family: 'Google Sans', cursive;">Oldest Dispute in day's =  </span></td><td><asp:Label ID="lblMaxDaysOpen" runat="server" CssClass="max-days" /></td>
                    </tr>
                </table>
            </center>
        </div>
        
    </div>

    <div id="stop" class="scrollTop" title="Beam me up">
        <i class="material-icons myScroller" style="font-size: 32px;">expand_less</i>
    </div>

    <!-- Snackbar Success Message -->
    <div id="snackbar">Successfully Updated Dispute!</div>

    <!-- Snackbar (jQuery) -->
    <script type="text/javascript">
        function ShowSnackbar() 
        {
            var x = document.getElementById("snackbar");
            x.className = "show";

            setTimeout(function () { x.className = x.className.replace("show", ""); }, 3500);
        }
    </script>

    <!-- Help File Modal -->
    <script type="text/javascript">
        var modal = document.getElementById('myModal');
        var btn = document.getElementById("myBtn");
        var span = document.getElementsByClassName("close")[0];

        btn.onclick = function () 
        {
            modal.style.display = "block";
        }

        // X Click
        span.onclick = function () 
        {
            //modal.style.display = "none";
            $(modal).fadeOut(800);
        }

        window.onclick = function (event) 
        {
            if (event.target == modal) 
            {
                //modal.style.display = "none";
                $(modal).fadeOut(800);
            }
        }
    </script>

    <!-- Help File Examples -->
    <script type="text/javascript">
        var acc = document.getElementsByClassName("accordion");
        var i;

        for (i = 0; i < acc.length; i++) 
        {
            acc[i].addEventListener("click", function () 
            {
                this.classList.toggle("active");
                var panel = this.nextElementSibling;
                
                if (panel.style.maxHeight) 
                {
                    panel.style.maxHeight = null;
                }
                else 
                {
                    panel.style.maxHeight = panel.scrollHeight + "px";
                }
            });
        }
    </script>

    <!-- jQuery to show Dashboard -->
    <script type="text/javascript">
        $(function () 
        {
             $("#dialog").dialog({
                 autoOpen: false,
                 show: {
                     effect: "blind",
                     duration: 600
                 },
                 hide: {
                     effect: "explode",
                     duration: 300
                 }
             });

             $("#opener").on("click", function () 
             {
                 $("#dialog").dialog("open");
             });
        });
    </script>

    <script type="text/javascript">
        $(document).ready(function () 
        {
          /******************************
              BOTTOM SCROLL TOP BUTTON
           ******************************/

          // declare variable
          var scrollTop = $(".scrollTop");

          $(window).scroll(function () 
          {
            // declare variable
            var topPos = $(this).scrollTop();

            // if user scrolls down - show scroll to top button
               if (topPos > 150) 
               {
                 $(scrollTop).css("opacity", "1");
               }
               else 
               {
                 $(scrollTop).css("opacity", "0");
               }

          }); // scroll END

          //Click event to scroll to top
         $(scrollTop).click(function () 
          {
            $('html, body').animate({
              scrollTop: 5
            }, 400);
            return false;

          }); // click() scroll top EMD

         

        }); // ready() END

    </script>
</asp:Content>
