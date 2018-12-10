using System.Collections.Generic;
using UnityEngine;

namespace Project_Hackathon_2019.Support {
    public class ObjectPool : MonoBehaviour {

        public int DefaultPoolSize = 3;

        public static ObjectPool Instance;

        [System.Serializable]
        public class Pool {
            public GameObject Prefab;
            public int Count;
        }
        public Pool[] PredefinedPools;

        private Dictionary<GameObject, Stack<GameObject>> pools = new Dictionary<GameObject, Stack<GameObject>> ();

        void Awake () {
            if (Instance == null) {
                Instance = this;

            } else if (Instance != this) {
                Destroy (gameObject);
            }
        }

        private void Start () {
            foreach (Pool definition in PredefinedPools) {
                RegisterPool (definition.Prefab, definition.Count);
            }
        }

        public Stack<GameObject> RegisterPool (GameObject prefab, int count) {
            if (!pools.ContainsKey (prefab)) {
                pools.Add (prefab, initializePool (prefab, count));
            }
            return pools[prefab];
        }

        private Stack<GameObject> initializePool (GameObject prefab, int count) {
            Stack<GameObject> pool = new Stack<GameObject> (count);
            for (int i = 0; i < count; i++) {
                pool.Push (createPoolMember (prefab));
            }
            return pool;
        }

        private GameObject createPoolMember (GameObject prefab) {
            GameObject member = Instantiate (prefab, Vector3.zero, Quaternion.identity);
            member.AddComponent<ObjectPoolMember> ().PoolKey = prefab;
            member.name = member.name + " (Pooled)";
            member.SetActive (false);
            return member;
        }

        public GameObject Spawn (GameObject prefab, Vector3 position, Quaternion rotation) {
            if (!pools.ContainsKey (prefab)) {
                RegisterPool (prefab, DefaultPoolSize);
            }

            if (pools[prefab].Count == 0) {
                pools[prefab].Push (createPoolMember (prefab));
            }

            GameObject member = pools[prefab].Pop ();
            resetPoolMember (ref member);
            member.transform.position = position;
            member.transform.rotation = rotation;

            member.SetActive (true);
            return member;
        }

        private void resetPoolMember (ref GameObject member) {
            Rigidbody rb = member.GetComponent<Rigidbody> ();
            if (rb) {
                rb.velocity = Vector3.zero;
            }
        }

        public void Despawn (GameObject obj) {
            ObjectPoolMember member = obj.GetComponent<ObjectPoolMember> ();
            if (!member) {
                Debug.LogError ("Object " + obj + " wasn't spawned from Object pool so we'll just destroy it");
                Destroy (obj);
            } else {
                obj.SetActive (false);
                pools[member.PoolKey].Push (obj);
            }
        }
    }

    public class ObjectPoolMember : MonoBehaviour {
        public GameObject PoolKey;
    }
}
