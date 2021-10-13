using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeCodeAuthorizer.Model;
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
