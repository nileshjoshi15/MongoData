using BarCode.API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarCode.API.Data
{
    public class CheckedOutBookRepo : BaseMongoRepository<CheckedOutBook>, ICheckedOutBookRepo
    {
        private readonly MongoDBContext _mctx;

        public CheckedOutBookRepo(IOptions<Settings> settings)
        {
            _mctx = new MongoDBContext(settings);
        }

        protected override IMongoCollection<CheckedOutBook> Collection
        {
            get
            {
                return _mctx.checkedOutBooks;

            }
        }

        public virtual async Task<CheckedOutBook> GetCheckedoutBookByBookIdAsync(string bookid)
        {
            return await Collection.Find(x => x.BookId.Equals(bookid)).FirstOrDefaultAsync();
        }
    }
}
