using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;      //Áß¿ä

public class StartManager : MonoBehaviour
{
    public void StartClick()
    {
       
       SceneManager.LoadScene(1);
    }
}
