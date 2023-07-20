using System;
using Interfaces;

namespace Models.Enemy
{
    public sealed class EnemyMovement : IMovable
    {
        private readonly IHealth _health;
        
        public EnemyMovement(IHealth health, float speed, EnemyTarget target = default)
        {
            Speed = speed;
            Target = target;
            _health = health;
        }
        
        public float Speed { get; private set; }
        public EnemyTarget Target { get; private set; }

        public void Activate()
        {
            _health.Died += OnDied;
        }

        public void Deactivate()
        {
            _health.Died -= OnDied;
        }

        public void IncreaseSpeed(float newSpeed)
        {
            if (newSpeed <= Speed)
                throw new ArgumentNullException();

            Speed = newSpeed;
        }
        
        public void SetTarget(EnemyTarget target)
        {
            if (target == Target)
                throw new ArgumentNullException();
            
            Target = target;
        }

        private void OnDied()
        {
            Target = null;
        }
    }
}