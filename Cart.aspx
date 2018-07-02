<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <section class="bg-title-page p-t-40 p-b-50 flex-col-c-m" style="background-image: url(images/heading-pages-01.jpg);">
		<h2 class="l-text2 t-center">
			Cart
		</h2>
	</section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
        <div style="align:center">

     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowDataBound="GridView1_RowDataBound"  ShowFooter="True" Width="1350px"  >
        <Columns>
            <asp:TemplateField HeaderText="S.No">
                <ItemTemplate>
                    <%#Container.DataItemIndex+1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText=" Name">
                <ItemTemplate>
                    <asp:HiddenField ID="hdProductid" Value='<%#Eval("CartID") %>' runat="server" />
                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("PName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price">
                <ItemTemplate>
                    <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("PPrice") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Image">
                <ItemTemplate>
                    <asp:Image ID="Image1" Height="64px" ImageUrl='<%#"~/ProductPhotos/"+Eval("PImage") %>' Width="64px" runat="server" /> 
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("Quantity") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <b>Total Amount</b>
                </FooterTemplate>
            </asp:TemplateField>
           
            <asp:TemplateField HeaderText="Total" >
                <ItemTemplate>
                    <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lblTotalamount" runat="server" Text=""></asp:Label>
                </FooterTemplate>
                
            </asp:TemplateField>
            <%--<asp:CommandField DeleteText="Remove" ShowDeleteButton="True" />--%>

            
            <asp:TemplateField HeaderText="Remove Selected">
                <ItemTemplate>
                    <asp:CheckBox ID="chkDelete" runat="server" />
                    
                </ItemTemplate>
            </asp:TemplateField>
            
            
             
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
        
    </asp:GridView>
            </div>
    <div class="btn-addcart-product-detail size9 trans-0-4 m-t-10 m-b-10">
        <asp:Button ID="btnDelete" class="flex-c-m sizefull bg1 bo-rad-23 hov1 s-text1 trans-0-4" runat="server" Text="Delete" OnClick="btnDelete_Click" />
        </div>


    <%--section class="cart bgwhite p-t-70 p-b-100">
		<div class="container">
			<!-- Cart item -->
			<div class="container-table-cart pos-relative">
				<div class="wrap-table-shopping-cart bgwhite">
					<table class="table-shopping-cart">
						<tr class="table-head">
							<th class="column-1"></th>
							<th class="column-2">Product</th>
							<th class="column-3">Price</th>
							<th class="column-4 p-l-70">Quantity</th>
							<th class="column-5">Total</th>
						</tr>

						<tr class="table-row">
							<td class="column-1">
								<div class="cart-img-product b-rad-4 o-f-hidden">
									<img src="images/item-10.jpg" alt="IMG-PRODUCT">
								</div>
							</td>
							<td class="column-2">Men Tshirt</td>
							<td class="column-3">$36.00</td>
							<td class="column-4">
								<div class="flex-w bo5 of-hidden w-size17">
									<button class="btn-num-product-down color1 flex-c-m size7 bg8 eff2">
										<i class="fs-12 fa fa-minus" aria-hidden="true"></i>
									</button>

									<input class="size8 m-text18 t-center num-product" type="number" name="num-product1" value="1">

									<button class="btn-num-product-up color1 flex-c-m size7 bg8 eff2">
										<i class="fs-12 fa fa-plus" aria-hidden="true"></i>
									</button>
								</div>
							</td>
							<td class="column-5">$36.00</td>
						</tr>

						<tr class="table-row">
							<td class="column-1">
								<div class="cart-img-product b-rad-4 o-f-hidden">
									<img src="images/item-05.jpg" alt="IMG-PRODUCT">
								</div>
							</td>
							<td class="column-2">Mug Adventure</td>
							<td class="column-3">$16.00</td>
							<td class="column-4">
								<div class="flex-w bo5 of-hidden w-size17">
									<button class="btn-num-product-down color1 flex-c-m size7 bg8 eff2">
										<i class="fs-12 fa fa-minus" aria-hidden="true"></i>
									</button>

									<input class="size8 m-text18 t-center num-product" type="number" name="num-product2" value="1">

									<button class="btn-num-product-up color1 flex-c-m size7 bg8 eff2">
										<i class="fs-12 fa fa-plus" aria-hidden="true"></i>
									</button>
								</div>
							</td>
							<td class="column-5">$16.00</td>
						</tr>
					</table>
				</div>
			</div>--%>

			<%--<div class="flex-w flex-sb-m p-t-25 p-b-25 bo8 p-l-35 p-r-60 p-lr-15-sm">
				<div class="flex-w flex-m w-full-sm">
					<div class="size11 bo4 m-r-10">
						<input class="sizefull s-text7 p-l-22 p-r-22" type="text" name="coupon-code" placeholder="Coupon Code">
					</div>

					<div class="size12 trans-0-4 m-t-10 m-b-10 m-r-10">
						<!-- Button -->
						<button class="flex-c-m sizefull bg1 bo-rad-23 hov1 s-text1 trans-0-4">
							Apply coupon
						</button>
					</div>
				</div>

				<div class="size10 trans-0-4 m-t-10 m-b-10">
					<!-- Button -->
					<button class="flex-c-m sizefull bg1 bo-rad-23 hov1 s-text1 trans-0-4">
						Update Cart
					</button>
				</div>--%>
			</div>

			<!-- Total -->
			<div class="bo9 w-size18 p-l-40 p-r-40 p-t-30 p-b-38 m-t-30 m-r-0 m-l-auto p-lr-15-sm">
				<h5 class="m-text20 p-b-24">
					Cart Totals
				</h5>

				<!--  -->
				
                <div class="flex-w flex-sb-m p-t-26 p-b-30">
					<span class="m-text22 w-size19 w-full-sm">
						SubTotal:
					</span>

					<%--<span class="m-text21 w-size20 w-full-sm">
						$39.00
					</span>--%>
                    <asp:Label ID="lblSubTotal" runat="server" class="m-text21 w-size20 w-full-sm" Text=""></asp:Label>
				</div>

				<!--  -->
				<div class="flex-w flex-sb bo10 p-t-15 p-b-20">
					<span class="s-text18 w-size19 w-full-sm">
						Delivery Information
					</span>

					<div class="w-size20 w-full-sm">
						<%--<p class="s-text8 p-b-23">
							There are no shipping methods available. Please double check your address, or contact us if you need any help.
						</p>--%>

						<%--<span class="s-text19">
							Calculate Shipping
						</span>--%>

						<div class="rs2-select2 rs3-select2 rs4-select2 bo4 of-hidden w-size21 m-t-8 m-b-12">
							<%--<select class="selection-2" name="country">
								<option>Select a city...</option>
								<option>Pokhara</option>
								<option>Chitwan</option>
								<option>Biratnagar</option>
							</select>--%>
                            <asp:DropDownList ID="ddlAddress" runat="server">
                                <asp:ListItem>Select your address...</asp:ListItem>
                                <asp:ListItem>Kathmandu</asp:ListItem>
                                <asp:ListItem>Pokhara</asp:ListItem>
                                <asp:ListItem>Chitwan</asp:ListItem>
                                <asp:ListItem>Biratnagar</asp:ListItem>
                                <asp:ListItem>Dharan</asp:ListItem>
                            </asp:DropDownList>
						</div>

						<div class="size13 bo4 m-b-12">
						<%--<input class="sizefull s-text7 p-l-15 p-r-15" type="text" name="state" placeholder="State /  country">--%>
                            <asp:TextBox ID="txtPhoneNUmber" class="sizefull s-text7 p-l-15 p-r-15" placeholder="Phone Number" runat="server"></asp:TextBox>
						</div>

						<%--<div class="size13 bo4 m-b-22">
							<input class="sizefull s-text7 p-l-15 p-r-15" type="text" name="postcode" placeholder="Postcode / Zip">
						</div>--%>

						<%--<div class="size14 trans-0-4 m-b-10">
							<!-- Button -->
							<button class="flex-c-m sizefull bg1 bo-rad-23 hov1 s-text1 trans-0-4">
								Update Totals
							</button>
						</div>--%>
					</div>
				</div>

				<!--  -->
				<div class="flex-w flex-sb-m p-t-26 p-b-30">
					<span class="m-text22 w-size19 w-full-sm">
						Total:
					</span>

					<%--<span class="m-text21 w-size20 w-full-sm">
						$39.00
					</span>--%>
                    <asp:Label ID="lblTotal" runat="server" class="m-text21 w-size20 w-full-sm" Text=""></asp:Label>
				</div>

				<div class="size15 trans-0-4">
					<!-- Button -->
					<%--<button class="flex-c-m sizefull bg1 bo-rad-23 hov1 s-text1 trans-0-4">
						Proceed to Checkout
					</button>--%>
                    <asp:Button ID="btnCheckout" runat="server" class="flex-c-m sizefull bg1 bo-rad-23 hov1 s-text1 trans-0-4" Text="Proceed To Checkout" />
				</div>
			</div>
				<!--  -->
				
				</div>
			</div>
		</div>
	</section>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder5" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder6" Runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder7" Runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder8" Runat="Server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder9" Runat="Server">
</asp:Content>

