using System;
using System.Collections.Generic;
using System.IO;

namespace Tumakov
{
    enum BankTypes
    {
        Current,
        Saving
    }
    class Bank : IDisposable
    {
        private static uint accountNumberSeed = 0;
        public uint accountNumber { get; }
        public decimal accountBalance { get; private set; }
        public BankTypes accountBankType { get; private set; }
        private bool disposed = false;
        public Queue<BankTransaction> AllTransactions = new Queue<BankTransaction>();

        public Bank(decimal accountBalance, BankTypes accountBankType)
        {
            accountNumber = GenerateAccountNumber();
            this.accountBalance = accountBalance;
            this.accountBankType = accountBankType;
        }
        public Bank()
        {
            accountNumber = GenerateAccountNumber();
        }
        public Bank(decimal accountBalance)
        {
            accountNumber = GenerateAccountNumber();
            this.accountBalance = accountBalance;
        }
        public Bank(BankTypes accountBankType)
        {
            accountNumber = GenerateAccountNumber();
            this.accountBankType = accountBankType;
        }
        private uint GenerateAccountNumber()
        {
            accountNumberSeed++;
            return accountNumberSeed;
        }
        public void ReplenishAccountBalance(decimal accountBalance)
        {
            if (accountBalance >= 0)
            {
                this.accountBalance += accountBalance;
                BankTransaction replenishBalance = new BankTransaction(accountBalance);
                AllTransactions.Enqueue(replenishBalance);
            }
            else
                Console.WriteLine("Введено отрицательное значение!");
        }
        public void WithdrawAccountBalance(decimal accountBalance)
        {
            if (accountBalance <= this.accountBalance && accountBalance >= 0)
            {
                this.accountBalance -= accountBalance;
                BankTransaction withdrawBalance = new BankTransaction(accountBalance);
                AllTransactions.Enqueue(withdrawBalance);
            }    
            else
                Console.WriteLine("Недостаточно денег на счете! Либо введено отрицательное значение!");
        }
        public void TransferMoneyToAnotherAccount(Bank secondAccount, uint sumOfTransfer)
        {
            if (sumOfTransfer > 0)
            {
                if (accountBalance > sumOfTransfer)
                {
                    accountBalance -= sumOfTransfer;
                    secondAccount.accountBalance += sumOfTransfer;
                    BankTransaction transferBalance = new BankTransaction(sumOfTransfer);
                    AllTransactions.Enqueue(transferBalance);
                    Console.WriteLine("Деньги успешно переведены!");
                }
                else
                    Console.WriteLine("На счете недостаточно средств!");
            }
            else
                Console.WriteLine("Введите положительное значение!!!");
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    using (StreamWriter writer = new StreamWriter("AllTransactions.txt"))
                    {
                        foreach (var transaction in AllTransactions)
                        {
                            writer.WriteLine($"{transaction.DateTime} {transaction.SumOfTransaction}");
                        }
                    }
                }
                disposed = true;
            }
        }
        ~Bank()
        {
            Dispose(false);
        }
    }
}