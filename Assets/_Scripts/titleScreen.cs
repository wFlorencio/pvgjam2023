using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class titleScreen : MonoBehaviour
{
    public TextMeshProUGUI pressEnterText, versionText;
    public GameObject MainMenu, PressEnter, fadePanelObj;
    public Button be_newGame, bt_quit;
    public RawImage fadePanel;
    public  Color currentColor = new Color(0, 0, 0, 1);
    public float fadeInDuration = 2f, fadeOutDuration = 1.3f, blinkInterval = 0.5f;
    bool blinkingStarted = false;
    
    void Awake()
    {
        MainMenu.SetActive(false);
    }

    void Start()
    { 
        ShowVersion();
        StartCoroutine(FadeIn());
        StartCoroutine(BlinkText());
        StartCoroutine(CheckForInput());

        // Oculta botão SAIR se o jogo tiver rodando direto do Navegador
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            if (bt_quit != null)
            {
                bt_quit.gameObject.SetActive(false);
            }
        }

        // Adicione um listener para chamar a função QuitGame() quando o botão for clicado
        be_newGame.onClick.AddListener(StartNewGame);
        bt_quit.onClick.AddListener(QuitGame);
    }


    IEnumerator FadeIn()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeInDuration)
        {
            currentColor.a = 1 - (elapsedTime / fadeInDuration);
            fadePanel.color = currentColor;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        currentColor.a = 0;
        fadePanel.color = currentColor;
        fadePanelObj.SetActive(false);
    }



    IEnumerator BlinkText()
    {
        while (true) 
        {
            pressEnterText.enabled = !pressEnterText.enabled;
            yield return new WaitForSeconds(blinkInterval);
        }
    }


    IEnumerator CheckForInput()
    {
        float startTime = Time.time;

        while (Time.time - startTime < 1.5f)
        {
            yield return null; // Aguarda até que tenham se passado 2 segundos
        }

        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                PressEnter.SetActive(false);
                MainMenu.SetActive(true);
                break;
            }
            yield return null;
        }
    }

    void StartNewGame()
    {
        StartCoroutine(FadeOutAndStart());
    }

        IEnumerator FadeOutAndStart()
    {
        
        fadePanelObj.SetActive(true);
        float elapsedTime = 0f;

        while (elapsedTime < fadeOutDuration)
        {
            currentColor = fadePanel.color;
            currentColor.a = (elapsedTime / fadeOutDuration);
            fadePanel.color = currentColor;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        currentColor.a = 1;
        fadePanel.color = currentColor;

        SceneManager.LoadScene("Start");
    }

    void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

    void ShowVersion()
    {
        if(versionText != null)
        {
            versionText.text = "Versão: " + Application.version;
        }
    }
    

}
