using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssencialsLoader : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // Gambiarra!
        if (Player.instance == null)
        {
            Player clone = Instantiate(player).GetComponent<Player>();

            Player.instance = clone;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
