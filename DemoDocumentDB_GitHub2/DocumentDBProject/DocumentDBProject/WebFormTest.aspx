<%@ Page Language="C#" AutoEventWireup="true" Async="true" CodeBehind="WebFormTest.aspx.cs" Inherits="DocumentDBProject.WebFormTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
        <asp:Label ID="lblMessage" runat="server" Text="MESSAGE"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="UserID:"></asp:Label>
        <br />
        <asp:TextBox ID="txtUserID" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Name:"></asp:Label>
        <br />
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Age:"></asp:Label>
        <br />
        <asp:TextBox ID="txtAge" runat="server" MaxLength="2"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Sex:"></asp:Label>
        <br />
        <asp:TextBox ID="txtSex" runat="server" MaxLength="1"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnAddUser" runat="server" OnClick="btnAddUser_Click" Text="Add user" />
&nbsp;&nbsp;
        <asp:Button ID="btnUpdateUser" runat="server" OnClick="btnUpdateUser_Click" Text="Update user" />
&nbsp;&nbsp;
        <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete user" Width="99px" />
&nbsp;&nbsp;
        <asp:Button ID="btnGetUser" runat="server" OnClick="btnGetUser_Click" Text="Get user" />
&nbsp;&nbsp;
        <asp:Button ID="btnGetAllUsers" runat="server" Text="Get all users" OnClick="btnGetAllUsers_Click" />
        <br />
        <br />
        <asp:GridView ID="gridUsers" runat="server">
        </asp:GridView>
    </div>
    </form>
</body>
</html>
