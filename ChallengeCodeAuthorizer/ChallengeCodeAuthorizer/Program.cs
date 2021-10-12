using ChallengeCodeAuthorizer;
using System.Text.Json;
using System.Text.Json.Serialization;

string input = Console.ReadLine();

Account account = JsonSerializer.Deserialize<Account>(input);

Console.Read();


