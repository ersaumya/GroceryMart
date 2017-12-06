using GroceryMart.BAL.Abstration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryMart.BAL
{
    public interface IUnitOfWork
    {
        IAuthenticateRepository AuthenticateRepo { get; }
        ICategoryRepository CategoryRepo { get; }
        IOrderRepository OrderRepo { get; }
        IProductRepository ProductRepo { get; }
        int SaveChanges();
    }
}
