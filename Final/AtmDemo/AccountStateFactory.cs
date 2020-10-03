using AtmDemo.States;

namespace AtmDemo
{
    public class AccountStateFactory : IAccountStateFactory
    {
        public IAccountState CreateOpenState() => new AccountStateOpen();
        public IAccountState CreateCloseState() => new AccountStateClose(this);
    }
}