#region References
using ChallengeCodeAuthorizer.States;
using ChallengeCodeAuthorizer.Validation;
#endregion

namespace ChallengeCodeAuthorizer.Rules.Transaction
{
    public class AccountNotInitialized : IRule
    {
        #region Public Methods
        public bool IsApplicable(State state)
        {
            return !state.AccountIsCreated();
        }
        
        public Violation Execute()
        {
            return Violation.AccountNotInitialized;
        }
        #endregion

    }
}
