using System;
using Interfaces;

namespace Models
{
    public sealed class Timer : IUpdatable
    {
        private const int SecondsInMinute = 60;
        
        private float _currentTime;
        private bool _canStart;

        public event Action MinutesChanged;
        
        public int Seconds { get; private set; }
        public int Minutes { get; private set; }

        public void Start()
        {
            _canStart = true;
        }

        public void Stop()
        {
            _canStart = false;
        }
        
        public void Update(float deltaTime)
        {
            if (_canStart == false)
                return;
            
            _currentTime += deltaTime;
            
            Seconds = (int)_currentTime;

            if (Seconds % SecondsInMinute != 0 || Seconds == 0)
                return;
            
            Minutes++;
            MinutesChanged?.Invoke();
        }
    }
}