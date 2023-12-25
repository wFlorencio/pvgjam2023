using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaveColetavel : MonoBehaviour
{
    public float velocidadeRotacao = 30f;
    private AudioSource audioSource;
    private bool somReproduzido = false;
    private bool coletaRegistrada = false;

     private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        transform.Rotate(0f, 0f, velocidadeRotacao * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !somReproduzido && !coletaRegistrada)
        {
            GameManager gameManager = GameObject.Find("GAME_MANAGER").GetComponent<GameManager>();
            gameManager.AdicionaChave();

            if (audioSource != null && audioSource.clip != null)
            {
                StartCoroutine(ReproduzirESubsequentementeDestruir());
                somReproduzido = true; 
            }
            else
            {
                Destroy(gameObject);
            }
            coletaRegistrada = true;
        }
    }

    private System.Collections.IEnumerator ReproduzirESubsequentementeDestruir()
    {
        audioSource.Play();

        yield return new WaitForSeconds(audioSource.clip.length);

        Destroy(gameObject);
    }
}