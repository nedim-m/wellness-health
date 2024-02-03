using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Model.Transaction;

namespace wellness.Service.IServices
{
    public interface ITransactionService
    {
        /*Task SaveTransactionAsync(Transaction transaction);*/
        Task SaveTransactionAsync(object transaction);
    }
}
