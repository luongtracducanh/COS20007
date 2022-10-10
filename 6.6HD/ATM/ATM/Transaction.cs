using System;

namespace ATM
{
    public enum TransactionType
    {
        Deposit,
        Withdrawal,
        Transfer
    }

    public class Transaction
    {
        public TransactionType TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public int TransactionID { get; set; }
        public Int64 BankAccountNoFrom { get; set; }
        public Int64 BankAccountNoTo { get; set; }
        public decimal TransactionAmount { get; set; }
    }
}
