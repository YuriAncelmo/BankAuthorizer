using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeCodeAuthorizer
{
    public class Context
    {
        State state;
        Account account;
        public Context(State state)
        {
            this.State = state;
        }
        public State State
        {
            get { return this.state; }
            set
            {
                this.state = value;
                Console.WriteLine("State: " + state.GetType().Name);
            }
        }

        public Account Account { get => account; set => account = value; }

        public void Request()
        {
            state.Handle(this);
        }
    }
}
