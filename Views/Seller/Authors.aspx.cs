using OnlineBookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBookShop.Views.Seller
{
    public partial class Authors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IEnumerable<AuthorsClass> catobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44340/api/");
            var consumeapi = hc.GetAsync("Authors");
            consumeapi.Wait();
            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displayrecords = readdata.Content.ReadAsAsync<IList<AuthorsClass>>();
                displayrecords.Wait();
                catobj = displayrecords.Result;
                AuthorsGridView.DataSource = catobj;
                AuthorsGridView.DataBind();
            }
        }
    }
}