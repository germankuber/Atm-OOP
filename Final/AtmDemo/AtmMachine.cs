namespace AtmDemo
{
    public class AtmMachine
    {
        private readonly Account _account;

        public AtmMachine(Account account)
        {
            _account = account;
        }

        public void Deposit(decimal amount) => _account.Deposit( Money.Create(amount));
        public void WithDraw(decimal amount) => _account.WithDraw(Money.Create(amount));
        public void HolderVerified() => _account.HolderVerified();
        public decimal Summary() => _account.Summary();
        public void OpenAccount() => _account.Open();



    }
}
