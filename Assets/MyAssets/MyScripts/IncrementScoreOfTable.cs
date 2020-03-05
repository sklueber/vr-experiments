using UnityEngine;

//weird hacky way to give the prefab objects access to the correct table object (which is effectively the Game Manager)
public class IncrementScoreOfTable : MonoBehaviour
{
    GameObject table;
    ScoringSystem scoreScript;
    public float detectionLength;

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
    //When a block is let go, cast rays up and down to check whether the block was put on top of another block. If it wasn't, the player has lost. Otherwise, he scored a point.
    public void OnBlockDetachFromHand()
    {
        RaycastHit hit;
        if ((Physics.Raycast(transform.position, Vector3.down, out hit, detectionLength)) || (Physics.Raycast(transform.position, Vector3.up, out hit, detectionLength)))
        {
            if (hit.collider.tag == "Block")
            {
                scoreScript.Invoke("IncrementScore", 0);
            }
            else
            {
                scoreScript.Invoke("SetLost", 0);
            }
        }



    }
}
