using System;

using AtmDemo.Errors;
using AtmDemo.States;

namespace AtmDemo
{
    public class Account
    {
        private IAccountState _state;
        private readonly IAccountStateFactory _stateFactory;
        private Money _money;
        private readonly string _holder;

        internal Account(IAccountState accountState,
            IAccountStateFactory stateFactory,
            Money initialMoney,
            string holder)
        {
            _state = accountState;
            _stateFactory = stateFactory;
            _money = initialMoney;
            _holder = holder;
        }

        public decimal Summary() => _money.Amount;


        public void Deposit(Money money) =>
            _state.Deposit(money, moneyToDeposit => _money += moneyToDeposit);


        public void WithDraw(Money money) =>
            _state.WithDraw(money, moneyToDeposit => _money -= moneyToDeposit);


        public void HolderVerified() => _state = _stateFactory.CreateOpenState();

        public void Open() => _state = _stateFactory.CreateOpenState();
    }
}
