using UnityEngine;


public class MyButtonScript : MonoBehaviour
{
    //public GameObject table;
    TowerGeneration genScript;
    public GameObject blockPrefab;

    public void Start()
    {
        genScript = GameObject.FindObjectOfType(typeof(TowerGeneration)) as TowerGeneration;

    }
    public void OnButtonDown()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Block"))
        {
            Destroy(obj);
        }
        genScript.Invoke("Start", 0);
    }

    public void OnButtonUp()
    {

    }
}