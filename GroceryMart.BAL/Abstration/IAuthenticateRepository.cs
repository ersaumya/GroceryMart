using GroceryMart.DomainModels.Entities;
using GroceryMart.DomainModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryMart.BAL.Abstration
{
    public interface IAuthenticateRepository:IRepository<User>
    {
        UserViewModel ValidateUser(string Username, string Password);
    }
}
