using System;

using AtmDemo.Errors;

namespace AtmDemo
{


    public class AccountStateClose : IAccountState
    {
        public AccountState State => AccountState.Close;
        public void Deposit(Money amount, Action<Money> depositMoney) =>
            throw new AccountClosedException();

        public void WithDraw(Money amount, Action<Money> withDrawMoney) =>
            throw new AccountClosedException();

        public IAccountState Open() => new AccountStateOpen();

        public IAccountState HolderVerified() => throw new AccountClosedException();

        public IAccountState Close(Money money) => this;
    }
}