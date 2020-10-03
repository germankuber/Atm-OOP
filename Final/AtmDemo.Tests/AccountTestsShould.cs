using AtmDemo.Errors;
using Xunit;

namespace AtmDemo.Tests
{

    public class AccountTestsShould
    {
        private readonly Account _sut;
        private readonly AtmMachine _atmMachine;

        public AccountTestsShould()
        {
            _sut = AccountBuilder.CloseAccount(  Money.Create(1000), "Germán Küber");

            _atmMachine = new AtmMachine(_sut);
        }
        [Fact]
        public void Cant_Deposit_Money_Is_Not_Closed()
        {
            Assert.Throws<AccountClosedException>(() => _atmMachine.Deposit(100));
        }
        [Fact]
        public void Cant_Deposit_Money_Is_Not_Verified()
        {
            _atmMachine.OpenAccount();
            Assert.Throws<AccountNotVerifiedException>(() => _atmMachine.Deposit(100));
        }
        [Fact]
        public void Can_Deposit_Money()
        {
            _atmMachine.OpenAccount();
            _atmMachine.HolderVerified();
            _atmMachine.Deposit(100);
            Assert.Equal(1100, _atmMachine.Summary());
        }

        [Fact]
        public void Cant_WithDraw_Money_Is_Not_Closed()
        {
            Assert.Throws<AccountClosedException>(() => _atmMachine.WithDraw(100));
        }
        [Fact]
        public void Cant_WithDraw_Money_Is_Not_Verified()
        {
            _atmMachine.OpenAccount();
            Assert.Throws<AccountNotVerifiedException>(() => _atmMachine.WithDraw(100));
        }
        [Fact]
        public void Can_WithDraw_Money()
        {
            _atmMachine.OpenAccount();
            _atmMachine.HolderVerified();
            _atmMachine.WithDraw(100);
            Assert.Equal(900, _atmMachine.Summary());
        }
    }
}