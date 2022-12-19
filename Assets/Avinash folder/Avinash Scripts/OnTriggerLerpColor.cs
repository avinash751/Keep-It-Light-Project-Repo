using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerLerpColor : MonoBehaviour
{
    [SerializeField]Color transparentColor;
    MeshRenderer mesh;
    [SerializeField] Color colorToLerpTo;
    [SerializeField] Color EnterColor;
    [SerializeField] float frequency;
    [SerializeField] bool entered;
    bool loop;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        transparentColor = new Color(0,0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
       LerpColorEnter();
       LooplerpColor();
       lerpColorExit(transparentColor);
      
    }


    void LooplerpColor()
    {
        if(loop && entered)
        {
            mesh.material.color = Color.Lerp(mesh.material.color, colorToLerpTo, Mathf.Sin(Time.time * frequency) );
        }
       
    }

    void lerpColorExit(Color endColor)
    {
        if (!entered)
        {
            mesh.material.color = Color.Lerp(mesh.material.color, endColor, Time.deltaTime * 2);
        }
    }

    void LerpColorEnter()
    {
        if (entered)
        {
            mesh.material.color = Color.Lerp(mesh.material.color, EnterColor, Time.deltaTime * 1.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out FpsMovment player))
        {
            entered = true;
            Invoke(nameof(enableLoopingLerp), 2);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out FpsMovment player))
        {
            entered = false;
            loop = false;
        }
    }

    void enableLoopingLerp()
    {
        loop = true;
    }
}
