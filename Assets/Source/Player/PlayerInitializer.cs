using Models;
using UnityEngine;

namespace Player
{
    public sealed class PlayerInitializer : MonoBehaviour
    {
        public RaycastCreator RaycastCreator { get; private set; }
        
        private void Start()
        {
            RaycastCreator = new RaycastCreator(Camera.main);
        }
    }
}