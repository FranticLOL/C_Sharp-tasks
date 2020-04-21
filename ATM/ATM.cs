using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ATM
{
    class ATM
    {
        protected List<List<int>> exchange(int value, int[] banknotes)
        { //basic algorithm
            List<List<int>> result = new List<List<int>>();
            Array.Sort(banknotes);
            for (int i = banknotes.Length - 1; i > -1; --i)
            {
                if (value - banknotes[i] < 0)
                {
                    continue;
                }
                if (value - banknotes[i] == 0)
                {
                    List<int> buffer = new List<int>();
                    buffer.Add(banknotes[i]);
                    result.Add(buffer);
                }
                if (value - banknotes[i] > 0)
                {
                    foreach (List<int> buffer in exchange(value - banknotes[i], copyOfRange(banknotes, 0, i + 1)))
                    {
                        buffer.Add(banknotes[i]);
                        result.Add(buffer);
                    }
                }
            }

            return result;
        }

        public void work() {
            List<int> banknotes = new List<int>();
            Console.WriteLine("Input a banknotes: ");
            string bank = Console.ReadLine();
            Regex pattern = new Regex("\\s*\\s");
            String[] banknotesStr = pattern.Split(bank);
            string pattern2 = "[0-9]+";
            Regex rgx = new Regex(pattern2);

            for (int i = 0; i < banknotesStr.Length; i++)
            {
                if (rgx.Match(banknotesStr[i]).Success)
                {
                    if (Int32.Parse(banknotesStr[i]) > 0)
                    {
                        banknotes.Add(Int32.Parse(banknotesStr[i]));
                    }
                    else
                    {
                        throw new ATMExeption("You cannot enter not positive banknote: ", Int32.Parse(banknotesStr[i]));
                    }
                }
                else
                {
                    throw new IOException("Incorrect input of banknotes");
                }
            }

            Console.WriteLine("Input output value: ");
                String value = Console.ReadLine();

                if (Int32.Parse(value) <= 0) {
                    throw new ATMExeption("You cannot enter not positive value: ", Int32.Parse(value));
                }

                banknotes = removeDuplicates(banknotes);

                int[] banknotesArr = banknotes.ToArray();
                List<List<int>> result = exchange(Int32.Parse(value), banknotesArr);
                Console.WriteLine("Number of options: " + result.Count);

                foreach (List<int> integers in result) {
                    foreach (int number in integers) {
                        if (number <= 0) {
                            throw new ATMExeption("Result error", number);
                        }
                    }
                }
                result.ForEach(element => {
                    element.ForEach(num => Console.Write(num + " "));
                    Console.WriteLine();
                    });

        }

        int[] copyOfRange(int[] src, int start, int end)
        {
            int len = end - start;
            int[] dest = new int[len];
            Array.Copy(src, start, dest, 0, len);
            return dest;
        }

        List<int> removeDuplicates(List<int> banknotes)
        {
            HashSet<int> set = new HashSet<int>();
            return set.Union(banknotes).ToList();
        }

    }

    public class ATMExeption : Exception
        {

        public ATMExeption(String message, int banknote) : base(message + banknote)
            {
            }
        }
}
