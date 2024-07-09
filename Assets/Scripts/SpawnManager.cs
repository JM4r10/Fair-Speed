using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] interactivePrefabs;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] List<GameObject> obstaclesInScene = new();
    [SerializeField] private int minSpawnTime, maxSpawnTime;

    void Start()
    {
        obstaclesInScene = CreateInactiveObjects(obstaclesInScene);
        StartCoroutine(RandomSpawn());
    }
    private List<GameObject> CreateInactiveObjects(List<GameObject> oBList)
    {
        foreach (GameObject obstaclePrefab in interactivePrefabs)
        {
            GameObject obstacleOb = Instantiate(obstaclePrefab, transform.position, transform.rotation);
            oBList.Add(obstacleOb);
            obstacleOb.SetActive(false);
        }

        return oBList;
    }

    private IEnumerator RandomSpawn()
    {
        while (true)
        {
            int _spawnInterval = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(_spawnInterval);
            SpawnRandomOb();
        }
    }

    private void SpawnRandomOb()
    {
        GameObject _randomOb = obstaclesInScene[Random.Range(0, obstaclesInScene.Count)];
        Transform _randomSpawnPoint;

        if (_randomOb.CompareTag("Power-up"))
        {
            _randomSpawnPoint = spawnPoints[0];
        }
        else
        {
            _randomSpawnPoint = spawnPoints[1];
        }

        if (_randomOb.activeInHierarchy) return;
        _randomOb.transform.position = _randomSpawnPoint.position;
        _randomOb.SetActive(true);

    }
}
