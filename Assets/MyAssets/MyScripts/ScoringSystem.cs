using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    public GameObject scoreLabel; //TODO specify
    int score;
    int highscore;
    bool onNewHighscore;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        highscore = 0; //could be replaced by savefile but that's a bit too much right now
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void incremenetScore()
    {
        score++;
        if (score > highscore)
        {
            highscore = score;
            if(!onNewHighscore)
            {
                achievedNewHighscore();
            }
        }
        updateLabel();
    }

    private void updateLabel()
    {
        Debug.Log($"Score: {score}, Highscore: {highscore}");
    }

    private void achievedNewHighscore()
    {
        Debug.Log("Congratulations");
    }
}
