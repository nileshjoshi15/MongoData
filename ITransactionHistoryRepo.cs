using BarCode.API.Models;

namespace BarCode.API.Data
{
    public interface ITransactionHistoryRepo : IRepository<TransactionHistory, string>
    {
    }
}
