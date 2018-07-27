using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text P1ScoreText;
    public Text P2ScoreText;
    public Text P3ScoreText;
    public Text P4ScoreText;

    public int P1ScoreCount;
    public int P2ScoreCount;
    public int P3ScoreCount;
    public int P4ScoreCount;

    public Text TimerText;
    public float Timer = 120f;

	// Use this for initialization
	void Start ()
    {
        Time.timeScale = 1;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Timer -= Time.deltaTime;
        TimerText.text = "Time: " + Mathf.Round(Timer);

        P1ScoreText.text = "P1: " + P1ScoreCount;
        P2ScoreText.text = "P2: " + P2ScoreCount;
        P3ScoreText.text = "P3: " + P3ScoreCount;
        P4ScoreText.text = "P4: " + P4ScoreCount;

        if (Timer <= 0)
        {
            Time.timeScale = 0;
        }
    }
}
