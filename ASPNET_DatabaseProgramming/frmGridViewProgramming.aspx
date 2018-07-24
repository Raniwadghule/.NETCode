<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmGridViewProgramming.aspx.cs" Inherits="ASPNET_DatabaseProgramming._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        
        <asp:GridView ID="gdvEmp" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1"  OnPageIndexChanged="gdvEmp_PageIndexChanged" OnPageIndexChanging="gdvEmp_PageIndexChanging" OnRowCancelingEdit="gdvEmp_RowCancelingEdit" OnRowDeleting="gdvEmp_RowDeleting" OnRowEditing="gdvEmp_RowEditing" OnRowUpdating="gdvEmp_RowUpdating">
            <Columns>
                <asp:BoundField DataField="EmpNo" HeaderText="EmpNo" SortExpression="EmpNo" />
                <asp:BoundField DataField="EmpName" HeaderText="EmpName" SortExpression="EmpName" />
                <asp:BoundField DataField="EmpSalary" HeaderText="EmpSalary" SortExpression="EmpSalary" />
                <asp:BoundField DataField="DeptNo" HeaderText="DeptNo" SortExpression="DeptNo" />
                <asp:CommandField ShowEditButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnSave" runat="server" Text="Add.." OnClick="btnSave_Click" />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:EmployeeConnectionString %>" SelectCommand="SELECT * FROM [tbl_employee]" 
            UpdateCommand="Update tbl_employee SET EmpName=@EmpName,EmpSalary=@EmpSalary,DeptNo=@DeptNo WHERE EmpNo=@EmpNo"
         ></asp:SqlDataSource>
    </div>
    
</asp:Content>
