
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System;

// Clase para representar la puntuación del partido


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

    private void Update()
    {
        if (marcadorEquipoA == 3 || marcadorEquipoB == 3)
        {
            // Si se cumple, muestra el mensaje del ganador
            string mensaje;
            if (marcadorEquipoA > marcadorEquipoB)
            {
               mensaje = "El ganador es el Equipo Rojo, con un resultado de " + marcadorEquipoB + " a " + marcadorEquipoA;
               guardarPuntuacion(mensaje);
            }
            else
            {
               mensaje = "El ganador es el Equipo Azul, con un resultado de " + marcadorEquipoA + " a " + marcadorEquipoB;
               guardarPuntuacion(mensaje);
            }
            
            // Reinicia los marcadores y vuelve a cargar la escena
            PlayerPrefs.SetString("MensajeFinDeJuego", mensaje);
            SceneManager.LoadScene("GameOver");
            ReiniciarMarcadores();
        }
    }

    // Método para guardar el resultado del partido en un archivo JSON
    private void guardarPuntuacion(string mensaje)
    {


  string filePath = "Assets/data.txt";

    // Agregar una nueva línea al final para separar los mensajes
    string line = "{\"partido\": \"" + mensaje + "\"}" + Environment.NewLine;

    // Escribir el mensaje al final del archivo
    File.AppendAllText(filePath, line);
       
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

    public void pausa()
    {
        Time.timeScale = 0;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
    }

    public void reanudar()
    {
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
    }

    public void reiniciar()
    {
        Time.timeScale = 1f;
        ReiniciarMarcadores();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MenuPrincipal()
    {
        Time.timeScale = 1f;
        ReiniciarMarcadores();
        SceneManager.LoadScene("Menu");
        MusicManager.instance.PlayMusic();
    }
}
