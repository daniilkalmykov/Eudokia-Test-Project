using Blinders;
using Interfaces;
using UnityEngine;

namespace Views
{
    [RequireComponent(typeof(HealthBlinder))]
    public sealed class EnemyView : MonoBehaviour
    {
        private HealthBlinder _healthBlinder;
        private IHealth _health;

        private void Awake()
        {
            _healthBlinder = GetComponent<HealthBlinder>();

            _health = _healthBlinder.Health;
        }

        private void OnEnable()
        {
            _health.Died += OnDied;
        }

        private void OnDisable()
        {
            _health.Died -= OnDied;
        }

        private void OnDied()
        {
            gameObject.SetActive(false);
        }
    }
}