using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailureDetection : MonoBehaviour
{
    ScoringSystem scoreScript;
    // Start is called before the first frame update
    void Start()
    {
        scoreScript = gameObject.GetComponent<ScoringSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Block")
        {
            Debug.Log("detected block on ground");
            scoreScript.Invoke("SetLost", 0);
        }
    }
}
