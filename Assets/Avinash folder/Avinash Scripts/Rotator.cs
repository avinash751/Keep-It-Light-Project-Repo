using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] float RotationSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(transform.up * RotationSpeed * Time.deltaTime);
    }
}
