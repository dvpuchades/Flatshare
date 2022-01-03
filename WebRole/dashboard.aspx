<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="WebRole.dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <p>
        FLATSHARE</p>
    <form id="form1" runat="server">
    <div>
        <br />
        Search:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="SearchBar" runat="server" Width="546px"></asp:TextBox>
&nbsp;&nbsp;
        <asp:Button ID="SearchButton" runat="server" OnClick="SearchButton_Click" Text="Search" />
        </div>
        <div>
            <br />
            <br />
            My
            Announce:<br />
            <br />
            <asp:Table ID="MyAnnounceTable" runat="server">
            </asp:Table>
            <br />
            <br />
            Announce:<br />
            <br />
            <asp:Table ID="AnnounceTable" runat="server">
            </asp:Table>
            <br />
            <br />
        </div>
        <div>
            Users:<br />
            <br />
            <asp:Table ID="UserTable" runat="server">
            </asp:Table>
            <br />
            <br />
        </div>
        <div>
            Upload your Announce:<br />
            <br />
            Address:
            <asp:TextBox ID="formAddress" runat="server"></asp:TextBox>
            <br />
            City:
            <asp:TextBox ID="formCity" runat="server"></asp:TextBox>
            <br />
            Rooms:
            <asp:TextBox ID="formRooms" runat="server"></asp:TextBox>
            <br />
            Prize:
            <asp:TextBox ID="formPrize" runat="server"></asp:TextBox>
            <br />
            Description:
            <asp:TextBox ID="formDescription" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="CreateAnnounce" runat="server" OnClick="CreateAnnounce_Click" Text="Create" />
            <asp:Button ID="UpdateFormButton" runat="server" Enabled="False" OnClick="UpdateFormButton_Click" Text="Update" Visible="False" />
            <br />
        </div>
        <div>
            <br />
            <br />
            Profile:<br />
            <asp:Label ID="nicknameLabel" runat="server"></asp:Label>
            <br />
            <asp:Label ID="ageLabel" runat="server"></asp:Label>
            <br />
            <asp:Label ID="interestLabel" runat="server"></asp:Label>
            <br />
            <asp:Label ID="activityLabel" runat="server"></asp:Label>
            <br />
            <asp:Label ID="searchingInLabel" runat="server"></asp:Label>
            <br />
            <br />
            Update your profile:<br />
            <br />
            Age:
            <asp:TextBox ID="profileAgeTextBox" runat="server"></asp:TextBox>
            <br />
            Interest:
            <asp:TextBox ID="profileInterestTextBox" runat="server"></asp:TextBox>
            <br />
            Activity:
            <asp:TextBox ID="profileActivityTextBox" runat="server"></asp:TextBox>
            <br />
            Searching in:
            <asp:TextBox ID="profileSearchingInTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="updateProfileButton" runat="server" OnClick="updateProfileButton_Click" Text="Update" />
        </div>
    </form>
</body>
</html>
