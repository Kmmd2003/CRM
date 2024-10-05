using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Invoice
    {
        public int id { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime RegDate { get; set; }
        public bool IsCheckedOut { get; set; }
        public DateTime CheckoutDate { get; set; }
        public customer customer { get; set; } 
        public User User { get; set; } 
        public List<Product> products { get; set; } = new List<Product>();

    }
}
