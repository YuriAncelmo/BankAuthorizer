using Newtonsoft.Json;
using ChallengeCodeAuthorizer.Models;

namespace ChallengeCodeAuthorizer
{
    public class Helper
    {
        public static Type returnTypeOfJson(string? json)
        {
            if (json != null)
                try
                {
                    JsonConvert.DeserializeObject<dynamic>(json).account.ToObject<Account>();
                    return typeof(Account);
                }
                catch (Exception ex)
                {
                    return typeof(Transaction);
                }
            else
                return null;
        }
        public static void replaceJson(ref string json)
        {
            json = json.Replace("-", "");
            json = json.Replace(" ", "");
        }
    }
}
