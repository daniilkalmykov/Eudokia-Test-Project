using Blinders;
using Models;
using TMPro;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(TimerBlinder))]
    [RequireComponent(typeof(TMP_Text))]
    public sealed class TimerView : MonoBehaviour
    {
        private TimerBlinder _timerBlinder;
        private TMP_Text _time;
        private Timer _timer;
        
        private void Awake()
        {
            _timerBlinder = GetComponent<TimerBlinder>();
            _time = GetComponent<TMP_Text>();

            _timer = _timerBlinder.Timer;
        }

        private void Update()
        {
            _time.text = _timer.Seconds.ToString().Length == 1
                ? $"{_timer.Minutes} : 0{_timer.Seconds}"
                : $"{_timer.Minutes} : {_timer.Seconds}";
        }
    }
}