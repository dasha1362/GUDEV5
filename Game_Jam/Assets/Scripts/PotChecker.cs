using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PotChecker : MonoBehaviour
{

    public int playerNum;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(CheckSurroundingItems), 1, 1);
    }

    void CheckSurroundingItems()
    {
        var items = GameObject.FindGameObjectsWithTag("Ingredient")
            .Where(t => Vector3.Distance(t.transform.position ,transform.position) < 1 && t.GetComponent<GrabChecker>().LastPlayerNumber == playerNum).ToArray();
        foreach (var item in items)
        {
            Destroy(item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
