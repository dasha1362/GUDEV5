using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SpawnWater : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform prefab;
    public GameObject[] spawners;
    void Start(){
    }


    void OnTriggerEnter(Collider other) {
        Vector3 playerPosition = other.transform.position;
        Instantiate(prefab, new Vector3(playerPosition.x + Random.Range(-5.0f, 5.0f), 0.3f, playerPosition.z + Random.Range(-5.0f, 5.0f)), Quaternion.identity);
    }




    // Update is called once per frame
    void Update()
    {

    }
}
