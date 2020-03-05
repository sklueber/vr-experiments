using UnityEngine;


public class MyButtonScript : MonoBehaviour
{
    TowerGeneration genScript;
    ScoringSystem scoreScript;
    public GameObject blockPrefab;


    public void Start()
    {
        genScript = GameObject.FindObjectOfType(typeof(TowerGeneration)) as TowerGeneration;
        scoreScript = GameObject.FindObjectOfType(typeof(ScoringSystem)) as ScoringSystem;
    }
    public void OnButtonDown() //Resets all Towers, not just those from a given table
    {
        genScript.ForceBuildNewTower();
        scoreScript.ResetScore();
    }

    public void OnButtonUp()
    {

    }
}