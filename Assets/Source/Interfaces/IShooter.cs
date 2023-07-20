using System.Numerics;

namespace Interfaces
{
    public interface IShooter
    {
        float ShootingDistance { get; }
        
        void Shoot(Vector3 target);
    }
}