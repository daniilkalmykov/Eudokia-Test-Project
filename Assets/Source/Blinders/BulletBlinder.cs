using GameLogic;
using Models;
using UnityEngine;
using Views;
using Vector3 = System.Numerics.Vector3;

namespace Blinders
{
    [RequireComponent(typeof(BulletCollisionHandler))]
    [RequireComponent(typeof(BulletView))]
    public sealed class BulletBlinder : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private BulletView _bulletView;
        private Bullet _bullet;
        private BulletCollisionHandler _bulletCollisionHandler;

        private void Awake()
        {
            _bulletCollisionHandler = GetComponent<BulletCollisionHandler>();
            _bulletView = GetComponent<BulletView>();
        }

        public void Init(float damage, Vector3 target)
        {
            _bullet = new Bullet(_speed, damage, target);

            _bulletView.Init(_bullet);
            _bulletCollisionHandler.Init(_bullet);
        }
    }
}