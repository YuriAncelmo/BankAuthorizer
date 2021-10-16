#region References
using ChallengeCodeAuthorizer.States;
using ChallengeCodeAuthorizer.Validation;
#endregion

namespace ChallengeCodeAuthorizer.Rules
{
    public interface IRule
    {
        #region Contracts
        bool IsApplicable(State state);
        Violation Execute();
        #endregion
    }
}
