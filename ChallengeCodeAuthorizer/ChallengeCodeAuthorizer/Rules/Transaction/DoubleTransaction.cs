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
            ///TODO: need confirm if the 2 is inclusive or exclusive
            return state.Account.transactions.Count(transaction =>
                        ( state.currentTransaction.time - transaction.time ).Minutes < 2 //Transactions where range is less than 2
                      && transaction.merchant == state.currentTransaction.merchant
                      && transaction.amount == state.currentTransaction.amount)
                        > 0
                         && state.accountCreated(); //Count if is more than 3      
        }
        public Violation Execute()
        {
            return Violation.DoubleTransaction;
        }
        #endregion

    }
}
