#region References
using ChallengeCodeAuthorizer.Models;
using ChallengeCodeAuthorizer.States;
using ChallengeCodeAuthorizer.Validation;
using ChallengeCodeAuthorizer.Response;
#endregion

namespace ChallengeCodeAuthorizer
{
    internal class AccountNotCreated : State
    {
        #region Constructor
        public AccountNotCreated(State state): this(state.Account)//"this" calls another constructor of this class, with the determinated parameters 
        {
        }
        public AccountNotCreated(Account account)
        {
            this.Account = account;//bind the two instances 
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Represents the state of account
        /// </summary>
        /// <returns>false because account is not created</returns>
        public override bool accountCreated()
        {
            return false;
        }

        /// <summary>
        /// Make the same as Account Created , but the difference is that state is changed
        /// </summary>
        /// <param name="violations"></param>
        /// <returns></returns>
        public override ResponseAccount getResponseAccount(List<Violation> violations)
        {
            if(violations.Count == 0) StateChangeCheck();//The status changes to create if don't have violations 
            ResponseAccount responseAccountCreate = new ResponseAccount(this.Account);//Podemos pegar a response             responseAccountCreate.violations = values;
            return responseAccountCreate;
        }
        public void StateChangeCheck()
        {
            account.State = new AccountCreated(this);
        }
        #endregion

    }
}
