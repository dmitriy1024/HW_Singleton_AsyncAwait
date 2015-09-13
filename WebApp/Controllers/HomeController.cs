using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var stringsFromDB = await Task.Run(() => GetFromDB());
            
            return View(stringsFromDB);
        }

        public ActionResult TestLogging()
        {
            Logger.Instance.Write("some message");
            return View("Error");
        }

        private List<string> GetFromDB()
        {
            var list = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                list.Add("Lorem ipsum dolor sit amet");
            }

            return list;
        }
    }   
}