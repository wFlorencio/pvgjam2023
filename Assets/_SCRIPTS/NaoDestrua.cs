using UnityEngine;

public class NaoDestrua : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        // Verifica se já existe um objeto com o mesmo nome na cena
        GameObject[] objetosComMesmoNome = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject obj in objetosComMesmoNome)
        {
            if (obj.name == gameObject.name && obj != gameObject)
            {
                // Se já existe, destrua o objeto atual
                Destroy(gameObject);
                break;
            }
        }
    }
}