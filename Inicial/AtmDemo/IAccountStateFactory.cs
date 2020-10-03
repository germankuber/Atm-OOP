namespace AtmDemo
{
    public interface IAccountStateFactory
    {
        IAccountState CreateOpenState();
        IAccountState CreateCloseState();
    }
}