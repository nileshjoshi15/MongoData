using BarCode.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarCode.API.Data
{
    public interface IBookRepo : IRepository<Book, string>
    {
        Task<Book> GetByBarcode(string barcode);
    }
}
