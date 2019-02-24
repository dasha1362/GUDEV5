using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SpawnFruit : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform prefab;
    public GameObject[] spawners;
    void Start()
    {
        print(spawners);
        if (spawners == null || spawners.Length == 0)
        {
            spawners = GameObject.FindGameObjectsWithTag("Spawn");
            print(spawners.Length);
        }

        InvokeRepeating(nameof(SpawnPrefab), 5, 5);
    }

    void SpawnPrefab()
    {
        var chosenSpawnerPosition = spawners[Random.Range(0,spawners.Length)].transform.position;
        Instantiate(prefab, new Vector3(chosenSpawnerPosition.x + Random.Range(-5.0f, 5.0f), 0.3f, chosenSpawnerPosition.z + Random.Range(-5.0f, 5.0f)), Quaternion.identity);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
