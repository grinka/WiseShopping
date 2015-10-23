using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheBesShopping.Code;
using TheBesShopping.Models.Data;

namespace TheBesShopping.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult TestSqlConnection()
        {
            //using ( var connection = ConnectionFactory.GetOpenConnection() )
            //{
            //    var dd = connection.Query<test_table>( "select * from test_table" );
            //    ViewBag.Data = dd;
            //}
            //ViewBag.Data = "Testing";
            //ViewBag.Data = new { Test = new { } };
            ViewBag.Message = "Testing SQL Connection With Dapper.";
            return View();
        }
    }
}