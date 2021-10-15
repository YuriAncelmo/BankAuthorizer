using ChallengeCodeAuthorizer.States;
using ChallengeCodeAuthorizer.Validation;

namespace ChallengeCodeAuthorizer.Rules
{
    internal interface IRule
    {
        bool IsApplicable(State state);
        Violation Execute(); 
    }
}
