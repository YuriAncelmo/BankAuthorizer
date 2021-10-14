
using ChallengeCodeAuthorizer.States;

namespace ChallengeCodeAuthorizer.Rules
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
