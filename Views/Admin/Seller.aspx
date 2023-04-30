<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Seller.aspx.cs" Inherits="OnlineBookShop.Views.Admin.Seller" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col">
                 <h3 class="text-center">Manage Sellers</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <div class="mb-3">
                    <label for="" class="form-label text-success">Seller Name</label>
                    <input type="text" placeholder="Name" runat="server" id="SNameTb" autocomplete ="off" class="form-control" />
                </div>
                <div class="mb-3">
                    <label for="" class="form-label text-success">Seller Email</label>
                    <input type="email" placeholder="Email" runat="server" id="EmailTb" autocomplete="off" class="form-control" />
                </div>
                <div class="mb-3">
                    <label for="" class="form-label text-success">Seller Phone</label>
                    <input type="text" placeholder="Phone" runat="server" id="PhoneTb" autocomplete="off" class="form-control" />
                </div>
                <div class="mb-3">
                    <label for="" class="form-label text-success">Seller Password</label>
                    <input type="text" placeholder="Password" runat="server" id="AddressTb" autocomplete="off" class="form-control" />
                </div>
                <div class="row">
                    <asp:Label runat="server" ID="ErrMsg" class="text-danger text-center"></asp:Label>
                    <div class="col d-grid">
                        <asp:Button Text="Update" ID="EditBtn" runat="server" class="btn-warning btn-block btn" OnClick="EditBtn_Click" /></div>
                    <div class="col d-grid">
                        <asp:Button Text="Save" ID="SaveBtn" runat="server" class="btn-success btn-block btn" OnClick="SaveBtn_Click" /></div>
                    <div class="col d-grid">
                        <asp:Button Text="Delete" ID="DeleteBtn" runat="server" class="btn-danger btn-block  btn" OnClick="DeleteBtn_Click" /></div>
                </div>
                </div>
            
            <div class="col-md-8">
                <asp:GridView ID="SellerList" runat="server" class="table table-bordered" CellPadding="4" AutoGenerateSelectButton="True" OnSelectedIndexChanged="SellerList_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <Headerstyle BackColor="teal" Font-Bold="False" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
                </div>
            </div>
    </div>
</asp:Content>
