<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" 
    AutoEventWireup="true" CodeFile="ManageProducts.aspx.cs" Inherits="ManageProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="wrapper">
        <div style="width:800px">
    <div class="panel panel-primary">
        
    <div class="panel-body">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">Category<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlcategory" ErrorMessage="Choose Category" ForeColor="Red" InitialValue="Choose Category" ValidationGroup="a">*</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style2">
                    <asp:DropDownList ID="ddlcategory" CssClass="form-control" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Product Name<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtproductname" ErrorMessage="Product Name Required" ForeColor="Red" ValidationGroup="a">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtproductname" CssClass="form-control" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Artist<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtartist" ErrorMessage="Artist Nmae Required" ForeColor="Red" ValidationGroup="a">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtartist" CssClass="form-control" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Price<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtprice" ErrorMessage="Price Required" ForeColor="Red" ValidationGroup="a">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtprice" CssClass="form-control" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HiddenField ID="HiddenField2" runat="server" />
                </td>
                <td>
                    <asp:Image ID="Image2" runat="server" Width="108px" />
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>Image<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Image Required" ForeColor="Red" ValidationGroup="a">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload1" CssClass="form-control" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td class="auto-style2">
                    <asp:Button ID="btnsave"  runat="server" Text="Save" OnClick="btnsave_Click" ValidationGroup="a" />
                    <asp:Button ID="btnupdate"  runat="server" Text="Update" OnClick="btnupdate_Click" />
                    <asp:Button ID="btndelete"  runat="server" Text="Delete" OnClick="btndelete_Click" />
                    </td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td class="auto-style2">
                    <asp:Label ID="lblmessage" runat="server"></asp:Label>
                    </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style2">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" BackColor="Black" ForeColor="Red" ValidationGroup="a" />
                    </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <asp:GridView ID="GridView1" CssClass="table table-bordered" runat="server" Width="629px" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" OnRowEditing="GridView1_RowEditing">
                        <Columns>
                            <asp:TemplateField HeaderText="SN">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CID">
                                <ItemTemplate>
                                    <%#Eval("CID") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PName">
                                <ItemTemplate>
                                    <%#Eval("PName") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PArtist">
                                <ItemTemplate>
                                    <%#Eval("PArtist") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Image">
                                <ItemTemplate>
                                    <asp:Image ID="Image1" Height="64px" ImageUrl='<%#"~/Productphotos/"+Eval("PImage") %>' Width="64px" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                        <PagerStyle CssClass="gridview"/>
                        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" ForeColor="#330099" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                        <SortedAscendingCellStyle BackColor="#FEFCEB" />
                        <SortedAscendingHeaderStyle BackColor="#AF0101" />
                        <SortedDescendingCellStyle BackColor="#F6F0C0" />
                        <SortedDescendingHeaderStyle BackColor="#7E0000" />
                    </asp:GridView>
                </td>
            </tr>
            </table>
    </div>
    </div>
            </div>
        </div>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

