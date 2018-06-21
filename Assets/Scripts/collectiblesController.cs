using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collectiblesController : MonoBehaviour {

    public bool isCollected;
    public bool playSound;
    AudioSource audioSource;
    string points;

	// Use this for initialization
	void Start () {
        isCollected = false;
        points = this.GetComponent<Text>().text ;
        audioSource = this.GetComponent<AudioSource>();
        playSound = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (isCollected)
        {
            if (playSound)
            {
                audioSource.Play();
                playSound = false;
            }

            //Destroy after 1 second
            Destroy(this.gameObject, 1f);
            //The disappear animation
            Disappear();

        }
	}

    void Disappear()
    {
        //Space.self = go up (y axis according to object)
        //Space.world = go up (y axis according to world)
        this.transform.Translate(Vector3.up * .25f, Space.World);
        this.transform.Rotate(Vector3.up, 720 * Time.deltaTime);
        this.transform.localScale += new Vector3(.25f, .25f, .25f) * Time.deltaTime;
        //points.transform.Translate(Vector3.up * .25f, Space.World);
    }

}
