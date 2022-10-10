using System;
using System.ComponentModel;

namespace ATM
{
    public enum SecureMenu
    {
        // have to assign values because enum would start with 0 if no value was given

        [Description("Check Balance")]
        CheckBalance = 1,

        [Description("Place Deposit")]
        PlaceDeposit = 2,

        [Description("Make Withdrawal")]
        MakeWithdrawal = 3,

        [Description("Perform Transfer")]
        PerformTransfer = 4,

        [Description("Transaction")]
        ViewTransaction = 5,

        [Description("Logout")]
        Logout = 6
    }

    public static class Screen
    {
        internal static string currency = "AUD"; // initially used VND

        public static VMTransfer TransferForm()
        {
            var vmTransfer = new VMTransfer();

            vmTransfer.RecipientAccountNumber = Utility.GetValidIntInput("recipient's account number");
            vmTransfer.TransferAmount = Utility.GetValidDecimalInput("amount");
            vmTransfer.RecipientAccountName = Utility.GetRawInput("recipient's account name");

            return vmTransfer;
        }
        
        public static void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("LTDA ATM Main Menu");
            Console.WriteLine("\n1. Insert card");
            Console.WriteLine("2. Exit\n");
        }

        public static void ShowSecureMenu()
        {
            Console.Clear();
            Console.WriteLine("LTDA ATM Secure Menu");
            Console.WriteLine("\n1. Balance Enquiry");
            Console.WriteLine("2. Cash Deposit");
            Console.WriteLine("3. Withdrawal");
            Console.WriteLine("4. Money Transfer");
            Console.WriteLine("5. Transactions");
            Console.WriteLine("6. Logout\n");
        }
    }
}
