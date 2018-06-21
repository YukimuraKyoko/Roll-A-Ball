using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody rb;
    public float moveSpeed = 1000f;
    public float jumpVelocity = 0;
    public float jumpHeight = 16f;
    canvasController cc;
    Vector3 resetPosition;
    GameObject player;
    public GameObject checkpointCanvas;
    public GameObject pointCanvas;
	public GameObject Explosion;
	public GameObject Points;
    public GameObject hazardPoints;
    float respawnTime = 0.7f;
    string state = "Moving";
    
    

	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody>();
        //GameObject.Find() searches for a gameobject in the hierarchy with the name passed to it
        cc = GameObject.Find("Canvas").GetComponent<canvasController>();
        resetPosition = transform.position;

    }


	
	// Update is called once per frame
	void Update () {
        if(state == "Moving")
        {
            Movement();
        }
        if(state == "Jump")
        {
            Jump();
            Movement();
        }

        //Reset Position if too low
        if(this.transform.position.y < -10f)
        {
            ReturnToCheckpoint();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpVelocity = jumpHeight;
            state = "Jump";
        }
    }





    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.tag == "Checkpoint")
        {
            if(resetPosition != other.transform.position)
            {
                resetPosition = other.transform.position;

                GameObject temp = (GameObject)Instantiate(checkpointCanvas);
                Destroy(temp, 1.5f);
            }
        }

        if (other.gameObject.tag == "Collectible")
        {
           cc.IncreaseScore(50);
            other.GetComponent<collectiblesController>().isCollected = true;
            GameObject temp = (GameObject)Instantiate(pointCanvas);
			GameObject temp2 = (GameObject)Instantiate(Points);
			temp2.transform.position = other.transform.position;
            Destroy(temp, 1.5f);
			Destroy (temp2, 1f);
        }

        if (other.gameObject.tag == "Hazard")
        {
            //Delays ReturnToCheckpoint() by 1.5sec
            Invoke("ReturnToCheckpoint", respawnTime);
			GameObject temp = (GameObject)Instantiate(Explosion);
			temp.transform.position = other.transform.position;
            GameObject temp3 = (GameObject)Instantiate(hazardPoints);
            temp3.transform.position = other.transform.position;
            Destroy(temp3, 1f);
            cc.IncreaseScore(-30);
        }
    }

    void ReturnToCheckpoint()
    {
        cc.LoseLives();
        rb.Sleep();
        this.transform.position = resetPosition;
        
    }

    void Movement()
    {
        float hdir = Input.GetAxisRaw("Horizontal");
        float vdir = Input.GetAxisRaw("Vertical");

        //Arrows Keys - Left/Right = (value, 0, 0), Up/down = (0, 0, value), combined = (value, 0 value)
        Vector3 directionVector = new Vector3(hdir, 0, vdir);

        //Length of vector is always 1
        Vector3 unitVector = directionVector.normalized;

        //Movement speed by direction with given moveSpeed
        Vector3 forceVector = unitVector * moveSpeed * Time.deltaTime;

        //Add to object
        rb.AddForce(forceVector);

        Vector3 jumpVector = Vector3.up * 10f * Time.deltaTime;
    }

    void Jump()
    {
        if (jumpVelocity < 0)
        {
            return;
        }
        jumpVelocity -= 1.25f;
    }
}
