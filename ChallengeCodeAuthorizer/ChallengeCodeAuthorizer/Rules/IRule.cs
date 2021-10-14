using ChallengeCodeAuthorizer.States;
namespace ChallengeCodeAuthorizer.Rules
{
    internal interface IRule
    {
        bool IsApplicable(State state);
        Violation Execute(); 
    }
}
