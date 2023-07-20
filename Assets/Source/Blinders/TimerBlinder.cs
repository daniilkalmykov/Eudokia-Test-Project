using Models;
using UnityEngine;

namespace Blinders
{
    public sealed class TimerBlinder : MonoBehaviour
    {
        public Timer Timer { get; } = new Timer();

        private void Update()
        {
            Timer.Update(Time.deltaTime);
        }
    }
}