using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeCodeAuthorizer
{
    public class AccountCreated : State
    {
        public override ResponseAccount getResponseAccount()
        {
            ResponseAccount responseAccount = new ResponseAccount();    
            responseAccount.account = this.Account;
            responseAccount.violations = new object[] { Violation.AccountAlreadyInitialized };
            return responseAccount;
            
        }

        public override void Handle(Context context)
        {
            context.State = new AccountCreated();
        }
    }
}
