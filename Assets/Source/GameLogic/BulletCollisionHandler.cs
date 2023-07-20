using Blinders;
using Interfaces;
using UnityEngine;

namespace GameLogic
{
    public sealed class BulletCollisionHandler : MonoBehaviour
    {
        private IDamageCauser _damageCauser;
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out HealthBlinder healthBlinder))
                _damageCauser.Cause(healthBlinder.Health);

            Destroy(gameObject);
        }

        public void Init(IDamageCauser damageCauser)
        {
            _damageCauser = damageCauser;
        }
    }
}