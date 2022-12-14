using System;
using UnityEngine;

public class FpsCameraRotation : MonoBehaviour
{
    [SerializeField] Camera FpsCamera;
    [SerializeField] float MouseAxisX;
    [SerializeField] float MouseAxisY;
    [SerializeField] Transform CameraPositionHolder;
    [Range(0,200)][SerializeField] float CameraSensetivity;



    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked;
        MouseAxisX = FpsCamera.transform.rotation.eulerAngles.x;
        MouseAxisY = FpsCamera.transform.rotation.eulerAngles.y;


    }


    void Update()
    {
       RotateCameraPsoitionHolderForMovemntDirection();
       RotateCamera();
    }

    private void LateUpdate()
    {
        
    }

    void RotateCameraPsoitionHolderForMovemntDirection() // Horizontal rotation
    {
       
       CameraPositionHolder.rotation = Quaternion.Euler(MouseAxisX * Vector3.up ); /// how does roatation and rotate fucntion differ?
    }

    void RotateCamera()
    {
        MouseAxisX += Input.GetAxis("Mouse X") * CameraSensetivity * Time.deltaTime; /// why do we have to add axix every frame? 
        MouseAxisY -= Input.GetAxis("Mouse Y") * CameraSensetivity * Time.deltaTime; // the value betwwen -1 and 1 in y axis camera of unity is inverted, that why we substract
        MouseAxisY = Mathf.Clamp(MouseAxisY, -90, 90);
        FpsCamera.transform.rotation = Quaternion .Euler(MouseAxisX * Vector3.up + MouseAxisY*Vector3.right);

    }
}
