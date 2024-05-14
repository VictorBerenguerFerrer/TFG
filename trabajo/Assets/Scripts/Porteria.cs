using UnityEngine;

public class Porteria : MonoBehaviour
{
    public MarcadorDeGoles marcador; // Referencia al script MarcadorDeGoles

 void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.enabled = false;
    }    // Método que se llama cuando un objeto entra en la portería


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("pelota"))
        {
            // Marcar gol para el equipo correspondiente a la portería
            if (this.CompareTag("EquipoA"))
            {
                marcador.IncrementarMarcadorEquipoA(); // Incrementar el marcador del equipo A
                marcador.ReiniciarEscena();
            }
            else if (this.CompareTag("EquipoB"))
            {
                marcador.IncrementarMarcadorEquipoB(); // Incrementar el marcador del equipo B
                marcador.ReiniciarEscena();
            }
            
            
            marcador.ReiniciarEscena();
        }
    }
}
