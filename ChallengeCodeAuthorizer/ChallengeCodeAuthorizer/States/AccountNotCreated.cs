using ChallengeCodeAuthorizer.Models;
using ChallengeCodeAuthorizer.States;
using ChallengeCodeAuthorizer.Validation;
using ChallengeCodeAuthorizer.Response;

namespace ChallengeCodeAuthorizer
{
    internal class AccountNotCreated : State
    {
        public AccountNotCreated(State state): this(state.Account)//"this" calls another constructor of this class, with the determinated parameters 
        {
        }
        public AccountNotCreated(Account account)
        {
            this.Account = account;//bind the two instances 
        }

        public override bool accountCreated()
        {
            return false;
        }

        public override ResponseAccount getResponseAccount(List<Violation> violations)
        {
            //TODO I can be better
            string[] values = new string[violations.Count];
            for (int i = 0; i < violations.Count; i++)
            {
                values[i] = violations[i].Value;
            }

            if(violations.Count == 0) StateChangeCheck();//The status changes to create if don't have violations 
            ResponseAccount responseAccountCreate = new ResponseAccount(this.Account);//Podemos pegar a response 
            responseAccountCreate.violations = values;
            return responseAccountCreate;
        }
        public void StateChangeCheck()
        {
            account.State = new AccountCreated(this);
        }
      
        
    }
}
