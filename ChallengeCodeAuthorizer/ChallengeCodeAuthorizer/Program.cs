using ChallengeCodeAuthorizer;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

string input= "-1";
Account account = null;
while (input != "")
{
    input = Console.ReadLine();
    if(Helper.returnTypeOfJson(input) == typeof(Account))
    {
        //Process Account
        Account new_account = JsonConvert.DeserializeObject<dynamic>(input).account.ToObject<ChallengeCodeAuthorizer.Account>();
        Validation.AccountViolations(account, new_account);
        Console.WriteLine(JsonConvert.SerializeObject(account.getResponseAccount()));
    }
    else
    {
        Transaction transaction = JsonConvert.DeserializeObject<dynamic>(input).transaction.ToObject<ChallengeCodeAuthorizer.Transaction>();
        Console.WriteLine(JsonConvert.SerializeObject(transaction.Process(account)));
    }
    

    
}

