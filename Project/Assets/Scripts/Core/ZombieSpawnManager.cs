using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ZombieSpawnManager : MonoBehaviour 
{
    [SerializeField]
    List<Transform> spawnThinZombiePoints = new List<Transform>();
    [SerializeField]
    List<Transform> spawnFatZombiePoints = new List<Transform>();

    [SerializeField]
    GameObject spawnPack = null;
    
    [SerializeField]
    GameObject fatZombie = null;

    [SerializeField]
    float timeSpawnThin= 3f;
    [SerializeField]
    float timeSpawnFat = 3f;

    [SerializeField]
    int countOfWave = 5;

    bool timeToSpawnThin = true;
    bool timeToSpawnFat = true;

    private void Start()
    {
        foreach(Transform spoint in transform)
        {
            if(spoint.tag == "TallPoint")
                spawnThinZombiePoints.Add(spoint);
            if(spoint.tag == "FatPoint")
               spawnFatZombiePoints.Add(spoint);
        }
    }

    private void Update() {
        if(timeToSpawnThin  && GameObject.FindGameObjectsWithTag("Zombie").Length < 30)
            StartCoroutine("SpawnPack",timeSpawnThin);

        if(timeToSpawnFat && GameObject.FindGameObjectsWithTag("FatZombie").Length < 5)
            StartCoroutine("SpawnFatZombie", timeSpawnFat);
    }

    IEnumerator SpawnPack(float timeSpawn)
    {
        timeToSpawnThin = false;
        var spawnPlace = spawnThinZombiePoints[Random.Range(0,spawnThinZombiePoints.Count-1)];
        yield return new WaitForSeconds(timeSpawn);
        var clone = Instantiate(spawnPack.transform,spawnPlace.position,Quaternion.identity);
        timeToSpawnThin = true;
    }

    IEnumerator SpawnFatZombie(float timeSpawn)
    {
        timeToSpawnFat = false;
        var spawnPlace = spawnFatZombiePoints[Random.Range(0, spawnFatZombiePoints.Count - 1)];
        yield return new WaitForSeconds(timeSpawn);
        var clone = Instantiate(fatZombie.transform, spawnPlace.position, Quaternion.identity);
        timeToSpawnFat = true;
    }
}