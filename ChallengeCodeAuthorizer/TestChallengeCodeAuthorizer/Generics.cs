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
        [Fact]
        public void OperationSelectorAccount()
        {
            string inputAccount = @"{""account"": {""active - card"": true, ""available - limit"": 100}}";

            Assert.True(ChallengeCodeAuthorizer.Helper.returnTypeOfJson(inputAccount) == typeof(ChallengeCodeAuthorizer.Account));
        }

        [Fact]
        public void OperationSelectorTransaction()
        {
            string inputTransaction = @"{""transaction"": {""merchant"": ""Burger King"", ""amount"": 20, ""time"": ""2019 - 02 - 13T10: 00:00.000Z""}}";

            Assert.True(ChallengeCodeAuthorizer.Helper.returnTypeOfJson(inputTransaction) == typeof(ChallengeCodeAuthorizer.Transaction));
        }

    }
}
