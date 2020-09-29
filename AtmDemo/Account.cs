using System;
using AtmDemo.Errors;

namespace AtmDemo
{
    public class Account
    {
        private bool _isVerified = false;
        private bool _isOpen = false;
        private decimal _amount;
        private readonly string _holder;

        public Account(bool isVerified, bool isOpen, decimal initialAmount, string holder)
        {
            _isVerified = isVerified;
            _isOpen = isOpen;
            _amount = initialAmount;
            _holder = holder;
        }

        public decimal Summary() => _amount;

        public void Deposit(decimal amount)
        {
            if (!_isOpen)
            {
                Console.WriteLine("La cuenta se encuentra cerrada");
                throw new AccountClosedException();
            }
            if (_isOpen && !_isVerified)
            {
                Console.WriteLine("La cuenta no se encuentra verificada");
                throw new AccountNotVerifiedException();
            }
            if (_isOpen && _isVerified)
                deposit(amount);
        }
        private void deposit(decimal amount) => this._amount += amount;

        public void WithDraw(decimal amount)
        {
            if (!_isOpen)
            {
                Console.WriteLine("La cuenta se encuentra cerrada");
                throw new AccountClosedException();
            }
            if (_isOpen && !_isVerified)
            {
                Console.WriteLine("La cuenta no se encuentra verificada");
                throw new AccountNotVerifiedException();
            }
            if (_isOpen && _isVerified)
                withDraw(amount);

        }
        private void withDraw(decimal amount)
        {
            if (amount <= this._amount)
                this._amount -= amount;
            else
            {
                Console.WriteLine("La cuenta no tiene suficiente dinero");
                throw new AccountHasNotMoneyException();
            }
        }

        public void HolderVirfied()
        {
            //No se puede verificar una cuenta si esta no se encuentra abierta
            if (!_isOpen)
                throw new AccountClosedException();

            _isVerified = true;
        }
        public void Open()
        {
            _isOpen = true;
        }
        public void Close()
        {
            if (_amount > 0)
                throw new AccountHasMoneyException();

            this._isOpen = false;

        }
        public AccountState State()
        {
            if (_isOpen)
                return AccountState.Open;

            return AccountState.Close;
        }
    }
}
