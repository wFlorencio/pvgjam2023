using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaveColetavel : MonoBehaviour
{
    public float velocidadeRotacao = 30f;
    public AudioSource audioSource; 

    private void Update()
    {
        transform.Rotate(0f, 0f, velocidadeRotacao * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager gameManager = GameObject.Find("GAME_MANAGER").GetComponent<GameManager>();
            gameManager.AdicionaChave();

            if (audioSource != null)
            {
                audioSource.Play();
            }


            Destroy(gameObject);
        }
    }
}