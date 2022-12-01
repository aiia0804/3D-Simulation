using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] patientPrefab;
    public int numPatients;
    public bool keepSpawing = false;

    MoneySystem moneySystem;

    private void Start()
    {
        moneySystem = FindObjectOfType<MoneySystem>();
    }

    IEnumerator SpawnPatient()
    {
        while (keepSpawing)
        {
            var index = Random.Range(0, patientPrefab.Length);
            var patient = Instantiate(patientPrefab[index], this.transform.position, Quaternion.identity);
            patient.GetComponent<Patient>().SetUp(moneySystem);
            yield return new WaitForSeconds(Random.Range(1, 3));
        }
    }

    public void Open_Clinic()
    {
        StartCoroutine(SpawnPatient());
        keepSpawing = true;
    }
    public void Close_Clininc()
    {
        StopAllCoroutines();
        keepSpawing = false;
    }
}
