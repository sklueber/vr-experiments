using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//weird hacky way to give the prefab objects access to the correct table object (which is effectively the Game Manager)
public class IncrementScoreOfTable : MonoBehaviour
{
    GameObject table;
    ScoringSystem scoreScript;
    // Start is called before the first frame update
    void Start()
    {
        table = GameObject.Find("Table");
        scoreScript = table.GetComponent(typeof(ScoringSystem)) as ScoringSystem;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementScoreOfTablePlease()
    {
        scoreScript.Invoke("IncrementScore", 0);
    }
}
