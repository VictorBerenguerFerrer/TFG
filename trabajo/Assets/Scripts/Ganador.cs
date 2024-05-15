using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Ganador : MonoBehaviour
{
    public Text mensaje;

    
    void Start()
    {
        string ganador = PlayerPrefs.GetString("MensajeFinDeJuego");
        // Mostrar el mensaje en el Texto
        mensaje.text = ganador;
       
    }
    public void Reiniciar(){
        SceneManager.LoadScene("Menu");
        

    }
    

    // Update is called once per frame



}
