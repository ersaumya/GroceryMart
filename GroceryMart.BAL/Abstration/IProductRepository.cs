using GroceryMart.DomainModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryMart.BAL.Abstration
{
    public interface IProductRepository:IRepository<Product>
    {
    }
}
