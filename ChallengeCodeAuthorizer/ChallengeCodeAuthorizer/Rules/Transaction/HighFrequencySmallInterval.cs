#region References 
using ChallengeCodeAuthorizer.States;
using ChallengeCodeAuthorizer.Validation;
#endregion

namespace ChallengeCodeAuthorizer.Rules.Transaction
{
    internal class HighFrequencySmallInterval : IRule
    {
        #region Public Methods
        public bool IsApplicable(State state)
        {
            if (state.Account != null && state.currentTransaction != null)
            {
                int highFrequencyTransactions = state.Account.Transactions.Count(transaction =>
                       (state.currentTransaction.Time - transaction.Time).Minutes < 2);//Transactions where range is less (or equal?) than 2


                //TODO: need confirm if the 2 is inclusive or exclusive
                return highFrequencyTransactions > 2 && state.AccountIsCreated(); //Count if is more than 3             
            }
            else 
                return false;
        }
        public Violation Execute()
        {
            return Violation.HighFrequencySmallInterval;
        }
        #endregion

    }
}
