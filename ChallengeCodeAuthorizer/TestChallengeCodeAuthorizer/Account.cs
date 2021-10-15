using Newtonsoft.Json;
using Xunit;

namespace TestChallengeCodeAuthorizer
{
    public class Account
    {
        [Fact]
        public void Create()
        {
            string? input = "{\"account\": {\"active - card\": false, \"available - limit\": 750}}";
            input = input.Replace(" ", "").Replace("-", "");
            dynamic? rootaccountdynamic = JsonConvert.DeserializeObject<dynamic>(input);
            ChallengeCodeAuthorizer.Models.Account rootaccount = rootaccountdynamic.account.ToObject<ChallengeCodeAuthorizer.Models.Account>();
            ChallengeCodeAuthorizer.Response.ResponseAccount response = new ChallengeCodeAuthorizer.Response.ResponseAccount();
            response.account = new ChallengeCodeAuthorizer.Models.Account();
            response.account.activecard = false;
            response.account.availablelimit = 750;
            response.violations = new object[0];

            //Assert.True(response.Equals(rootaccount.getResponseAccount()));


        }
    }
}