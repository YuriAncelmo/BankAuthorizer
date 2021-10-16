#region References
using ChallengeCodeAuthorizer.States;
using ChallengeCodeAuthorizer.Validation;
#endregion

namespace ChallengeCodeAuthorizer.Rules.Account
{
    public class AccountAlreadyInitialized : IRule
    {
        #region Public methods
        public bool IsApplicable(State state)
        {
            return state.accountCreated();
        }
        public Violation Execute()
        {
            return Violation.AccountAlreadyInitialized;
        }
        #endregion

    }
}
