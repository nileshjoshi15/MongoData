using BarCode.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarCode.API.Data
{
    public interface ICheckedOutBookRepo : IRepository<CheckedOutBook, string>
    {
        Task<CheckedOutBook> GetCheckedoutBookByBookIdAsync(string bookid);
    }
}
