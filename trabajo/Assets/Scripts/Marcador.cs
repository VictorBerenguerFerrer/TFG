using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MarcadorDeGoles : MonoBehaviour
{
    public Text marcadorEquipoATexto;
    public Text marcadorEquipoBTexto;

    public int marcadorEquipoA;
    public int marcadorEquipoB;

    [SerializeField] private GameObject botonPausa;

    [SerializeField] private GameObject menuPausa;
    

    void Start()
    {
        // Obtener los marcadores guardados (si los hay)
        if (PlayerPrefs.HasKey("MarcadorEquipoA"))
        {
            marcadorEquipoA = PlayerPrefs.GetInt("MarcadorEquipoA");
        }
        if (PlayerPrefs.HasKey("MarcadorEquipoB"))
        {
            marcadorEquipoB = PlayerPrefs.GetInt("MarcadorEquipoB");
        }
         
        // Actualizar los textos de los marcadores
        ActualizarMarcadores();
       
    }

    private void Update(){
         if (marcadorEquipoA == 3 || marcadorEquipoB == 3)
        {
            // Si se cumple, muestra el mensaje del ganador
            String mensaje ;
            if (marcadorEquipoA > marcadorEquipoB)
            {
               mensaje = "El ganador es el Equipo Rojo.";
            }
            else
            {
               mensaje = "El ganador es el Equipo Azul.";
            }
            
            // Reinicia los marcadores y vuelve a cargar la escena
             PlayerPrefs.SetString("MensajeFinDeJuego", mensaje);
             SceneManager.LoadScene("GameOver");
            ReiniciarMarcadores();
        }
    }

    // Método para incrementar el marcador del Equipo A
    public void IncrementarMarcadorEquipoA()
    {
        marcadorEquipoA++;
        GuardarMarcadores();
    }

    // Método para incrementar el marcador del Equipo B
    public void IncrementarMarcadorEquipoB()
    {
        marcadorEquipoB++;
        GuardarMarcadores();
    }

    // Método para guardar los marcadores
    private void GuardarMarcadores()
    {
        PlayerPrefs.SetInt("MarcadorEquipoA", marcadorEquipoA);
        PlayerPrefs.SetInt("MarcadorEquipoB", marcadorEquipoB);
        PlayerPrefs.Save();

        // Actualizar los textos de los marcadores
        ActualizarMarcadores();
    }

    // Método para actualizar los textos de los marcadores
    private void ActualizarMarcadores()
    {
        marcadorEquipoATexto.text = marcadorEquipoA.ToString();
        marcadorEquipoBTexto.text = marcadorEquipoB.ToString();
    }

    // Método para reiniciar la escena
    public void ReiniciarEscena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Método para reiniciar los marcadores
    public void ReiniciarMarcadores()
    {
        marcadorEquipoA = 0;
        marcadorEquipoB = 0;
        GuardarMarcadores();
    }


    public void pausa(){

        Time.timeScale = 0;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);

    }

    public void reanudar(){
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
    }

    public void reiniciar(){
        Time.timeScale = 1f;
        ReiniciarMarcadores();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MenuPrincipal(){
        Time.timeScale = 1f;
        ReiniciarMarcadores();
        SceneManager.LoadScene("Menu");
        MusicManager.instance.PlayMusic();
    }

}
