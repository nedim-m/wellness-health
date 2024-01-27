using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Model.Transaction;

using wellness.Service.IServices;

namespace wellness.Service.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly Database.DbWellnessContext _context;
        private readonly IMapper _mapper;

        public TransactionService(Database.DbWellnessContext context, IMapper mapper)
        {
            _context=context;
            _mapper=mapper;
        }

        public async Task SaveTransactionAsync(Transaction transaction)
        {

            var obj = _mapper.Map<Database.Transaction>(transaction);

            _context.Transactions.Add(obj);

            await _context.SaveChangesAsync();
        }
    }
}
