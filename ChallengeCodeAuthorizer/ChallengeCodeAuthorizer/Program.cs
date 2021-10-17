#region References
using ChallengeCodeAuthorizer;
using Newtonsoft.Json;
using ChallengeCodeAuthorizer.Models;
using ChallengeCodeAuthorizer.Rules;
using ChallengeCodeAuthorizer.Rules.Transaction;
using ChallengeCodeAuthorizer.Rules.Account;
using ChallengeCodeAuthorizer.Validation;
#endregion

#region Header
string header =
   "  _  _      ___            _              \n"
+ @" | \| |_  _| _ ) __ _ _ _ | |__           " + "\n"
+ @" | .` | || | _ \/ _` | ' \| / /           " + "\n"
+ @" |_|\_|\_,_|___/\__,_|_||_|_\_\           " + "\n"
+ @"   /_\ _  _| |_| |_  ___ _ _(_)______ _ _ " + "\n"
+ @"  / _ \ || |  _| ' \/ _ \ '_| |_ / -_) '_|" + "\n"
+ @" /_/ \_\_,_|\__|_||_\___/_| |_/__\___|_|  " + "\n";


#endregion
#region Variables
string input = String.Empty;
Account account = new Account();
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
Console.WriteLine(header);


string pathAssembly = System.Reflection.Assembly.GetExecutingAssembly().Location;
string directory = System.IO.Path.GetDirectoryName(pathAssembly);
Console.WriteLine("Coloque os arquivos que deseja processar no diretório " + directory);
Console.WriteLine();
Console.WriteLine("Após isso pressione 'Enter'");
Console.ReadLine();
bool continuar = true;
while (continuar)
{
    Console.WriteLine("Lista de arquivos disponíveis");

    DirectoryInfo directoryInfo = new DirectoryInfo(directory);
    FileInfo[] Files = directoryInfo.GetFiles("*.txt");
    for (int i = 0; i < Files.Count(); i++)
    {
        Console.WriteLine(i + " - " + Files[i].Name);
    }
    Console.WriteLine("Digite qual arquivo deseja processar: ");
    int fileNumber = int.Parse(Console.ReadLine());
    string[] lines = System.IO.File.ReadAllLines(Files[fileNumber].FullName);
    account = new Account();

    for (int i = 0; i < lines.Length; i++)
    {
        input = lines[i];
        if (input != "")
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
    Console.WriteLine("Digite \"S\" para continuar, e N para sair:");
    continuar = Console.ReadLine() == "S";
}
#endregion

