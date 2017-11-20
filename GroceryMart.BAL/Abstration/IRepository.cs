using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryMart.BAL.Abstration
{
    public interface IRepository<TEntity> where TEntity:class
    {
        void Add(TEntity model);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(object Id);
        void Modify(TEntity model);
        void Delete(TEntity model);
        void DeleteById(object Id);
    }

}
