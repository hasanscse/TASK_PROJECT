<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddMultipleEmployee.aspx.cs" Inherits="TASK_PROJECT.AddMultipleEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <script type="text/javascript">
        $(function () {
            $('#MainContent_txtDateOfBirth').datetimepicker();
        });
      </script>

    <script src="Scripts/WebForms/WebUIValidation.js"></script>

    <script>
        function LikeBtnClick() {
            var firstName, lastName, email, phone, emailExp;
            firstName = $("#MainContent_txtFirstName").val();
            lastName = $("#MainContent_txtLastName").val();
            email = $("#MainContent_txtEmail").val();
            phone = $("#MainContent_txtPhone").val();

            emailExp = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([com\co\.\in])+$/;

            if (firstName == '') {
                alert("Please Enter First Name");

                document.getElementById("MainContent_txtFirstName").style.border = "2px solid Red";
                $("#MainContent_txtFirstName").focus();


                return false;
            }
            if (firstName.length <= 1) {
                alert("Minimum Character will be two!");

                document.getElementById("MainContent_txtFirstName").style.border = "2px solid Red";
                $("#MainContent_txtFirstName").focus();
                return false;
            }
            if (lastName == '') {
                alert("Please Enter last Name");
                document.getElementById("MainContent_txtLastName").style.border = "2px solid Red";
                $("#MainContent_txtLastName").focus();

                return false;
            }
            if (lastName.length <= 1) {
                alert("Minimum Character will be two!");
                document.getElementById("MainContent_txtLastName").style.border = "2px solid Red";
                $("#MainContent_txtLastName").focus();
                return false;
            }
            if (email == '') {

                alert("Please Enter Email");
                document.getElementById("MainContent_txtEmail").style.border = "2px solid Red";
                $("#MainContent_txtEmail").focus();
                return false;
            }
            if (email != '') {

                if (!email.match(emailExp)) {
                    alert("Invalid Email Id");
                    document.getElementById("MainContent_txtEmail").style.border = "2px solid Red";
                    $("#MainContent_txtEmail").focus();
                    return false;
                }
            }
            if (phone == '') {
                alert("Please enter Phone");
                document.getElementById("MainContent_txtPhone").style.border = "2px solid Red";
                $("#MainContent_txtPhone").focus();
                return false;
            }

        }
    </script>

    <div class="jumbotron text-center">
        <div class="container">
            <div class="page-header">

                <div class="panel-primary">
                    <div class="panel-heading">
                        <h3><b>Add Multiple Employee</b></h3>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <div class="panel panel-primary">
                        <div class="panel-body">
                            <div class="text-right">
                                <div class="row">
                                    <div class="col">
                                        <asp:TextBox ID="txtID" Visible="False" class="form-control" runat="server">                               
                                        </asp:TextBox>
                                    </div>
                                    <div class="col">

                                        <label class="col-sm-5 control-label">First Name :</label>
                                        <asp:TextBox ID="txtFirstName" placeholder="Enter First Name" class="form-control" runat="server">                               
                                        </asp:TextBox>
                                        <span id="spn "></span>
                                    </div>
                                    <div class="col">
                                        <label class="col-sm-5 control-label">Last Name :</label>
                                        <asp:TextBox ID="txtLastName" placeholder="Enter Last Name" class="form-control" runat="server">                               
                                        </asp:TextBox>

                                    </div>
                                    <div class="col">
                                        <label class="col-sm-5 control-label">Email :</label>
                                        <asp:TextBox ID="txtEmail" placeholder="Enter Email" class="form-control" TextMode="Email" runat="server">                               
                                        </asp:TextBox>
                                    </div>
                                    <div class="col">
                                        <label class="col-sm-5 control-label">Phone :</label>
                                        <asp:TextBox ID="txtPhone" placeholder="Enter Phone" class="form-control" TextMode="Number" runat="server">                               
                                        </asp:TextBox>
                                    </div>

                                    <div class="col">
                                        <label class="col-sm-5 control-label">Department :</label>
                                        <asp:DropDownList ID="cmbDepartment" class="form-control" runat="server" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col">
                                        <label class="col-sm-5 control-label">Date Of Birth :</label>
                                        <asp:TextBox ID="txtDateOfBirth" placeholder="Select Date" class="form-control" runat="server" AutoPostBack="true" OnTextChanged="txtDateOfBirth_TextChanged">                               
                                        </asp:TextBox>
                                    </div>
                                    <div>
                                        <label class="col-sm-5 control-label">Age :</label>
                                        <asp:TextBox ID="txtAge" placeholder="" ReadOnly="true" class="form-control" runat="server">                               
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-sm-7">
                                        <asp:RadioButton ID="rdMale" runat="server" Text="Male" Checked="True" GroupName="Radio" AutoPostBack="true" />
                                        <asp:RadioButton ID="rdFemale" runat="server" Text="Female" GroupName="Radio" AutoPostBack="true" />
                                    </div>
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
            </div>

            <div class="row">
                <div class="panel panel-primary">
                    <div class="panel-body">

                        <div class="text-right">


                            <asp:GridView ID="dgdepartment" runat="server" AutoGenerateColumns="false" CssClass="table table-striped"
                                Font-Names="Comic Sans MS" AllowPaging="true">
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="Id" ItemStyle-Width="70" />
                                </Columns>
                                <Columns>
                                    <asp:BoundField DataField="FIRST_NAME" HeaderText="First Name" ItemStyle-Width="70" />
                                </Columns>

                                <Columns>
                                    <asp:BoundField DataField="LAST_NAME" HeaderText="Last Name" ItemStyle-Width="70" />
                                </Columns>


                                <Columns>
                                    <asp:BoundField DataField="EMAIL" HeaderText="Email" ItemStyle-Width="70" />
                                </Columns>

                                <Columns>
                                    <asp:BoundField DataField="DATE_OF_BIRTH" HeaderText="Date of Birth" ItemStyle-Width="150" DataFormatString="{0:dd-MMM-yyyy}" />
                                </Columns>
                                <Columns>
                                    <asp:BoundField DataField="PHONE" HeaderText="Phone" ItemStyle-Width="70" />
                                </Columns>
                                <Columns>
                                    <asp:BoundField DataField="GENDER" HeaderText="Gender" ItemStyle-Width="70" />
                                </Columns>
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label Visible="false" ID="lblID" runat="server" Text='<%#Bind("ID")%>'>
                                            </asp:Label>
                                            <asp:Button BackColor="blue" ID="btnEdit" OnClick="btnEdit_Click" runat="server"
                                                Text="Edit" ShowSelectButton="True" class="btn btn-primary"></asp:Button>
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
    </div>


</asp:Content>
