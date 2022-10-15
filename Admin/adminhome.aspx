<%@ Page Title="Home" Language="C#" MasterPageFile="~/Admin/AdminSite1.Master" AutoEventWireup="true" CodeBehind="adminhome.aspx.cs" Inherits="DoctorAppointmentScheduling.Admin.adminhome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- ======= Breadcrumbs Section ======= -->
    <section class="breadcrumbs">
        <div class="container">

            <div class="d-flex justify-content-between align-items-center">
                <h2></h2>
                <ol>
                    <li><a href="adminhome.aspx">Home</a></li>
                    <li>Admin</li>
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
                                <p>Appointment</p>
                            </div>
                        </HeaderTemplate>
                        <ContentTemplate>
                            <h3 class="alert alert-success">Appointments List </h3>

                            <div class="container" id="rptdDIV" runat="server" visible="false">

                                <div class="row">
                                    <div class="table-responsive">
                                        <h5>All Patients List</h5>
                                        <hr />
                                        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                            <HeaderTemplate>
                                                <table class="table table-bordered user-list" style="text-align: center; font-size: smaller">
                                                    <thead class=" alert-info">
                                                        <tr>
                                                            <th><span>#</span></th>
                                                            <th><span>Date</span></th>
                                                            <th><span>Time</span></th>
                                                            <th><span>Doctor</span></th>
                                                            <th><span>Patient</span></th>
                                                            <th><span>Patient Email</span></th>
                                                            <th><span>Disease Desc</span></th>
                                                            <th><span>Remarks</span></th>
                                                            <th><span>Status</span></th>


                                                            <th>&nbsp;Action</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                            </HeaderTemplate>
                                            <ItemTemplate>

                                                <tr>
                                                    <td><%#Eval("ID") %>  </td>
                                                    <td><%#Eval("AppDate") %> </td>
                                                    <td><%#Eval("AppTime") %> </td>
                                                    <td><%#Eval("DocName") %> </td>

                                                    <td><%#Eval("PatName") %>  </td>
                                                    <td><%#Eval("PatEmail") %>  </td>
                                                    <td><%#Eval("AboutDisease") %>  </td>
                                                    <td><%#Eval("DocRemarks") %>  </td>
                                                    <td><%#Eval("AppStatus") %>  </td>



                                                    <td style="width: 10%;">

                                                        <asp:LinkButton ID="lnkstatus" class="table-link text-success" CommandArgument='<%#Eval("ID") %>' CommandName="approved" Text="" ToolTip="Approval Status" runat="server" OnClientClick="return confirm('Do you want to approve?');">                                                                           
                                                                            <span class="fa-stack">
                                                                                <i class="fa fa-square fa-stack-2x"> </i>
                                                                                <i class="fa fa-check fa-stack-1x fa-inverse "></i>
                                                                                
                                                                            </span>                                                                      
                                                        </asp:LinkButton>

                                                        <asp:LinkButton ID="lnkEdit" class="table-link text-primary" runat="server" CommandArgument='<%#Eval("ID") %>' CommandName="edit" ToolTip="Add Remarks">                                                                            
                                                                            <span class="fa-stack">
                                                                                <i class="fa fa-square fa-stack-2x"></i>
                                                                                <i class="fa fa-pencil fa-stack-1x fa-inverse"></i>
                                                                            </span>
                                                        </asp:LinkButton>

                                                        <asp:LinkButton ID="lnkDelete" class="table-link text-danger" CommandArgument='<%#Eval("ID") %>' CommandName="delete" Text="" ToolTip="View Remarks" runat="server" OnClientClick="return confirm('Do you want to delete this row?');">                                                                           
                                                                            <span class="fa-stack">
                                                                                <i class="fa fa-square fa-stack-2x"> </i>
                                                                                <i class="fa fa-trash fa-stack-1x fa-inverse "></i>
                                                                                
                                                                            </span>                                                                      
                                                        </asp:LinkButton>



                                                    </td>
                                                </tr>

                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </tbody>
                                                        </table>
                                            </FooterTemplate>
                                        </asp:Repeater>

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

                                                <%-- <asp:TemplateField HeaderText="AppDate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGV1ApDate" runat="server" Text='<%# Eval("AppDate")%>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEditApDate" CssClass="#" runat="server" Text='<%# Eval("AppDate")%>'
                                                Style="text-transform: uppercase"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>--%>
                                                <asp:BoundField DataField="AppTime" HeaderText="AppTime" ReadOnly="true" DataFormatString = "{0:hh:mm tt}"  /> 
                                                <%--<asp:TemplateField HeaderText="AppTime">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGV1ApTime" runat="server" Text='<%# Eval("AppTime")%>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEditApTime" CssClass="#" runat="server" Text='<%# Eval("AppTime")%>'
                                                Style="text-transform: uppercase"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>--%>
                                                <asp:BoundField DataField="DocName" HeaderText="Doctor" ReadOnly="true" />
                                                <%--<asp:TemplateField HeaderText="Doctor">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGV1ApDoctor" runat="server" Text='<%# Eval("DocName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEditApDoctor" CssClass="#" runat="server" Text='<%# Eval("DocName")%>'
                                                Style="text-transform: uppercase"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>--%>
                                                <asp:BoundField DataField="PatName" HeaderText="PatName" ReadOnly="true" />

                                                <%--<asp:TemplateField HeaderText="Patient">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGV1ApPatient" runat="server" Text='<%# Eval("PatName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEditApPatient" CssClass=" " runat="server" Text='<%# Eval("PatName")%>'
                                                Style="text-transform: uppercase"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>--%>
                                                <asp:BoundField DataField="AboutDisease" HeaderText="AboutDisease" ReadOnly="true" />

                                                <%--<asp:TemplateField HeaderText="AboutDisease">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGV1ApAboutDisease" runat="server" Text='<%# Eval("AboutDisease")%>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEditApAboutDisease" CssClass=" " runat="server" Text='<%# Eval("AboutDisease")%>'
                                                Style="text-transform: uppercase"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>--%>


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





                                                <%--<asp:TemplateField HeaderText="Batch">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGV1Batch" runat="server" Text='<%# Eval("Batch")%>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lblEditGV1BatchID" runat="server" Text='<%# Eval("BatchID")%>' Visible="false"></asp:Label>
                                            <asp:DropDownList ID="ddlGV1Batch" CssClass="" runat="server">
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                    </asp:TemplateField>--%>


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

                                                        <asp:LinkButton ID="lnkDelete" class="table-link text-danger" CommandArgument='<%#Eval("ID") %>' CommandName="delete" OnClick="lnkDelete_Click" Text="" ToolTip="View Remarks" runat="server" OnClientClick="return confirm('Do you want to delete this row?');">                                                                           
                                                                            <span class="fa-stack">
                                                                                <i class="fa fa-square fa-stack-2x"> </i>
                                                                                <i class="fa fa-trash fa-stack-1x fa-inverse "></i>
                                                                                
                                                                            </span>                                                                      
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:ImageButton ID="imgbtnUpdate" CommandName="Update" runat="server" ImageUrl="~/assets/img/updated.png" ToolTip="Update" Height="32px" Width="32px" />
                                                        <asp:ImageButton ID="imgbtnCancel" runat="server" CommandName="Cancel" ImageUrl="~/assets/img/cancel.png" ToolTip="Cancel" Height="32px" Width="32px" />
                                                    </EditItemTemplate>

                                                </asp:TemplateField>





                                                <%--<asp:CommandField ShowEditButton="True" ControlStyle-CssClass="btn btn-sm btn-primary" />
                                    <asp:CommandField ShowDeleteButton="true" ButtonType="Button" ControlStyle-CssClass="btn btn-danger btn-sm" />--%>
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
