using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [System.Serializable]
    [SerializeField]
    public class Pool
    {
        public GameObject prefab;
        public string tag;
        public int size;
    }

    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private List<Pool> pools;
    [SerializeField] private Dictionary<string, Queue<GameObject>> _poolDictionary;

    private void Awake()
    {

        foreach (Pool _pool in pools)
        {
            Queue<GameObject> _objectPool = new();

            for (int i = 0; i < _pool.size; i++)
            {
                GameObject _ob = _pool.prefab;
                Instantiate(_ob);
                _ob.SetActive(false);
                _objectPool.Enqueue(_ob);
            }

            _poolDictionary.Add(_pool.tag, _objectPool);
        }

    }

    private GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        GameObject objectSpawn = _poolDictionary[tag].Dequeue();

        if (objectSpawn.activeInHierarchy)
            objectSpawn.SetActive(true);
        objectSpawn.transform.position = position;
        objectSpawn.transform.rotation = rotation;

        _poolDictionary[tag].Enqueue(objectSpawn);

        return objectSpawn;
    }
}
