using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryMart.BAL.Abstration;
using GroceryMart.BAL.Implementation;
using System.Data.Entity;
using GroceryMart.DAL;

namespace GroceryMart.BAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext db;
        public UnitOfWork()
        {
            db = new DatabaseContext();
        }

        private IAuthenticateRepository _authenticateRepo;
        public IAuthenticateRepository AuthenticateRepo
        {
            get
            {
                if (_authenticateRepo == null)
                    _authenticateRepo = new AuthenticateRepository(db);

                return _authenticateRepo;
            }
        }

        private ICategoryRepository _categoryRepo;
        public ICategoryRepository CategoryRepo
        {
            get
            {
                if (_categoryRepo == null)
                    _categoryRepo = new CategoryRepository(db);

                return _categoryRepo;
            }
        }
        private IProductRepository _productRepo;
        public IProductRepository ProductRepo
        {
            get
            {
                if (_productRepo == null)
                    _productRepo = new ProductRepository(db);

                return _productRepo;
            }
        }
        private IOrderRepository _orderRepo;
        public IOrderRepository OrderRepo
        {
            get
            {
                if (_orderRepo == null)
                    _orderRepo = new OrderRepository(db);

                return _orderRepo;
            }
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }


       
    }
}
