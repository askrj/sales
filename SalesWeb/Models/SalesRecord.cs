using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SalesWeb.Models.Enums;

namespace SalesWeb.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Amount { get; set; }
        public SaleStaus Staus { get; set; }
        public Seller Seller { get; set; }

        public SalesRecord()
        {
            
        }

        public SalesRecord(int id, DateTime date, double amount, SaleStaus staus, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Seller = seller;
        }
    }
}