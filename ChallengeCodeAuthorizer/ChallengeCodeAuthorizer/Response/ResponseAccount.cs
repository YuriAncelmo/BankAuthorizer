#region References
using ChallengeCodeAuthorizer.Models;
#endregion

namespace ChallengeCodeAuthorizer.Response
{
    public class ResponseAccount
    {
        #region Properties
        public Account account { get; set; }
        public object[] violations  { get; set; }
        #endregion

        #region Constructor
        public ResponseAccount(Account account)
        {
            this.account = account;
            violations = new object[0];
        }
        //Tests reason
        public ResponseAccount()
        {

        }
        #endregion

        #region Public methods
        /// <summary>
        /// Return if current object is equals to another , in level of properties
        /// </summary>
        /// <param name="obj">obj to be compared</param>
        /// <returns>True if is equal</returns>
        public bool Equals(ResponseAccount? obj)
        {
            return this.account.availablelimit == obj.account.availablelimit
                      && this.account.activecard == obj.account.activecard
                      && this.violations.Count() == obj.violations.Count();
                
        }
        #endregion
    }

}
