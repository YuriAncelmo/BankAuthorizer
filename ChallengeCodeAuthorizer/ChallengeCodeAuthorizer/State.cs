using ChallengeCodeAuthorizer.Models;

namespace ChallengeCodeAuthorizer
{
    public abstract class State
    {
        public Account account;
        public Transaction currentTransaction;
        
        public Account Account { get => account; set => account = value; }

        public abstract ResponseAccount getResponseAccount();
    }
}
