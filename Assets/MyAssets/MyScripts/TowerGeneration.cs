using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGeneration : MonoBehaviour
{
    public GameObject blockPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(blockPrefab, new Vector3(0, 0.53F + i * 0.015F, 1.58F), Quaternion.identity);
            yield return new WaitForSeconds(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
