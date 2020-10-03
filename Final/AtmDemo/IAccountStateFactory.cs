using AtmDemo.States;

namespace AtmDemo
{
    public interface IAccountStateFactory
    {
        IAccountState CreateOpenState();
        IAccountState CreateCloseState();
    }
}