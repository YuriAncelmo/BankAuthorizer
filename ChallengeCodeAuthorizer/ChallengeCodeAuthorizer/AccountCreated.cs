
using ChallengeCodeAuthorizer.Model;

namespace ChallengeCodeAuthorizer
{
    public class AccountCreated : State
    {
        public AccountCreated(State state) :this(state.Account){  
        }
        public AccountCreated(Account account)
        {
            this.Account = account;
        }
        public override ResponseAccount getResponseAccount()
        {
            ResponseAccount responseAccount = new ResponseAccount();    
            responseAccount.account = this.Account;
            responseAccount.violations = new object[] { Violation.AccountAlreadyInitialized.Value };
            return responseAccount;
        }

    }
}
