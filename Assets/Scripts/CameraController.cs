using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject Player;
    public Vector2 velocity;
    public float smoothTimex;
    public float smoothTimey;
    public bool bounds;
    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;
    //public float RunBack;

    private float offset;

    // Use this for initialization
    void Awake ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        //offset = transform.position - Player.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {

        offset = GetComponent<Camera>().transform.position.x - Player.transform.position.x;

        //Debug.Log(offset);

        //transform.position = Player.transform.position + offset;

        float posX = Mathf.SmoothDamp(transform.position.x, Player.transform.position.x, ref velocity.x, smoothTimex);
        float posY = Mathf.SmoothDamp(transform.position.y, Player.transform.position.y, ref velocity.y, smoothTimey);

        transform.position = new Vector3(posX, posY, transform.position.z);

        if (bounds)
        {       
            if ((PlayerController.dirFacing == 2) && (minCameraPos.x >= -39.21f) )
            {
                
                minCameraPos.x = GetComponent<Camera>().transform.position.x;
            }

            if(minCameraPos.x < -39.21f)
            {
                minCameraPos.x = -39.21f;
            }
            else if(minCameraPos.x >= maxCameraPos.x)
            {
                minCameraPos.x = maxCameraPos.x;
            }
            
            transform.position = new Vector3(Mathf.Clamp(transform.position.x + offset, minCameraPos.x, maxCameraPos.x),
                                 Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
                                 Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));

            Debug.Log("Offset: " + offset);
            Debug.Log("Transform Pos: " + transform.position);
            Debug.Log("Camera: " + GetComponent<Camera>().transform.position.x);
            Debug.Log("minCamera: " + minCameraPos.x);
        }

    }
}
