#region References
using ChallengeCodeAuthorizer;
using Newtonsoft.Json;
using ChallengeCodeAuthorizer.Models;
using ChallengeCodeAuthorizer.Rules;
using ChallengeCodeAuthorizer.Rules.Transaction;
using ChallengeCodeAuthorizer.Rules.Account;
using ChallengeCodeAuthorizer.Validation;
#endregion

#region Variables
string input = String.Empty;
Account account = new Account ();
#endregion

#region Rules
IRule[] transactionRules = new IRule[]
{
    new AccountNotInitialized(),
    new CardNotActive(),
    new InsufficientLimit(),
    new HighFrequencySmallInterval(),
    new DoubleTransaction()
};

IRule[] accountRules = new IRule[]
{
    new AccountAlreadyInitialized()
};
#endregion

#region Execution
string[] lines = System.IO.File.ReadAllLines(args[0]);
for(int i=0; i< lines.Length;i++)
{
    input = lines[i];
    if (Helper.returnTypeOfJson(input) == typeof(Account))
    {
        Helper.replaceJson(ref input);

        var dynamic = JsonConvert.DeserializeObject<dynamic>(input);
        List<Violation> violations = new Evaluator(accountRules).Execute(account.State);

        if (violations.Count == 0)
            account = dynamic.account.ToObject<Account>();
        
        Console.WriteLine(JsonConvert.SerializeObject(account.State.getResponseAccount(violations)));
    }
    else
    {
        Transaction transaction = JsonConvert.DeserializeObject<dynamic>(input).transaction.ToObject<Transaction>();
        account.State.currentTransaction = transaction;
        List<Violation> violations = new Evaluator(transactionRules).Execute(account.State);
        
        if (violations.Count == 0)
            account.State.ProcessTransaction();
            
        Console.WriteLine(JsonConvert.SerializeObject(account.State.getResponseAccount(violations)));
    }



} 
#endregion

