using ChallengeCodeAuthorizer.Models;

namespace ChallengeCodeAuthorizer.States
{
    public class AccountCreated : State
    {
        public AccountCreated(State state) : this(state.Account)
        {
        }
        public AccountCreated(Account account)
        {
            Account = account;
        }
        public override ResponseAccount getResponseAccount()
        {
            ResponseAccount responseAccount = new ResponseAccount();
            responseAccount.account = Account;
            responseAccount.violations = new object[] { Violation.AccountAlreadyInitialized.Value };
            return responseAccount;
        }

    }
}
