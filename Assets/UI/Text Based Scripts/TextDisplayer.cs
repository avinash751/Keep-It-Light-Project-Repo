using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextDisplayer : MonoBehaviour
{
    public string ValueYouAreShowing;
    public string TextAddon;
    public Value ScriptableValue;
    public TextMeshProUGUI TextToDisplay;

    private void Awake()
    {
        TextToDisplay = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        TextToDisplay.text = TextAddon + ScriptableValue.value.ToString();
    }
}
