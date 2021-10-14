using ChallengeCodeAuthorizer.States;
using Newtonsoft.Json;

namespace ChallengeCodeAuthorizer.Models
{
    public class Account
    {
        public bool activecard { get; set; }
        public int availablelimit { get; set; }
        [JsonIgnore]
        public List<Transaction> transactions {  get; set; }

        public Account()
        {
            //Novas contas não estão criadas por padrão
            State = new AccountNotCreated(this);//Bind the two instances 
            transactions = new List<Transaction>();
        }

        [JsonIgnore]
        private State state;
        [JsonIgnore]
        public State State
        {
            get { return state; }
            set
            {
                state = value;
                Console.WriteLine("State:" + state.GetType().Name);
            }
        }



    }
}
