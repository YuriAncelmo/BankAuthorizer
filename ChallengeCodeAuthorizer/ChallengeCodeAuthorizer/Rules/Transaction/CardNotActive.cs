#region References
using ChallengeCodeAuthorizer.States;
using ChallengeCodeAuthorizer.Validation;
#endregion

namespace ChallengeCodeAuthorizer.Rules.Transaction
{
    internal class CardNotActive : IRule
    {
        #region Public Methods
        public bool IsApplicable(State state)
        {
            return state.Account != null && !state.Account.ActiveCard && state.AccountIsCreated();//If card is not active, is applicable for rule
        }
        public Violation Execute()
        {
            return Violation.CardNotActive; 
        }
        #endregion

    }
}
