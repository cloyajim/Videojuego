using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuInicio : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void teleport() { 
        SceneManager.LoadScene ("MainVideo");
}

    public void Exit(){
        Application.Quit();
    }

    public void cinematica(){
        SceneManager.LoadScene ("MainScene");
    }
}
