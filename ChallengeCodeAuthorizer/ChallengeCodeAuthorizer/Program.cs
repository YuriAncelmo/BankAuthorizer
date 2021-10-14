using ChallengeCodeAuthorizer;
using Newtonsoft.Json;
using ChallengeCodeAuthorizer.Models;
using ChallengeCodeAuthorizer.States;
using ChallengeCodeAuthorizer.Rules;

string input = "-1";
Account account = new Account();
IRule[] transactionRules = new IRule[]
{
    new AccountNotInitialized(),
    new CardNotActive(),
    new InsufficientLimit(),
    new HighFrequencySmallInterval(),
    new DoubleTransaction()
};

do
{
    input = Console.ReadLine();
    if (Helper.returnTypeOfJson(input) == typeof(Account))
    {
        //Process Account
        JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
        jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
        Helper.replaceJson(ref input);
        var dynamic = JsonConvert.DeserializeObject<dynamic>(input);

        if (account.State.GetType() != typeof(AccountCreated))
            account = dynamic.account.ToObject<Account>();
        //Validation Must Be in Evaluator 
        Console.WriteLine(JsonConvert.SerializeObject(account.State.getResponseAccount(new List<Violation>())));
    }
    else
    {
        Transaction transaction = JsonConvert.DeserializeObject<dynamic>(input).transaction.ToObject<Transaction>();
        account.State.currentTransaction = transaction;
        //Console.WriteLine(JsonConvert.SerializeObject(transaction.Process(account)));
        List<Violation> violations = new Evaluator(transactionRules).Execute(account.State);
        if (violations.Count == 0)
        {
            account.transactions.Add(account.State.currentTransaction);
            account.availablelimit -= transaction.amount;
        }   
        Console.WriteLine(JsonConvert.SerializeObject(account.State.getResponseAccount(violations)));
    }



} while (input != "");

