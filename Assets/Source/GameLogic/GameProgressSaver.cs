using UnityEngine;

namespace GameLogic
{
    public sealed class GameProgressSaver
    {
        private const string Time = "Time";
        
        public static void SetTime(int value)
        {
            PlayerPrefs.SetInt(Time, value);
        }
        
        public static int GetTime()
        {
            return PlayerPrefs.GetInt(Time);
        }
    }
}