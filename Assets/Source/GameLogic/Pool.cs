using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameLogic
{
    public abstract class Pool<T> : MonoBehaviour where T : MonoBehaviour
    {
        private readonly List<T> _pool = new List<T>();

        public IEnumerable<T> GetObjects()
        {
            return _pool;
        }

        protected void Init(T t, Vector3 spawnPoint)
        {
            var newObject = Instantiate(t, spawnPoint, Quaternion.identity, transform);
            newObject.gameObject.SetActive(false);    
            
            _pool.Add(newObject);
        }

        protected bool TryGetObject(out T t)
        {
            t = _pool.FirstOrDefault(t => t.gameObject.activeSelf == false);

            return t != null;
        }
    }
}