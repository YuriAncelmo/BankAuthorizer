using Newtonsoft.Json;
using System.Collections.Generic;
using Xunit;
using ChallengeCodeAuthorizer;
using ChallengeCodeAuthorizer.Validation;
using ChallengeCodeAuthorizer.Rules.Account ;
using ChallengeCodeAuthorizer.Rules;
using System;

namespace TestChallengeCodeAuthorizer
{
    public class Account
    {
        [Fact]
        public void Create()
        {
            string? input = "{\"account\": {\"active - card\": false, \"available - limit\": 750}}";
            

            ChallengeCodeAuthorizer.Models.Account? account = new ();
            IRule[] accountRules = new IRule[]
            {
                new AccountAlreadyInitialized()
            };

            Helper.ReplaceJson(ref input);

            var dynamic = JsonConvert.DeserializeObject<dynamic>(input);
            if (dynamic != null)
            {
                ChallengeCodeAuthorizer.Models.Account? currentAccount = dynamic.account.ToObject<ChallengeCodeAuthorizer.Models.Account>();
                List<Violation> violations = new Evaluator(accountRules).Execute(account.State);

                if (violations.Count == 0 && currentAccount != null)
                    account = currentAccount;

                ChallengeCodeAuthorizer.Response.ResponseAccount response = new();
                response.Account = new();
                response.Account.ActiveCard = false;
                response.Account.AvailableLimit = 750;
                response.Violations = Array.Empty<object>();

                Assert.True(response.Equals(account.State.GetResponseAccount(violations)));
            }
            else
            {
                Assert.True(false);
            }

        }
        [Fact]
        public void AlreadyCreate()
        {
            string? input = "{\"account\": {\"active - card\": false, \"available - limit\": 750}}";


            ChallengeCodeAuthorizer.Models.Account account = new ();
            IRule[] accountRules = new IRule[]
            {
                new AccountAlreadyInitialized()
            };

            Helper.ReplaceJson(ref input);
            var dynamic = JsonConvert.DeserializeObject<dynamic>(input);
            if (dynamic != null)
            {
                ChallengeCodeAuthorizer.Models.Account? currentAccount = dynamic.account.ToObject<ChallengeCodeAuthorizer.Models.Account>();
                List<Violation> violations = new Evaluator(accountRules).Execute(account.State);

                if (violations.Count == 0 && currentAccount != null)
                {
                    account = currentAccount;
                    account.State.GetResponseAccount(violations);//Change the state to created 
                }

                violations = new Evaluator(accountRules).Execute(account.State);


                ChallengeCodeAuthorizer.Response.ResponseAccount response = new();
                response.Account = new();
                response.Account.ActiveCard = false;
                response.Account.AvailableLimit = 750;
                response.Violations = new object[1] { new AccountAlreadyInitialized() };

                Assert.True(response.Equals(account.State.GetResponseAccount(violations)));
            }
            else
                Assert.True(false);

        }

    }
}