using AtmDemo.Errors;

namespace AtmDemo
{
    public class Money
    {
        public decimal Amount { get; }

        private Money(decimal amount)
        {
            Amount = amount;
        }

        public static Money Create(decimal initialAmount)
        {
            if (initialAmount <= 0)
                throw new AccountHasNotMoneyException();
            return new Money(initialAmount);
        }

        public static Money operator +(Money x, Money y) =>
            new Money(x.Amount + y.Amount);

        public static Money operator -(Money x, Money y)
        {
            if (x.Amount - y.Amount < 0)
                throw new AccountHasNotMoneyException();
            return new Money(x.Amount - y.Amount);
        }
    }
}