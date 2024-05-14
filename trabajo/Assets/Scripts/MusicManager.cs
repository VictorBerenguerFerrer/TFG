using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance; // Singleton para la música persistente

    public AudioSource musicSource; // El AudioSource para la música

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Mantener la música al cambiar de escena
        }
        else
        {
            Destroy(gameObject); // Si ya existe una instancia, destruir esta
        }
    }

    public void PlayMusic()
    {
        if (musicSource != null && !musicSource.isPlaying)
        {
            musicSource.Play(); // Reproducir la música si no se está reproduciendo
        }
    }

    public void StopMusic()
    {
       
            musicSource.Stop(); // Detener la música si se está reproduciendo
        
    }

    public void MuteMusic(bool mute)
    {
        if (musicSource != null)
        {
            musicSource.mute = mute; // Silenciar o desilenciar la música
        }
    }
}
