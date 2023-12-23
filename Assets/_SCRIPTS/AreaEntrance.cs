using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
    
    public string transitionName;

    // Use this for initialization
    void Start()
    {
        if (transitionName == Player.instance.areaTransitionName)
        {
            Player.instance.transform.position = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Player transition name: " + PlayerController.instance.areaTransitionName + " Transition name: " + transitionName);
    }
}
