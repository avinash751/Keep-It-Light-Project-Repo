using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRate : MonoBehaviour
{
    [SerializeField] int TargetFrameRate;
    void Start()
    {
        Application.targetFrameRate = TargetFrameRate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
