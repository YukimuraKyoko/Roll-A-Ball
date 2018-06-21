using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    Vector3 offset;
    Vector3 ZoomOut = new Vector3(0, 0, 0);
    Vector3 ZoomIn = new Vector3(0, 0, 0);
    public GameObject player;

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = player.transform.position + offset + ZoomOut + ZoomIn;

        if (Input.GetKey(KeyCode.Z))
        {
            
             ZoomOut += new Vector3(0, 5, -5) * Time.deltaTime;
            
        }
        if (Input.GetKey(KeyCode.X))
        {
            ZoomIn += new Vector3(0, -5, 5) * Time.deltaTime;
        }
	}
    
}
