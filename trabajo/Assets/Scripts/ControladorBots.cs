using UnityEngine;

public class ControladorBots : MonoBehaviour
{
    public GameObject ball;
    public float moveSpeed = 5f;
    public float minDistanceToBall = 4f;
    public float launchForce = 10f;

    public float friction = 0.95f; 
    public bool nearBall = false;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    void Update()
    {


        float distanceToBall = Vector3.Distance(transform.position, ball.transform.position);

        // Si está lejos del balón, mueve aleatoriamente
        if (distanceToBall > minDistanceToBall)
        {
           nearBall = false;
        }
        else
        {
            // Si está cerca del balón, lanza hacia él
            nearBall = true;
        }
    }

  public void MoveRandomly()
{
    // Genera una dirección aleatoria
    Vector2 randomDirection = Random.insideUnitCircle.normalized;

    // Aplica la velocidad al Rigidbody2D
    rb.velocity = randomDirection * moveSpeed;
}

private void FixedUpdate()
    {
        
            rb.velocity *= friction;
           
        
    }

   public void LaunchTowardsBall()
    {
        // Calcula la dirección hacia el balón
        Vector3 directionToBall = (ball.transform.position - transform.position).normalized;

        // Lanza al personaje hacia el balón
        rb.AddForce(directionToBall * launchForce, ForceMode2D.Impulse);
       
    }

    
}
