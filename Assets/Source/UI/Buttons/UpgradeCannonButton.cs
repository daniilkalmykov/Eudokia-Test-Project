using System.Collections.Generic;
using Models;
using ScriptableObjects;
using UnityEngine;

namespace UI.Buttons
{
    public sealed class UpgradeCannonButton : GameButton
    {
        [SerializeField] private List<CannonStats> _cannonStats;
        [SerializeField] private int _price;

        private Cannon _cannon;
        private Wallet _wallet;

        protected override void OnDisable()
        {
            base.OnDisable();
            
            _wallet.MoneyChanged -= OnMoneyChanged;
        }

        public void Init(Cannon cannon, Wallet wallet)
        {
            _cannon = cannon;
            _wallet = wallet;

            _wallet.MoneyChanged += OnMoneyChanged;
            
            TurnOff();
        }

        protected override void OnClick()
        {
            TryUpgrade();
        }

        private void OnMoneyChanged()
        {
            if (_wallet.Money >= _price)
                TurnOn();
            else
                TurnOff();
        }

        private void TryUpgrade()
        {
            var newCannonLevel = _cannon.Level + 1;
            var newCannonStats = _cannonStats[newCannonLevel];

            _cannon.Upgrade(newCannonStats.Damage, newCannonStats.Delay);
            _wallet.SpendMoney(_price);
            
            if (newCannonLevel < _cannonStats.Count - 1) 
                return;
            
            TurnOff();

            _wallet.MoneyChanged -= OnMoneyChanged;
        }
    }
}