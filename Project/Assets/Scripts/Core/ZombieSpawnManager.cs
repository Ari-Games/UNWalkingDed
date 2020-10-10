using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ZombieSpawnManager : MonoBehaviour 
{
    [SerializeField]
    List<Transform> spawnPoints = new List<Transform>();

    [SerializeField]
    GameObject spawnPack = null;

    [SerializeField]
    float timeToSpawn = 3f;

    [SerializeField]
    int countOfWave = 5;

    bool isTimeToSpawn = true;

    private void Start()
    {
        foreach(Transform spoint in transform)
        {
            spawnPoints.Add(spoint);
        }
    }

    private void Update() {
        if(isTimeToSpawn  && GameObject.FindGameObjectsWithTag("Zombie").Length <= 30)
            StartCoroutine("SpawnPack",timeToSpawn);
    }

    IEnumerator SpawnPack(float timeToSpawn)
    {
        isTimeToSpawn = false;
        var spawnPlace = spawnPoints[Random.Range(0,spawnPoints.Count-1)];
        yield return new WaitForSeconds(timeToSpawn);
        var clone = Instantiate(spawnPack.transform,spawnPlace.position,Quaternion.identity);
        isTimeToSpawn = true;
    }
}