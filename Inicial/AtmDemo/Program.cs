using System;

namespace AtmDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new Account(false, false, 1000, "Germán Küber");

            var atmMachine = new AtmMachine(account);
        }
    }
}
