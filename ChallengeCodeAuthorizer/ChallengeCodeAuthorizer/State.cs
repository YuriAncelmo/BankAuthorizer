using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeCodeAuthorizer
{
    public abstract class State
    {
        private Account account;

        public Account Account { get => account; set => account = value; }

        public abstract void Handle(Context context);
        public abstract ResponseAccount getResponseAccount();
    }
}
