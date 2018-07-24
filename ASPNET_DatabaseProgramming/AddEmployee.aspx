<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="ASPNET_DatabaseProgramming.AddEmployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:Label ID="Label1" runat="server" Text="EmpNo:"></asp:Label>
            <asp:TextBox ID="txtEmpNo" runat="server"></asp:TextBox><br />
             <asp:Label ID="Label2" runat="server" Text="EmpName"></asp:Label>
            <asp:TextBox ID="txtEmpName" runat="server"></asp:TextBox><br />
             <asp:Label ID="Label3" runat="server" Text="EmpSalary"></asp:Label>
            <asp:TextBox ID="txtEmpSalary" runat="server"></asp:TextBox><br />
             <asp:Label ID="Label4" runat="server" Text="DEPNO"></asp:Label>
            <asp:TextBox ID="txtDeptNo" runat="server"></asp:TextBox><br />
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"  />
        </div>
    </form>
</body>
</html>
