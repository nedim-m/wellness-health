using AutoMapper;
using System.Threading.Tasks;
using wellness.Model.Transaction;
using wellness.Service.Database;
using wellness.Service.IServices;

namespace wellness.Service.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly DbWellnessContext _context;
        private readonly IMapper _mapper;

        public TransactionService(DbWellnessContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task SaveTransactionAsync(Model.Transaction.Transaction transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction), "Transaction cannot be null");
            }

            var obj = _mapper.Map<Database.Transaction>(transaction);

            _context.Transactions.Add(obj);

            await _context.SaveChangesAsync();
        }
    }
}