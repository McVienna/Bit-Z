using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject m_PLayerPrefab;
    public GameObject m_EnemyPrefab;

	// Use this for initialization
	void Start ()
    {
        Instantiate(m_PLayerPrefab);
        Instantiate(m_EnemyPrefab);
	}
	
	// Update is called once per frame
	void Update () {
		 
	}
}
