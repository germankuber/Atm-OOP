namespace AtmDemo
{
    public static class AccountBuilder
    {
        private static readonly IAccountStateFactory Factory = new AccountStateFactory();
        public static Account CreateOpenAccount(Money initialMoney, string holder) =>
            new Account(Factory.CreateOpenState(), initialMoney, holder);
        public static Account CreateCloseAccount(Money initialMoney, string holder) =>
            new Account(Factory.CreateCloseState(), initialMoney, holder);
    }
}