using System;

namespace ATM
{
    public class VMTransfer
    {
        public decimal TransferAmount { get; set; }
        public Int64 RecipientAccountNumber { get; set; }
        public string RecipientAccountName { get; set; }
    }
}
