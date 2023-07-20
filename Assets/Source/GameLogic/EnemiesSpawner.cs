using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Blinders;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameLogic
{
    public sealed class EnemiesSpawner : Pool<EnemyTargetsHolderBlinder>
    {
        [SerializeField] private List<Wave<EnemyTargetsHolderBlinder>> _waves;
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private List<EnemyTargetBlinder> _enemyTargetBlinders;
        [SerializeField] private float _delayBetweenWaves;
        [SerializeField] private WalletBlinder _walletBlinder;

        private int _spawnedEnemiesCount;
        private float _timeAfterLastBotSpawned;
        private Coroutine _coroutine;
        private int _currentWaveNumber;
        private Wave<EnemyTargetsHolderBlinder> _currentWave;

        public event Action EnemySet;
        
        private void Start()
        {
            ResetOptions();

            for (var i = 0; i < _currentWave.Count; i++)
            {
                var index = Random.Range(0, _currentWave.ObjectsCount);
                var enemy = _currentWave.TryGetObject(index);

                if (enemy == null)
                    throw new ArgumentNullException();

                Init(enemy, transform.position);
            }
        }

        private void Update()
        {
            if (_currentWave == null)
                return;

            _timeAfterLastBotSpawned += Time.deltaTime;

            if (_timeAfterLastBotSpawned >= _currentWave.Delay)
            {
                if (TryGetObject(out var enemy) == false)
                    return;

                _timeAfterLastBotSpawned = 0;

                SetEnemy(enemy);
                _spawnedEnemiesCount++;
            }

            if (_spawnedEnemiesCount <= _currentWave.Count)
                return;

            _currentWave = null;

            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(WaitTimeBetweenWaves());

            if (_currentWaveNumber != _waves.Count - 1)
                return;

            ResetOptions();
        }

        public void TryReduceTimeAfterLastBotSpawned(float delay)
        {
            if (delay <= 0)
                throw new ArgumentNullException();

            _timeAfterLastBotSpawned -= delay;
        }
        
        private void SetEnemy(EnemyTargetsHolderBlinder enemy)
        {
            if (enemy == null)
                throw new ArgumentNullException();
            
            var enemyTargets = new List<EnemyTargetBlinder>();
            var spawnPointIndex = Random.Range(0, _spawnPoints.Length);
            
            for (var i = 0; i < enemy.TargetsCount; i++)
            {
                var availableTargets = _enemyTargetBlinders.Where(blinder => blinder.EnemyTarget.IsAvailable).ToArray();
                
                if (availableTargets.Length == 0)
                    throw new ArgumentNullException();

                var target = availableTargets[Random.Range(0, availableTargets.Length)];
                target.EnemyTarget.SetUnavailable();
                
                enemyTargets.Add(target);
            }

            if (enemy.TryGetComponent(out HealthBlinder healthBlinder) == false)
                throw new ArgumentNullException();

            if (enemy.TryGetComponent(out EnemyRewardBlinder enemyRewardBlinder) == false)
                throw new ArgumentNullException();
            
            healthBlinder.Health.Reset();            
            enemy.Init(enemyTargets);
            enemyRewardBlinder.Init(_walletBlinder.Wallet);
            
            enemy.transform.position = _spawnPoints[spawnPointIndex].position;
            enemy.gameObject.SetActive(true);

            EnemySet?.Invoke();
        }

        private void ResetOptions()
        {
            _spawnedEnemiesCount = 0;
            _currentWaveNumber = 0;
            
            TrySetWave(_currentWaveNumber);
        }
        
        private void TrySetWave(int waveNumber)
        {
            if (waveNumber < 0 || waveNumber >= _waves.Count)
                return;

            _currentWave = _waves[waveNumber];
        }
        
        private IEnumerator WaitTimeBetweenWaves()
        {
            yield return new WaitForSeconds(_delayBetweenWaves);
            
            _spawnedEnemiesCount = 0;
            _currentWaveNumber++;
            
            TrySetWave(_currentWaveNumber);
        }
    }
}