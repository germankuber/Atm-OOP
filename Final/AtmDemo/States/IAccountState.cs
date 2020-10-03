using System;

namespace AtmDemo.States
{
    public interface IAccountState
    {
        void Deposit(Money amount, Action<Money> depositMoney);
        void WithDraw(Money amount, Action<Money> withDrawMoney);
        IAccountState Open();
        IAccountState Verify();
    }
}