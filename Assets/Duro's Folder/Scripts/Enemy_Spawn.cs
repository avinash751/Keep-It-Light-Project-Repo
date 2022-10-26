using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{

    public GameObject SpawnEnemy;

    // Start is called before the first frame update
    void Start()
    {
        InstantiateEnemy ();
    }

    void InstantiateEnemy()
    {
        GameObject GO_Current = (GameObject)Instantiate(SpawnEnemy);
        GO_Current.transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z);

        StartCoroutine("waitForFewSeconds");
    }

    IEnumerator waitForFewSeconds()
    {
        yield return new WaitForSeconds(7.0f);
        InstantiateEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
