<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddMultiEmployeeNew.aspx.cs" Inherits="TASK_PROJECT.AddMultiEmployeeNew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    
  <div class="jumbotron text-center">
  
  <div class="container">
  <div class="page-header">
   
       <div class="panel-primary">
      <div class="panel-heading">
       <h3><b>Employee Info</b></h3>

      </div>
   
    </div>

  </div>
    
    <div class="row">
        <div class="panel panel-primary">
            <div class="panel-body">
              

                <asp:GridView ID="dgdepartment" runat="server" AutoGenerateColumns="false" CssClass="table table-striped"
                    lowPaging="true"
                    Font-Names="Comic Sans MS" 
                   PagerStyle-CssClass="pagingDiv">

                      <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="Id" ItemStyle-Width="70" />
                                </Columns>

                                <Columns>
                                    <asp:BoundField DataField="FIRST_NAME" HeaderText="First Name" ItemStyle-Width="70" />
                                </Columns>

                                  <Columns>
                                    <asp:BoundField DataField="EMAIL" HeaderText="Email" ItemStyle-Width="70" />
                                </Columns>

                                <Columns>
                                    <asp:BoundField DataField="DATE_OF_BIRTH" HeaderText="Date of Birth" ItemStyle-Width="70" />
                                </Columns>

                                <Columns>
                                    <asp:BoundField DataField="PHONE" HeaderText="Phone" ItemStyle-Width="70" />
                                </Columns>
                                <Columns>
                                    <asp:BoundField DataField="GENDER" HeaderText="Gender" ItemStyle-Width="70" />
                                </Columns>



                </asp:GridView>
            </div>
        </div>
    </div>
    <div class="row" id="AddEmployeeGroup" runat="server">

        <div class="col-sm-6">
            <div class="panel panel-primary">
                <div class="panel-body">

                      <div class="text-right">
                                <div class="row">
                                    <div class="col">

                                        <label class="col-sm-5 control-label">First Name :</label>
                                        <asp:TextBox ID="txtFirstName" placeholder="Enter First Name" class="form-control" runat="server">                               
                                        </asp:TextBox>
                                    </div>
                                    <div class="col">
                                        <label class="col-sm-5 control-label">Last Name :</label>
                                        <asp:TextBox ID="txtLastName" placeholder="Enter Last Name" class="form-control" runat="server">                               
                                        </asp:TextBox>

                                    </div>
                                    <div class="col">
                                        <label class="col-sm-5 control-label">Email :</label>
                                        <asp:TextBox ID="txtEmail" placeholder="Enter Email" class="form-control" runat="server">                               
                                        </asp:TextBox>

                                    </div>
                                    <div class="col">
                                        <label class="col-sm-5 control-label">Phone :</label>
                                        <asp:TextBox ID="txtPhone" placeholder="Enter Phone" class="form-control"  runat="server">                               
                                        </asp:TextBox>

                                    </div>

                                    <div class="col">
                                        <label class="col-sm-5 control-label">Department :</label>
                                        <asp:DropDownList ID="cmbDepartment" class="form-control" runat="server" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>

                                    <div class="col">
                                        <label class="col-sm-5 control-label">Date Of Birth :</label>
                                        <asp:TextBox ID="txtDateOfBirth" placeholder="Select Date" class="form-control" runat="server" >                               
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


                                </div>
                            </div>


                    <div class="form-group">
                        <asp:Button class="btn btn-primary" ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                       
                    </div>

                </div>

            </div>
        </div>


    </div>

      </div>
      </div>



</asp:Content>
