using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

/*
    [Header("ELEMENTOS DO PERSONAGEM")]
    [SerializeField] public GameObject multitool;
    [SerializeField] public GameObject baioneta;
    [SerializeField] public GameObject loader;
    [SerializeField] public GameObject ponteiro;
    [SerializeField] public GameObject chave;
*/

    [Header("ELEMENTOS DE JOGO")]
    [SerializeField] public float timer;
    [SerializeField] private int enemyCounter = 0;
    [SerializeField] private int enemyTotal = 29;
    [SerializeField] private int signatureCounter = 0; //6
    [SerializeField] private int signatureTotal = 10; //6
    
    [SerializeField] private bool IsGameOver = false; 
    


    [Header("ELEMENTOS DA GUI")]
    [SerializeField] public TextMeshProUGUI temporizador;
    [SerializeField] public TextMeshProUGUI robot_count;
    [SerializeField] public TextMeshProUGUI key_count;
    
    [SerializeField] public GameObject gameOverScreen;
    [SerializeField] public GameObject endGameScreen;
    


    [Header("POWER-UPS (bool)")]
    [SerializeField] private bool powerUp_jump = false; //1
    [SerializeField] private bool powerUp_super_jump = false; //2

    [SerializeField] private bool powerUp_multitool = false; //3
    [SerializeField] private bool powerUp_multitool_key = false; //4
    [SerializeField] private bool powerUp_multitool_loader = false; //5
    [SerializeField] private bool powerUp_multitool_bayoneta = false; //6

    
    void Start()
    {
        //timer = 60.0f;
        UpdateRobotCounter();
        UpdateKeyCounter();
    }

    void Update()
    {
        //UpdateTimer();
        timer = Mathf.Max(timer - Time.deltaTime, 0.0f);
        string tempoFormatado = FormatTime(timer);
        temporizador.text = tempoFormatado;

        //Verificador De GameOver
        //if (timer <= 0.0f || "algum robô for destruído" )
        if (timer <= 0.0f)
        {
            GameOver();
        }

        if(enemyCounter == enemyTotal || signatureCounter == signatureTotal)
        {
            EndGame();
        }
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(IsGameOver)
            {
                ResetStage();
            }
        }

        //COMANDOS PARA DEBUG
        //f1 - JUMP
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if(!powerUp_jump)
            {
                powerUp_jump = true;
                Debug.Log("Salto Ativo");
            }
            else
            {
                powerUp_jump = false;
                Debug.Log("Salto  Desativado");
            }
        }

        //f2 - SUPER JUMP
        if (Input.GetKeyDown(KeyCode.F2))
        {
            if(!powerUp_super_jump)
            {
                powerUp_super_jump = true;
                Debug.Log("Super Salto Ativo");
            }
            else
            {
                powerUp_super_jump = false;
                Debug.Log("Super Salto Desativo");
            }
        }

        //f3 - ARMA
        if (Input.GetKeyDown(KeyCode.F3))
        {
            if(!powerUp_multitool)
            {
                powerUp_multitool = true;
                Debug.Log("MultiTool Ativa");
            }
            else
            {
                powerUp_multitool = false;
                Debug.Log("MultiTool Desativa");
            }
        }

        // f4 - ASSINATURA
        if (Input.GetKeyDown(KeyCode.F4))
        {
            if(powerUp_multitool_key == false)
            {
                powerUp_multitool_key = true;
                Debug.Log("Assinatura Ativa");
            }
            else
            {
                powerUp_multitool_key = false;
                Debug.Log("Assinatura Desativa");
            }
        }

        // F5 - CARREGADOR
        if (Input.GetKeyDown(KeyCode.F5))
        {
           if(powerUp_multitool_loader == false)
            {
                powerUp_multitool_loader = true;
                Debug.Log("Carregador Ativo");
            }
            else
            {
                powerUp_multitool_loader = false;
                Debug.Log("Carregador Desativo");
            }
        }

        // F6 - BAIONETA
        if (Input.GetKeyDown(KeyCode.F6))
        {
            if(powerUp_multitool_bayoneta == false)
            {
                powerUp_multitool_bayoneta = true;
                Debug.Log("Baioneta Ativa");
            }
            else
            {
                powerUp_multitool_bayoneta = false;
                Debug.Log("Baioneta Desativa");
            }
        }
        
    }

    private void UpdateTimer()
    {
        timer = Mathf.Max(timer - Time.deltaTime, 0.0f);
        string tempoFormatado = FormatTime(timer);
        temporizador.text = tempoFormatado;
    }

    private void UpdateKeyCounter()
    {
        string valorx = " " + signatureCounter + "/" + signatureTotal + " ";
        key_count.text = valorx;
    }

    private void UpdateRobotCounter()
    {
        string valory = " " + enemyCounter + "/" + enemyTotal + " ";
        robot_count.text = valory;
    }

    string FormatTime(float tempo)
    {
        int minutos = Mathf.FloorToInt(tempo / 60);
        int segundos = Mathf.FloorToInt(tempo % 60);
        int milissegundos = Mathf.FloorToInt((tempo * 100) % 100);

        // Formata o tempo como "00:00:00"
        return string.Format("{0:00}.{1:00}.{2:00}", minutos, segundos, milissegundos);
    }

    private void GameOver()
    {
        IsGameOver = true;
        Time.timeScale =  0;
        gameOverScreen.SetActive(true);
    }

    private void EndGame()
    {
        Time.timeScale =  0;
        endGameScreen.SetActive(true);
    }

    private void ResetStage()
    {
        //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale =  1;
        IsGameOver = false;
        gameOverScreen.SetActive(false);
        timer = 3.0f;
        //SceneManager.LoadScene(currentSceneIndex);
        SceneManager.LoadScene("level1");
    }


//useless
    public void GetPowerUp(int type)
    {
        switch (type)
        {
            case 1:
                powerUp_jump = true;
                break;

            case 2:
                powerUp_super_jump = true;
                break;

            case 3:
                powerUp_multitool = true;
                break;

            case 4:
                powerUp_multitool_key = true;
                break;

            case 5:
                powerUp_multitool_loader = true;
                break;

            case 6:
                powerUp_multitool_bayoneta = true;
                break;

            default:
                break;
        }

    }
}
