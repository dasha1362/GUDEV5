using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

	GameObject player;
    public int playerNum;
    public float followSpeed;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject p in players)
        {
            if (playerNum == p.GetComponent<PlayerController>().playerNum)
            {
                player = p;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, 3, player.transform.position.z - 6), followSpeed);
    }
}
