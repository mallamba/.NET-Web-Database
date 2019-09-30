using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
	public class Client
	{

		public Client() { }

		public Client(int id, string name)
		{
			this.Id = id;
			this.Name = name;
		}

		public int Id { get; set; }

		public string Name { get; set; }


		public class ViewModell
		{
			public IEnumerable<Client> ClientDetailList { get; set; }
		}

	}
}
