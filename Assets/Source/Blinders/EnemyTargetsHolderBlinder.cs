using System.Collections.Generic;
using Models.Enemy;
using UnityEngine;

namespace Blinders
{
    [RequireComponent(typeof(HealthBlinder))]
    public sealed class EnemyTargetsHolderBlinder : MonoBehaviour
    {
        private readonly List<EnemyTarget> _targets = new List<EnemyTarget>();
        
        private IEnumerable<EnemyTargetBlinder> _enemyTargetBlinders;
        private HealthBlinder _healthBlinder;

        [field: SerializeField] public int TargetsCount { get; private set; }
        
        public EnemyTargetsHolder TargetsHolder { get; private set; }

        private void Awake()
        {
            _healthBlinder = GetComponent<HealthBlinder>();
        }

        private void OnDisable()
        {
            TargetsHolder?.Deactivate();
        }

        public void Init(List<EnemyTargetBlinder> enemyTargetBlinders)
        {
            _enemyTargetBlinders = enemyTargetBlinders;
            
            foreach (var enemyTargetBlinder in enemyTargetBlinders)
                _targets.Add(enemyTargetBlinder.EnemyTarget);

            TargetsHolder = new EnemyTargetsHolder(_targets, _healthBlinder.Health);
            
            TargetsHolder.Activate();
        }

        public IEnumerable<EnemyTargetBlinder> GetTargets()
        {
            return _enemyTargetBlinders;
        }
    }
}