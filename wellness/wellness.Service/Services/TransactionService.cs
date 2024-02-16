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

   

        public async Task SaveTransactionAsync(object transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction), "Transaction cannot be null");
            }

           
            var amountObject = GetPropertyValue<object>(transaction, "Amount");
            var currency = GetPropertyValue<string>(transaction, "Currency");
            var paymentMethod = GetPropertyValue<string>(transaction, "PaymentMethod");
            var timeStamp = GetPropertyValue<DateTime>(transaction, "Timestamp");
            var membershipTypeId = GetPropertyValue<int>(transaction, "MemberShipTypeId");
            var userId = GetPropertyValue<int>(transaction, "UserId");


            decimal amount;
            if (amountObject is int intAmount)
            {
                amount = intAmount / 100m;
            }
            else if (amountObject is decimal decimalAmount)
            {
                amount = decimalAmount;
            }
            else
            {
                throw new ArgumentException("Invalid type for Amount property", nameof(transaction));
            }

            var transactionToInsert = new Model.Transaction.Transaction
            {
                Amount = amount,
                Currency = currency,
                PaymentMethod = paymentMethod,
                Timestamp = timeStamp,
                MemberShipTypeId = membershipTypeId,
                UserId= userId
            };

            if (transactionToInsert == null)
            {
                throw new ArgumentException("Invalid transaction object", nameof(transaction));
            }

            var obj = _mapper.Map<Database.Transaction>(transactionToInsert);

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

           
            throw new ArgumentException($"Property '{propertyName}' not found or invalid type on object", nameof(propertyName));
        }

    }
}