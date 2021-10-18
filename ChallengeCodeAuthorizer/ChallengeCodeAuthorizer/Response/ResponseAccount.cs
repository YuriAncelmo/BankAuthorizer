#region References
using ChallengeCodeAuthorizer.Models;
#endregion

namespace ChallengeCodeAuthorizer.Response
{
    public class ResponseAccount
    {
        #region Properties
        public Account? Account { get; set; }
        public object[]? Violations { get; set; }
        #endregion

        #region Constructor
        public ResponseAccount(Account? account)
        {
            this.Account = account;
            Violations = Array.Empty<object>();
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
            if (this.Account != null && obj?.Account != null)
                return this.Account.AvailableLimit == obj.Account.AvailableLimit
                      && this.Account.ActiveCard == obj.Account.ActiveCard
                      && this.Violations?.Length == obj.Violations?.Length;
            else if (this.Account == obj?.Account)
                return true;
            else return false;

        }
        #endregion
    }

}
