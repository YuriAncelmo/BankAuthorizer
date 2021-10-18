#region References
using ChallengeCodeAuthorizer.Models;
using ChallengeCodeAuthorizer.Response;
using ChallengeCodeAuthorizer.Validation;
#endregion

namespace ChallengeCodeAuthorizer.States
{
    public class AccountCreated : State
    {
        #region Constructor
        public AccountCreated(State? state) : this(state?.Account)
        {
        }
        public AccountCreated(Account? account)
        {
            Account = account;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Indicate the state of account created
        /// </summary>
        /// <returns></returns>
        public override bool AccountIsCreated()
        {
            return true;
        }
        /// <summary>
        /// Construct the Response according to account,transactions and it's violations
        /// </summary>
        /// <param name="violations">list of violations</param>
        /// <returns>Response account ready to be used</returns>
        public override ResponseAccount GetResponseAccount(List<Violation> violations)
        {
            //TODO I can be better
            string[] values = new string[violations.Count];
            for (int i = 0; i < violations.Count; i++)
            {
                values[i] = violations[i].Value;
            }

            ResponseAccount responseAccount = new()
            {
                Account = Account,
                Violations = values
            };
            return responseAccount;
        }
        #endregion
    }
}
