int[] ints = Console.ReadLine()
    .Split(" ")
    .Select(int.Parse)
    .ToArray();

int catchNumber = 0;

while(catchNumber < 3)
{
    string[] cmdArgs = Console.ReadLine()
        .Split(" ")
        .ToArray();

    string cmd = cmdArgs[0];

    if(cmd == "Replace")
    {
        try
        {
            int index = int.Parse(cmdArgs[1]);
            int element = int.Parse(cmdArgs[2]);

            if(index < 0 || index >= ints.Length)
            {
                throw new IndexOutOfRangeException();
            }
            ints[index] = element;

        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("The index does not exist!");
            catchNumber++;
        }
        catch (FormatException)
        {
            Console.WriteLine("The variable is not in the correct format!");
            catchNumber++;
        }
    }
    else if(cmd == "Print")
    {
        try
        {
            int startIndex = int.Parse(cmdArgs[1]);
            int endIndex = int.Parse(cmdArgs[2]);
            if (startIndex < 0 || startIndex >= ints.Length || endIndex < 0 || endIndex >= ints.Length)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = startIndex; i <= endIndex; i++)
            {
                if(i != endIndex)
                {
                    Console.Write(ints[i] + ", ");
                }
                else
                {
                    Console.WriteLine(ints[i]);
                }
            }
        }
        catch(IndexOutOfRangeException)
        {
            Console.WriteLine("The index does not exist!");
            catchNumber++;
        }
        catch (FormatException)
        {
            Console.WriteLine("The variable is not in the correct format!");
            catchNumber++;
        }
    }
    else if(cmd == "Show")
    {
        try
        {
            int index = int.Parse(cmdArgs[1]);
            if(index < 0 || index >= ints.Length)
            {
                throw new IndexOutOfRangeException();
            }
            Console.WriteLine(ints[index]);
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("The index does not exist!");
            catchNumber++;
        }
        catch (FormatException)
        {
            Console.WriteLine("The variable is not in the correct format!");
            catchNumber++;
        }
    }

}


Console.WriteLine(String.Join(", ", ints));