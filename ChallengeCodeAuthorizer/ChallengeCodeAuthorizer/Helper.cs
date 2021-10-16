#region References
using Newtonsoft.Json;
using ChallengeCodeAuthorizer.Models;
#endregion

namespace ChallengeCodeAuthorizer
{
    public class Helper
    {
        #region Public Methods
        /// <summary>
        /// This method decide what is the type of json, based on this format 
        /// </summary>
        /// <param name="json">The json to decide</param>
        /// <returns>identified type</returns>
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


        /// <summary>
        /// This method remove all - and ' ' of the fields active - card and available - limit
        /// </summary>
        /// <param name="json">json formated</param>
        public static void replaceJson(ref string json)
        {
            json = json.Replace("active - card", "activecard");
            json = json.Replace("available - limit", "availablelimit");
        }
        #endregion
    }
}
