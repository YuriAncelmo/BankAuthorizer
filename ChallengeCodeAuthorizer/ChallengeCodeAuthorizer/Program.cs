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
string? input = String.Empty;
Account? account;
string? directory = String.Empty;
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

if (args.Length == 0)
{
    string? pathAssembly = System.Reflection.Assembly.GetExecutingAssembly().Location;
    directory = System.IO.Path.GetDirectoryName(pathAssembly);
    Console.WriteLine("Como você não colocou nenhum arrquivo como parâmetro, coloque os arquivos que deseja processar no diretório " + directory);
    Console.WriteLine();
    Console.WriteLine("Após isso pressione 'Enter'");
    Console.ReadLine();
}
bool continuar = true;
while (continuar)
{
    string[] lines;
    if (args.Length == 0 && directory != null)
    {
        Console.WriteLine("Lista de arquivos disponíveis");

        DirectoryInfo directoryInfo = new(directory);
        FileInfo[] Files = directoryInfo.GetFiles("*.txt");
        for (int i = 0; i < Files.Length; i++)
        {
            Console.WriteLine(i + " - " + Files[i].Name);
        }
        Console.WriteLine("Digite qual arquivo deseja processar: ");
        string? option = Console.ReadLine();
        if (option != null)
            lines = System.IO.File.ReadAllLines(Files[int.Parse(option)].FullName);
        else
            lines = Array.Empty<string>();
    }
    else
        lines = System.IO.File.ReadAllLines(args[0]);

    account = new Account();

    for (int i = 0; i < lines.Length; i++)
    {
        input = lines[i];

        Helper.ReplaceJson(ref input);

        if (input != null)
        {
            dynamic? dynamic = JsonConvert.DeserializeObject<dynamic>(input);
            if (dynamic != null)
                if (Helper.ReturnTypeOfJson(input) == typeof(Account))
                {

                    Account? currentAccount = dynamic.account.ToObject<Account>();
                    if (currentAccount != null && account != null)
                    {
                        List<Violation> violations = new Evaluator(accountRules).Execute(account.State);

                        if (violations.Count == 0)
                            account = currentAccount;
                        
                        Console.WriteLine(JsonConvert.SerializeObject(account?.State.GetResponseAccount(violations)).ToLower());
                    }
                }
                else
                {
                    Transaction? transaction = dynamic.transaction.ToObject<Transaction>();
                    if (transaction != null && account != null)
                    {
                        account.State.currentTransaction = transaction;
                        List<Violation> violations = new Evaluator(transactionRules).Execute(account.State);

                        if (violations.Count == 0)
                            account.State.ProcessTransaction();

                        Console.WriteLine(JsonConvert.SerializeObject(account.State.GetResponseAccount(violations)).ToLower());
                    }
                }
        }
    }
    Console.WriteLine("Digite \"S\" para continuar, e N para sair:");
    continuar = Console.ReadLine() == "S";
}
#endregion

