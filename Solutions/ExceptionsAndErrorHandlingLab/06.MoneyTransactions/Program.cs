using System.Security.Principal;

string[] bankAccounts = Console.ReadLine()
    .Split(',')
    .ToArray();

var accountDetails =  new Dictionary<int, double>();

foreach (var account in bankAccounts)
{
    string[] accountArgs = account.Split("-");

    int number = int.Parse(accountArgs[0]);
    double balance = double.Parse(accountArgs[1]);

    accountDetails.Add(number, balance);
}

string input = Console.ReadLine();

while (input != "End")
{
    string[] cmdArgs = input.Split();
    try
    {
        string cmd = cmdArgs[0];
        if(cmd != "Deposit" &&  cmd != "Withdraw")
        {
            throw new ArgumentException("Invalid command!");
        }
        int number = int.Parse(cmdArgs[1]);
        if (!accountDetails.ContainsKey(number))
        {
            throw new ArgumentException("Invalid account!");
        }
        double sum = double.Parse(cmdArgs[2]);
        if(cmd == "Withdraw" && sum > accountDetails[number])
        {
            throw new ArgumentException("Insufficient balance!");
        }

        if(cmd == "Deposit")
        {
            accountDetails[number] += sum;
        }
        else if(cmd == "Withdraw")
        {
            accountDetails[number] -= sum;
        }

        Console.WriteLine($"Account {number} has new balance: {accountDetails[number]:f2}");
    }
    catch(ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }


    Console.WriteLine("Enter another command");
    input = Console.ReadLine();
}