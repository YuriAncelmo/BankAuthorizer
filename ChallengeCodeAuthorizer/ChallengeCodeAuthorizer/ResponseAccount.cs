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
        public object[] violations  { get; set; }
        public ResponseAccount(Account account)
        {
            this.account = account;
            violations = new object[0];
        }
        //Tests reason
        public ResponseAccount()
        {

        }
        public bool Equals(ResponseAccount? obj)
        {
            return this.account.availablelimit == obj.account.availablelimit
                      && this.account.activecard == obj.account.activecard
                      && this.violations.Count() == obj.violations.Count();
                
        }

    }
   
}
