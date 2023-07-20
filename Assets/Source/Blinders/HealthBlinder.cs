using Interfaces;
using Models;
using ScriptableObjects;
using UnityEngine;

namespace Blinders
{
    public sealed class HealthBlinder : MonoBehaviour
    {
        [SerializeField] private EnemyStats _enemyStats;
        
        public IHealth Health { get; private set; }

        private void Awake()
        {
            Health = new Health(_enemyStats.MaxHealth);
        }
    }
}