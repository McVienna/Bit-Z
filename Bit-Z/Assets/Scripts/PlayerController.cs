
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float maxSpeed = 10f;
    public Vector2 jumpForce = new Vector2(0, 300);


    bool facingRight = true;

    public Rigidbody2D rig_bod;

    Animator anim;

    
    // Use this for initialization
	void Start ()
    {
        rig_bod = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

    }

    /// <summary>
    /// No Use of delta-time because FixedUpdate function -> called for working with rigidbody!
    /// FixedUpdate is called once per Frame!
    /// </summary>
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(move));

        rig_bod.velocity = new Vector2(move * maxSpeed, rig_bod.velocity.y);

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }

        if (Input.GetKeyDown("space"))
        {
            rig_bod.AddForce(new Vector2(0, 300));

        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
