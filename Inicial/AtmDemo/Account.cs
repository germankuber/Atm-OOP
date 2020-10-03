using AtmDemo.Errors;

namespace AtmDemo
{
    public class Account
    {
        private IAccountState _accountState;
        private Money _money;
        private readonly string _holder;

        internal Account(IAccountState accountState, Money money, string holder)
        {
            _accountState = accountState;
            _money = money;
            _holder = holder;
        }

        public decimal Summary() => _money.Amount;

        public void Deposit(Money amount) =>
            _accountState.Deposit(amount, money => _money += money);

        public void WithDraw(Money amount) =>
            _accountState.WithDraw(amount, (money => _money -= money));

        public void HolderVerified() => _accountState = _accountState.HolderVerified();

        public void Open() => _accountState = _accountState.Open();
        public void Close() => _accountState = _accountState.Close(_money);
        public AccountState State() => _accountState.State;
    }
}
