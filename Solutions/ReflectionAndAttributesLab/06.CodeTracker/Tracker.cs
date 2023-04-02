using System.Reflection;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);
            MethodInfo[] methods = type.GetMethods();

            foreach (MethodInfo method in methods)
            {
                if(method.GetCustomAttributes(typeof(AuthorAttribute)) is not null)
                {
                    AuthorAttribute[] authorAttributes = method.GetCustomAttributes(typeof(AuthorAttribute), true) as AuthorAttribute[];

                    foreach (AuthorAttribute authorAttribute in authorAttributes)
                    {
                        Console.WriteLine($"{method.Name} is written by {authorAttribute.Name}");
                    }
                }
            }
        }
    }
}
