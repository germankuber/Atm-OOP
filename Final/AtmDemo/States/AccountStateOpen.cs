using System;

namespace AtmDemo.States
{
    public class AccountStateOpen: IAccountState
    {
        public void Deposit(Money amount, Action<Money> depositMoney) =>
            depositMoney(amount);
        public void WithDraw(Money amount, Action<Money> withDrawMoney) =>
            withDrawMoney(amount);

        public IAccountState Open() => this;

        public IAccountState Verify() => this;
    }
}