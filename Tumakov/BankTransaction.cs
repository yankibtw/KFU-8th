using System;

namespace Tumakov
{
    class BankTransaction
    {
        public readonly DateTime DateTime;
        public readonly decimal SumOfTransaction;

        public BankTransaction(decimal SumOfTransaction)
        {
            this.SumOfTransaction = SumOfTransaction;
            DateTime = DateTime.Now;
        }

    }
}
