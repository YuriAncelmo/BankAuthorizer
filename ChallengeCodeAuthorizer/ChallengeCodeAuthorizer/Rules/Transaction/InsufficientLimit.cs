using ChallengeCodeAuthorizer.States;
using ChallengeCodeAuthorizer.Validation;


namespace ChallengeCodeAuthorizer.Rules.Transaction
{
    internal class InsufficientLimit : IRule
    {

        public bool IsApplicable(State state)
        {
            return state.currentTransaction.amount >= state.Account.availablelimit  && state.accountCreated();
        }
        public Violation Execute()
        {
            return Violation.InsufficientLimit;
        }

    }
}
