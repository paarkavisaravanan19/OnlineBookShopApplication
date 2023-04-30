<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Seller/SellerMaster.Master" AutoEventWireup="true" CodeBehind="Selling.aspx.cs" Inherits="OnlineBookShop.Views.Seller.Selling" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function PrintBill()
        {
            var PGrid = document.getElementById('<%=BillList.ClientID%>');
            PGrid.bordr = 0;
            var PWin = window.open('', 'PrintGrid', 'left=100, top=100, width=1024,height=768, tollbar = 0, scrollbars=1, status =0, resizable=1');
            PWin.document.write(PGrid.outerHTML);
            PWin.document.close();
            PWin.focus();
            PWin.print();
            
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
    <div class="container-fluid">
        <div class="row">

        </div>
        <div class="row">
            <div class="col-md-5">
                <h3  class="text-center" style="color:teal;"><b>Book Details</b></h3>
                <div class="row">
                    <div class="col">
                        <div class="mt-3">
                              <label for="" class="form-label text-success">Book Name</label>
                              <input type="text" placeholder="Book Name" autocomplete="off" class="form-control" id="BNameTb"  runat="server"/>
                        </div>
                    </div>
                    <div class="col">
                        <div class="mt-3">
                              <label for="" class="form-label text-success">Book Price</label>
                              <input type="text" placeholder="Your Email" autocomplete="off" class="form-control" id="BPriceTb"  runat="server"/>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <div class="mt-3">
                              <label for="" class="form-label text-success">Quantity</label>
                              <input type="text" placeholder="Quantity" autocomplete="off" class="form-control" id="BQtyTb"  runat="server"/>
                        </div>
                    </div>
                    <div class="col">
                        <div class="mt-3">
                              <label for="" class="form-label text-success">Date</label>
                              <input type="datetime"  class="form-control" id="DateTb"  runat="server"/>
                        </div>
                    </div>
                    
                </div>
                <br />
                <div class="row">
                        <div class="col d-grid">
                            <asp:Button Text="Add To Bill" runat="server" ID="AddToBillBtn" class="btn-warning btn-block btn" OnClick="AddToBillBtn_Click" />
                        </div>
                    </div>
                <div class="row mt-5">
                     <h4  class="text-center" style="color:brown;" ><b>Book List</b></h4>
                    <div class="col">
                        <asp:GridView ID="BooksList" runat="server" class="table table-bordered" CellPadding="4" AutoGenerateSelectButton="True" OnSelectedIndexChanged="BooksList_SelectedIndexChanged">
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
            <div class="col-md-7">
                <h4  class="text-center" style="color: crimson;" ><b>Client's Bill</b></h4>
                    <div class="col">
                        <asp:GridView ID="BillList" runat="server" class="table table-bordered" CellPadding="4" AutoGenerateSelectButton="True" OnSelectedIndexChanged="BooksList_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <Headerstyle BackColor="SlateBlue" Font-Bold="False" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>

                        <div class="d-grid">
                            <asp:Label runat="server" ID="GrdTotalTb" class="text-danger text-center"></asp:Label><br />
                            <asp:Button Text="Print" runat="server" ID="PrintBtn" OnClientClick="PrintBill()" class="btn-warning btn-block btn" OnClick="PrintBtn_Click" />
                    </div>
                       
                    </div>
            </div>
        </div>
    </div>
</asp:Content>
