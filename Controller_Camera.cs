using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Camera : MonoBehaviour
{
    public Transform target;


    // Update is called once per frame
    void Update()
    {
        if (GameManager.gm.gState != GameManager.GameState.Run)
        {
            return;
        }
        transform.position = target.position;
    }
}
