using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{

    public Sprite[] slides;  // Array de sprites para os slides
    private int indiceAtual = 0;  // Índice do slide atual
    private bool pausado = false;  // Indica se a sequência está pausada


 void Start()
    {
        MostrarSlideAtual();
    }

 void Update()
 {
        // Verifica a entrada do jogador apenas se não estiver pausado
        if (!pausado)
        {
            // Avança para o próximo slide com a tecla esquerda do mouse ou ao clicar em qualquer lugar na tela
            if (Input.GetMouseButtonDown(0))
            {
                AvancarSlide();

                // Se chegou ao último slide, carrega a cena "Start"
                if (indiceAtual >= slides.Length - 1)
                {
                    CarregarCenaStart();
                }
            }
        }

        // Pausa ou continua a sequência com a barra de espaço
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pausado = !pausado;
        }
    }

    void AvancarSlide()
    {
        // Verifica se ainda há mais slides para mostrar
        if (indiceAtual < slides.Length - 1)
        {
            indiceAtual++;
            MostrarSlideAtual();
        }
        else
        {
            Debug.Log("Fim da sequência de slides.");
        }
    }

    void MostrarSlideAtual()
    {
        // Atualiza o SpriteRenderer para exibir o slide atual
        if (indiceAtual < slides.Length)
        {
            GetComponent<SpriteRenderer>().sprite = slides[indiceAtual];
        }
    }

    void CarregarCenaStart()
    {
        SceneManager.LoadScene("level1");
    }
}
