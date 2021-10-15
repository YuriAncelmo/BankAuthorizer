
using ChallengeCodeAuthorizer.States;
using ChallengeCodeAuthorizer.Validation;

namespace ChallengeCodeAuthorizer.Rules.Transaction
{
    public class AccountNotInitialized : IRule
    {
        public bool IsApplicable(State state)
        {
            return !state.accountCreated();
        }
        
        public Violation Execute()
        {
            return Violation.AccountNotInitialized;
        }

        
    }
}
