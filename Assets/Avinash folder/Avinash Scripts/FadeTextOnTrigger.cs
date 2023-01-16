using UnityEngine;
using TMPro;

public class FadeTextOnTrigger : MonoBehaviour
{
    // The TextMeshPro object that will be faded
    public TextMeshPro text;

    // The amount of time it takes for the text to fade in or out
    public float fadeDuration = 1f;


    // The initial color of the text
    private Color initialColor;

    // A flag indicating whether the text is currently fading in or out
    private bool fadeIn;
    private bool fadeOut;

    // The amount of time that has elapsed since the fade started
    private float elapsedTime;

    // The target alpha value of the text
    private float targetAlpha;

    [SerializeField] float DelayDurationTofadeIn;

    void Start()
    {
      InitializeTextColor();
    }

    void Update()
    {
        CheckWhetherToFadeOrNot(); 
    }

    void CheckWhetherToFadeOrNot()
    {
        if (fadeIn || fadeOut)
        {
            UpdateFade();

            // If the fade has completed, stop fading
            if (elapsedTime >= fadeDuration)
            {
                fadeIn = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // If the trigger has been entered and the text is not already fading in, start fading in
        if (other.TryGetComponent(out FpsMovment player) )
        {
            StartFadeIn();
            Debug.Log("player has entered");
        }
    }

    void OnTriggerExit(Collider other)
    {
        // If the trigger has been exited and the text is not already fading out, start fading out
        if (other.TryGetComponent(out FpsMovment player)  )
        {
            CancelInvoke(nameof(DelayToEnableFading));
            StartFadeOut();
        }
    }

    void StartFadeIn()
    {
        fadeOut = false;
        Invoke(nameof(DelayToEnableFading), DelayDurationTofadeIn);
        initialColor = text.color;
       
        elapsedTime = 0f;
        targetAlpha = 1f;
    }

    void StartFadeOut()
    {
        initialColor = text.color;
        fadeIn = false;
        fadeOut= true;
        elapsedTime = 0f;
        targetAlpha = 0f;
    }

    void UpdateFade()
    {
        elapsedTime += Time.deltaTime;
        float t = elapsedTime / fadeDuration;

        text.color = new Color(initialColor.r, initialColor.g, initialColor.b, Mathf.Lerp(initialColor.a, targetAlpha, t));
    }

    void DelayToEnableFading()
    {
        fadeIn = true;
    }

    void InitializeTextColor()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        initialColor = text.color;
    }
}




