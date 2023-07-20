using System;

namespace Models
{
    public sealed class Wallet
    {
        public event Action MoneyChanged;
        
        public int Money { get; private set; }

        public void AddMoney(int money)
        {
            if (money <= 0)
                throw new ArgumentNullException();

            Money += money;
            
            MoneyChanged?.Invoke();
        }

        public void SpendMoney(int money)
        {
            if (money <= 0 || money > Money)
                throw new ArgumentNullException();
            
            Money -= money;
            
            MoneyChanged?.Invoke();
        }
    }
}