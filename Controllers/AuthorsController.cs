using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineBookShop.Models;

namespace OnlineBookShop.Controllers
{
    public class AuthorsController : ApiController
    {
        public IHttpActionResult GetAutdetails()
        {
            BookShopASPDBEntities1 db2 = new BookShopASPDBEntities1();
            var result2 = db2.AuthorTbls.ToList();
            return Ok(result2);
        }
    }
}
