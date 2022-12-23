using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveAndLoad : MonoBehaviour
{
    public void Save()
    {
        BinaryFormatter Translate = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Player.Pos"; //giving the path of where to create file
        FileStream stream = new FileStream(path , FileMode.Create); //creating the file
        DataToSave saveThis = new DataToSave(); //specify what data to save
        saveThis.x = transform.position.x; //saving transform of player
        saveThis.y = transform.position.y;
        saveThis.z = transform.position.z;
        Translate.Serialize(stream, saveThis); //translating what im saving  //where im saving and what im saving
        stream.Close();
    }

    public void Load() // getting the information ^^ and loading it
    {
        BinaryFormatter Translate = new BinaryFormatter(); 
        string path = Application.persistentDataPath + "/Player.Pos"; 
        FileStream stream = new FileStream(path, FileMode.Open);
        DataToSave LoadedThings = Translate.Deserialize(stream) as DataToSave;
        stream.Close();
        Vector3 LoadedPos = transform.position;
        LoadedPos.x = LoadedThings.x;
        LoadedPos.y = LoadedThings.y;
        LoadedPos.z = LoadedThings.z;
        transform.position = LoadedPos;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            Save();
        }
    }
}
