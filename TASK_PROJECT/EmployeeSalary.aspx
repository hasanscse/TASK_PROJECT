<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeSalary.aspx.cs" Inherits="TASK_PROJECT.EmployeeSalary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        $(function () {
            $('#MainContent_txtDateOfBirth').datetimepicker();
        });
    </script>

    <script src="Scripts/WebForms/WebUIValidation.js"></script>


    <script>
        function LikeBtnClick() {
            var salary, HomeRent, OtherRent, ExtraAmount;


            salary = $("#MainContent_txtSalary").val();
            HomeRent = $("#MainContent_txtHomeRent").val();
            OtherRent = $("#MainContent_txtOtherRent").val();


            ExtraAmount = HomeRent + OtherRent;       


            if (salary == '') {
                alert("Salary Can not be null!");
                document.getElementById("MainContent_txtFirstName").style.border = "2px solid Black";
                $("#MainContent_txtSalary").focus();
                return false;
            }

            if (HomeRent == '') {
                alert("HomeRent Can not be null!");
                document.getElementById("MainContent_txtHomeRent").style.border = "2px solid Black";
                $("#MainContent_txtHomeRent").focus();
                return false;
            }

            if (OtherRent == '') {
                alert("Other Rent Can not be null!");
                document.getElementById("MainContent_txtOtherRent").style.border = "2px solid Black";
                $("#MainContent_txtOtherRent").focus();
                return false;
            }

            //if (ExtraAmount > salary) {

            //    alert("Sum of Home Rent and Other Rent Can not be Greater-than Basic Salary!");
            //    document.getElementById("MainContent_txtHomeRent").style.border = "2px solid Black";
            //    document.getElementById("MainContent_txtOtherRent").style.border = "2px solid Black";
            //    $("#MainContent_txtOtherRent").focus();
            //    return false;


            //}

            else {
                document.getElementById("MainContent_txtOtherRent").style.border = "2px solid white";
                document.getElementById("MainContent_txtHomeRent").style.border = "2px solid white";
                document.getElementById("MainContent_txtFirstName").style.border = "2px solid white";
            }



        }
    </script>

    <div class="jumbotron text-center">
        <div class="container">
            <div class="page-header">

                <div class="panel-primary">
                    <div class="panel-heading">
                        <h3><b>Employee Salary</b></h3>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <div class="panel panel-primary">
                        <div class="panel-body">
                            <div class="text-right">

                                <div class="row">
                                    <div class="col-md-3">
                                        <div class="input-group">
                                            <div class="col">
                                                <asp:TextBox ID="txtEMPLOYEEID" Visible="False" class="form-control" runat="server">                               
                                                </asp:TextBox>
                                            </div>


                                            <div class="col">
                                                <label class="col-sm-2 control-label">Employee</label>
                                                <asp:DropDownList ID="cmbEmployee" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbEmployee_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>

                                        </div>
                                        <!-- /.input-group -->
                                    </div>
                                    <!-- /.col-md-6 -->
                                    <div class="col-md-6">
                                        <div class="input-group">
                                            <div class="col">

                                                <label class="col-sm-1 control-label">Salary</label>
                                                <asp:TextBox ID="txtSalary" placeholder="Salary" class="form-control" ReadOnly="True" TextMode="Number" runat="server">                               
                                                </asp:TextBox>

                                            </div>

                                        </div>
                                        <!-- /.input-group -->
                                    </div>
                                    <!-- /.col-md-6 -->



                                    <div class="col-md-3">
                                        <div class="input-group">
                                            <div class="col">

                                                <label class="col-sm-1 control-label">
                                                </label>
                                                <asp:TextBox ID="txtName" placeholder="Name" Visible="false" class="form-control" ReadOnly="True" runat="server">                               
                                                </asp:TextBox>

                                            </div>

                                        </div>
                                        <!-- /.input-group -->
                                    </div>


                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <div class="input-group">

                                            <div class="col">
                                                <label class="col-sm-5 control-label">Month</label>
                                                <asp:DropDownList ID="cmbMonth" class="form-control" runat="server" AutoPostBack="true">
                                                    <asp:ListItem Text="January" Value="January"> </asp:ListItem>
                                                    <asp:ListItem Text="February" Value="February"> </asp:ListItem>
                                                    <asp:ListItem Text="March" Value="March"> </asp:ListItem>
                                                    <asp:ListItem Text="April" Value="April"> </asp:ListItem>
                                                    <asp:ListItem Text="May" Value="May"> </asp:ListItem>
                                                    <asp:ListItem Text="June" Value="June"> </asp:ListItem>
                                                    <asp:ListItem Text="July" Value="July"> </asp:ListItem>
                                                    <asp:ListItem Text="August" Value="August"> </asp:ListItem>
                                                    <asp:ListItem Text="September" Value="September"> </asp:ListItem>
                                                    <asp:ListItem Text="October" Value="October"> </asp:ListItem>
                                                    <asp:ListItem Text="November" Value="November"> </asp:ListItem>
                                                    <asp:ListItem Text="December" Value="December"> </asp:ListItem>
                                                </asp:DropDownList>
                                            </div>



                                        </div>
                                        <!-- /.input-group -->
                                    </div>
                                    <div class="col-md-6">
                                        <div class="input-group">

                                            <div class="col">
                                                <label class="col-sm-5 control-label">Year</label>
                                                <asp:DropDownList ID="cmbYear" class="form-control" runat="server" AutoPostBack="true">
                                                    <asp:ListItem Text="2024" Value="2024"> </asp:ListItem>
                                                    <asp:ListItem Text="2025" Value="2025"> </asp:ListItem>
                                                    <asp:ListItem Text="2026" Value="2026"> </asp:ListItem>
                                                    <asp:ListItem Text="2027" Value="2027"> </asp:ListItem>
                                                </asp:DropDownList>

                                            </div>



                                        </div>
                                        <!-- /.input-group -->
                                    </div>

                                </div>


                                <div class="row">
                                    <div class="col-md-3">


                                        <div class="input-group">
                                            <div class="col">

                                                <label class="col-sm-1 control-label">HomeRent</label>
                                                <asp:TextBox ID="txtHomeRent" placeholder="Home Rent" class="form-control" TextMode="Number" runat="server">                               
                                                </asp:TextBox>

                                            </div>

                                        </div>



                                        <!-- /.input-group -->
                                    </div>
                                    <div class="col-md-6">
                                        <div class="input-group">
                                            <div class="col">

                                                <label class="col-sm-1 control-label">OtherRent</label>
                                                <asp:TextBox ID="txtOtherRent" placeholder="OtherRent" class="form-control" TextMode="Number" runat="server">                               
                                                </asp:TextBox>

                                            </div>

                                        </div>
                                        <!-- /.input-group -->
                                    </div>

                                </div>



                                <!--/.row -->


                                <div class="form-group">

                                    <asp:Button class="btn btn-primary" ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" OnClientClick="return LikeBtnClick();" />
                                    <asp:Button class="btn btn-primary" ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                                </div>




                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <%--   <div class="col-sm-6">
            <div class="panel panel-primary">
                <div class="panel-body">                     
                </div>
            </div>
        </div>--%>

            <div class="row">
                <div class="panel panel-primary">
                    <div class="panel-body">
                        
                        <div class="text-right">
                             <asp:Button class="btn btn-primary" ID="Reverse" runat="server" Text="Sort Reverse" OnClick="btnReverse_Click"  />
                            <asp:GridView ID="dgSalary" runat="server" AutoGenerateColumns="false" CssClass="table table-striped"
                                Font-Names="Comic Sans MS" AllowPaging="true">

                                <Columns>
                                    <asp:BoundField DataField="EMPLOYEE_SALARY_ID" HeaderText="Sl" ItemStyle-Width="70" />
                                </Columns>
                                <Columns>
                                    <asp:BoundField DataField="NAME" HeaderText="Name" ItemStyle-Width="70" />
                                </Columns>


                                <Columns>
                                    <asp:BoundField DataField="MONTH" HeaderText="Month" ItemStyle-Width="70" />
                                </Columns>
                                <Columns>
                                    <asp:BoundField DataField="YEAR" HeaderText="Year" ItemStyle-Width="70" />
                                </Columns>

                                <Columns>
                                    <asp:BoundField DataField="BASIC_SALARY" HeaderText="Basic Salary" ItemStyle-Width="70" />


                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Button runat="server" Text="Sort" ID="btnSalarydesc" OnClick="btnSalarydesc_Click" CommandName="FamilyClicked" />
                                        </HeaderTemplate>
                                    </asp:TemplateField>

                                </Columns>
                                <Columns>
                                    <asp:BoundField DataField="HOME_RENT" HeaderText="Home Rent" ItemStyle-Width="70" />

                                        <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Button runat="server" Text="Sort" ID="btnHomeRent" OnClick="btnHomeRentdesc_Click" CommandName="FamilyClicked" />
                                        </HeaderTemplate>
                                    </asp:TemplateField>


                                </Columns>
                                <Columns>
                                    <asp:BoundField DataField="OTHER_RENT" HeaderText="Other Rent" ItemStyle-Width="70" />


                                        <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Button runat="server" Text="Sort" ID="btnOther" OnClick="btnOther_Click" CommandName="FamilyClicked" />
                                        </HeaderTemplate>
                                    </asp:TemplateField>

                                </Columns>




                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label Visible="false" ID="lblEMPLOYEE_SALARY_ID" runat="server" Text='<%#Bind("EMPLOYEE_SALARY_ID")%>'>
                                            </asp:Label>

                                            <asp:Button BackColor="Red" ID="btndelete" OnClick="btndelete_Click" runat="server"
                                                Text="Delete" ShowSelectButton="True" class="btn btn-primary"></asp:Button>



                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                            </asp:GridView>

                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Button class="btn btn-primary" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                </div>

            </div>
        </div>
</asp:Content>
