
using ChallengeCodeAuthorizer.Models;

namespace ChallengeCodeAuthorizer.Rules
{
    internal class HighFrequencySmallInterval : IRule
    {
        public bool IsApplicable(State state)
        {
            List<Transaction> a = state.Account.transactions.Skip(Math.Max(0, state.Account.transactions.Count() - 3)).ToList(); // Consider chronologic enter 
            return true;
        }
        public Violation Execute()
        {
            throw new NotImplementedException();
        }

        
    }
}
