using Models;
using Models.Enemy;
using UnityEngine;

namespace Blinders
{
    [RequireComponent(typeof(HealthBlinder))]
    public sealed class EnemyRewardBlinder : MonoBehaviour
    {
        [SerializeField] private uint _minReward;
        [SerializeField] private uint _maxReward;
        
        private HealthBlinder _healthBlinder;
        private EnemyReward _enemyReward;
        
        private void Awake()
        {
            _healthBlinder = GetComponent<HealthBlinder>();
        }

        private void OnDisable()
        {
            _enemyReward?.Deactivate();
        }

        public void Init(Wallet wallet)
        {
            _enemyReward = new EnemyReward(wallet, _healthBlinder.Health, _minReward, _maxReward);
            
            _enemyReward.Activate();
        }
    }
}