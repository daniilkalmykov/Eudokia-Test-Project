using System;
using System.Linq;
using Blinders;
using GameLogic;
using UnityEngine;

namespace UI.Buttons.Boosters
{
    public sealed class KillEnemiesBooster : Booster
    {
        [SerializeField] private Pool<EnemyTargetsHolderBlinder> _pool;

        protected override void OnClick()
        {
            KillEnemies();
        }

        private void KillEnemies()
        {
            var livingEnemies = _pool.GetObjects().Where(blinder => blinder.transform.gameObject.activeSelf);

            foreach (var enemy in livingEnemies)
            {
                if (enemy.TryGetComponent(out HealthBlinder healthBlinder) == false)
                    throw new ArgumentNullException();

                healthBlinder.Health.TryTakeDamage(healthBlinder.Health.MaxHealth);
            }
        }
    }
}