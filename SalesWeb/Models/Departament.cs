using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SalesWeb.Controllers;

namespace SalesWeb.Models
{
    public class Departament
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
        public string? Name { get; set; }
        public ICollection<Seller> Sellers{ get; set; } = new List<Seller>();

        public Departament()
        {
            
        }

        public Departament(int id, string name) 
        {
            Id = id;
            Name = name;
        }


        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime Initial, DateTime Final)
        {
            return Sellers.Sum(seller => seller.TotalSales(Initial, Final));
        }
    }
}