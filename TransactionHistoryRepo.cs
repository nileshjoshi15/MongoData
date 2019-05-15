using BarCode.API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BarCode.API.Data
{
    public class TransactionHistoryRepo : BaseMongoRepository<TransactionHistory>, ITransactionHistoryRepo
    {
        private readonly MongoDBContext _mctx;

        public TransactionHistoryRepo(IOptions<Settings> settings)
        {
            _mctx = new MongoDBContext(settings);
        }

        protected override IMongoCollection<TransactionHistory> Collection
        {
            get
            {
                return _mctx.transactionHistory;
            }
        }
    }
}