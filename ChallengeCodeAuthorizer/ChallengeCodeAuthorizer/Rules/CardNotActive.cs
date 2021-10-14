

using ChallengeCodeAuthorizer.States;

namespace ChallengeCodeAuthorizer.Rules
{
    internal class CardNotActive : IRule
    {
        public bool IsApplicable(State state)
        {
            return state.Account != null && !state.Account.activecard && state.accountCreated();//If card is not active, is applicable for rule
        }
        public Violation Execute()
        {
            return Violation.CardNotActive; 
        }

        
    }
}
