using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class BOTONES : MonoBehaviour
{
    public static bool modoJuego = false;

    public AudioSource clickSound; // El AudioSource para el sonido del clic
    public float delayBeforeSceneChange = 0.5f;
    public void EmpezarJuego(){

        StartCoroutine(ReproducirSonido("Menu2"));

    }

    public void Multijugador(){
        
        StartCoroutine(ReproducirSonido("SelectorEquipos"));
        modoJuego = false;
    }

    public void Local(){
        
        StartCoroutine(ReproducirSonido("SelectorEquipos"));
        modoJuego = true;
    }
   
   public void CerrarJuego(){
    Application.Quit();
   }
   
    public void RestartGame()
    {
         int indiceEscenaActual = SceneManager.GetActiveScene().buildIndex;
        int indiceEscenaAnterior = indiceEscenaActual - 1;
            
        SceneManager.LoadScene(indiceEscenaAnterior);
        
    }



     IEnumerator ReproducirSonido(string nombre)
    {
        if (clickSound != null)
        {
            clickSound.Play(); // Reproducir el sonido
            yield return new WaitForSeconds(delayBeforeSceneChange); // Esperar antes de cambiar de escena
        }

        SceneManager.LoadScene(nombre); // Cambiar de escena después de la espera
    }
}
