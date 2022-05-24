using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    //tiempo de aparicion 
    public float fadeDuration = 1f;

    public float displayImageDuration = 1f;

    private bool isPlayerAtExit, isPlayerCaught;

    //se detecta el trigger por objeto
    public GameObject player;
    
    //la imagen de salida que desaparece
    public CanvasGroup exitBackgroundImageCanvasGroup;
    //La imagen de que fua atrapado
    public CanvasGroup  caughtBackgroundImageCanvasGroup;

    //variable de audio
    public AudioSource exitAudio, caughtAudio;

    //garantizar que la variable se use una sola vez
    private bool hasAudioPlayed;

    //contador para el segundo de rigor
    private float timer;

   
    

    

    // declaramos el metodo de entrada para el trigger
    private void OnTriggerEnter(Collider other)
    {
        // si el objeto con el que chocas es el mismo (player)
        if (other.gameObject == player) {
            isPlayerAtExit = true;
        }
    }

    private void Update()
    {
        if (isPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        }
        else if (isPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }

        
       
    }

    //metodo que lanza el fin de la partida 
    //imagecanvasgroup es la imagen de partida correspondiente
    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource){

        //para que el audio se reprodusca o no
        if (!hasAudioPlayed){
            audioSource.Play();
            hasAudioPlayed = true;
        }

        timer += Time.deltaTime;
            // se pone para que nos de 1 o 0 y el math es para conservarlo 
        imageCanvasGroup.alpha = Mathf.Clamp(timer / fadeDuration, 0, 1);
            
            // si es mayor timer se termina el juego 
        if ( timer > fadeDuration + displayImageDuration){
            if (doRestart){
            //se resetea el nivel 
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
            }else{
            //se acaba la partida y se cierra el juego
            Application.Quit();
            }
            
        }
    }  

    //cambia el valor de la variable booleana
    public void CatchPalyer(){
        isPlayerCaught = true;
    }

    

}



    
        
    

