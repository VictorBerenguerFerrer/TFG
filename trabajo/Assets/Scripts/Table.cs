using UnityEngine;

public class Texto : MonoBehaviour
{
    public TextAsset archivoTexto; // Asigna el archivo desde el Inspector

    void Start()
    {
        if (archivoTexto != null)
        {
            string contenido = archivoTexto.text;
            Debug.Log("Contenido del archivo: " + contenido);
        }
        else
        {
            Debug.LogError("No se ha asignado ningún archivo de texto.");
        }
    }
}
