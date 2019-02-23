using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int playerNum;
	Rigidbody rb;
	public float walkSpeed;
    public float grabRange;
    GameObject heldItem;
    int grabCooldown;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horInp;
        float verInp;
        float grab;
        if (playerNum == 1)
        {
            horInp = Input.GetAxis("HorizontalP1");
            verInp = Input.GetAxis("VerticalP1");
            grab = Input.GetAxis("GrabP1");
        }
        else
        {
            horInp = Input.GetAxis("HorizontalP2");
            verInp = Input.GetAxis("VerticalP2");
            grab = Input.GetAxis("GrabP2");
        }
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
        if (heldItem == null && Vector3.Distance(transform.position, closestIngred.transform.position) <= grabRange && grab > 0 && grabCooldown == 0)
        {
            if (closestIngred.GetComponent<GrabChecker>().holdingPlayer != null)
            {
                closestIngred.GetComponent<GrabChecker>().holdingPlayer.GetComponent<PlayerController>().heldItem = null;
                closestIngred.GetComponent<GrabChecker>().holdingPlayer.GetComponent<PlayerController>().anim.SetBool("holding", false);
            }
            closestIngred.GetComponent<GrabChecker>().holdingPlayer = this.gameObject;
            closestIngred.GetComponent<GrabChecker>().isGrabbed = true;
            heldItem = closestIngred;
            grabCooldown = 30;
            anim.SetBool("holding", true);
        }
        if (heldItem != null && grab > 0 && grabCooldown == 0)
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
