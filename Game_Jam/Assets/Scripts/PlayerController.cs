using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	Rigidbody rb;
	public float walkSpeed;
    public float grabRange;
    public GameObject heldItem;
    public int grabCooldown;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * walkSpeed, 0f, Input.GetAxis("Vertical") * walkSpeed);
        GameObject[] ingredients = GameObject.FindGameObjectsWithTag("Ingredient");
        GameObject closestIngred = UtilFunctions.FindClosestObject(transform.position, ingredients);
        if (heldItem == null && Vector3.Distance(transform.position, closestIngred.transform.position) <= grabRange && Input.GetAxis("Grab") > 0 && grabCooldown == 0)
        {
            closestIngred.GetComponent<GrabChecker>().holdingPlayer = this.gameObject;
            closestIngred.GetComponent<GrabChecker>().isGrabbed = true;
            heldItem = closestIngred;
            grabCooldown = 30;
        }
        if (heldItem != null && Input.GetAxis("Grab") > 0 && grabCooldown == 0)
        {
            heldItem.GetComponent<GrabChecker>().isReleased = true;
            heldItem = null;
            grabCooldown = 30;
        }

        if (grabCooldown > 0)
        {
            grabCooldown--;
        }

    }
}
