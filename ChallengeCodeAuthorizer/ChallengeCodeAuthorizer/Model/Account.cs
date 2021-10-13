using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeCodeAuthorizer.Model
{
    public class Account
    {
        public bool activecard { get; set; }
        public int availablelimit { get; set; }
        public Account()
        {
            //Novas contas não estão criadas por padrão
            this.State = new AccountNotCreated(this);//Bind the two instances 
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
