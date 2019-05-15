using BarCode.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarCode.API.Data
{
    public interface IUserRepo : IRepository<User, string>
    {
        Task<User> GetByBarCodeIdAsync(string id);
    }
}
