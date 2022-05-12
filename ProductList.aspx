<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductList.aspx.cs" Inherits="ProductList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gvProduct" runat="server" AutoGenerateColumns="false" OnRowCommand="gvProduct_RowCommand" OnRowDeleting="gvProduct_RowDeleting" >
                <Columns>
                    <asp:BoundField HeaderText="Product Id" DataField="Id" />
                    <asp:BoundField HeaderText="Product Name" DataField="ProductName" />
                    <asp:BoundField HeaderText="Product Quntity" DataField="ProductQuntity" />
                    <asp:BoundField HeaderText="Product Price" DataField="ProductPrice" />
                    <asp:BoundField HeaderText="Company Name" DataField="Company.CompanyName" />
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandArgument='<%# Eval("Id").ToString() %>' CommandName="Delete" />
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Update">
                        <ItemTemplate>
                            <asp:HyperLink ID="btnUpdate" runat="server" Text="Update" NavigateUrl='<%# "~/ProductAddEdit.aspx?ProductId=" + Eval("Id").ToString() %>' CommandName="Update" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:HyperLink ID="hlAdd" runat="server" NavigateUrl="~/ProductAddEdit.aspx">Add</asp:HyperLink>
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
