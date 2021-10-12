using Newtonsoft.Json;
using Xunit;

namespace TestChallengeCodeAuthorizer
{
    public class Account
    {
        [Fact]
        public void Create()
        {
            string input = @"{""account"": {""active - card"": false, ""available - limit"": 750}}";
            input.Replace(" ", "");
            input.Replace("-","");
            ChallengeCodeAuthorizer.Account account = JsonConvert.DeserializeObject<ChallengeCodeAuthorizer.Account>(input);
            
            ChallengeCodeAuthorizer.ResponseAccount response = new ChallengeCodeAuthorizer.ResponseAccount();
            response.account = new ChallengeCodeAuthorizer.Account();
            response.account.activecard = false;
            response.account.availablelimit = 750;
            response.violations = new object[0];

            //Assert.Equal(response, account.getResponseAccount());

            
        }
        public void DecideOperationExecute()
        {

        }
    }
}