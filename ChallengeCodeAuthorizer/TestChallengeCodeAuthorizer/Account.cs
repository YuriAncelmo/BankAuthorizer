using Newtonsoft.Json;
using Xunit;
using ChallengeCodeAuthorizer;

namespace TestChallengeCodeAuthorizer
{
    public class Account
    {
        [Fact]
        public void Create()
        {
            string input = "{\"account\": {\"active - card\": false, \"available - limit\": 750}}";
            input = input.Replace(" ", "").Replace("-", "");
            ChallengeCodeAuthorizer.Models.Account rootaccount = JsonConvert.DeserializeObject<dynamic>(input).account.ToObject<ChallengeCodeAuthorizer.Models.Account>();
            //ChallengeCodeAuthorizer.Account account = rootaccount.account;

            ChallengeCodeAuthorizer.ResponseAccount response = new ChallengeCodeAuthorizer.ResponseAccount();
            response.account = new ChallengeCodeAuthorizer.Models.Account();
            response.account.activecard = false;
            response.account.availablelimit = 750;
            response.violations = new object[0];

            //Assert.True(response.Equals(rootaccount.getResponseAccount()));


        }
        public void DecideOperationExecute()
        {

        }
    }
}