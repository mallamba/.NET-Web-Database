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
			String s = "Text i en sessionsvariabel";
			HttpContext.Session.SetString("test", s);
			return View();
		}


		public IActionResult Omoss()
		{
			ViewData["Message"] = "Laboration nummer 1";
			ViewBag.text1 = "I Laborationen utforskar vi Visual Studio och MVC-arkitekturen";

			return View();
		}


		public IActionResult Extra()
		{
			String s2 = HttpContext.Session.GetString("test");
			ViewBag.text2 = s2;
			return View();
		}


		public IActionResult Modell()
		{
			Item myitem = new Item();
			//string s = JsonConvert.SerializeObject(myitem);

			return View(myitem);
		}


		public IActionResult Modell2()
		{
			Item myitem = new Item();
			return View(myitem);
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


			Client.ViewModell vm = new Client.ViewModell
			{
				ClientDetailList = clients3
			};

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
