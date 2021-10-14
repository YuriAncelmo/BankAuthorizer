using ChallengeCodeAuthorizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeCodeAuthorizer
{
    internal class Validation
    {
        
        public ResponseAccount Account(ResponseAccount response)
        {
            //response.violations = AccountViolations();
            return response;
        }

        public static ResponseAccount AccountViolations(Account? old_account, Account new_account)
        {
            ResponseAccount response = new ResponseAccount();
            if (old_account != null )//Já existe conta criada
            {
                response.violations = new object[] { Violation.AccountAlreadyInitialized };
                response.account = old_account;
            }
            else 
                response.account = new_account;
            return response;


        }
        public static ResponseAccount TransactionViolations(Account account, Violation violation)
        {
            ResponseAccount response = new ResponseAccount();
            response.account = account;
            response.violations = new object[] { violation.Value };
            return response;
        }
    }
}
