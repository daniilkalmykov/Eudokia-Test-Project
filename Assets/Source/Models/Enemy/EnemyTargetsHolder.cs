using System;
using System.Collections.Generic;
using Interfaces;

namespace Models.Enemy
{
    public sealed class EnemyTargetsHolder
    {
        private readonly List<EnemyTarget> _enemyTargets;
        private readonly IHealth _health;
        
        public EnemyTarget CurrentTarget { get; private set; }
        
        public EnemyTargetsHolder(IEnumerable<EnemyTarget> enemyTargets, IHealth health)
        {
            _enemyTargets = (List<EnemyTarget>)enemyTargets;
            _health = health;
        }

        public void Activate()
        {
            _health.Died += OnDied;
        }

        public void Deactivate()
        {
            _health.Died -= OnDied;
        }

        public void SetCurrentTarget(EnemyTarget enemyTarget)
        {
            if (enemyTarget == null || enemyTarget == CurrentTarget)
                throw new ArgumentNullException();

            CurrentTarget = enemyTarget;
        }

        private void OnDied()
        {
            Clear();
        }

        private void Clear()
        {
            foreach (var enemyTarget in _enemyTargets)
                enemyTarget.SetAvailable();
            
            _enemyTargets.Clear();
        }
    }
}