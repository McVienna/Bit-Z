
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float maxSpeed = 10f;
    public Vector2 jumpForce = new Vector2(0, 300);
    public Rigidbody2D rig_bod;
    //public GameObject Bullet;
    public LayerMask ground;
    public static int dirFacing = 2;


    //private Transform myTrans;
    //private Vector2 myDirection;
    //private float ShootForce = 0.1f;


    bool facingRight = true;

    Animator anim;

    
    // Use this for initialization
	void Start ()
    {
        rig_bod = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //myTrans = transform;

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

        //var screenPos = Camera.main.WorldToScreenPoint(myTrans.position);
        //print("screenPos: " + screenPos);
        //myDirection = new Vector2(screenPos.x, screenPos.y);
        //print("myDirection: " + myDirection);

        if (move > 0 && !facingRight)
        {
            Flip();
            dirFacing = 2;
        }
        else if (move < 0 && facingRight)
        {
            Flip();
            dirFacing = 1;
        }

		if (Input.GetKeyDown("w"))
        {        
            Jump();     
        }

        //if(Input.GetKeyDown("space"))
        //{
        //    //Shoot();
        //    print("space");
        //}
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    bool IsGrounded()
    {
        Vector2 pos = transform.position;
        Vector2 dir = Vector2.down;
        float dis = 2.5f;

        Debug.DrawRay(pos, dir, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(pos, dir, dis, ground);
        if(hit.collider != null)
        {
            return true;
        }

        return false;
    }

    void Jump()
    {
        if(!IsGrounded())
        {
            return;
        }
        else
        {
            rig_bod.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
            //rig_bod.AddForce(new Vector2(0, 300));
        }
    }

    //void Shoot()
    //{
    //    var bullet = Instantiate(Bullet, myTrans.position, myTrans.rotation) as GameObject;

    //    if(bullet)
    //    {
    //        print("in bullet drin");
    //        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());

    //        var rigid = bullet.GetComponent<Rigidbody2D>();

    //        rigid.AddForce(myDirection * ShootForce, ForceMode2D.Impulse);
    //        //rigid.AddForce(Vector3.forward * 1000);

    //        Destroy(bullet, 5.0f);
    //    }

    //    else
    //    {
    //        Debug.LogError("nix Bullet");
    //    }


    //}

}

