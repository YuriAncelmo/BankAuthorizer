#region References
using Newtonsoft.Json;
#endregion

namespace ChallengeCodeAuthorizer.Models
{
    public class Transaction
    {
        #region Json Properties
        public string? Merchant { get; set; }
        public int Amount { get; set; }
        public DateTime Time { get; set; }
        #endregion

    }

}
