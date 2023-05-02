﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBookShop.Views.Admin
{
    public partial class Author : System.Web.UI.Page
    {
        //declaring model
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con= new Models.Functions();
            //calling method
            ShowAuthors();
        }
        private void ShowAuthors()
        {
            //book details display from server
            string Query = "Select * from AuthorTbl";
            AuthorsList.DataSource = Con.GetData(Query);
            AuthorsList.DataBind();
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(ANameTb.Value==""|| GenCb.SelectedIndex==-1||CountryCb.SelectedIndex == -1)
                {
                    ErrMsg.Text = "Missing Data!!";
                }
                else
                {
                    //inserting book details by the admin
                    string AName = ANameTb.Value;
                    string Gender= GenCb.SelectedItem.ToString();
                    string Country=CountryCb.SelectedItem.ToString();
                    string Query = "insert into AuthorTbl values( '{0}','{1}','{2}')";
                    Query= string.Format(Query, AName, Gender, Country);
                    Con.SetData(Query);
                    ShowAuthors();
                    ErrMsg.Text = "Author Details has been  inserted Successfully!!";
                    ANameTb.Value = "";
                    GenCb.SelectedIndex = -1;
                    CountryCb.SelectedIndex = -1;
                }
            }
            catch (Exception ex) 
            {
                ErrMsg.Text = ex.Message;
            }
        }
        int Key = 0;
        protected void AuthorsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //visualizing the book details in the table format
            ANameTb.Value = AuthorsList.SelectedRow.Cells[2].Text;
            GenCb.SelectedItem.Value = AuthorsList.SelectedRow.Cells[3].Text;
            CountryCb.SelectedItem.Value = AuthorsList.SelectedRow.Cells[4].Text;
            if (ANameTb.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(AuthorsList.SelectedRow.Cells[1].Text);
            }

        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            //updating book details
            try
            {
                if (ANameTb.Value == "" || GenCb.SelectedIndex == -1 || CountryCb.SelectedIndex == -1)
                {
                    ErrMsg.Text = "Missing Data!!";
                }
                else
                {
                    string AName = ANameTb.Value;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Country = CountryCb.SelectedItem.ToString();
                    string Query = "update AuthorTbl set AutName ='{0}',AutGender='{1}',AutCountry='{2}' where AutId={3}";
                    Query = string.Format(Query, AName, Gender, Country, AuthorsList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowAuthors();
                    ErrMsg.Text = "Author Details has been  Updated Successfully!!";
                    ANameTb.Value = "";
                    GenCb.SelectedIndex = -1;
                    CountryCb.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            //deleting the record from the server based on bookId
            try
            {
                if (ANameTb.Value == "" || GenCb.SelectedIndex == -1 || CountryCb.SelectedIndex == -1)
                {
                    ErrMsg.Text = "Select an Author Data!!";
                }
                else
                {
                    string AName = ANameTb.Value;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Country = CountryCb.SelectedItem.ToString();
                    string Query = "delete from AuthorTbl where AutId={0}";
                    Query = string.Format(Query,AuthorsList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowAuthors();
                    ErrMsg.Text = "Author Details has been  Deleted Successfully!!";
                    ANameTb.Value = "";
                    GenCb.SelectedIndex = -1;
                    CountryCb.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }
    }
}