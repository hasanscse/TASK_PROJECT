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
										<label class="col-sm-5 control-label">Month :</label>
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
									<div class="col">
										<label class="col-sm-5 control-label">Year :</label>
										<asp:DropDownList ID="cmbYear" class="form-control" runat="server" AutoPostBack="true">
											<asp:ListItem Text="2024" Value="2024"> </asp:ListItem>
											<asp:ListItem Text="2025" Value="2025"> </asp:ListItem>
											<asp:ListItem Text="2026" Value="2026"> </asp:ListItem>
											<asp:ListItem Text="2027" Value="2027"> </asp:ListItem>
										</asp:DropDownList>

									</div>

									
								</div>

								<div class="col">
									<label class="col-sm-5 control-label">Home Rent :</label>
									<asp:TextBox ID="txtHomeRent" placeholder="Enter Home Rent" class="form-control" TextMode="Number" runat="server">                               
									</asp:TextBox>
								</div>

								<div class="col">
									<label class="col-sm-5 control-label">Other Rent :</label>
									<asp:TextBox ID="txtOtherRent" placeholder="Enter Other Rent" class="form-control" TextMode="Number" runat="server">                               
									</asp:TextBox>
								</div>

								<div class="row">
									<div class="col-md-3">
										<div class="input-group">
											<div class="col">
												<asp:TextBox ID="txtEMPLOYEEID" Visible="False" class="form-control" runat="server">                               
												</asp:TextBox>
											</div>


											<div class="col">
												<label class="col-sm-2 control-label">Employee</label>
												<asp:DropDownList ID="cmbEmployee" class="form-control" runat="server" AutoPostBack="true">
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
										<asp:TextBox ID="txtSalary" placeholder="Salary" class="form-control" TextMode="Number" runat="server">                               
										</asp:TextBox>
										
									</div>
											
										</div>
										<!-- /.input-group -->
									</div>
									<!-- /.col-md-6 -->
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
		</div>

		<div class="row">
			<div class="panel panel-primary">
				<div class="panel-body">

					<div class="text-right">

						<asp:GridView ID="dgSalary" runat="server" AutoGenerateColumns="false" CssClass="table table-striped"
							Font-Names="Comic Sans MS" AllowPaging="true">

							<Columns>
								<asp:BoundField DataField="EMPLOYEE_SALARY_ID" HeaderText=" Salary Id" ItemStyle-Width="70" />
							</Columns>
							<Columns>
								<asp:BoundField DataField="MONTH" HeaderText="Month" ItemStyle-Width="70" />
							</Columns>
							<Columns>
								<asp:BoundField DataField="YEAR" HeaderText="Year" ItemStyle-Width="70" />
							</Columns>

							<Columns>
								<asp:BoundField DataField="BASIC_SALARY" HeaderText="Basic Salary" ItemStyle-Width="70" />
							</Columns>
							<Columns>
								<asp:BoundField DataField="HOME_RENT" HeaderText="Home Rent" ItemStyle-Width="70" />
							</Columns>
							<Columns>
								<asp:BoundField DataField="OTHER_RENT" HeaderText="Other Rent" ItemStyle-Width="70" />
							</Columns>
						</asp:GridView>

					</div>
				</div>
			</div>

			<div class="form-group">
				<asp:Button class="btn btn-primary" ID="btnSave" runat="server" Text="Save" />
			</div>

		</div>
	</div>
	</div>

</asp:Content>
