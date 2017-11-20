using GroceryMart.DomainModels.Entities;
using GroceryMart.DomainModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryMart.BAL.Abstration
{
    public interface IOrderRepository:IRepository<Order>
    {
        int SaveCart(Cart model);
        void PlacedOrder(TransactionViewModel model);
    }
}
