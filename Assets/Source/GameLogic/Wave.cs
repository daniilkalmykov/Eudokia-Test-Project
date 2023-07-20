using System;
using UnityEngine;

namespace GameLogic
{
    [Serializable]
    public sealed class Wave<T> where T : MonoBehaviour
    {
        [SerializeField] private T[] _objects;
        
        [field: SerializeField] public int Count { get; private set; }
        [field: SerializeField] public float Delay { get; private set; }

        public int ObjectsCount => _objects.Length;
        
        public T TryGetObject(int index)
        {
            if (index < 0 || index >= _objects.Length)
                throw new ArgumentNullException();

            return _objects[index];
        }
    }
}