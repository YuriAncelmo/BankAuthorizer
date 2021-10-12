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
            response.violations = AccountViolations();
            return response;
        }

        private object[] AccountViolations()
        {
            throw new NotImplementedException();
        }
    }
}
