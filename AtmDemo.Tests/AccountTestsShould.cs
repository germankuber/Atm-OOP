using AtmDemo.Errors;
using Xunit;

namespace AtmDemo.Tests
{

    public class AccountTestsShould
    {
        private Account _sut;
        private AtmMachine _atmMachine;

        public AccountTestsShould()
        {
            _sut = new Account(false, false, 1000, "Germán Küber");

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
            _atmMachine.HolderVirfied();
            _atmMachine.Deposit(100);
            Assert.Equal(1100, _atmMachine.Summary());
        }

        [Fact]
        public void Cant_WithDraw_Money_Is_Not_Closed()
        {
            Assert.Throws<AccountClosedException>(() => _atmMachine.WithDraw(100));
        }

        [Fact]
        public void Cant_WithDraw_Money_Does_Not_Have_Enough_Money()
        {
            _atmMachine.OpenAccount();
            _atmMachine.HolderVirfied();
            Assert.Throws<AccountHasNotMoneyException>(() => _atmMachine.WithDraw(10000));
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
            _atmMachine.HolderVirfied();
            _atmMachine.WithDraw(100);
            Assert.Equal(900, _atmMachine.Summary());
        }

        [Fact]
        public void Cant_Verified_Account_Is_Not_Open()
        {
            //No se puede verificar una cuenta si esta no se encuentra abierta
            Assert.Throws<AccountClosedException>(() => _atmMachine.HolderVirfied());
        }
        [Fact]
        public void Cant_Close_Account_Has_Money()
        {
            //Cerrar cuenta del cliente
            // No se puede cerrar si este tiene dinero
            Assert.Throws<AccountHasMoneyException>(() => _atmMachine.CloseAccount());
        }
        [Fact]
        public void Can_Close_Account()
        {
            //Cerrar cuenta del cliente
            // No se puede cerrar si este tiene dinero
            AccountAlreadyToOperate();
            _atmMachine.WithDraw(1000);
            _atmMachine.CloseAccount();

            Assert.Equal(AccountState.Close, _atmMachine.StateAccount());

        }

        [Fact]
        public void Be_Open()
        {
            _atmMachine.OpenAccount();
            Assert.Equal(AccountState.Open, _atmMachine.StateAccount());
        }


        private void AccountAlreadyToOperate()
        {
            _atmMachine.OpenAccount();
            _atmMachine.HolderVirfied();
        }
    }
}