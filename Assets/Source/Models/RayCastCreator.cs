using UnityEngine;

namespace Models
{
    public sealed class RaycastCreator
    {
        private readonly Camera _camera;
        
        public RaycastCreator(Camera camera)
        {
            _camera = camera;
        }
        
        public Vector3 GetDirection(Vector3 position, float distance)
        {
            return _camera.ScreenPointToRay(position).GetPoint(distance);
        }
    }
}