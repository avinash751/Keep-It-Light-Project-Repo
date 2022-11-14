using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoColorLerper : MonoBehaviour
{
    [SerializeField, HideInInspector] DarkOrbDestroyer lightOrb;
    [SerializeField, HideInInspector] LightOrbAmmoCountSystem orbAmmo;
    [SerializeField] Value maxAmmo;
    public Color[] colorsToLerp;
    public  int colorToLerpIndex;
    [SerializeField] MeshRenderer mesh;
    [SerializeField] float lerpTime;
    [SerializeField] Color glowColor;
    [SerializeField]float intesnsity;
    void Start()
    {

        lightOrb = GetComponent<DarkOrbDestroyer>();
        orbAmmo = GetComponent<LightOrbAmmoCountSystem>();
        colorToLerpIndex = maxAmmo.value -1;
    }

  

    // Update is called once per frame
    void Update()
    {
        if (lightOrb.trigger.orbObject ==this.gameObject)
        {
            LerpOrbColorWhenPickedUp();
            LerpOrbColorWhenNotPickedUp();
        }
    }

    void LerpOrbColorWhenNotPickedUp()
    {
        if(!lightOrb.IsPickedUp && !lightOrb.IsThrown && lightOrb.YoyoShot)
        {
            intesnsity = Mathf.Lerp(intesnsity, 10, Time.deltaTime * 8f);

            mesh.material.color = Color.Lerp(mesh.material.color, Color.yellow, Time.deltaTime * lerpTime);
            LerpOrbEmisionColor(glowColor,Color.black);
        }
    }

    void LerpOrbColorWhenPickedUp()
    {
        
        if (lightOrb.IsPickedUp && !lightOrb.IsThrown)
        {
            if(intesnsity>1)
            {
                intesnsity = Mathf.Lerp(intesnsity, 0, Time.deltaTime * 5f);
            }
           
            LerpAccordingToLerpIndex();
            LerpOrbEmisionColor(Color.black, glowColor);
        }
    }

   

    void LerpOrbColorWhenThrown()
    {
       
        if (lightOrb.trigger.orbObject == gameObject && lightOrb.IsThrown)
        {
    
            intesnsity = Mathf.Lerp(intesnsity, 10, Time.deltaTime * 0.3f);

            LerpOrbEmisionColor(glowColor, Color.black);
        }
    }

    void LerpAccordingToLerpIndex()
    {
        mesh.material.color = Color.Lerp(mesh.material.color, colorsToLerp[colorToLerpIndex], Time.deltaTime * lerpTime);
    }

    void LerpOrbEmisionColor(Color c1, Color c2)
    {
        mesh.material.SetColor("_EmissionColor", Color.Lerp(c1 * intesnsity , c2, Time.deltaTime *3f));
    }

    public void reduceColorLerpIndex(int amount)
    {
        if (colorToLerpIndex > 0 && colorToLerpIndex!=1)
        {
            colorToLerpIndex-=amount;
        }

        if(colorToLerpIndex > 0 && colorToLerpIndex ==1)
        {
            colorToLerpIndex--;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        LerpOrbColorWhenThrown();
    }


}
