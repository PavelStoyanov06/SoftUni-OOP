const int End = 100;

int start = 1;

int[] arr = new int[10];

for (int i = 0; i < arr.Length; i++)
{
	int num = ReadNumber(start, End);
	if(num is 0)
	{
		i--;
		continue;
	}
	arr[i] = num;
	start = num;
}

Console.WriteLine(String.Join(", ", arr));




int ReadNumber(int start, int end)
{
	int number = 0;
	try
	{
		number = int.Parse(Console.ReadLine());
		if(number <= start || number >= end)
		{
			throw new ArgumentOutOfRangeException();
		}
	}
	catch (FormatException)
	{
        Console.WriteLine("Invalid Number!");
		return 0;
    }
	catch(ArgumentOutOfRangeException ex)
	{
		Console.WriteLine($"Your number is not in range {start} - {end}!");
		return 0;
	}

	return number;
}