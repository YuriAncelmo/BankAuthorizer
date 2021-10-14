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

        public override bool accountCreated()
        {
            return true;
        }

        public override ResponseAccount getResponseAccount(List<Violation> violations)
        {
            //TODO I can be better
            string[] values = new string[violations.Count];
            for (int i = 0; i < violations.Count; i++)
            {
                values[i] = violations[i].Value;
            }

            ResponseAccount responseAccount = new ResponseAccount();
            responseAccount.account = Account;
            responseAccount.violations = values;
            return responseAccount;
        }

    }
}
