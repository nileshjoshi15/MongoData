using BarCode.API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarCode.API.Data
{
    public class MongoDBContext
    {
        private IMongoDatabase MongoDatabase { get; }
        
        public MongoDBContext(IOptions<Settings> settings)
        {
            var mongoUrl = new MongoUrl(settings.Value.ConnectionString);
            IMongoClient client = new MongoClient(mongoUrl);
            MongoDatabase = client.GetDatabase(mongoUrl.DatabaseName);
        }


        public IMongoCollection<Book> book => MongoDatabase.GetCollection<Book>("Books");
        public IMongoCollection<User> user => MongoDatabase.GetCollection<User>("Users");
        public IMongoCollection<CheckedOutBook> checkedOutBooks => MongoDatabase.GetCollection<CheckedOutBook>("Checkedoutbooks");
        public IMongoCollection<TransactionHistory> transactionHistory => MongoDatabase.GetCollection<TransactionHistory>("TransactionHistory");
    }
}
