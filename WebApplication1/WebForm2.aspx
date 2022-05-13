<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>

    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            </asp:GridView>
            <br />
            <br />
            <asp:GridView ID="GridView2" runat="server">
            </asp:GridView>
            <br />
        </div>
    </form>

</body>
</html>
