using System.Collections;
namespace FredisChallenge.Entities
{
    public class Fredis
    {
        private Dictionary<string, string> _database { get; set; }
        private List<FredisTransaction> _transactions { get; set; }

        public Fredis()
        {
            _database = new Dictionary<string, string>();
            _transactions = new List<FredisTransaction>();
        }
        private FredisTransaction GetLastTransaction()
        {
            return _transactions.Last();
        }

        public void Set(string key, string value)
        {
            GetLastTransaction().Set(key, value);
        }
        public string? Get(string key)
        {
            return GetLastTransaction().Get(key);
        }
        public void Del(string key)
        {
            GetLastTransaction().Del(key);
        }

        public void Begin()
        {
            FredisTransaction transaction = new FredisTransaction(_database);
            _transactions.Add(transaction);

        }

        public void Commit()
        {
            FredisTransaction transaction = GetLastTransaction();
            transaction.Status = FredisTransactionStatus.Done;
            MergeDatabase(transaction.Transactions);

        }
        public void MergeDatabase(Dictionary<string, string> transactions)
        {
            foreach (var transaction in transactions)
            {
                _database[transaction.Key] = transaction.Value;
            }
        }



    }
}