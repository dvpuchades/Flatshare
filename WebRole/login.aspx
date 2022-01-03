<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebRole.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            FLATSHARE<br />
            <br />
        </div>
        <div>
            Log in:<br />
            <br />
            email:
            <asp:TextBox ID="loginEmail" runat="server"></asp:TextBox>
            <br />
            password:
            <asp:TextBox ID="loginPassword" runat="server"></asp:TextBox>
        </div>
        <p>
            <asp:Button ID="loginButton" runat="server" OnClick="Button1_Click" Text="Log in!" />
        </p>
        <p>
            &nbsp;</p>
        <div>
            Sign up:<br />
            <br />
            nickname:
            <asp:TextBox ID="signupNickname" runat="server"></asp:TextBox>
            <br />
            email:
            <asp:TextBox ID="signupEmail" runat="server"></asp:TextBox>
            <br />
            passsword:
            <asp:TextBox ID="signupPassword" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Sign up!" />
        </div>
        <div>
            <asp:Label ID="errorLabel" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
