using GroceryMart.BAL.Abstration;
using GroceryMart.DAL;
using GroceryMart.DomainModels.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryMart.DomainModels.ViewModels;

namespace GroceryMart.BAL.Implementation
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private DatabaseContext context
        {
            get
            {
                return db as DatabaseContext;
            }
        }

        public OrderRepository(DbContext db)
        {
            this.db = db;
        }
        public int SaveCart(Cart model)
        {
            context.Carts.Add(model);
            context.SaveChanges();
            return model.CartId; 
        }

        public void PlacedOrder(TransactionViewModel model)
        {
            Transaction tran = new Transaction();
            tran.Amount = model.Amount;
            tran.CartId = model.CartId;
            tran.Tran_Id = model.Tran_Id;
            tran.CreatedDate = DateTime.Now;
            tran.PaymentType = model.PaymentType;
            tran.Status = model.Status;
            Cart cart = context.Carts.Where(c => c.CartId == model.CartId).FirstOrDefault();

            if (tran.Status == "success")
            {

                Order ord = new Order();
                ord.CartId = cart.CartId;
                ord.CreatedDate = DateTime.Now;
                ord.CustomerName = model.Name;
                ord.ShippingAddress = model.Address;
                ord.Total = cart.Total;
                ord.UserId = cart.UserId;

                foreach (var item in cart.Items)
                {
                    OrderItem obj = new OrderItem();
                    obj.ProductId = item.ProductId;
                    obj.Quantity = item.Quantity;
                    obj.Total = item.Total;
                    obj.UnitPrice = item.UnitPrice;

                    ord.OrderItems.Add(obj);
                }
                context.Orders.Add(ord);
            }
            tran.UserId = cart.UserId;
            context.Transactions.Add(tran);
        }
    }
}
