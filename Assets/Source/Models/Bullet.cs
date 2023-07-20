using System;
using System.Numerics;
using Interfaces;

namespace Models
{
    public sealed class Bullet : IMovable, IDamageHolder, IDamageCauser, IVectorHolder
    {
        public Bullet(float speed, float damage, Vector3 target)
        {
            if (speed <= 0 || damage <= 0)
                throw new ArgumentNullException();

            Speed = speed;
            Damage = damage;
            Target = target;
        }
        
        public float Speed { get; }
        public float Damage { get; }
        public Vector3 Target { get; }
        
        public void Cause(IHealth health)
        {
            health.TryTakeDamage(Damage);
        }
    }
}