
using System;
using AtmDemo.Errors;

namespace AtmDemo.States
{

    public class AccountStateNoVerified: IAccountState
    {
        private readonly IAccountStateFactory _accountStateFactory;

        public AccountStateNoVerified(IAccountStateFactory accountStateFactory)
        {
            _accountStateFactory = accountStateFactory;
        }
        public void Deposit(Money amount, Action<Money> depositMoney)=>

            throw new AccountNotVerifiedException();
        public void WithDraw(Money amount, Action<Money> withDrawMoney) =>
            throw new AccountNotVerifiedException();
        public IAccountState Open() => _accountStateFactory.CreateOpenState();

        public IAccountState Verify() => _accountStateFactory.CreateOpenState();

    }
}