using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            ATM atm = new ATM();
            try
            {
                atm.work();
            }
            catch (IOException ex) {
                Console.WriteLine(ex.Message);
            }
            catch(ATMExeption ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}