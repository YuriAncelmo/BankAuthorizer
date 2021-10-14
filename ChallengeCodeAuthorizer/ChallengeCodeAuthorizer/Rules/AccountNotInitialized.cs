
namespace ChallengeCodeAuthorizer.Rules
{
    public class AccountNotInitialized : IRule
    {
        public bool IsApplicable(State state)
        {
            return state.GetType() == typeof(AccountNotCreated);
        }
        
        public Violation Execute()
        {
            return Violation.AccountNotInitialized;
        }

        
    }
}
