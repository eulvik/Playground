using System;
using System.AddIn.Hosting;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using ServiceLoaderHostViewAdapter;

namespace ServiceCoHoster
{
    class Program
    {
        static Dictionary<AddInToken, IServiceLoader> _activatedTokens = new Dictionary<AddInToken, IServiceLoader>();
        static void Main(string[] args)
        {
            string addInRoot = Path.Combine(Environment.CurrentDirectory, "Pipeline");

            string[] warnings = AddInStore.Update(addInRoot);
            foreach (string warning in warnings)
                Console.WriteLine(warning);

            Collection<AddInToken> tokens = AddInStore.FindAddIns(typeof(IServiceLoader), addInRoot);

            RunServiceLoader(ChooseService(tokens), tokens);
        }
        private static void RunServiceLoader(IServiceLoader serviceLoader, Collection<AddInToken> tokens)
        {
            if (serviceLoader == null)
            {
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Available operations: load, start, stop");
            Console.WriteLine("Type \"exit\" to exit");
            String line = Console.ReadLine();
            try
            {
                switch (line)
                {
                    case "start":
                        Console.WriteLine("Host AppDomain: " + AppDomain.CurrentDomain.FriendlyName);
                        Console.WriteLine("Starting service result{0}", serviceLoader.StartService());
                        break;
                    case "stop":
                        Console.WriteLine("Host AppDomain: " + AppDomain.CurrentDomain.FriendlyName);
                        Console.WriteLine("Stopping service result{0}", serviceLoader.StopService());
                        break;
                    case "load":
                        Console.WriteLine("Host AppDomain: " + AppDomain.CurrentDomain.FriendlyName);
                        Console.WriteLine("Loading service result{0}", serviceLoader.LoadService());
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("{0} is an invalid command. Valid commands are load,start,stop", line);
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Invalid command: {0}. Commands must be formated: [number] [operation] [number]",
                    line);
            }


            RunServiceLoader(ChooseService(tokens), tokens);
        }

        private static IServiceLoader ChooseService(Collection<AddInToken> tokens)
        {
            if (tokens.Count == 0)
            {
                Console.WriteLine("No calculators are available");
                return null;
            }

            Console.WriteLine("Available Services: ");
            // Show the token properties for each token in the AddInToken collection  
            // (tokens), preceded by the add-in number in [] brackets. 
            int tokNumber = 1;
            foreach (AddInToken tok in tokens)
            {
                Console.WriteLine(String.Format("\t[{0}]: {1} - {2}\n\t{3}\n\t\t {4}\n\t\t {5} - {6}",
                    tokNumber.ToString(),
                    tok.Name,
                    tok.AddInFullName,
                    tok.AssemblyName,
                    tok.Description,
                    tok.Version,
                    tok.Publisher));
                tokNumber++;
            }
            Console.WriteLine("Which service do you want to use?");
            String line = Console.ReadLine();
            int selection;
            if (Int32.TryParse(line, out selection))
            {
                if (selection <= tokens.Count)
                {
                    var tokenToUse = tokens[selection - 1];
                    if (!_activatedTokens.ContainsKey(tokenToUse))
                        _activatedTokens[tokenToUse] = tokenToUse.Activate<IServiceLoader>(new AddInProcess(), AddInSecurityLevel.FullTrust);

                    return _activatedTokens[tokenToUse];
                }
            }
            Console.WriteLine("Invalid selection: {0}. Please choose again.", line);
            return ChooseService(tokens);
        }
    }
}
