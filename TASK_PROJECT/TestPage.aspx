<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="TASK_PROJECT.TestPage" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

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
    <div class="row" >
        <div class="col-sm-6">
            <div class="panel panel-primary">
                <div class="panel-body">


                    <div class="form-group">
                        <label class="col-sm-4 control-label">
                            Department :</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="dopDepartment" class="form-control" runat="server" AutoPostBack="true"
                                OnSelectedIndexChanged="dopDepartment_SelectedIndexChanged">
                                <asp:ListItem Text="All" Value="0"></asp:ListItem>
                            </asp:DropDownList>


                        </div>


                    </div>

             
                         

                </div>
            </div>
        </div>


          <div class="col-sm-6">
            <div class="panel panel-primary">
                <div class="panel-body">



                 <div class="form-group">
                        <label class="col-sm-4 control-label">
                            Paging No :</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="dopPaging" class="form-control" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="dopPaging_SelectedIndexChanged"  
                              >
                                <asp:ListItem Text="0" Value="0"></asp:ListItem>
                                  <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                   <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                   <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                   <asp:ListItem Text="4" Value="4"></asp:ListItem> 
                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                            </asp:DropDownList>


                        </div>
                    </div>
                         

                </div>
            </div>
        </div>


    </div>
    <div class="row">
        <div class="panel panel-primary">
            <div class="panel-body">

                <div class="text-right">


                    <%-- <asp:Button class="glyphicon glyphicon-print" ID="btnPrint" OnClick="btnPrint_Click" runat="server"
                        Text="Print" ShowSelectButton="True"></asp:Button>--%>
                    <asp:Button class="glyphicon glyphicon-plus" ID="btnAddVisible" width="40px" Height="30px" runat="server" Text="+" OnClick="btnAddVisible_Click" />


          

                    <asp:LinkButton ID="btnPrint"
                        runat="server"
                        CssClass="btn btn-info btn-lg"
                        OnClick="btnPrint_Click">
                    <span aria-hidden="true" class="glyphicon glyphicon-print"></span>Print
                    </asp:LinkButton>



                    <%--   <asp:DropDownList ID="DDPrintOpt" Width="80px" runat="server" CssClass="custom-select">
                        <asp:ListItem Selected="True" Value="PDF">PDF</asp:ListItem>
                        <asp:ListItem Value="HTML">HTML</asp:ListItem>
                        <asp:ListItem Value="WORD">Word</asp:ListItem>
                        <asp:ListItem Value="EXCEL">Excel</asp:ListItem>
                    </asp:DropDownList>


                    <asp:LinkButton ID="lnkPrint" runat="server" OnClick="lnkPrint_Click" CssClass="btn btn-success"><span class=" fa fa-print"></span></asp:LinkButton>--%>
                </div>


                <asp:GridView ID="dgdepartment" runat="server" AutoGenerateColumns="false" CssClass="table table-striped"
                    lowPaging="true"
                    Font-Names="Comic Sans MS" AllowPaging="true"
                    OnPageIndexChanging="OnPageIndexChanging" PageSize="2" PagerStyle-CssClass="pagingDiv">

                    <Columns>
                        <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="Id" ItemStyle-Width="70" />
                    </Columns>

                    <Columns>
                        <asp:BoundField DataField="NAME" HeaderText="Name" ItemStyle-Width="70" />
                    </Columns>

                    <Columns>
                        <asp:BoundField DataField="SALARY" HeaderText="Salary" ItemStyle-Width="70" />
                    </Columns>

                    <Columns>
                        <asp:BoundField DataField="DEPARTMENT_NAME" HeaderText="Department Name" ItemStyle-Width="70" />
                    </Columns>

                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>

                                <asp:Label Visible="false" ID="lblEMPLOYEE_ID" runat="server" Text='<%#Bind("EMPLOYEE_ID")%>'>
                                </asp:Label>

                                <asp:Button BackColor="blue" ID="btnEdit" OnClick="btnEdit_Click" runat="server"
                                    Text="Edit" ShowSelectButton="True" class="btn btn-primary"></asp:Button>
                                <asp:Button BackColor="Red" ID="btndelete" OnClick="btndelete_Click" runat="server"
                                    Text="Delete" ShowSelectButton="True" class="btn btn-primary"></asp:Button>

                                <asp:Button BackColor="green" ID="btnIndividual" OnClick="btnIndividual_Click" runat="server"
                                    Text="viewInfo" ShowSelectButton="True" class="btn btn-primary" ></asp:Button>

                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>
            </div>
        </div>
    </div>
    <div class="row" id="AddEmployeeGroup" runat="server">

        <div class="col-sm-6">
            <div class="panel panel-primary">
                <div class="panel-body">

                    <div class="form-group">
                        <label class="col-sm-4 control-label">
                        </label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtEmployeeID" placeholder="Enter Name" class="form-control" runat="server">                               
                            </asp:TextBox>

                        </div>
                    </div>


                    <div class="form-group">
                        <label class="col-sm-4 control-label">
                            Name :</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtNAME" placeholder="Enter Name" class="form-control" runat="server">                               
                            </asp:TextBox>

                        </div>
                    </div>


                    <div class="form-group">
                        <label class="col-sm-4 control-label">
                            Department :</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="cmbDepartment" class="form-control" runat="server" AutoPostBack="true"
                                OnSelectedIndexChanged="dopDepartment_SelectedIndexChanged">
                            </asp:DropDownList>

                        </div>
                    </div>


                    <div class="form-group">
                        <label class="col-sm-4 control-label">
                            Salary :</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtSalary" placeholder="Enter Salary" class="form-control" runat="server">                               
                            </asp:TextBox>
                        </div>
                    </div>


                    <div class="form-group">
                        <asp:Button class="btn btn-primary" ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                        <asp:Button class="btn btn-primary" ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                        <asp:Button class="btn btn-danger" ID="btnClose" runat="server" Text="Close" OnClick="btnClose_Click" />
                    </div>

                </div>

            </div>
        </div>


    </div>

      </div>
      </div>

    
</asp:Content>
