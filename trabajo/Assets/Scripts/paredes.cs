using UnityEngine;

public class DesactivarRenderersPorEtiqueta : MonoBehaviour
{
    public string etiquetaObjetosDesactivar; // La etiqueta de los objetos que deseas desactivar

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
    }
}
