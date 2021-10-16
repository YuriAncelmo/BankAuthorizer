#region References
using ChallengeCodeAuthorizer.Models;
using ChallengeCodeAuthorizer.Response;
using ChallengeCodeAuthorizer.Validation;
#endregion

namespace ChallengeCodeAuthorizer.States;

public abstract class State
{
    #region Properties
    public Account account;
    public Transaction currentTransaction;
    public Account Account { get => account; set => account = value; }
    #endregion

    #region Constracts
    public abstract ResponseAccount getResponseAccount(List<Violation> violations);
    public abstract bool accountCreated();
    #endregion
    #region Internal Methods
    /// <summary>
    /// Add transaction to account transactions , remove the amount and set current transaction = null
    /// </summary>
    internal void ProcessTransaction()
    {
        account.transactions.Add(account.State.currentTransaction);
        account.availablelimit -= currentTransaction.amount;
        currentTransaction = null;
    }
    #endregion
}
