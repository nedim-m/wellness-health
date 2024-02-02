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

        /*public async Task SaveTransactionAsync(Model.Transaction.Transaction transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction), "Transaction cannot be null");
            }

            var obj = _mapper.Map<Database.Transaction>(transaction);

            _context.Transactions.Add(obj);

            await _context.SaveChangesAsync();
        }*/

        public async Task SaveTransactionAsync(object transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction), "Transaction cannot be null");
            }

            // Assuming transaction has Amount and Currency properties
            var amount = GetPropertyValue<int>(transaction, "Amount");
            var currency = GetPropertyValue<string>(transaction, "Currency");
            var paymentMethod = GetPropertyValue<string>(transaction, "PaymentMethod");
            var timeStamp = GetPropertyValue<DateTime>(transaction, "Timestamp");
            var membershipTypeId = GetPropertyValue<int>(transaction, "MemberShipTypeId");

            var transactiontoInsert = new Model.Transaction.Transaction
            {
                Amount = amount/100,
                Currency = currency,
                PaymentMethod = paymentMethod,
                Timestamp=timeStamp,
                MemberShipTypeId= membershipTypeId,
            };

            if (transactiontoInsert == null)
            {
                throw new ArgumentException("Invalid transaction object", nameof(transaction));
            }

            var obj = _mapper.Map<Database.Transaction>(transactiontoInsert);

            _context.Transactions.Add(obj);

            await _context.SaveChangesAsync();
        }

        private T GetPropertyValue<T>(object obj, string propertyName)
        {
            var propertyInfo = obj.GetType().GetProperty(propertyName);
            if (propertyInfo != null)
            {
                return (T)propertyInfo.GetValue(obj);
            }

            // Handle property not found or invalid type
            throw new ArgumentException($"Property '{propertyName}' not found or invalid type on object", nameof(propertyName));
        }

    }
}