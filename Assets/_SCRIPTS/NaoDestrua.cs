using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaoDestrua : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
