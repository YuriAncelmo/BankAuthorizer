using ChallengeCodeAuthorizer.Model;
namespace ChallengeCodeAuthorizer
{
    public abstract class State
    {
        public Account account;

        public Account Account { get => account; set => account = value; }

        public abstract ResponseAccount getResponseAccount();
    }
}
