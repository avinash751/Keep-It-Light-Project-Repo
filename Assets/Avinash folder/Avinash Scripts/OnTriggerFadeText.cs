using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnTriggerFadeText : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI textToFade;
    [SerializeField] string textAddon;

    [SerializeField] float FadeInSpeed;
    [SerializeField] float FadeOutSpeed;
    [SerializeField] float delay;
    [SerializeField] bool isInTrigger;
    [SerializeField] bool startfade;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FadeInText();
        FadeOutText();
        
       
    }

   


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<FpsMovment>(out var player))
        {
            isInTrigger = true;
            textToFade.text = textAddon;
            Invoke(nameof(startFading),delay);
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if(other.gameObject.TryGetComponent<FpsMovment>(out var player))
        {
            isInTrigger = false;
            startfade = false;
        }
    }

    void startFading()
    {
        if(isInTrigger)
        {
            startfade = true;
        }
    }


    void FadeInText()
    {
        if(startfade)
        {
            textToFade.color = Color.Lerp(textToFade.color,Color.white, Time.deltaTime * FadeInSpeed);
        }
    }

    void FadeOutText()
    {
        if (!isInTrigger)
        {
            textToFade.color = Color.Lerp(textToFade.color, Color.clear, Time.deltaTime * FadeOutSpeed);
        }
    }





}
