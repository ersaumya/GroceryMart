using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryMart.DomainModels.ViewModels
{
    public class ReceiptViewModel
    {
        public string TransactionId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Amount { get; set; }
        public string Status { get; set; }
        public string PaymentType { get; set; }
    }
}
