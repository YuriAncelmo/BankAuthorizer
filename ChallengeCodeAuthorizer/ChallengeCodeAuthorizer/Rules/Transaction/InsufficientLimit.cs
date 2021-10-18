#region References
using ChallengeCodeAuthorizer.States;
using ChallengeCodeAuthorizer.Validation;
#endregion

namespace ChallengeCodeAuthorizer.Rules.Transaction
{
    internal class InsufficientLimit : IRule
    {
        #region Public Methods
        public bool IsApplicable(State state)
        {
            if (state.currentTransaction != null && state.Account != null)
                return state.currentTransaction.Amount >= state.Account.AvailableLimit
                    && state.AccountIsCreated();
            else return false;
        }
        public Violation Execute()
        {
            return Violation.InsufficientLimit;
        }
        #endregion
    }
}
