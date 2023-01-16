using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    PickUpObjectTrigger triggerTrap;
    bool orbIsPlaced;
    Animator playDoor;
    [SerializeField] string trapDoor;
    BoxCollider collider;
    public AudioSource DoorSound;
    public Transform CenterPlaceHolder;
    bool startScallingOrb;
    GameObject orbOntrigger;
    public MeshRenderer mesh;
    float pedestalGlowIntensity;
    Color emmisiveColor = Color.black;

    void Start() 
	{
		collider = GetComponent<BoxCollider>();
		triggerTrap = FindObjectOfType<PickUpObjectTrigger>();
        playDoor = UnityEngine.GameObject.FindGameObjectWithTag(trapDoor).GetComponent<Animator>();
        DoorSound = GetComponentInChildren<AudioSource>();
        mesh.material.SetColor("_EmissionColor",emmisiveColor*0);
    }


    private void Update()
    {
        ScaleLighOrbWhenOnlyOnTrigger();
        LerpPedestalEmisionColor();

      
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Light Orb")
        {

            if (!triggerTrap.isPickedUp  && !orbIsPlaced && !triggerTrap.yoyoShot.yoyoShot)
            {
                SetLightOrbPositionOnTriggerPedestal(other.gameObject);
                Invoke(nameof(PlayDoorSoundAndAnimation),0.5f);
                other.transform.GetChild(1).gameObject.SetActive(false);

                Invoke(nameof(StartScalingDownLightOrb), 0.5f);
                Invoke(nameof(EnablePlayerCollider), 2f);
                StartCoroutine(DestroyLightOrb(other.gameObject,2.5f));
                
            } 
        }
         
    }

    IEnumerator DestroyLightOrb(GameObject other,float time)
    {
        yield return new WaitForSeconds(time);
        other.GetComponent<IDestroyable>().DestroyObject();
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent( out FpsMovment player))
        {
            triggerTrap.GetComponent<BoxCollider>().enabled = true;
        }
    }
    void SetLightOrbPositionOnTriggerPedestal(GameObject orb)
    {
        RemoveLightOrbTransformConstraints(orb.gameObject);
        SetLightOrbToCenter(orb.transform);
        makeSureOrbStaysOnPedestal(orb);
        orbOntrigger = orb;
    }

    void ScaleOrbToNothingness(Transform orb)
    {
        if (startScallingOrb)
        {
            orb.localScale = Vector3.Lerp(orb.localScale, Vector3.zero, Time.deltaTime * 3f);
        }
    }


    void SetLightOrbToCenter(Transform orb)
    {
        orb.position = CenterPlaceHolder.position;
    }

    void makeSureOrbStaysOnPedestal(GameObject orb)
    {
        orb.GetComponent<SphereCollider>().enabled = false;
        orbIsPlaced = true;
        triggerTrap.GetComponent<BoxCollider>().enabled = false;
        triggerTrap.hasClicked = false;
    
    }
    void RemoveLightOrbTransformConstraints(GameObject orb)
    {
        orb.transform.parent = null;
        orb.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }
    void PlayDoorSoundAndAnimation()
    {
        DoorSound.Play();
        playDoor.SetTrigger("Door Open");
    }

    void StartScalingDownLightOrb()
    {
        startScallingOrb = true;
    }

    void ScaleLighOrbWhenOnlyOnTrigger()
    {
        if (orbOntrigger != null)
        {
            ScaleOrbToNothingness(orbOntrigger.transform);
        }
    }

    void LerpPedestalEmisionColor()
    {
        if(orbIsPlaced && startScallingOrb)
        {
            Color targetColor = new Color(191, 39, 0);
            emmisiveColor = Color.Lerp(emmisiveColor, targetColor, Time.deltaTime * 1f);

           pedestalGlowIntensity = Mathf.Lerp(pedestalGlowIntensity, 2.5f, Time.deltaTime * 1f);
           mesh.material.SetColor("_EmissionColor",emmisiveColor* pedestalGlowIntensity);
        }
    }
    
    void EnablePlayerCollider()
    {
        triggerTrap.GetComponent<BoxCollider>().enabled = true;
    }
}
