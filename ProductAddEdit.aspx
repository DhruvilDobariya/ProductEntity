<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductAddEdit.aspx.cs" Inherits="ProductAddEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <form>
                <div>
                    Enter Product Name : 
                    <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
                </div>
                <div>
                    Enter Product Quntity : 
                    <asp:TextBox ID="txtProductQuntity" runat="server"></asp:TextBox>
                </div>
                <div>
                    Enter Product Price : 
                    <asp:TextBox ID="txtProductPrice" runat="server"></asp:TextBox>
                </div>
                <div>
                    Select Company : 
                    <asp:DropDownList ID="ddlCompany" runat="server"></asp:DropDownList>
                </div>
                <div>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    <asp:HyperLink ID="hyBack" runat="server" NavigateUrl="~/ProductList.aspx" >Back</asp:HyperLink>
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </div>
            </form>
        </div>
    </form>
</body>
</html>
