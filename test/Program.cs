using System.IO;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ChildClass cc = new ChildClass();
            List<string> playerNames = new List<string>();
            StreamReader input = null;
            string name = "";

            while ((name = input.ReadLine()) != null)
            {
                playerNames.Add(name);
            }
        }
    }

    public class BaseClass
    {
        public BaseClass()
        {
            Console.WriteLine("I am a base class!");
        }
    }

    public class ChildClass : BaseClass
    {
        public ChildClass() : base()
        {
            Console.WriteLine("I am a child class!");
        }
    }
}
