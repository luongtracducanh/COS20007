namespace ATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LTDAbankATM atm = new LTDAbankATM();
            atm.Initialize();
            atm.Execute();
        }
    }
}
