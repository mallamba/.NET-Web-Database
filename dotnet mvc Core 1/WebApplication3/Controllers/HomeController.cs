using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;



namespace WebApplication3.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			string s = "Text i en sessionsvariabel på Index-hem-sidan";
			HttpContext.Session.SetString("indextext", s);
            ViewBag.text = s;
            return View();
		}


		public IActionResult Omoss()
		{
            string s = "Text i en sessionsvariabel på Omoss-sidan";
            HttpContext.Session.SetString("omosstext", s);
            ViewData["Message"] = "Text som har sparats i ViewData";
			ViewBag.text1 = "Tect som har sparats i ViewBag";
            ViewBag.text2 = s;
            return View();
		}


		public IActionResult Extra()
		{
			string s2 = HttpContext.Session.GetString("indextext");
			ViewBag.indextext = s2;
            s2 = HttpContext.Session.GetString("omosstext");
            ViewBag.omosstext = s2;
            return View();
		}


		public IActionResult Modell()
		{
            Item myitem = new Item();
            //myitem.Name = "hÄR ÄR NAMNET ÄNDRAT";
            string s1 = JsonConvert.SerializeObject(myitem);
            HttpContext.Session.SetString("modell", s1);
            ViewBag.jsonsträng1 = s1;
            return View(myitem);
        }


		public IActionResult Modell2()
		{
            string s2 = HttpContext.Session.GetString("modell");
            ViewBag.jsonsträng2 = s2;
            Item myitem2 = JsonConvert.DeserializeObject<Item>(s2);
            return View(myitem2);
        }


		public IActionResult Client()
		{

			List<Client> clients = new List<Client>
			{
				new Client(1, "Axis AB"),
				new Client(2, "Handi AB"),
				new Client(3, "Sandi AB"),
				new Client(4, "Britt Marie ek")
			};

			ViewData["clients-in-list"] = clients;



			List<Client> clients2 = new List<Client>
			{
				new Client(1, "Beev"),
				new Client(2, "Naaast"),
				new Client(3, "Craast"),
				new Client(4, "Ubiin")
			};

			ViewBag.clients = clients2;


			List<Client> clients3 = new List<Client>
			{
				new Client(1, "Asdfg"),
				new Client(2, "Qwert"),
				new Client(3, "Zxcvb"),
				new Client(4, "Uiopå")
			};


            Client.ViewModell vm = new Client.ViewModell();
            vm.ClientDetailList = clients3;

			return View(vm);

		}

        public IActionResult Itemlist1()
        {
            var itemlist = new List<Item>();
            itemlist.Add(new Item { Id = 1, Name = "Bertile" });
            itemlist.Add(new Item { Id = 2, Name = "Louise" });

            string s = JsonConvert.SerializeObject(itemlist);

            ViewBag.jsonsträng3 = s;

            HttpContext.Session.SetString("itemlist1", s);
            return View(itemlist);
        }


        public IActionResult ItmlistFromSession()
        {
            var itemlist = new List<Item>();
            string s = HttpContext.Session.GetString("itemlist1");
            if(s != null  || s == "")
            {
                itemlist = JsonConvert.DeserializeObject<List<Item>>(s);
            }
            
            return View(itemlist);
        }





        [HttpGet]
        public IActionResult Form1()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Form1(IFormCollection fc)
        {
            string s = fc["textexempel"];
            ViewBag.form1 = s;
            return View();
        }





        [HttpGet]
        public IActionResult Form2()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Form2(IFormCollection fc)
        {
            string s = fc["textexempel"];
            ViewBag.form2 = s;
            return View();
        }




        [HttpGet]
        public IActionResult Form3()
        {
            return View();
        }



        [HttpGet]
        public IActionResult Form4([FromQuery]string form3text)
        {
            ViewBag.form4 = form3text;
            return View();
        }




        public IActionResult SignIn()
        {
            return View();
        }



        public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
