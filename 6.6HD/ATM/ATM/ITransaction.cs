namespace ATM
{
    public interface ITransaction
    {
        void InsertTransaction(BankAccount account, Transaction transaction);
        void ViewTransaction(BankAccount account);
    }
}
