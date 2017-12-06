using GroceryMart.DomainModels.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GroceryMart.DomainModels.ViewModels
{
    [NotMapped]
    public class ProductViewModel:Product
    {
        public HttpPostedFileBase file { get; set; }
    }
}
