using System.Collections;
using UnityEngine;

namespace UI.Buttons.Boosters
{
    public abstract class Booster : GameButton
    {
        [SerializeField] private float _delay;

        private Coroutine _coroutine;

        protected void StartWaitTimeToTurnOnCoroutine()
        {
            if (_coroutine != null)
                StartCoroutine(WaitTimeToTurnOn());

            _coroutine = StartCoroutine(WaitTimeToTurnOn());
        }
        
        private IEnumerator WaitTimeToTurnOn()
        {
            yield return new WaitForSeconds(_delay);
            TurnOn();
        }
    }
}