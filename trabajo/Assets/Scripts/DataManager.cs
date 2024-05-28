using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }

    private string filePath;
    
    private void Awake()
    {
         
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Establecer la ruta del archivo usando Application.persistentDataPath para que no se pierda cuando se compile.
            filePath = Path.Combine(Application.persistentDataPath, "data.data");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveMatches(string matches)
    {
        
            File.AppendAllText(filePath, matches + "\n");
            Debug.Log("Mensaje guardado correctamente.");
        
        
    }

    public string LoadMatches()
    {
        
                string partidos = File.ReadAllText(filePath);
                Debug.Log("Mensaje cargado correctamente."+ partidos);
                return partidos;
            
        
    }
}
