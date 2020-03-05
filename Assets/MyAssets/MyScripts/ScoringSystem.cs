using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    public GameObject scoreLabel; //TODO specify
    public bool resetOnDestroy;
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

    private void OnDestroy()
    {
        score = 0;
        if (resetOnDestroy) highscore = 0; //TODO does not work
        onNewHighscore = false;
    }

    public void IncremenetScore()
    {
        score++;
        if (score > highscore)
        {
            highscore = score;
            if (!onNewHighscore)
            {
                AchievedNewHighscore();
                onNewHighscore = true;
            }
        }
        UpdateLabel();
    }

    private void UpdateLabel()
    {
        Debug.Log($"Score: {score}, Highscore: {highscore}");
    }

    private void AchievedNewHighscore()
    {
        Debug.Log("Congratulations");
    }

    public void ResetScore()
    {
        score = 0;
        onNewHighscore = false;
        UpdateLabel();
    }
}
