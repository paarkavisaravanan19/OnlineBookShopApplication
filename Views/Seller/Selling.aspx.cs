using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace OnlineBookShop.Views.Seller
{

    public partial class Selling : System.Web.UI.Page
    {
        Models.Functions Con;
        int SellerId = WebForm1.User;
        string SName = WebForm1.UName;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            if (!IsPostBack)
            {
                ShowBooks();
                DataTable dt= new DataTable();
                dt.Columns.AddRange(new DataColumn[5]
                {
                    new DataColumn("ID"),
                    new DataColumn("Book"),
                    new DataColumn("Price"),
                    new DataColumn("Quantity"),
                    new DataColumn("Total")
                });
                ViewState["Bill"] = dt;
                this.BindGrid();
            }
        }
        protected void BindGrid()
        {
            BillList.DataSource = ViewState["Bill"];
            BillList.DataBind();
        }
        private void ShowBooks()   
        {
            string Query = "select BId as Code, BName as Name, BQty as Stock, BPrice as Price from BookTbl";
            BooksList.DataSource = Con.GetData(Query);
            BooksList.DataBind();
        }
        int Key = 0;
        int Stock = 0;
        protected void BooksList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BNameTb.Value = BooksList.SelectedRow.Cells[2].Text;
            Stock = Convert.ToInt32(BooksList.SelectedRow.Cells[3].Text);
            BPriceTb.Value = BooksList.SelectedRow.Cells[4].Text;
           

            if (BNameTb.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(BooksList.SelectedRow.Cells[1].Text);
            }
        }
        private void InsertBill()
        {
            string Query = "insert into BillTbl values({0},{1})";
            Query = string.Format(Query, SellerId, GrdTotal);
            Con.SetData(Query);

        }
        protected void PrintBtn_Click(object sender, EventArgs e)
        { 
            InsertBill();
        }

        private void UpdateStock()
        {
            int NewQty;
            NewQty = Convert.ToInt32(BooksList.SelectedRow.Cells[3].Text) - Convert.ToInt32(BQtyTb.Value);
            string Query = "update BookTbl set BQty= {0} where BId={1}";
            Query = string.Format(Query, NewQty, BooksList.SelectedRow.Cells[1].Text);
            Con.SetData(Query);
            ShowBooks();
        }
        
        int GrdTotal = 0;
        int Amount = 0;
        protected void AddToBillBtn_Click(object sender, EventArgs e)
        {
            if(BQtyTb.Value == "" || BPriceTb.Value==""|| BNameTb.Value=="")
            {

            }
            else
            {
                int total = Convert.ToInt32(BQtyTb.Value) * Convert.ToInt32(BPriceTb.Value);
                DataTable dt = (DataTable)ViewState["Bill"];
                dt.Rows.Add(BillList.Rows.Count + 1,
                    BNameTb.Value.Trim(),
                    BPriceTb.Value.Trim(),
                    BQtyTb.Value.Trim(),
                    total);
                ViewState["Bill"] = dt;
                this.BindGrid();
                UpdateStock();
                for (int i = 0; i < BillList.Rows.Count - 1; i++)
                {
                    GrdTotal = total + Convert.ToInt32(BillList.Rows[i].Cells[5].Text);
                }
                if (BillList.Rows.Count == 1)
                {
                    GrdTotal = total;
                }
                Amount = GrdTotal;
                GrdTotalTb.Text = "Rs. " + GrdTotal;
                BNameTb.Value = "";
                BPriceTb.Value = "";
                BQtyTb.Value = "";
                GrdTotal = 0;
            }
        }

    }
}