using Models.Enemy;
using ScriptableObjects;
using UnityEngine;

namespace Blinders
{
    [RequireComponent(typeof(HealthBlinder))]
    public sealed class EnemyMovementBlinder : MonoBehaviour
    {
        [SerializeField] private EnemyStats _enemyStats;
        
        private HealthBlinder _healthBlinder;
        
        public EnemyMovement EnemyMovement { get; private set; }

        private void Awake()
        {
            _healthBlinder = GetComponent<HealthBlinder>();
        }

        private void OnEnable()
        {
            EnemyMovement?.Activate();
        }

        private void OnDisable()
        {
            EnemyMovement?.Deactivate();
        }

        private void Start()
        {
            EnemyMovement = new EnemyMovement(_healthBlinder.Health, _enemyStats.Speed);
            EnemyMovement.Activate();
        }
    }
}