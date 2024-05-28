using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;

public class MatchBoard : MonoBehaviour
{
    public Text textoCanvas; // Asigna el objeto Text desde el Inspector

    [System.Serializable]
    public class Partidos
    {
        public string partido;
    }

    void Start()
    {
        string archivoGuardado = Path.Combine(Application.persistentDataPath, "data.data");

        // Lee todas las líneas del archivo
        string[] lineas = File.ReadAllLines(archivoGuardado);

        // Crea una lista para almacenar los mensajes
        List<string> resultados = new List<string>();

        // Itera sobre cada línea y obtén el mensaje
        foreach (string linea in lineas)
        {
            // Deserializa el JSON y obtén el mensaje
            
            Partidos partidos = JsonUtility.FromJson<Partidos>(linea);
            resultados.Add(partidos.partido);
        }

        // Une todos los mensajes en una sola cadena separada por saltos de línea
        string mensajesConcatenados = string.Join("\n", resultados);

        // Actualiza el contenido del objeto Text en el canvas
        textoCanvas.text = mensajesConcatenados;
    }
}
