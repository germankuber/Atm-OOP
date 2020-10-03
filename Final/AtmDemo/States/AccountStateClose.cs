
using System;

using AtmDemo.Errors;

namespace AtmDemo.States
{
    public class AccountStateClose : IAccountState
    {

        private readonly IAccountStateFactory _accountStateFactory;

        public AccountStateClose(IAccountStateFactory accountStateFactory)
        {
            _accountStateFactory = accountStateFactory;
        }

        public void Deposit(Money amount, Action<Money> depositMoney) =>

            throw new AccountClosedException();
        public void WithDraw(Money amount, Action<Money> withDrawMoney) =>
            throw new AccountClosedException();
       
        public IAccountState Open() => _accountStateFactory.CreateOpenState();

        public IAccountState Verify() => _accountStateFactory.CreateOpenState();

    }
}