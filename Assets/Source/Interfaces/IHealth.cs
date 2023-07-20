using System;

namespace Interfaces
{
    public interface IHealth
    {
        event Action Changed;
        event Action Died;
        
        float CurrentHealth { get; }
        float MaxHealth { get; }

        void TryTakeDamage(float damage);
        void Reset();
        void IncreaseHealth(float newHealth);
    }
}