using System;

namespace Tumakov
{
    internal class Program
    {
        static void Lesson1()
        {
            Bank account1 = new Bank(560, BankTypes.Current);
            Bank account2 = new Bank(560);
            Bank account3 = new Bank(BankTypes.Current);
            Bank account4 = new Bank();

            Console.WriteLine(account1.accountBalance);
            Console.WriteLine(account2.accountBankType);
            Console.WriteLine(account3.accountBalance);
            Console.WriteLine(account4.accountBalance);
        }
        static void Lesson2()
        {
            Bank account = new Bank(2000);
            account.WithdrawAccountBalance(500);
            account.ReplenishAccountBalance(1000);
            foreach (var item in account.AllTransactions) { 
                Console.WriteLine($"Время изменения баланса: {item.DateTime}\nСумма изменения баланса: {item.SumOfTransaction}");
            }
        }
        static void Lesson3()
        {
            using (var account = new Bank(2500))
            {              
                account.WithdrawAccountBalance(500);
                account.ReplenishAccountBalance(1000);
            }
        }
        static void Main(string[] args)
        {
            //Lesson1();
            //Lesson2();
            //Lesson3();

            Song song = new Song("Lalalala", "Y2K");
            Song song2 = new Song("LadaSedan", "Timati", song);
            Song song3 = new Song("Cadilac", "Morgenshtern", song2);
            Console.WriteLine(song3.previousSong.name);
        }
    }
}
