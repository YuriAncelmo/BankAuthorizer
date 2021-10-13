using ChallengeCodeAuthorizer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public override ResponseAccount getResponseAccount()
        {

            StateChangeCheck();//O status se torna criado
            ResponseAccount responseAccountCreate = new ResponseAccount(this.Account);//Podemos pegar a response 
            return responseAccountCreate;
        }
        public void StateChangeCheck()
        {
            account.State = new AccountCreated(this);
        }
      
        
    }
}
