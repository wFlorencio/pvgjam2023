using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiTool : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            Sprite spriteDoObjeto = spriteRenderer.sprite;
        }
        else
        {
            Debug.LogError("O objeto não possui componente SpriteRenderer.");
        }
    }

    void Update()
    {
        
    }
}
