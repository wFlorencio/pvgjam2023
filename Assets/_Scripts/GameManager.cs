using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("POWER-UPS")]
    [SerializeField] private bool powerUp_jump = false; //1
    [SerializeField] private bool powerUp_super_jump = false; //2

    [SerializeField] private bool powerUp_multitool = false; //3
    [SerializeField] private bool powerUp_multitool_key = false; //4
    [SerializeField] private bool powerUp_multitool_loader = false; //5
    [SerializeField] private bool powerUp_multitool_bayoneta = false; //6

    [Header("ELEMENTOS DO PERSONAGEM")]
    [SerializeField] public GameObject multitool;
    [SerializeField] public GameObject baioneta;
    [SerializeField] public GameObject loader;
    [SerializeField] public GameObject ponteiro;
    [SerializeField] public GameObject chave;

    [Header("ELEMENTOS DE CENA")]
    [SerializeField] public TextMeshProUGUI temporizador;
    [SerializeField] public float timer;
    
    void Awake()
    {
        multitool.SetActive(powerUp_multitool);
        baioneta.SetActive(powerUp_multitool_bayoneta);
        loader.SetActive(powerUp_multitool_loader);
        ponteiro.SetActive(powerUp_multitool_loader);
        chave.SetActive(powerUp_multitool_key);
    }

    void Start()
    {
        timer = 60.0f;
    }

    void Update()
    {
        //UpdateTimer();
        timer = Mathf.Max(timer - Time.deltaTime, 0.0f);
        string tempoFormatado = FormatTime(timer);
        temporizador.text = tempoFormatado;
        
    }

    private void UpdateTimer()
    {
        timer = Mathf.Max(timer - Time.deltaTime, 0.0f);
        string tempoFormatado = FormatTime(timer);
        temporizador.text = tempoFormatado;
    }

    string FormatTime(float tempo)
    {
        int minutos = Mathf.FloorToInt(tempo / 60);
        int segundos = Mathf.FloorToInt(tempo % 60);
        int milissegundos = Mathf.FloorToInt((tempo * 100) % 100);

        // Formata o tempo como "00:00:00"
        return string.Format("{0:00}.{1:00}.{2:00}", minutos, segundos, milissegundos);
    }



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
    

        //Toca musiquinha de triunfo
        //Spawna janela com texto explicativo
    }
}
