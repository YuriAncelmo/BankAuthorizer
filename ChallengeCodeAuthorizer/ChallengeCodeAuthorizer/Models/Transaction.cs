

using Newtonsoft.Json;

namespace ChallengeCodeAuthorizer.Models
{
    public class Transaction
    {
        public string merchant { get; set; }
        public int amount { get; set; }
        public DateTime time { get; set; }
        [JsonIgnore]
        public bool executed { get; set; }
        public Transaction()
        {
            executed = false;
        }
        public ResponseAccount Process(Account account)
        {
            ResponseAccount response = new ResponseAccount(account);
            
            //Available Limit
            if (account.availablelimit > amount)
                account.availablelimit -= amount;
            else
                response = Validation.TransactionViolations(account, Violation.InsufficientLimit);
            
            return response;
        }
    }

}
