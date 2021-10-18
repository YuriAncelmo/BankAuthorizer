#region References
using ChallengeCodeAuthorizer.States;
using Newtonsoft.Json;
#endregion

namespace ChallengeCodeAuthorizer.Models
{
    public class Account
    {
        #region Json Properties
        public bool ActiveCard { get; set; }
        public int AvailableLimit { get; set; }
        #endregion

        #region No Json Properties
        [JsonIgnore]
        public List<Transaction> Transactions {  get; set; }
        
        //[JsonIgnore]
        //private State state;
        [JsonIgnore]
        public State State
        {
            get;
            set;
        }
        #endregion

        #region Constructor
        public Account()
        {
            //Novas contas não estão criadas por padrão
            State = new AccountNotCreated(this);//Bind the two instances 
            Transactions = new List<Transaction>();
        }
        #endregion

    }
}
