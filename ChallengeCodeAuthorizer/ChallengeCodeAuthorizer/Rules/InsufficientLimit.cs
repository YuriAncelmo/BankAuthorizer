
namespace ChallengeCodeAuthorizer.Rules
{
    internal class InsufficientLimit : IRule
    {

        public bool IsApplicable(State state)
        {
            return state.currentTransaction.amount >= state.Account.availablelimit;
        }
        public Violation Execute()
        {
            return Violation.InsufficientLimit;
        }

    }
}
