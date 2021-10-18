#region References
using ChallengeCodeAuthorizer.States;
using ChallengeCodeAuthorizer.Validation;
#endregion

namespace ChallengeCodeAuthorizer.Rules.Transaction
{
    internal class DoubleTransaction : IRule
    {
        #region Public Methods
        public bool IsApplicable(State state)
        {
            if (state != null && state.Account != null && state.currentTransaction != null)
                ///TODO: need confirm if the 2 is inclusive or exclusive
                return state.Account.Transactions.Any(transaction =>
                        (state.currentTransaction.Time - transaction.Time).Minutes < 2 //Transactions where range is less than 2
                      && transaction.Merchant == state.currentTransaction.Merchant
                      && transaction.Amount == state.currentTransaction.Amount)
                         && state.AccountIsCreated(); //Count if is more than 3      
            else return false;
        }
        public Violation Execute()
        {
            return Violation.DoubleTransaction;
        }
        #endregion

    }
}
