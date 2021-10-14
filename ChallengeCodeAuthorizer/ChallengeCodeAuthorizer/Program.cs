using ChallengeCodeAuthorizer;
using Newtonsoft.Json;
using ChallengeCodeAuthorizer.Models;
using ChallengeCodeAuthorizer.States;

string input = "-1";
Account account = new Account();
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

        Console.WriteLine(JsonConvert.SerializeObject(account.State.getResponseAccount()));
        //Console.WriteLine(JsonConvert.SerializeObject(account.getResponseAccount()));
    }
    else
    {
        Transaction transaction = JsonConvert.DeserializeObject<dynamic>(input).transaction.ToObject<Transaction>();
        //Console.WriteLine(JsonConvert.SerializeObject(transaction.Process(account)));
    }



} while (input != "");

