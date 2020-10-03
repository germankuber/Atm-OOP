using System;

using AtmDemo.Errors;

namespace AtmDemo
{
    public class AccountStateNotVerified : IAccountState
    {
        public AccountState State => AccountState.Close;
        public void Deposit(Money amount, Action<Money> depositMoney) =>
            throw new AccountNotVerifiedException();

        public void WithDraw(Money amount, Action<Money> withDrawMoney) =>
            throw new AccountNotVerifiedException();

        public IAccountState Open() => new AccountStateOpen();

        public IAccountState HolderVerified() => new AccountStateOpen();

        public IAccountState Close(Money money)
        {
            if (money.Amount > 0)
                throw new AccountHasMoneyException();
            return new AccountStateClose();
        }

    }
}