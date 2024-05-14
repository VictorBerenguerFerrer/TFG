using UnityEngine;
using UnityEngine.UI;

public class ContadorLocal : MonoBehaviour
{
    public AudioSource audioSource; // El componente que reproduce el sonido
    public AudioClip eventSound;
    public Text countdownText;
    public float countdownDuration = 5f;
    public static float currentTime = 0f;
    private bool isCounting = false;

    private GameManager gm;

    private int contador = 0;

    public float maxIdleTime = 1f; // Tiempo en segundos antes de reiniciar el contador
    private float currentIdleTime = 0f;

    private bool turno = false;

    public PlayerController playerController;
    public PlayerController1 playerController1;
    public PlayerController2 playerController2; // Referencia al PlayerController
    public PlayerController3 playerController3;

    public ControladorBots bot;
    public ControladorBots bot2;
    public ControladorBots bot3;
    public ControladorBots bot4;

    
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
                LaunchBots(); // Llama al método para lanzar los bots
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
       

        currentIdleTime = 0;

    }

    public void LaunchBots()
    {
        if (bot.nearBall)
        {
            bot.LaunchTowardsBall();
            bot2.LaunchTowardsBall();
            bot3.LaunchTowardsBall();
            bot4.LaunchTowardsBall();

        }
        else
        {
            bot.MoveRandomly();
            bot2.MoveRandomly();
            bot3.MoveRandomly();
            bot4.MoveRandomly();


        }
    }

    public void Idle()
    {

        if (contador == 1)
        {

            if (!playerController.IsMoving || !playerController1.IsMoving || !playerController2.IsMoving || !playerController3.IsMoving)
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
