using UnityEngine;


public class MyButtonScript : MonoBehaviour
{
    TowerGeneration genScript;
    public GameObject blockPrefab;


    public void Start()
    {
        genScript = GameObject.FindObjectOfType(typeof(TowerGeneration)) as TowerGeneration;

    }
    public void OnButtonDown() //Resets all Towers, not just those from a given table
    {
        genScript.ForceBuildNewTower();
    }

    public void OnButtonUp()
    {

    }
}