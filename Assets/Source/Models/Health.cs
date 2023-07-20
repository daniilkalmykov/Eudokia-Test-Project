using System;
using Interfaces;
using UnityEngine;

namespace Models
{
    public sealed class Health : IHealth
    {
        public Health(float maxHealth)
        {
            CurrentHealth = maxHealth;
            MaxHealth = maxHealth;
        }

        public event Action Changed;
        public event Action Died;

        public float CurrentHealth { get; private set; }
        public float MaxHealth { get; private set; }

        public void TryTakeDamage(float damage)
        {
            if (damage <= 0)
                throw new ArgumentNullException();

            CurrentHealth -= damage;
            Debug.Log(CurrentHealth);
            
            if (CurrentHealth <= 0)
            {
                Died?.Invoke();
                return;
            }
            
            Changed?.Invoke();
        }

        public void Reset()
        {
            CurrentHealth = MaxHealth;
        }

        public void IncreaseHealth(float newHealth)
        {
            if (newHealth <= MaxHealth)
                throw new ArgumentNullException();

            MaxHealth = newHealth;
            Reset();
        }
    }
}