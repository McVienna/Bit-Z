
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float maxSpeed = 10f;
    bool facingRight = true;

    
    // Use this for initialization
	void Start ()
    {
		
	}

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
