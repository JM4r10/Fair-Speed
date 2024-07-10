using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] interactivePrefabs;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] List<GameObject> interactiveObs = new();
    [SerializeField] private int minSpawnTime, maxSpawnTime, minPoints;

    void Start()
    {
        interactiveObs = InstantiateObs(interactiveObs);
        StartCoroutine(RandomSpawn());
    }
    private List<GameObject> InstantiateObs(List<GameObject> interactiveObs)
    {
        foreach (GameObject interactivePrefab in interactivePrefabs)
        {
            GameObject interactiveOb = Instantiate(interactivePrefab, transform.position, transform.rotation);
            interactiveObs.Add(interactiveOb);
            interactiveOb.SetActive(false);
        }

        return interactiveObs;
    }

    private IEnumerator RandomSpawn()
    {
        while (true)
        {
            int _spawnInterval = Random.Range(minSpawnTime, maxSpawnTime);

            yield return new WaitForSeconds(_spawnInterval);

            var randomObj = ActivateRandomOb();
            SpawnAtRandomPos(randomObj);
        }
    }

    private void SpawnAtRandomPos(GameObject randomOb)
    {
        if (randomOb is null) return;

        Transform spawnPoint;

        if (randomOb.CompareTag("Power-up"))
        {
            spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        }
        else
        {
            spawnPoint = spawnPoints[1];
        }

        randomOb.transform.position = spawnPoint.position;
    }

    private GameObject ActivateRandomOb()
    {
        GameObject objToSpawn = GameManager.Instance.Score < minPoints ? interactiveObs[0] : interactiveObs[Random.Range(0, interactiveObs.Count)];

        if (objToSpawn.activeInHierarchy) return null;

        objToSpawn.SetActive(true);
        return objToSpawn;

    }
}
