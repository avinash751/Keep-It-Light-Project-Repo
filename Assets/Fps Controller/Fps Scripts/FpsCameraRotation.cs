using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FpsCameraRotation : MonoBehaviour
{
    [SerializeField] Camera FpsCamera;
    [SerializeField] float MouseAxisX;
    [SerializeField] float MouseAxisY;
    [Range(0,100)][SerializeField] float CameraSensetivity;
    

   
    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
       RotateCameraOnXaxis();
        RotateCameraOnYAxis();
    }

    void RotateCameraOnXaxis() // Horizontal rotation
    {
       MouseAxisX += Input.GetAxis("Mouse X") * Time.deltaTime; /// why do we have to add axix every frame? 
       transform.rotation = Quaternion.Euler(MouseAxisX * Vector3.up * CameraSensetivity ); /// how does roatation and rotate fucntion differ?
    }

    void RotateCameraOnYAxis()
    {
        MouseAxisY -= Input.GetAxis("Mouse Y") * CameraSensetivity * Time.deltaTime; // the value betwwen -1 and 1 in y axis camera of unity is inverted, that why we substract
        MouseAxisY = Mathf.Clamp(MouseAxisY, -90, 90);
        FpsCamera.transform.localEulerAngles = MouseAxisY * Vector3.right;
    }
}
