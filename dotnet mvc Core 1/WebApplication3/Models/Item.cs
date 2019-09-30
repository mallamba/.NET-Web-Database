using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Item
    {
        [Required]
        [Display(Name = "Könummer")]
		public int Id { get; set; }


        [Required]
        [Display(Name = "Namn")]
        public string Name { get; set; }

		public Item()
		{
			Id = 1;
			Name = "Test Modell";
		}

	}
}
