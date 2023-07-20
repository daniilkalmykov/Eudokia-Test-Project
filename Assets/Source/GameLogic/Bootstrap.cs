using System.Collections.Generic;
using Blinders;
using Models;
using Player;
using ScriptableObjects;
using UI.Buttons;
using UnityEngine;

namespace GameLogic
{
    public sealed class Bootstrap : MonoBehaviour
    {
        [SerializeField] private TimerBlinder _timerBlinder;
        [SerializeField] private EnemiesSpawner _enemiesSpawner;
        [SerializeField] private int _spawnedEnemiesToEnd;
        [SerializeField] private CannonShooter _cannonShooter;
        [SerializeField] private CannonStats _startCannonStats;
        [SerializeField] private UpgradeCannonButton _upgradeCannonButton;
        [SerializeField] private WalletBlinder _walletBlinder;
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private List<EnemyStats> _enemyStats;

        private Level _level;

        private void OnEnable()
        {
            _level?.Activate();
        }

        private void OnDisable()
        {
            _level?.Deactivate();
        }
        
        private void Start()
        {
            _level = new Level(_timerBlinder.Timer, _startCannonStats.Damage, _startCannonStats.Delay,
                _spawnedEnemiesToEnd, _playerInput, _canvasGroup, _enemiesSpawner, _enemiesSpawner.GetObjects(),
                _enemyStats);
            
            _cannonShooter.Init(_level.Cannon);
            _upgradeCannonButton.Init(_level.Cannon, _walletBlinder.Wallet);
            
            _level.Start();
            _level.Activate();
        }
    }
}