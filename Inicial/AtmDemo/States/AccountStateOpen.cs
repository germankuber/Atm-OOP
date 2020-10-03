using System;

using AtmDemo.Errors;

namespace AtmDemo
{
    public class AccountStateOpen : IAccountState
    {
        public AccountState State => AccountState.Open;
        public void Deposit(Money amount, Action<Money> depositMoney) =>
            depositMoney(amount);

        public void WithDraw(Money amount, Action<Money> withDrawMoney) =>
            withDrawMoney(amount);

        public IAccountState Open() => this;

        public IAccountState HolderVerified() => this;

        public IAccountState Close(Money money)
        {
            if (money.Amount > 0)
                throw new AccountHasMoneyException();
            return new AccountStateClose();
        }
    }
}