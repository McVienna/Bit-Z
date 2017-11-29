using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject m_PLayerPrefab;

	// Use this for initialization
	void Start ()
    {
        Instantiate(m_PLayerPrefab);
	}
	
	// Update is called once per frame
	void Update () {
		 
	}
}
