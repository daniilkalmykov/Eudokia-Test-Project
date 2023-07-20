using System;
using Interfaces;

namespace Models
{
    public sealed class Cannon : IDamageHolder
    {
        private const int StartLevel = 1;
        
        public Cannon(float damage, float delay)
        {
            Damage = damage;
            Delay = delay;
            Level = StartLevel;
        }

        public float Damage { get; private set; }
        public float Delay { get; private set; }
        public int Level { get; private set; }

        public void Upgrade(float damage, float delay)
        {
            if (damage <= Damage || delay >= Delay)
                throw new ArgumentNullException();
            
            Damage = damage;
            Delay = delay;
            Level++;
        }
    }
}