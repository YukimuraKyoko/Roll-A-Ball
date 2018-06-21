using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpCanvas : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(Vector3.up * 1f, Space.World);
    }
}
