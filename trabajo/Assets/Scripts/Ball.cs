using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    
    public AudioSource audioSource; // Asigna el AudioSource
    public AudioClip collisionSound;
    // Valor de fricción personalizable
    public float linearDrag = 0.4f;
    public float angularDrag = 0.4f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = linearDrag;
        rb.angularDrag = angularDrag;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       
        
            audioSource.PlayOneShot(collisionSound); // Reproducir el sonido al colisionar
        
    }



}
