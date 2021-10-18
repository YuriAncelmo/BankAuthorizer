#region References
using ChallengeCodeAuthorizer.Models;
using ChallengeCodeAuthorizer.Response;
using ChallengeCodeAuthorizer.Validation;
#endregion

namespace ChallengeCodeAuthorizer.States;

public abstract class State
{
    #region Properties
    public Account? account;
    public Transaction? currentTransaction;
    public Account? Account { get => account; set => account = value; }
    #endregion

    #region Constracts
    public abstract ResponseAccount GetResponseAccount(List<Violation> violations);
    public abstract bool AccountIsCreated();
    #endregion
    #region Internal Methods
    /// <summary>
    /// Add transaction to account transactions , remove the amount and set current transaction = null
    /// </summary>
    internal void ProcessTransaction()
    {
        if (account != null 
            && account.State != null 
            && account.State.currentTransaction != null
            && currentTransaction != null)
        {
            account.Transactions.Add(account.State.currentTransaction);
            account.AvailableLimit -= currentTransaction.Amount;
            currentTransaction = null;
        }
    }
    #endregion
}
