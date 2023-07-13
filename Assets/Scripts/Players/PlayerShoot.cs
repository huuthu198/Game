using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    PlayerController controls;
    public Animator animator;
    public GameObject bullet;
    public Transform bulletHole;
    public float force = 200;
    private void Awake()
    {
        controls = new PlayerController();
        controls.Enable();

        controls.Land.Shoot.performed += ctx => Fire();

    }

    private void Fire()
    {
        animator.SetTrigger("shoot");
        GameObject go = Instantiate(bullet, bulletHole.position, bullet.transform.rotation);
        if (GetComponent<PlayerMoveMent>().isFacing)
            go.GetComponent<Rigidbody2D>().AddForce(Vector2.right * force);
        else
	        go.GetComponent<Rigidbody2D>().AddForce(Vector2.left * force);
	    	
    } 
}
