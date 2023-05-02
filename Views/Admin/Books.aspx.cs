using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBookShop.Views.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            //declaring and initializing the connections
            Con = new Models.Functions();
            if (!IsPostBack)
            {
                //getting all the method to be shown in BOOKS MODULE
                ShowBooks();
                GetCategories();
                GetAuthors();
            }
            
        }
        private void ShowBooks()
        {
            //displaying all the Books details in the drop down list
            string Query = "select * from BookTbl";
            BooksList.DataSource = Con.GetData(Query);
            BooksList.DataBind();
        }
        private void GetCategories()
        {
            //displaying all the categories in the drop down list
            string Query = "select * from CategoryTbl";
            BCatCb.DataTextField = Con.GetData(Query).Columns["CatName"].ToString();
            BCatCb.DataValueField = Con.GetData(Query).Columns["CatId"].ToString();
            BCatCb.DataSource = Con.GetData(Query);
            BCatCb.DataBind();

        }
        private void GetAuthors()
        {
            //displaying all the Authors in the drop down list
            string Query = "select * from AuthorTbl";
            BAuthCb.DataTextField = Con.GetData(Query).Columns["AutName"].ToString();
            BAuthCb.DataValueField = Con.GetData(Query).Columns["AutId"].ToString();
            BAuthCb.DataSource = Con.GetData(Query);
            BAuthCb.DataBind();

        }
        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (BNameTb.Value == "" || BAuthCb.SelectedIndex == -1 || BCatCb.SelectedIndex == -1 || QtyTb.Value == "" || PriceTb.Value=="")
                {
                    ErrMsg.Text = "Missing Data!Enter all the details!";
                }
                else
                {
                    //performing insertion in the book details by the admin
                    string BName = BNameTb.Value;
                    string BAuth = BAuthCb.SelectedValue.ToString();
                    string BCategory = BCatCb.SelectedValue.ToString();
                    int Quantity = Convert.ToInt32(QtyTb.Value);
                    int Price= Convert.ToInt32(PriceTb.Value);

                    string Query = "insert into BookTbl values( '{0}',{1}, {2}, {3}, {4})";
                    Query = string.Format(Query, BName, BAuth, BCategory, Quantity,Price);
                    Con.SetData(Query);
                    ShowBooks();
                    ErrMsg.Text = "Book Details has been  Inserted Successfully!!";
                    BNameTb.Value = "";
                    BAuthCb.SelectedIndex = -1;
                    BCatCb.SelectedIndex = -1;
                    QtyTb.Value = "";
                    PriceTb.Value = "";
                }
            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }
        int Key = 0;
        protected void BooksList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Displaying BookDetails in Table Format
            BNameTb.Value = BooksList.SelectedRow.Cells[2].Text;
            BAuthCb.SelectedValue = BooksList.SelectedRow.Cells[3].Text;
            BCatCb.SelectedValue = BooksList.SelectedRow.Cells[4].Text;
            QtyTb.Value = BooksList.SelectedRow.Cells[5].Text;
            PriceTb.Value = BooksList.SelectedRow.Cells[6].Text;

            if (BNameTb.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(BooksList.SelectedRow.Cells[1].Text);
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (BNameTb.Value == "" || BAuthCb.SelectedIndex == -1 || BCatCb.SelectedIndex == -1 || QtyTb.Value == "" || PriceTb.Value == "")
                {
                    ErrMsg.Text = "Missing Data!Enter all the details!";
                }
                else
                {
                    //Performing Updation
                    string BName = BNameTb.Value;
                    string BAuth = BAuthCb.SelectedValue.ToString();
                    string BCategory = BCatCb.SelectedValue.ToString();
                    int Quantity = Convert.ToInt32(QtyTb.Value);
                    int Price = Convert.ToInt32(PriceTb.Value);

                    string Query = "delete from BookTbl where BId={0}";
                    Query = string.Format(Query, BooksList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowBooks();
                    ErrMsg.Text = "Book Details has been  Inserted Successfully!!";
                    BNameTb.Value = "";
                    BAuthCb.SelectedIndex = -1;
                    BCatCb.SelectedIndex = -1;
                    QtyTb.Value = "";
                    PriceTb.Value = "";
                }
            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (BNameTb.Value == "" || BAuthCb.SelectedIndex == -1 || BCatCb.SelectedIndex == -1 || QtyTb.Value == "" || PriceTb.Value == "")
                {
                    ErrMsg.Text = "Missing Data!Enter all the details!";
                }
                else
                {
                    //deleting record from the server
                    string BName = BNameTb.Value;
                    string BAuth = BAuthCb.SelectedValue.ToString();
                    string BCategory = BCatCb.SelectedValue.ToString();
                    int Quantity = Convert.ToInt32(QtyTb.Value);
                    int Price = Convert.ToInt32(PriceTb.Value);

                    string Query = "update BookTbl set BName= '{0}',BAuthor={1}, BCategory={2}, BQty= {3}, BPrice={4} where BId={5}";
                    Query = string.Format(Query, BName, BAuth, BCategory, Quantity, Price, BooksList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowBooks();
                    ErrMsg.Text = "Book Details has been  Updated Successfully!!";
                    BNameTb.Value = "";
                    BAuthCb.SelectedIndex = -1;
                    BCatCb.SelectedIndex = -1;
                    QtyTb.Value = "";
                    PriceTb.Value = "";
                }
            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }
    }
}