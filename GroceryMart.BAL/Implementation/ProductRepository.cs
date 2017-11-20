using GroceryMart.BAL.Abstration;
using GroceryMart.DAL;
using GroceryMart.DomainModels.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryMart.BAL.Implementation
{
    public class ProductRepository:Repository<Product>,IProductRepository
    {
        private DatabaseContext context
        {
            get
            {
                return db as DatabaseContext;
            }
        }
        public ProductRepository(DbContext db)
        {
            this.db = db;
        }
    }
}
