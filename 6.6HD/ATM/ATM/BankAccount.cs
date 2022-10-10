using System;

namespace ATM
{
    public class BankAccount
    {
        public string Name { get; set; }
        public Int64 AccountNumber { get; set; }
        public Int64 CardNumber { get; set; }
        public Int64 PinCode { get; set; }
        public decimal Balance { get; set; }
        public bool IsLocked { get; set; }
    }
}
