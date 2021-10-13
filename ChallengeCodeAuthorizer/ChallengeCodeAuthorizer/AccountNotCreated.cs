using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeCodeAuthorizer
{
    internal class AccountNotCreated : State
    {
        public override ResponseAccount getResponseAccount()
        {
            ResponseAccount responseAccountCreate = new ResponseAccount(this.Account);
            this.Account.state = new AccountCreated();
            return responseAccountCreate;
        }

        public override void Handle(Context context)
        {
            context.State = new AccountNotCreated();    
        }
        
    }
}
