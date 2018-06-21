using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvasController : MonoBehaviour {

    public GameObject scoreText;
    public GameObject livesText;
    public int score;
    private int lifes;

	// Use this for initialization
	void Start () {
        score = 0;
        lifes = 3;
        scoreText.GetComponent<Text>().text = "Score: 0";
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void IncreaseScore(int amount)
    {
        if(amount < 0 && score+amount < 0)
        {
            score = 0;
        }
        else
        {
            score += amount;
        }
        //score += amount;
        scoreText.GetComponent<Text>().text = "Score: " + score.ToString();
    }

    public void LoseLives()
    {
        lifes -= 1;
        livesText.GetComponent<Text>().text = "Lives: " + lifes.ToString();
    }
}
