using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeCodeAuthorizer.Model
{
    public class Transaction
    {
        public string merchant { get; set; }
        public int amount { get; set; }
        public DateTime time { get; set; }
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
