using Models.Enemy;
using UnityEngine;

namespace Blinders
{
    public sealed class EnemyTargetBlinder : MonoBehaviour
    {
        public EnemyTarget EnemyTarget { get; private set; } = new EnemyTarget();
    }
}