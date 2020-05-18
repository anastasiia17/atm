using System;
using System.Collections.Generic;
using System.Linq;

namespace bankomat
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var banknotesSet = new SortedSet<int>();
            try
            {
                Console.WriteLine("Enter sum of money");
                var sum = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Empty Argument"));
                if (sum <= 0)
                {
                    throw new ArgumentException("Not valid argument");
                }

                Console.WriteLine("Enter banknotes nominal");
                var banknotes = Console.ReadLine()?.Split(' ').ToArray();
                if (banknotes != null)
                    foreach (var banknote in banknotes)
                    {
                        int value = int.Parse(banknote);
                        if (value <= 0)
                        {
                            throw new ArgumentException("Not valid argument");
                        }
                        
                        banknotesSet.Add(value);
                    }
                else
                {
                    throw new ArgumentException("Empty Argument");
                }
                int[] banknotesArray = banknotesSet.ToArray();              
                ExchangeCoins exchanger = new ExchangeCoins(banknotesArray);
                List<string> result = exchanger.Exchange(sum);
                
                Console.WriteLine("Number of combinations: " + result.Count);
                result.ForEach(Console.WriteLine);
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(1);
            }


        }
    }
}