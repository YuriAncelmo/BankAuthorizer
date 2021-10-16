#region References
using Newtonsoft.Json;
#endregion

namespace ChallengeCodeAuthorizer.Models
{
    public class Transaction
    {
        #region Json Properties
        public string merchant { get; set; }
        public int amount { get; set; }
        public DateTime time { get; set; }
        #endregion

        #region No json properties
        [JsonIgnore]
        public bool executed { get; set; }
        #endregion

        #region Constructor
        public Transaction()
        {
            executed = false;
        }
        #endregion

    }

}
