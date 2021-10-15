using ChallengeCodeAuthorizer.States;
using ChallengeCodeAuthorizer.Validation;

namespace ChallengeCodeAuthorizer.Rules.Account
{
    internal class AccountAlreadyInitialized : IRule
    {
        public bool IsApplicable(State state)
        {
            return state.accountCreated();
        }
        public Violation Execute()
        {
            return Violation.AccountAlreadyInitialized;
        }

     
    }
}
