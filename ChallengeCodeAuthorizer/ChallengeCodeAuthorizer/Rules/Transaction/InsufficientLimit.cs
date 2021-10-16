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
            return state.currentTransaction.amount >= state.Account.availablelimit  && state.accountCreated();
        }
        public Violation Execute()
        {
            return Violation.InsufficientLimit;
        }
        #endregion
    }
}
