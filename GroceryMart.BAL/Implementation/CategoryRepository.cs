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
    public class CategoryRepository:Repository<Category>,ICategoryRepository
    {
        public DatabaseContext context
        {
            get
            {
                return db as DatabaseContext;
            }
        }
        public CategoryRepository(DbContext db)
        {
            this.db = db;
        }
    }
}
