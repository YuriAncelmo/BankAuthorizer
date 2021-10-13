using ChallengeCodeAuthorizer;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

string input = "-1";
State state = new AccountNotCreated();
while (input != "")
{
    input = Console.ReadLine();
    if(Helper.returnTypeOfJson(input) == typeof(Account))
    {
        //Process Account
        JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
        jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
        input = input.Replace("-","");
        input = input.Replace(" ", "");
        var dynamic = JsonConvert.DeserializeObject<dynamic>(input);
       
        state.Account = dynamic.account.ToObject<Account>();

        Console.WriteLine(JsonConvert.SerializeObject(state.getResponseAccount()));
        //Console.WriteLine(JsonConvert.SerializeObject(account.getResponseAccount()));
    }
    else
    {
        Transaction transaction = JsonConvert.DeserializeObject<dynamic>(input).transaction.ToObject<ChallengeCodeAuthorizer.Transaction>();
        //Console.WriteLine(JsonConvert.SerializeObject(transaction.Process(account)));
    }
    

    
}

