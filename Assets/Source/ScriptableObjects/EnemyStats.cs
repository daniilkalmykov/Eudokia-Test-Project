using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Enemy Level", menuName = "Stats / Create enemy stats", order = 52)]
    public sealed class EnemyStats : ScriptableObject
    {
        [field: SerializeField] public float MaxHealth { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
    }
}