using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinsController : MonoBehaviour
{
    public AudioSource clickSound; // El AudioSource para el sonido del clic
    public float delayBeforeSceneChange = 0.5f;
    public SpriteRenderer sp;
    public List<Sprite> skins = new List<Sprite>();
    private int selectedCharacter = 0 ;

    public GameObject playerskin;

    public SpriteRenderer sp2;
    public List<Sprite> skins2 = new List<Sprite>();
    private int selectedCharacter2 = 0 ;

    public GameObject playerskin2;

    public void NextOption()
    {
        selectedCharacter = selectedCharacter + 1;
        if (selectedCharacter == skins.Count)
        {
            selectedCharacter = 0;

        }
        sp.sprite = skins[selectedCharacter];
       
    }


    public void NextOption2()
    {
        selectedCharacter2 = selectedCharacter2 + 1;
        if (selectedCharacter2 == skins2.Count)
        {
            selectedCharacter2 = 0;

        }
        sp2.sprite = skins2[selectedCharacter2];
       
    }


     public void BackOption()
    {
        selectedCharacter = selectedCharacter - 1;
        if (selectedCharacter < 0)
        {
            selectedCharacter = skins.Count - 1;

        }
        sp.sprite = skins[selectedCharacter];
        
        
    }

    public void BackOption2()
    {
        selectedCharacter2 = selectedCharacter2 - 1;
        if (selectedCharacter2 < 0)
        {
            selectedCharacter2 = skins2.Count - 1;

        }
        sp2.sprite = skins2[selectedCharacter2];
        
        
    }

   

    public void PlayGame()
    {
        PlayerPrefs.SetInt("equipoSeleccionado", selectedCharacter);
        PlayerPrefs.SetInt("equipoSeleccionado2", selectedCharacter2);
         //PrefabUtility.SaveAsPrefabAsset(playerskin2,"Assets/equipoSeleccionado2.prefab");

         if(BOTONES.modoJuego == true){
            StartCoroutine(ReproducirSonido("Local"));
           
         }else{
            
             StartCoroutine(ReproducirSonido("Multijugador"));
         }
        
        
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
