using System;
using System.Collections.Generic;
using System.Linq;
using Blinders;
using GameLogic;
using Player;
using ScriptableObjects;
using UnityEngine;

namespace Models
{
    public sealed class Level
    {
        private readonly IEnumerable<EnemyTargetsHolderBlinder> _enemies;
        private readonly Timer _timer;
        private readonly int _spawnedEnemiesToEnd;
        private readonly PlayerInput _playerInput;
        private readonly CanvasGroup _canvasGroup;
        private readonly EnemiesSpawner _enemiesSpawner;
        private readonly IReadOnlyList<EnemyStats> _enemyStats;
        private readonly int _maxEnemiesLevel;

        private int _currentLevel;
        
        public Level(Timer timer, float cannonDamage, float cannonDelay, int spawnedEnemiesToEnd,
            PlayerInput playerInput, CanvasGroup canvasGroup, EnemiesSpawner enemiesSpawner,
            IEnumerable<EnemyTargetsHolderBlinder> enemies, IReadOnlyList<EnemyStats> enemyStats)
        {
            Cannon = new Cannon(cannonDamage, cannonDelay);
            _timer = timer;
            _spawnedEnemiesToEnd = spawnedEnemiesToEnd;
            _playerInput = playerInput;
            _canvasGroup = canvasGroup;
            _enemiesSpawner = enemiesSpawner;
            _enemies = enemies;
            _enemyStats = enemyStats;
            _maxEnemiesLevel = enemyStats.Count - 1;
        }
        
        public Cannon Cannon { get; private set; }

        public void Activate()
        {
            _enemiesSpawner.EnemySet += OnEnemySet;
            _timer.MinutesChanged += OnMinutesChanged;
        }

        public void Deactivate()
        {
            _enemiesSpawner.EnemySet -= OnEnemySet;
            _timer.MinutesChanged -= OnMinutesChanged;
        }
        
        public void Start()
        {
            _timer.Start();
        }

        private void End()
        {
            _timer.Stop();
            
            Time.timeScale = 0;
            _playerInput.enabled = false;
            _canvasGroup.interactable = false;

            GameProgressSaver.SetTime(_timer.Seconds);
        }

        private void OnMinutesChanged()
        {
            if (_currentLevel >= _maxEnemiesLevel)
                return;
            
            _currentLevel++;
            
            foreach (var enemy in _enemies)
            {
                if (enemy.TryGetComponent(out HealthBlinder healthBlinder) == false)
                    throw new ArgumentNullException();

                if (enemy.TryGetComponent(out EnemyMovementBlinder enemyMovementBlinder) == false)
                    throw new ArgumentNullException();
                
                healthBlinder.Health.IncreaseHealth(_enemyStats[_currentLevel].MaxHealth);
                enemyMovementBlinder.EnemyMovement.IncreaseSpeed(_enemyStats[_currentLevel].Speed);
            }
        }
        
        private void OnEnemySet()
        {
            if (_enemies.Where(enemy => enemy.gameObject.activeSelf).ToList().Count >= _spawnedEnemiesToEnd)
                End();
        }
    }
}