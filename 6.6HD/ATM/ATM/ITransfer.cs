namespace ATM
{
    public interface ITransfer
    {
        void PerformTransfer(BankAccount account, VMTransfer vmTransfer);
    }
}
