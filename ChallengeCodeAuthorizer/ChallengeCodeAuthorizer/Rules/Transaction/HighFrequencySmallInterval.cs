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

            //int highFrequencyTransactions = state.Account.transactions.Count(transaction =>
            //        (state.currentTransaction.time - transaction.time).Minutes < 2//Transactions where range is less (or equal?) than 2
            //        && state.currentTransaction.merchant != transaction.merchant);//From different merchants
            int highFrequencyTransactions = state.Account.transactions.Count(transaction =>
                    (state.currentTransaction.time - transaction.time).Minutes < 2);//Transactions where range is less (or equal?) than 2
                
                    
            //TODO: need confirm if the 2 is inclusive or exclusive
            return highFrequencyTransactions > 2 && state.accountCreated(); //Count if is more than 3             
        }
        public Violation Execute()
        {
            return Violation.HighFrequencySmallInterval;
        }
        #endregion

    }
}
