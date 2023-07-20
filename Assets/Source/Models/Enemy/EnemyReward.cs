using System;
using Interfaces;

namespace Models.Enemy
{
    public sealed class EnemyReward
    {
        private readonly IHealth _health;
        private readonly Wallet _wallet;
        private readonly int _minReward;
        private readonly int _maxReward;

        public EnemyReward(Wallet wallet, IHealth health, uint minReward, uint maxReward)
        {
            _wallet = wallet;
            _health = health;
            _minReward = (int)minReward;
            _maxReward = (int)maxReward;
        }

        public void Activate()
        {
            _health.Died += OnDied;
        }

        public void Deactivate()
        {
            _health.Died -= OnDied;
        }

        private void OnDied()
        {
            var random = new Random();
            _wallet.AddMoney(random.Next(_minReward, _maxReward));
        }
    }
}