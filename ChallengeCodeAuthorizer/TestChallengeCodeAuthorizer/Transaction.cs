using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestChallengeCodeAuthorizer
{
    public class Transaction
    {
        string input = "{{ \"transaction\": { \"merchant\": \"Burger King\", \"amount\": 20, \"time\": \"2019-02-13T10:00:00.000Z\"} } " +
           "{ \"transaction\": { \"merchant\": \"Habbib's\", \"amount\": 90, \"time\": \"2019-02-13T11:00:00.000Z\"} } " +
           "{ \"transaction\": { \"merchant\": \"McDonald's\", \"amount\": 30, \"time\": \"2019-02-13T12:00:00.000Z\"} }";
        [Fact]
        public void Authorize()
        {
            var transaction = new Transaction();
        }
    }
}
