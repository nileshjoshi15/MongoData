using BarCode.API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarCode.API.Data
{
    public class UserRepo : BaseMongoRepository<User>, IUserRepo
    {
        private readonly MongoDBContext _mctx;

        public UserRepo(IOptions<Settings> settings)
        {
            _mctx = new MongoDBContext(settings);
        }

        protected override IMongoCollection<User> Collection
        {
            get
            {
                return _mctx.user;
            }
        }

        public virtual async Task<User> GetByBarCodeIdAsync(string id)
        {
            return await Collection.Find(x => x.BarCode.Equals(id)).FirstOrDefaultAsync();
        }
    }
}
