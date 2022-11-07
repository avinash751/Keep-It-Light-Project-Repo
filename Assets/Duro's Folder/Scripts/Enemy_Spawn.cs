using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{

    public GameObject SpawnEnemy;
    [Range(1, 10)][SerializeField] float SpawnRate;
    public int SpawnRadius;

    // all spawn objects  that are part of the spawner
    private Transform SpawnDome;
    private Transform DarknessVolume;
    private Transform DarkFog;

    // Start is called before the first frame update

    private void OnValidate()
    {
        RefrenceAllSpawnvalues();
        InitialiseAllSpawnValues();
    }
    void Start()
    {
        InstantiateEnemy ();
    }

    void InstantiateEnemy()
    {
        Vector3 SpawnPosition = transform.position;

        GameObject GO_Current = (GameObject)Instantiate(SpawnEnemy);
        Vector2 CircleRadius =  Random.insideUnitCircle * SpawnRadius;
        GO_Current.transform.position = new Vector3( transform.position.x +CircleRadius.x,transform.position.y, transform.position.z + CircleRadius.y);

        StartCoroutine("waitForFewSeconds");
    }

    IEnumerator waitForFewSeconds()
    {
        yield return new WaitForSeconds(SpawnRate);
        InstantiateEnemy();
    }


    // debug drawing editor code 
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
