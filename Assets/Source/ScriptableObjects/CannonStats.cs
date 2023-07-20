using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Cannon Level", menuName = "Stats / Create cannon stats", order = 52)]
    public sealed class CannonStats : ScriptableObject
    {
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public float Delay { get; private set; }
    }
}