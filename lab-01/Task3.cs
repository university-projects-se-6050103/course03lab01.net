using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace lab_01
{
    public class Task3
    {
        public static void Run()
        {
            var lectors = ReadLectors();
            PrintLectorsList(lectors);
            var chosenLector = lectors[GetLectorChoise(lectors.Count) - 1];

            Console.WriteLine(
                $@"
                Hello Dear Lector {chosenLector.Item1}!
                My name is {Environment.MachineName}
                I am very glad to be present at your lecture: {chosenLector.Item2} now: {DateTime.Today}
                I am working on computer with name: {Dns.GetHostName()}, IP address: {GetIp().GetAwaiter().GetResult()}
                and MAC address: {GetMacAddress()}
                I realized that next time tasks from you will be more complicated, hope I'll cope with them.
                "
            );

            // Preserve exit
            Console.ReadKey();
        }

        private static List<Tuple<string, string>> ReadLectors()
        {
            var lectors = new List<Tuple<string, string>>();

            foreach (var line in File.ReadLines("./lectors.txt"))
            {
                if (line.Trim().Length < 5)
                {
                    continue;
                }

                var lector = line.Split('-')?[0].Trim();
                var subject = line.Split('-')?[1].Trim();

                if (string.IsNullOrEmpty(lector) || string.IsNullOrEmpty(subject))
                {
                    continue;
                }

                lectors.Add(Tuple.Create(lector, subject));
            }


            lectors.Sort((a, b) => string.Compare(a.Item1, b.Item1, StringComparison.Ordinal));

            return lectors;
        }

        private static void PrintLectorsList(List<Tuple<string, string>> lectors)
        {
            var lectorIndex = 0;
            lectors.ForEach(lector => { Console.WriteLine($"{++lectorIndex} {lector.Item1} - {lector.Item2}"); });
        }

        private static int GetLectorChoise(int lectorsSize)
        {
            Console.WriteLine("Choose a lector");
            var choiceString = Console.ReadLine();
            int choiceInt;
            var parseResult = int.TryParse(choiceString, out choiceInt);

            if (parseResult)
            {
                if (choiceInt <= 0 || choiceInt > lectorsSize)
                {
                    Console.WriteLine("Chosen number is invalid. Please try again");
                    return GetLectorChoise(lectorsSize);
                }

                return choiceInt;
            }

            Console.WriteLine("Invalid input. Please try again");
            return GetLectorChoise(lectorsSize);
        }

        private static async Task<string> GetIp()
        {
            return (await Dns.GetHostAddressesAsync(Dns.GetHostName()))[0].MapToIPv4().ToString();
        }

        private static string GetMacAddress()
        {
            return "00-14-22-01-23-45"; // TODO Get a real MAC address
        }
    }
}