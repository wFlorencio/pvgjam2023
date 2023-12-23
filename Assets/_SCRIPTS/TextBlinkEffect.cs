using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBlinkEffect : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;
    private float blinkInterval = 0.5f;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        StartCoroutine(BlinkText()); 
    }


    IEnumerator BlinkText()
    {
        while (true) 
        {
            text.enabled = !text.enabled;
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
