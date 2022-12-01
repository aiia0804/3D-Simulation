using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HosptialSpawn : MonoBehaviour
{
    [SerializeField] Transform spawnPos;
    [SerializeField] GameObject nursePrefab;
    [SerializeField] GameObject cleanerPrefab;

    public void SpawnNurse()
    {
        Instantiate(nursePrefab, spawnPos.position, Quaternion.identity);
    }

    public void SpawCleaner()
    {
        Instantiate(cleanerPrefab, spawnPos.position, Quaternion.identity);
    }
}
