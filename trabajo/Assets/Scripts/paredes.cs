using UnityEngine;

public class DesactivarRenderersPorEtiqueta : MonoBehaviour
{
    public string etiquetaObjetosDesactivar; // La etiqueta de los objetos que deseas desactivar
    public float targetAspect = 18.5f / 9f;
    void Start()
    {
        // Obtener todos los objetos con la etiqueta especificada
        GameObject[] objetosConEtiqueta = GameObject.FindGameObjectsWithTag(etiquetaObjetosDesactivar);

        // Desactivar el componente Renderer de cada objeto encontrado
        foreach (GameObject objeto in objetosConEtiqueta)
        {
            Renderer rendererObjeto = objeto.GetComponent<Renderer>();
            if (rendererObjeto != null)
            {
                rendererObjeto.enabled = false;
            }
        }



         // Obtén la relación de aspecto actual de la pantalla
        float windowAspect = (float)Screen.width / (float)Screen.height;

        // Calcula la escala de diferencia entre la relación de aspecto deseada y la actual
        float scaleHeight = windowAspect / targetAspect;

        // Obtén la cámara principal
        Camera camera = GetComponent<Camera>();

        // Si la escala de altura es menor que 1, significa que tenemos barras negras en los lados
        if (scaleHeight < 1.0f)
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;

            camera.rect = rect;
        }
        else // Si la escala de altura es mayor que 1, significa que tenemos barras negras arriba y abajo
        {
            float scaleWidth = 1.0f / scaleHeight;

            Rect rect = camera.rect;

            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }
    }

    }

