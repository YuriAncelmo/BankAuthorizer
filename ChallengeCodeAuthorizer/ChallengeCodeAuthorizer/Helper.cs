using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeCodeAuthorizer
{
    public class Helper
    {
        public static Type returnTypeOfJson(string? json)
        {
            if (json != null)
                try
                {
                    JsonConvert.DeserializeObject<dynamic>(json).account.ToObject<ChallengeCodeAuthorizer.Account>();
                    return typeof(ChallengeCodeAuthorizer.Account);
                }
                catch (Exception ex)
                {
                    return typeof(Transaction);
                }
            else
                return null;
        }
    }
}
