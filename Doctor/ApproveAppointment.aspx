<%@ Page Title="Approve Appointment" Language="C#" MasterPageFile="~/Doctor/DoctorSite1.Master" AutoEventWireup="true" CodeBehind="ApproveAppointment.aspx.cs" Inherits="DoctorAppointmentScheduling.Doctor.ApproveAppointment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- ======= Breadcrumbs Section ======= -->
    <section class="breadcrumbs">
        <div class="container">
            <div class="d-flex justify-content-between align-items-center">
                <h2></h2>
                <ol>
                    <li><a href="doctorhome.aspx">Home</a></li>
                    <li>Appoinement Page</li>
                </ol>
            </div>

        </div>
    </section>
    <!-- End Breadcrumbs Section -->

     <div class="container-fluid">
        <div class="row">
            <div class="col-sm-12">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <ajaxToolkit:TabContainer ID="TabContainer1" runat="server">
                    <ajaxToolkit:TabPanel ID="TabPanel1" runat="server">
                        <HeaderTemplate>
                            <div style="float: left; font-size: 15px;">
                                <p>Approved Appointment</p>
                            </div>
                        </HeaderTemplate>
                        <ContentTemplate>
                            <h3 class="alert alert-success">Approved Appointment </h3>
                            

                            <div class="container" id="rptdDIV" runat="server" visible="false">

                                <div class="row">
                                    <div class="table-responsive">
                                        

                                    </div>
                                </div>

                            </div>

                            <div class="container-fluid">
                                <div class="row">
                                    <div class="col-sm-12">                                       
                                        <table>
                                            <tr>
                                                <td>SearchBy:<asp:TextBox ID="txtFilterGrid1Record" CssClass="form-control" runat="server" placeholder="Search...." onkeyup="Search_Gridview(this)"></asp:TextBox></td>
                                                
                                                
                                            </tr>

                                        </table>
                                        <hr />

                                        <asp:GridView ID="GridView1" CssClass="table table-hover" AutoGenerateColumns="false"
                                            runat="server" EmptyDataText="Record Not Found..." DataKeyNames="ID" OnPageIndexChanging="GridView1_PageIndexChanging"
                                            OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowCommand="GridView1_RowCommand"
                                            OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDataBound="GridView1_RowDataBound"
                                            AllowPaging="True" PageSize="50" PagerSettings-Mode="Numeric" PagerSettings-NextPageText="&gt;" Font-Size="8pt">
                                            <Columns>

                                                <asp:TemplateField HeaderText="#">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="AppDate" HeaderText="AppDate" ReadOnly="true" ItemStyle-Width="150px" />
                                                
                                                <asp:BoundField DataField="AppTime" HeaderText="AppTime" ReadOnly="true" DataFormatString = "{0:hh:mm tt}"  /> 
                                                
                                                <asp:BoundField DataField="DocName" HeaderText="Doctor" ReadOnly="true" />
                                                
                                                <asp:BoundField DataField="PatName" HeaderText="PatName" ReadOnly="true" />
                                                
                                                <asp:BoundField DataField="AboutDisease" HeaderText="AboutDisease" ReadOnly="true" />                                               


                                                <asp:TemplateField HeaderText="Remarks">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGV1ApDocRemarks" runat="server" Text='<%# Eval("DocRemarks")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtEditApDocRemarks" CssClass=" " runat="server" Text='<%# Eval("DocRemarks")%>' Style="text-transform: uppercase" TextMode="MultiLine"></asp:TextBox>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>


                                                <asp:TemplateField HeaderText="Status">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGV1ApStatus" runat="server" Text='<%# Eval("AppStatus")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblEditGV1ApStatus" runat="server" Text='<%# Eval("AppStatusID")%>' Visible="false"></asp:Label>
                                                        <asp:DropDownList ID="ddlGV1ApStatus" CssClass="" runat="server">                                                            
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>


                                                <asp:TemplateField HeaderText="Action">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkstatus" class="table-link text-success" CommandArgument='<%#Eval("ID") %>' CommandName="approved" OnClick="lnkstatus_Click" Text="" ToolTip="Approval Status" runat="server" OnClientClick="return confirm('Do you want to approve?');">                                                                           
                                                                            <span class="fa-stack">
                                                                                <i class="fa fa-square fa-stack-2x"> </i>
                                                                                <i class="fa fa-check fa-stack-1x fa-inverse "></i>
                                                                                
                                                                            </span>                                                                      
                                                        </asp:LinkButton>

                                                        <asp:LinkButton ID="lnkEdit" class="table-link text-primary" runat="server" CommandArgument='<%#Eval("ID") %>' CommandName="edit" OnClick="lnkEdit_Click" ToolTip="Add Remarks">                                                                            
                                                                            <span class="fa-stack">
                                                                                <i class="fa fa-square fa-stack-2x"></i>
                                                                                <i class="fa fa-pencil fa-stack-1x fa-inverse"></i>
                                                                            </span>
                                                        </asp:LinkButton>

                                                        <%--<asp:LinkButton ID="lnkDelete" class="table-link text-danger" CommandArgument='<%#Eval("ID") %>' CommandName="delete" OnClick="lnkDelete_Click" Text="" ToolTip="View Remarks" runat="server" OnClientClick="return confirm('Do you want to delete this row?');">                                                                           
                                                                            <span class="fa-stack">
                                                                                <i class="fa fa-square fa-stack-2x"> </i>
                                                                                <i class="fa fa-trash fa-stack-1x fa-inverse "></i>
                                                                                
                                                                            </span>                                                                      
                                                        </asp:LinkButton>--%>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:ImageButton ID="imgbtnUpdate" CommandName="Update" runat="server" ImageUrl="~/assets/img/updated.png" ToolTip="Update" Height="32px" Width="32px" />
                                                        <asp:ImageButton ID="imgbtnCancel" runat="server" CommandName="Cancel" ImageUrl="~/assets/img/cancel.png" ToolTip="Cancel" Height="32px" Width="32px" />
                                                    </EditItemTemplate>

                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>

                                    </div>

                                </div>

                            </div>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    




                </ajaxToolkit:TabContainer>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function Search_Gridview(strKey) {
            var strData = strKey.value.toLowerCase().split(" ");
            var tblData = document.getElementById("<%=GridView1.ClientID %>");
            var rowData;
            for (var i = 1; i < tblData.rows.length; i++) {
                rowData = tblData.rows[i].innerHTML;
                var styleDisplay = 'none';
                for (var j = 0; j < strData.length; j++) {
                    if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                        styleDisplay = '';
                    else {
                        styleDisplay = 'none';
                        break;
                    }
                }
                tblData.rows[i].style.display = styleDisplay;
            }
        }
    </script>
</asp:Content>
