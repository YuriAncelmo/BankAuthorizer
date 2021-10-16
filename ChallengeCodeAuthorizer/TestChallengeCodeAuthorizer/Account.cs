using Newtonsoft.Json;
using System.Collections.Generic;
using Xunit;
using ChallengeCodeAuthorizer;
using ChallengeCodeAuthorizer.Validation;
using ChallengeCodeAuthorizer.Rules.Account ;
using ChallengeCodeAuthorizer.Rules;

namespace TestChallengeCodeAuthorizer
{
    public class Account
    {
        [Fact]
        public void Create()
        {
            string? input = "{\"account\": {\"active - card\": false, \"available - limit\": 750}}";
            

            ChallengeCodeAuthorizer.Models.Account account = new ChallengeCodeAuthorizer.Models.Account();
            IRule[] accountRules = new IRule[]
            {
                new AccountAlreadyInitialized()
            };

            Helper.replaceJson(ref input);

            var dynamic = JsonConvert.DeserializeObject<dynamic>(input);
            List<Violation> violations = new Evaluator(accountRules).Execute(account.State);

            if (violations.Count == 0)
                account = dynamic.account.ToObject<ChallengeCodeAuthorizer.Models.Account>();

            ChallengeCodeAuthorizer.Response.ResponseAccount response = new ChallengeCodeAuthorizer.Response.ResponseAccount();
            response.account = new ChallengeCodeAuthorizer.Models.Account();
            response.account.activecard = false; 
            response.account.availablelimit = 750;
            response.violations = new object[0];

            Assert.True(response.Equals(account.State.getResponseAccount(violations)));


        }
        [Fact]
        public void AlreadyCreate()
        {
            string? input = "{\"account\": {\"active - card\": false, \"available - limit\": 750}}";


            ChallengeCodeAuthorizer.Models.Account account = new ChallengeCodeAuthorizer.Models.Account();
            IRule[] accountRules = new IRule[]
            {
                new AccountAlreadyInitialized()
            };

            Helper.replaceJson(ref input);

            var dynamic = JsonConvert.DeserializeObject<dynamic>(input);
            List<Violation> violations = new Evaluator(accountRules).Execute(account.State);

            if (violations.Count == 0)
            { 
                account = dynamic.account.ToObject<ChallengeCodeAuthorizer.Models.Account>();
                account.State.getResponseAccount(violations);//Change the state to created 
            }

            violations = new Evaluator(accountRules).Execute(account.State);


            ChallengeCodeAuthorizer.Response.ResponseAccount response = new ChallengeCodeAuthorizer.Response.ResponseAccount();
            response.account = new ChallengeCodeAuthorizer.Models.Account();
            response.account.activecard = false;
            response.account.availablelimit = 750;
            response.violations = new object[1] {new AccountAlreadyInitialized()};

            Assert.True(response.Equals(account.State.getResponseAccount(violations)));


        }

    }
}