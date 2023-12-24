using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssencialsLoader : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        // Gambiarra!
        if (Player.instance == null)
        {
            Player clone = Instantiate(player).GetComponent<Player>();

            Player.instance = clone;
        }
    }

}
