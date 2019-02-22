using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabChecker : MonoBehaviour
{

	public GameObject holdingPlayer;
	public bool isGrabbed;
	public bool isReleased;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    	if (isGrabbed)
    	{
        	transform.position = new Vector3(holdingPlayer.transform.position.x, holdingPlayer.transform.position.y + 0.8f, holdingPlayer.transform.position.z);	
    	}
    	if (isReleased)
    	{
    		transform.position = new Vector3(holdingPlayer.transform.position.x, 0.3f, holdingPlayer.transform.position.z - 0.5f);
    		holdingPlayer = null;
    		isGrabbed = false;
    		isReleased = false;
    	}
    }
}
