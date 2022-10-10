using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleTables;

namespace ATM
{
    class LTDAbankATM : ILogin, IBalance, IDeposit, IWithdrawal, ITransfer, ITransaction
    {
        private static int attempts;
        private const int maxAttempts = 3;
        private const int minimumBalance = 10;
        private static decimal transactionAmount;

        private static List<BankAccount> _accountList;
        private static List<Transaction> _listOfTransactions;
        private static BankAccount selectedAccount;
        private static BankAccount inputAccount;

        public void Initialize()
        {
            transactionAmount = 0;
            _accountList = new List<BankAccount> // store account's data when initalize
            {
                new BankAccount() { Name = "Bach", AccountNumber = 180803, CardNumber = 123, PinCode = 111111, 
                    Balance = 1700.00m, IsLocked = false },
                new BankAccount() { Name = "Minh", AccountNumber = 140203, CardNumber = 456, PinCode = 222222, 
                    Balance = 3507.30m, IsLocked = false },
                new BankAccount() { Name = "Tuan", AccountNumber = 250903, CardNumber = 789, PinCode = 333333, 
                    Balance = 2905.12m, IsLocked = true }
            };
        }

        public void Execute()
        {
            // call the show menu methods up to each state of the program

            Screen.ShowMainMenu();

            while (true)
            {
                switch (Utility.GetValidIntInput("your option"))
                {
                    case 1:
                        CheckPassword();
                        _listOfTransactions = new List<Transaction>();
                        while (true)
                        {
                            Screen.ShowSecureMenu();
                            switch (Utility.GetValidIntInput("your option"))
                            {
                                case (int)SecureMenu.CheckBalance:
                                    CheckBalance(selectedAccount);
                                    break;
                                case (int)SecureMenu.PlaceDeposit:
                                    PlaceDeposit(selectedAccount);
                                    break;
                                case (int)SecureMenu.MakeWithdrawal:
                                    MakeWithdrawal(selectedAccount);
                                    break;
                                case (int)SecureMenu.PerformTransfer:
                                    var vMThirdPartyTransfer = new VMTransfer();
                                    vMThirdPartyTransfer = Screen.TransferForm();
                                    PerformTransfer(selectedAccount, vMThirdPartyTransfer);
                                    break;
                                case (int)SecureMenu.ViewTransaction:
                                    ViewTransaction(selectedAccount);
                                    break;
                                case (int)SecureMenu.Logout:
                                    Utility.PrintMessage("You have succesfully logout. Please collect your ATM card.", true);
                                    Execute();
                                    break;
                                default:
                                    Utility.PrintMessage("Invalid option entered.", false);
                                    break;
                            }
                        }
                    case 2:
                        Console.Write("\nThank you for using LTDA Bank. Exiting program now.");
                        Utility.printDotAnimation();
                        Environment.Exit(1);
                        break;
                    default:
                        Utility.PrintMessage("Invalid option entered.", false);
                        break;
                }
            }
        }

        public static void LockAccount() 
        {
            // exit the program when account's status is locked

            Console.Clear();
            Utility.PrintMessage("Your account is locked.", false);
            Console.WriteLine("If this is a mistake, please contact LTDA Bank to give your clarification statement " +
                "and unlock your account.");
            Console.ReadKey();
            Environment.Exit(1);
        }

        public void CheckPassword() 
        {
            // PIN validation

            bool pass = false;

            while (!pass)
            {
                inputAccount = new BankAccount();
                inputAccount.CardNumber = Utility.GetValidIntInput("ATM Card Number");

                Console.WriteLine("\nNote: For security reason, your PIN input will be hidden from the screen.");
                Console.Write("Enter 6-digit PIN: ");
                inputAccount.PinCode = Convert.ToInt32(Utility.GetHiddenConsoleInput());

                Console.Write("\nChecking card number and password.");
                Utility.printDotAnimation();

                foreach (BankAccount account in _accountList)
                {
                    if (inputAccount.CardNumber.Equals(account.CardNumber))
                    {
                        selectedAccount = account;
                        if (inputAccount.PinCode.Equals(account.PinCode))
                        {
                            if (selectedAccount.IsLocked)
                            {
                                LockAccount();
                            }
                            else
                            {
                                pass = true;
                            }
                        }
                        else
                        {
                            pass = false;
                            attempts++;
                            if (attempts >= maxAttempts)
                            {
                                selectedAccount.IsLocked = true;
                                LockAccount();
                            }
                        }
                    }
                }
                if (!pass)
                {
                    Utility.PrintMessage("Invalid card number or PIN.", false);
                }
                Console.Clear();
            }
        }

        public void CheckBalance(BankAccount bankAccount) 
        {
            // view account balance enquiry

            Utility.PrintMessage($"Your account balance is: {Utility.FormatAmount(bankAccount.Balance)}", true);
        }

        public static bool PreviewBanknotesCount(decimal amount) 
        {
            // split number into notes' values

            /* 
            int fifty = (int)amount / 50;
            int twenty = ((int)amount % 50) / 20;
            int ten = ((int)amount % 20) / 10;

            This approach did not work properly since after dividing the number by 50 and the remainder is less than 20, 
            the int value will be round down to 0, making the ten notes = 0 (false)
            */

            // improved approach

            int fiftyNotes = (int)amount / 50;
            int remainderOfFifty = (int)amount % 50;
            int twentyNotes = remainderOfFifty / 20;
            int remainderOfTwenty = remainderOfFifty % 20;
            int tenNotes =  remainderOfTwenty / 10;

            Console.WriteLine("\nNote(s) inserted:");
            Console.WriteLine("-----------------");
            Console.WriteLine($"50 x {fiftyNotes} = {50 * fiftyNotes} {Screen.currency}");
            Console.WriteLine($"20 x {twentyNotes} = {20 * twentyNotes} {Screen.currency}");
            Console.WriteLine($"10 x {tenNotes} = {10 * tenNotes} {Screen.currency}");
            Console.Write($"Total: {Utility.FormatAmount(amount)}\n\n");

            string option = Utility.GetValidIntInput("Press 1 to confirm or 0 to cancel").ToString();
            return (option.Equals("1") ? true : false);
        }

        public void InsertTransaction(BankAccount bankAccount, Transaction transaction)
        {
            // append transactions into the list of transactions for later view

            _listOfTransactions.Add(transaction);
        }

        public void PlaceDeposit(BankAccount account)
        {
            // increase your account balance enquiry by the amount of cash you inserted

            transactionAmount = Utility.GetValidDecimalInput("amount");
            Console.Write("Checking and counting banknotes.");
            Utility.printDotAnimation();

            if (transactionAmount <= 0)
            {
                Utility.PrintMessage("Amount needs to be bigger then 0. Please try again", false);
            }
            else if (transactionAmount % 10 != 0)
            {
                Utility.PrintMessage("Place in a deposit amount that is a multiplier of 10. Please try again", false);
            }
            else if (!PreviewBanknotesCount(transactionAmount))
            {
                Utility.PrintMessage($"You have cancelled your action.", false);
            }
            else
            {
                var transaction = new Transaction() // pass in transaction details
                {
                    BankAccountNoFrom = account.AccountNumber,
                    BankAccountNoTo = account.AccountNumber,
                    TransactionType = TransactionType.Deposit,
                    TransactionAmount = transactionAmount,
                    TransactionDate = DateTime.Now
                };

                InsertTransaction(account, transaction);
                account.Balance = account.Balance + transactionAmount;

                Utility.PrintMessage($"You have successfully deposited {Utility.FormatAmount(transactionAmount)}", true);
            }
        }

        public void MakeWithdrawal(BankAccount account)
        {
            // withdraw money from your bank account

            transactionAmount = Utility.GetValidDecimalInput("amount");

            if (transactionAmount <= 0)
            {
                Utility.PrintMessage("Amount needs to be bigger then 0. Try again.", false);
            }
            else if (transactionAmount > account.Balance)
            {
                Utility.PrintMessage($"Withdrawal failed. You do not have enough fund to withdraw " +
                    $"{Utility.FormatAmount(transactionAmount)}", false);
            }
            else if ((account.Balance - transactionAmount) < minimumBalance)
            {
                Utility.PrintMessage($"Withdrawal failed. Your account needs to have a minimum of " +
                    $"{Utility.FormatAmount(minimumBalance)}", false);
            }
            else if (transactionAmount % 10 != 0)
            {
                Utility.PrintMessage("Place in the withdrawal amount only with multiply of 10. Try again.", false);
            }
            else
            {
                var transaction = new Transaction() // pass in transaction details
                {
                    BankAccountNoFrom = account.AccountNumber,
                    BankAccountNoTo = account.AccountNumber,
                    TransactionType = TransactionType.Withdrawal,
                    TransactionAmount = transactionAmount,
                    TransactionDate = DateTime.Now
                };
                InsertTransaction(account, transaction);
                account.Balance = account.Balance - transactionAmount;

                Utility.PrintMessage($"Please collect your money. You have successfully withdraw " +
                    $"{Utility.FormatAmount(transactionAmount)}", true);
            }
        }

        public void PerformTransfer(BankAccount bankAccount, VMTransfer vMTransfer)
        {
            // handle input errors and recipient errors

            if (vMTransfer.TransferAmount <= 0)
            {
                Utility.PrintMessage("Amount needs to be than 0. Try again.", false);
            }
            else if (vMTransfer.TransferAmount > bankAccount.Balance)
            {
                Utility.PrintMessage($"Withdrawal failed. You do not have enough fund to withdraw " +
                    $"{Utility.FormatAmount(transactionAmount)}", false);
            }
            else if ((bankAccount.Balance - transactionAmount) < minimumBalance)
            {
                Utility.PrintMessage($"Withdrawal failed. Your account needs to have a minimum of " +
                    $"{Utility.FormatAmount(minimumBalance)}", false);
            }
            else
            {
                var receiver = (from b in _accountList where b.AccountNumber 
                                == vMTransfer.RecipientAccountNumber select b).FirstOrDefault();

                if (receiver == null)
                    Utility.PrintMessage("Transfer failed. Receipient's account number is invalid.", false);
                else if (receiver.Name != vMTransfer.RecipientAccountName)
                    Utility.PrintMessage("Transfer failed. Receipient's account name does not match.", false);
                else if (receiver == selectedAccount)
                {
                    Utility.PrintMessage("Transfer failed. You cannot be the receipient of your own transfer.", false);
                }
                else if (receiver.IsLocked == true)
                {
                    Utility.PrintMessage("Transfer failed. Recipient's account is locked.", false);
                }
                else
                {
                    Transaction transaction = new Transaction() // pass in transaction details
                    {
                        BankAccountNoFrom = bankAccount.AccountNumber,
                        BankAccountNoTo = vMTransfer.RecipientAccountNumber,
                        TransactionType = TransactionType.Transfer,
                        TransactionAmount = vMTransfer.TransferAmount,
                        TransactionDate = DateTime.Now
                    };

                    _listOfTransactions.Add(transaction);
                    Utility.PrintMessage($"You have successfully transferred out " +
                        $"{Utility.FormatAmount(vMTransfer.TransferAmount)} to {vMTransfer.RecipientAccountName}", true);
                    bankAccount.Balance = bankAccount.Balance - vMTransfer.TransferAmount;
                    receiver.Balance = receiver.Balance + vMTransfer.TransferAmount;
                }
            }
        }

        public void ViewTransaction(BankAccount bankAccount)
        {
            // view the list of transactions you have done since the program starts

            if (_listOfTransactions.Count == 0)
            {
                Utility.PrintMessage($"There is no transaction yet.", true);
            }
            else
            {
                var table = new ConsoleTable("Type", "From", "To", "Amount " + Screen.currency, "Transaction Date");

                foreach (var transaction in _listOfTransactions)
                {
                    table.AddRow(transaction.TransactionType, transaction.BankAccountNoFrom, transaction.BankAccountNoTo, 
                        transaction.TransactionAmount, transaction.TransactionDate);
                }
                table.Options.EnableCount = false;
                table.Write();
                Utility.PrintMessage($"You have performed {_listOfTransactions.Count} transactions.", true);
            }
        }
    }
}
