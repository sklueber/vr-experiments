using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    public Text scoreText;
    public Text highscoreText;
    public bool resetOnDestroy;
    int score;
    int highscore;
    bool onNewHighscore;
    bool lost;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        highscore = 0; //could be replaced by savefile but that's a bit too much right now
        lost = false;
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

    public void IncrementScore()
    {
        if (lost) return;
        score++;
        if (score > highscore)
        {
            highscore = score;
            if (!onNewHighscore)
            {
                AchievedNewHighscore();
                onNewHighscore = true;
                return;
            }
        }
        UpdateLabel();
    }

    private void UpdateLabel()
    {
        Debug.Log($"Score: {score}, Highscore: {highscore}");
        scoreText.text = score.ToString();
        highscoreText.text = highscore.ToString();
    }

    private void AchievedNewHighscore()
    {
        Debug.Log("Congratulations");
        scoreText.text = score.ToString();
        highscoreText.text = "New Highscore!";
    }

    public void ResetScore()
    {
        score = 0;
        onNewHighscore = false;
        lost = false;
        UpdateLabel();
    }

    public void SetLost()
    {
        if (lost) return;
        //Debug.Log("Game Over");
        lost = true;
        highscoreText.text = "Game Over!";
        scoreText.text = score.ToString();
    }
}
