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
    float blockLength;
    float blockHight;
    float blockWidth;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BuildTower());
        Vector3 blockScale = blockPrefab.transform.localScale;
        blockLength = blockScale.z;
        blockHight = blockScale.y;
        blockWidth = blockScale.x;
    }

    IEnumerator BuildTower()
    {
        for (int i = 0; i < towerHight; i += 2) //rows
        {
            for (int j = 0; j < 3; j++) //row of blocks facing in z-axis
            {
                Instantiate(blockPrefab, new Vector3(tableX + j * blockWidth, tableHight + dropHeight + i * blockHight, tableZ), Quaternion.identity); //TODO parameterize starting position of tower

                yield return new WaitForSeconds(1);
            }
            for (int k = 0; k < 3; k++) //row of blocks facing in x-axis
            {
                Instantiate(blockPrefab, new Vector3(tableX + blockWidth, tableHight + dropHeight + i * blockHight + blockHight, tableZ + (k - 1) * blockWidth), Quaternion.AngleAxis(90, Vector3.up)); //for z: middle block has same z as the "z-axis" blocks

                yield return new WaitForSeconds(1);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
