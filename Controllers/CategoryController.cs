using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineBookShop.Models;

namespace OnlineBookShop.Controllers
{
    public class CategoryController : ApiController
    {
        public IHttpActionResult GetCatDetails()
        {
            BookShopASPDBEntities db = new BookShopASPDBEntities();
            var result = db.CategoryTbls.ToList();
            return Ok(result);
        }
    }
}
