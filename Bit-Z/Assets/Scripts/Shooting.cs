﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public GameObject bullet;
    public Vector3 posLeft;
    public Vector3 posRight;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        posLeft = new Vector3(transform.position.x - 0.7f, transform.position.y);
        posRight = new Vector3(transform.position.x - 0.7f, transform.position.y);

        if(Input.GetKeyDown("space"))
        {
            if(PlayerController.dirFacing == 1)
            {
                ShootLeft();
                print("links schießen");
            }
            else if(PlayerController.dirFacing == 2)
            {
                ShootRight();
                print("rechts schießen");
            }
        }

	}

    void ShootLeft()
    {
        Instantiate(bullet, posLeft, Quaternion.identity);
    }

    void ShootRight()
    {
        Instantiate(bullet, posRight, Quaternion.identity);
    }
}
