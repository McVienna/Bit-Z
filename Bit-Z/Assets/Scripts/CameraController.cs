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
    private float minY;
    private float maxY, minX, maxX;

    //private Vector3 offset;

    // Use this for initialization
    void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {


        var camw = GetComponent<Camera>().orthographicSize;
        //var camh = GetComponent<Camera>().pixelHeight;
        //minCameraPos = new Vector3(minY, 0, -3);

        Debug.Log("Ortho: " + camw);

        float posX = Mathf.SmoothDamp(transform.position.x, Player.transform.position.x, ref velocity.x, smoothTimex);
        float posY = Mathf.SmoothDamp(transform.position.y, Player.transform.position.y, ref velocity.y, smoothTimey);

        transform.position = new Vector3(posX, posY, transform.position.z);

        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
                                             Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
                                             Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
            Debug.Log("Transform: " + transform.position);
        }

    }
}
