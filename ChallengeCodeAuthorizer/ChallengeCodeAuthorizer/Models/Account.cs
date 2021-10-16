#region References
using ChallengeCodeAuthorizer.States;
using Newtonsoft.Json;
#endregion

namespace ChallengeCodeAuthorizer.Models
{
    public class Account
    {
        #region Json Properties
        public bool activecard { get; set; }
        public int availablelimit { get; set; }
        #endregion

        #region No Json Properties
        [JsonIgnore]
        public List<Transaction> transactions {  get; set; }
        
        [JsonIgnore]
        private State state;
        [JsonIgnore]
        public State State
        {
            get { return state; }
            set
            {
                state = value;
            }
        }
        #endregion

        #region Constructor
        public Account()
        {
            //Novas contas não estão criadas por padrão
            State = new AccountNotCreated(this);//Bind the two instances 
            transactions = new List<Transaction>();
        }
        #endregion

    }
}
