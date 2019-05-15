using BarCode.API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarCode.API.Data
{
    public class BookRepo : BaseMongoRepository<Book>, IBookRepo
    {
        private readonly MongoDBContext _mctx;

        public BookRepo(IOptions<Settings> settings)
        {
            _mctx = new MongoDBContext(settings);
        }

        protected override IMongoCollection<Book> Collection
        {
            get
            {
                return _mctx.book;

            }
        }

        public virtual async Task<Book> GetByBarcode(string barcode)
        {
            return await Collection.Find(x => x.BarCode.Equals(barcode)).FirstOrDefaultAsync();
        }
    }
}
