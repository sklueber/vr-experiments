using System.Collections;
using UnityEngine;

public class TowerGeneration : MonoBehaviour
{
    public GameObject blockPrefab;
    public float tableHight;
    public float tableZ;
    public float tableX;
    public int towerHight;
    public float dropHeight;
    public float dropDelay;
    float blockLength;
    float blockHight;
    float blockWidth;
    Coroutine currentCoroutine;
    bool generationRunning;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 blockScale = blockPrefab.transform.localScale;
        blockLength = blockScale.z;
        blockHight = blockScale.y;
        blockWidth = blockScale.x;
        BuildTower();
    }

    IEnumerator BuildTowerCoroutine()
    {
        generationRunning = true;
        for (int i = 0; i < towerHight; i += 2) //rows
        {
            for (int j = 0; j < 3; j++) //row of blocks facing in z-axis
            {
                Instantiate(blockPrefab, new Vector3(tableX + j * blockWidth, tableHight + dropHeight + i * blockHight, tableZ), Quaternion.identity);
                yield return new WaitForSeconds(dropDelay);
            }
            for (int k = 0; k < 3; k++) //row of blocks facing in x-axis
            {
                Instantiate(blockPrefab, new Vector3(tableX + blockWidth, tableHight + dropHeight + i * blockHight + blockHight, tableZ + (k - 1) * blockWidth), Quaternion.AngleAxis(90, Vector3.up)); //for z: middle block has same z as the "z-axis" blocks
                yield return new WaitForSeconds(dropDelay);
            }
        }
        generationRunning = false;
    }


    public void BuildTower()
    {
        if (!generationRunning)
        {
            currentCoroutine = StartCoroutine(BuildTowerCoroutine());
        }
    }

    public void ForceBuildNewTower()
    {
        if (generationRunning)
        {
            StopCoroutine(currentCoroutine);
        }
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Block"))
        {
            Destroy(obj);
        }
        currentCoroutine = StartCoroutine(BuildTowerCoroutine());
   
    }

// Update is called once per frame
void Update()
{

}
}
