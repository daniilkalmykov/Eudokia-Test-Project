using GameLogic;
using UnityEngine;

namespace UI.Buttons.Boosters
{
    public sealed class FreezeBooster : Booster
    {
        [SerializeField] private float _freezeTime;
        [SerializeField] private EnemiesSpawner _enemiesSpawner;
        
        protected override void OnClick()
        {
            _enemiesSpawner.TryReduceTimeAfterLastBotSpawned(_freezeTime);
            
            TurnOff();
            StartWaitTimeToTurnOnCoroutine();
        }
    }
}