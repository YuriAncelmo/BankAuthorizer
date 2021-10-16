#region References
using ChallengeCodeAuthorizer.States;
using ChallengeCodeAuthorizer.Validation;
#endregion

namespace ChallengeCodeAuthorizer.Rules
{
    public class Evaluator
    {

        #region Properties
        private IEnumerable<IRule> Rules { get; }
        #endregion

        #region Constructor
        public Evaluator(IRule[] rules)
        {
            Rules = rules;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Execute rules in the state, to verify if one operation have violations
        /// </summary>
        /// <param name="state">The "context" of the application</param>
        /// <returns>List of the violations</returns>
        public List<Violation> Execute(State state)
        {
            List<Violation> violations = new List<Violation>();
            foreach (IRule rule in this.Rules)
            {
                if (rule.IsApplicable(state))
                    violations.Add(rule.Execute());
            }
            return violations;
        }
        #endregion
    }
}
