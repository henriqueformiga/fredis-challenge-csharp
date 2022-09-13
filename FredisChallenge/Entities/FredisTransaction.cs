using System.Transactions;
namespace FredisChallenge.Entities
{
    public class FredisTransaction
    {
        public Dictionary<string, string> Transactions { get; set; }
        public FredisTransactionStatus Status {get; set;} = FredisTransactionStatus.Open;


        public FredisTransaction(Dictionary<string, string> database)
        {
            Transactions = new Dictionary<string, string>();
            MergeDatabase(database);
            
        }

        public void MergeDatabase(Dictionary<string, string> transactions)
        {
            foreach (var transaction in transactions)
            {
                Transactions[transaction.Key] = transaction.Value;
            }
        }
        

        public void Set(string key, string value)
        {
            Transactions[key] = value;
        }
        public string? Get(string key)
        {
            return Transactions[key] ?? null;
        }
        public void Del(string key)
        {
            Transactions.Remove(key);
        }

    }

}