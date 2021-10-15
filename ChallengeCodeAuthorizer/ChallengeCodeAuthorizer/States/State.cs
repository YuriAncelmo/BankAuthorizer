using ChallengeCodeAuthorizer.Models;
using ChallengeCodeAuthorizer.Response;
using ChallengeCodeAuthorizer.Validation;

namespace ChallengeCodeAuthorizer.States;

public abstract class State
{
    public Account account;
    public Transaction currentTransaction;

    public Account Account { get => account; set => account = value; }

    public abstract ResponseAccount getResponseAccount(List<Violation> violations);
    public abstract bool accountCreated();

    internal void ProcessTransaction()
    {
        account.transactions.Add(account.State.currentTransaction);
        account.availablelimit -= currentTransaction.amount;
        currentTransaction = null;
    }
}
