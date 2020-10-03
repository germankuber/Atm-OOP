namespace AtmDemo
{
    public static class AccountBuilder
    {
        private static readonly IAccountStateFactory AccountStateFactory = new AccountStateFactory();
        public static Account OpenAccount(Money initialAmount, string holder) =>
            new Account(AccountStateFactory.CreateOpenState(), AccountStateFactory, initialAmount, holder);
        public static Account CloseAccount(Money initialAmount, string holder) =>
            new Account(AccountStateFactory.CreateCloseState(), AccountStateFactory, initialAmount, holder);
    }
}