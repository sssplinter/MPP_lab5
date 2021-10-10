using System;
using System.Linq;
using System.Reflection;


namespace Lab5
{
    internal class Program
    {
        public static int Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Not correct input");
                return 1;
            }

            var filePath = args[0];

            var s  = AssemblyReader.AssemblyReader.GetAttributeAssemblyInfo(filePath);
            
            // var assembly = Assembly.LoadFile(filePath);
            // var types = assembly.GetTypes().Where(t => t.IsPublic).OrderBy(t => t.Namespace + t.Name);
            // foreach (var type in types)
            // {
            //     Console.WriteLine(type.FullName);
            // }
            return 0;
        }
    }
}