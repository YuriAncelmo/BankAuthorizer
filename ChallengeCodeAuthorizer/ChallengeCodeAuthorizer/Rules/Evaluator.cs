
using ChallengeCodeAuthorizer.States;

namespace ChallengeCodeAuthorizer.Rules
{
    internal class Evaluator
    {

        private IEnumerable<IRule> Rules { get; }
        
        public Evaluator(IRule[] rules)
        {
            Rules = rules;
        }
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
    }
}
