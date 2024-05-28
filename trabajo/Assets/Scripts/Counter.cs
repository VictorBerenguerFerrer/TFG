using UnityEngine;
using UnityEngine.UI;

public class Contador : MonoBehaviour
{
    public Text countdownText;
    public AudioSource audioSource; // El componente que reproduce el sonido
    public AudioClip eventSound;
    public float countdownDuration = 10f;
    public static float currentTime = 0f;
    private bool isCounting = false;

    private GameManager gm;

    private int contador = 0;

    public float maxIdleTime = 1f; // Tiempo en segundos antes de reiniciar el contador
    private float currentIdleTime = 0f;

    private bool turno = false;

    public PlayerController playerController;
    public PlayerController1 playerController1;
    public PlayerController2 playerController2; 
    public PlayerController3 playerController3;

    public PlayerController4 playerController4;
    public PlayerController5 playerController5;
    public PlayerController6 playerController6; 
    public PlayerController7 playerController7;

    
    void Start()
    {

        MusicManager.instance.StopMusic();
        audioSource = GetComponent<AudioSource>();
        StartCountdown();
        
    }

    void Update()
    {
        if (isCounting)
        {
            currentTime -= Time.deltaTime;
            UpdateCountdownText();

            if (currentTime <= 0)
            {
                currentTime = 0;
                isCounting = false;
                LaunchPlayers(); // Llama al método para lanzar los personajes
                contador = 1;
                turno = true;
               
            }
        }

         Idle();        

    }

    void UpdateCountdownText()
    {
        countdownText.text = currentTime.ToString("F1");
    }

    public void StartCountdown()
    {
        audioSource.PlayOneShot(eventSound);
        currentTime = countdownDuration;
        
        isCounting = true;



    }

    public void ResetCountdown()
    {
        
        currentTime = countdownDuration;
        
        isCounting = true;

        turno = false;
        
    }

    public void LaunchPlayers()
    {
        // Llama al método LaunchObjects del PlayerController para lanzar los personajes
        if(playerController.hasBeenDragged){
                playerController.LaunchObject();
        }
        if(playerController1.hasBeenDragged){
                playerController1.LaunchObject();
        }
        if(playerController2.hasBeenDragged){
                playerController2.LaunchObject();
        }
        if(playerController3.hasBeenDragged){
                playerController3.LaunchObject();
        }
        if(playerController4.hasBeenDragged){
                playerController4.LaunchObject();
        }
        if(playerController5.hasBeenDragged){
                playerController5.LaunchObject();
        }
        if(playerController6.hasBeenDragged){
                playerController6.LaunchObject();
        }
        if(playerController7.hasBeenDragged){
                playerController7.LaunchObject();
        }
       

        currentIdleTime = 0;

    }

    

    public void Idle()
    {

        if (contador == 1)
        {

            if (!playerController.IsMoving || !playerController1.IsMoving || !playerController2.IsMoving || !playerController3.IsMoving ||!playerController4.IsMoving ||!playerController5.IsMoving ||!playerController6.IsMoving ||!playerController7.IsMoving )
            {

                currentIdleTime += Time.deltaTime;
                if (currentIdleTime >= maxIdleTime && turno == true)
                    {
                    
                        ResetCountdown();
                        
                    }
                

            }
            
            
        }

    }





}
