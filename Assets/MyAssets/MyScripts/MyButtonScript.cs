using UnityEngine;


public class MyButtonScript : MonoBehaviour
{
    TowerGeneration genScript;
    ScoringSystem scoreScript;
    public GameObject blockPrefab;
    public GameObject TablePrefab;

    public void Start()
    {
        genScript = GameObject.FindObjectOfType(typeof(TowerGeneration)) as TowerGeneration;
        scoreScript = TablePrefab.GetComponent<ScoringSystem>();
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