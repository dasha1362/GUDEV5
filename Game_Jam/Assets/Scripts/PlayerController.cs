using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	Rigidbody rb;
	public float walkSpeed;
    public float grabRange;
    GameObject heldItem;
    int grabCooldown;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horInp = Input.GetAxis("Horizontal");
        float verInp = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(horInp * walkSpeed, 0f, verInp * walkSpeed);
        anim.SetFloat("hSpeed", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("vSpeed", Mathf.Abs(rb.velocity.z));
        if (verInp > 0)
        {
            anim.SetInteger("direction", 0);
        }
        else if (verInp < 0)
        {
            anim.SetInteger("direction", 2);
        }
        else if (horInp > 0)
        {
            anim.SetInteger("direction", 1);
        }
        else if (horInp < 0)
        {
            anim.SetInteger("direction", 3);
        }
        GameObject[] ingredients = GameObject.FindGameObjectsWithTag("Ingredient");
        GameObject closestIngred = UtilFunctions.FindClosestObject(transform.position, ingredients);
        if (heldItem == null && Vector3.Distance(transform.position, closestIngred.transform.position) <= grabRange && Input.GetAxis("Grab") > 0 && grabCooldown == 0)
        {
            closestIngred.GetComponent<GrabChecker>().holdingPlayer = this.gameObject;
            closestIngred.GetComponent<GrabChecker>().isGrabbed = true;
            heldItem = closestIngred;
            grabCooldown = 30;
            anim.SetBool("holding", true);
        }
        if (heldItem != null && Input.GetAxis("Grab") > 0 && grabCooldown == 0)
        {
            heldItem.GetComponent<GrabChecker>().isReleased = true;
            heldItem = null;
            grabCooldown = 30;
            anim.SetBool("holding", false);
        }

        if (grabCooldown > 0)
        {
            grabCooldown--;
        }

    }
}
