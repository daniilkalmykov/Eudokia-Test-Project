using System;
using Interfaces;
using Models;
using UnityEngine;

namespace Views
{
    public sealed class BulletView : MonoBehaviour
    {
        private IMovable _movable;
        private IVectorHolder _vectorHolder;
        
        private void Update()
        {
            if (_movable == null)
                return;

            var target = new Vector3(_vectorHolder.Target.X, _vectorHolder.Target.Y, _vectorHolder.Target.Z);

            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * _movable.Speed);

            if (target == transform.position)
                Destroy(gameObject);
        }

        public void Init(Bullet bullet)
        {
            _movable = bullet ?? throw new ArgumentNullException();
            _vectorHolder = bullet;
        }
    }
}