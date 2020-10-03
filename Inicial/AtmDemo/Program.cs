using System;

namespace AtmDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = AccountBuilder.CreateOpenAccount(Money.Create(1000), "Germán Küber");

            var atmMachine = new AtmMachine(account);

            atmMachine.WithDraw(1000);
            atmMachine.CloseAccount();
            atmMachine.Deposit(200);

            var summary = atmMachine.Summary();
        }
    }
}
