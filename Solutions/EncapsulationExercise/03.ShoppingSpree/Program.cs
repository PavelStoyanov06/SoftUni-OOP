using _03.ShoppingSpree;

List<Person> people = new List<Person>();
List<Product> products = new List<Product>();

try
{
    string[] nameMoneyPairs = Console.ReadLine()
        .Split(";", StringSplitOptions.RemoveEmptyEntries)
        .ToArray();

    foreach (var pair in nameMoneyPairs)
    {
        string[] nameMoney = pair
            .Split("=", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        Person person = new Person(nameMoney[0], decimal.Parse(nameMoney[1]));
        people.Add(person);
    }

    string[] nameCostPairs = Console.ReadLine()
        .Split(";", StringSplitOptions.RemoveEmptyEntries)
        .ToArray();

    foreach (var pair in nameCostPairs)
    {
        string[] nameCost = pair
            .Split("=", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        Product product = new Product(nameCost[0], decimal.Parse(nameCost[1]));
        products.Add(product);
    }
}
catch(ArgumentException ex)
{
    Console.WriteLine(ex.Message);
    return;
}

string input;
while ((input = Console.ReadLine()) != "END")
{
    string[] cmdArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string personName = cmdArgs[0];
    string productName = cmdArgs[1];

    Person person = people.FirstOrDefault(x => x.Name == personName);
    Product product = products.FirstOrDefault(y => y.Name == productName);

    if(person is not null && product is not null)
    {
        Console.WriteLine(person.Add(product));
    }
}

foreach (var person in people)
{
    Console.WriteLine(person);
}