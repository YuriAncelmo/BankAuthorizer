using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeCodeAuthorizer
{
    public class ResponseAccount
    {
        public Account account { get; set; }
        public object[] violations { get; set; }
        public ResponseAccount(Account account)
        {
            this.account = account;
        }
        //Tests reason
        public ResponseAccount()
        {

        }

        
    }
    enum Violations
    {

    }
}
