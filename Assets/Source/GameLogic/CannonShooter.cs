using System.Collections;
using Blinders;
using Interfaces;
using Models;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace GameLogic
{
    public sealed class CannonShooter : MonoBehaviour, IShooter
    {
        [SerializeField] private BulletBlinder _bulletBlinder;
        [SerializeField] private Transform _bulletSpawnPoint;
        
        private Coroutine _coroutine;
        private bool _canShoot = true;
        private Cannon _cannon;

        [field: SerializeField] public float ShootingDistance { get; private set; }

        public void Init(Cannon cannon)
        {
            _cannon = cannon;
        }

        public void Shoot(Vector3 target)
        {
            if (_canShoot == false)
                return;
            
            var bulletBlinder =
                Instantiate(_bulletBlinder, _bulletSpawnPoint.position, Quaternion.identity);

            bulletBlinder.Init(_cannon.Damage, target);

            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(WaitTimeForNextShot());
            
            _canShoot = false;
        }

        private IEnumerator WaitTimeForNextShot()
        {
            yield return new WaitForSeconds(_cannon.Delay);

            _canShoot = true;
        }
    }
}