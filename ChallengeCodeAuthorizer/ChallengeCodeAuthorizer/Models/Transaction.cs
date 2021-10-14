

using Newtonsoft.Json;

namespace ChallengeCodeAuthorizer.Models
{
    public class Transaction
    {
        public string merchant { get; set; }
        public int amount { get; set; }
        public DateTime time { get; set; }
        [JsonIgnore]
        public bool executed { get; set; }
        public Transaction()
        {
            executed = false;
        }
        
    }

}
