using System;
using System.ComponentModel.DataAnnotations;

namespace SuperMarket.Core
{
    public class Transa
    {
        [Key]
        public int TransactionId { get; set; }
        public DateTime TimeStamp { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } // au cas ou le nom de produit à changé
        public double Price { get; set; }
        public int BeforeQty { get; set; }
        public int SoldQty { get; set; }
        public string CashierName { get; set; }
    }
}
