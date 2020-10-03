using System;

namespace AtmDemo
{
    public interface IAccountState
    {
        AccountState State { get; }
        void Deposit(Money amount, Action<Money> depositMoney);
        void WithDraw(Money amount, Action<Money> withDrawMoney);
        IAccountState Open();
        IAccountState HolderVerified();
        IAccountState Close(Money money);
    }
}