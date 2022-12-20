
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    [Header("Enemy Prefabs to spawn")]
    public GameObject SpawnEnemy1;
    public GameObject SpawnEnemy2;

    //public GameObject SpawnEnemy;
    public int spawnAmount;

    [Header("Spawn Related Settings")]
    public  float startSpawnRateEnemy1;
    public float startSpawnRateEnemy2;
    public int SpawnRadius;

    // all spawn objects  that are part of the spawner
    [HideInInspector]
    public Transform SpawnDome;
    [HideInInspector]
    public Transform DarknessVolume;
    [HideInInspector]
    public Transform DarkFog;

    // Start is called before the first frame update

    private void OnValidate()
    {
        RefrenceAllSpawnvalues();
        InitialiseAllSpawnValues();
    }
    void Start()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            InstantiateEnemy1();
        }
        //InstantiateEnemy1 ();
        InvokeRepeating(nameof(InstantiateEnemy2), startSpawnRateEnemy2, startSpawnRateEnemy2);
    }

    private void Update()
    {
        InitialiseAllSpawnValues ();
    }

    void InstantiateEnemy1()
    {
        
        Vector3 SpawnPosition = transform.position;

        GameObject GO_Current = (GameObject)Instantiate(SpawnEnemy1);
        Vector2 CircleRadius =  Random.insideUnitCircle  * SpawnRadius;
        GO_Current.transform.position = new Vector3( transform.position.x +CircleRadius.x,transform.position.y, transform.position.z + CircleRadius.y);

        StartCoroutine("waitForFewSeconds");

        /*
        GameObject GO_Current = (GameObject)Instantiate(SpawnEnemy);
        Vector3 position = transform.position + Random.insideUnitSphere * 7f;
        GO_Current.transform.position = position;

        StartCoroutine("waitForFewSeconds");
        */
    }

    void InstantiateEnemy2()
    {
        Vector3 SpawnPosition = transform.position;

        GameObject Enemy2 = (GameObject)Instantiate(SpawnEnemy2);
        Vector2 CircleRadius = Random.insideUnitCircle ;
        Enemy2.transform.position = new Vector3(transform.position.x + CircleRadius.x, transform.position.y, transform.position.z + CircleRadius.y);
        Enemy2.GetComponent<Revolve>().targetToRevolveAround = this.transform;
    }

    IEnumerator waitForFewSeconds()
    {
        yield return new WaitForSeconds(startSpawnRateEnemy1);
        InstantiateEnemy1();
    }

    // debug drawing editor code 

#if  UNITY_EDITOR
    private void OnDrawGizmos()
    {
        UnityEditor.Handles.color = new Color(0, 0, 0, 0.15f);
        UnityEditor.Handles.DrawSolidDisc(transform.position, Vector3.up, SpawnRadius);

        UnityEditor.Handles.color = Color.white;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.down, SpawnRadius,2.5f);

        GUIStyle Bold = new GUIStyle();
        Bold.richText = true;
        Bold.fontStyle = FontStyle.Bold;
        Bold.normal.textColor = Color.white;
        UnityEditor.Handles.Label(transform.position + new Vector3(0, 2, 0), gameObject.name,Bold);
    }

    private void OnDrawGizmosSelected()
    {
        UnityEditor.Handles.color = new Color(255, 0, 0, 0.4f);
        UnityEditor.Handles.DrawSolidDisc(transform.position, Vector3.up, SpawnRadius);

        UnityEditor.Handles.color = Color.white;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.down, SpawnRadius, 2.5f);

        GUIStyle Bold = new GUIStyle();
        Bold.richText = true;
        Bold.fontStyle = FontStyle.Bold;
        Bold.normal.textColor = Color.black;
        UnityEditor.Handles.Label(transform.position + new Vector3(0, 2, 0), gameObject.name, Bold);
    }

#endif
    void InitialiseAllSpawnValues()
    {
        SpawnDome.localScale = Vector3.one* (SpawnRadius * 2);
        DarknessVolume.localScale = new Vector3(SpawnRadius * 2, SpawnRadius, SpawnRadius * 2);
        DarkFog.localScale = Vector3.one * (SpawnRadius / 10);
    }
    void RefrenceAllSpawnvalues()
    {
        SpawnDome = transform.GetChild(1);
        DarknessVolume = transform.GetChild(2);
        DarkFog = transform.GetChild(3);

    }
}
