using ChallengeCodeAuthorizer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestChallengeCodeAuthorizer
{
    public class Generics
    {
        readonly string inputAccount = @"{""account"": {""active - card"": true, ""available - limit"": 100}}";
        readonly string inputTransaction = @"{""transaction"": {""merchant"": ""Burger King"", ""amount"": 20, ""time"": ""2019 - 02 - 13T10: 00:00.000Z""}}";

        [Fact]
        public void OperationSelectorAccount()
        {
        
            Assert.True(ChallengeCodeAuthorizer.Helper.ReturnTypeOfJson(inputAccount) == typeof(ChallengeCodeAuthorizer.Models.Account));
        }

        [Fact]
        public void OperationSelectorTransaction()
        {
            Assert.True(ChallengeCodeAuthorizer.Helper.ReturnTypeOfJson(inputTransaction) == typeof(ChallengeCodeAuthorizer.Models.Transaction));
        }
        [Fact]
        public void ConvertObject()
        {
            string aux = inputAccount;
            Helper.ReplaceJson(ref aux);
            ChallengeCodeAuthorizer.Models.Account? account = JsonConvert.DeserializeObject<ChallengeCodeAuthorizer.Models.Account>(aux);
            Assert.NotNull(account);
        }
    }
}
