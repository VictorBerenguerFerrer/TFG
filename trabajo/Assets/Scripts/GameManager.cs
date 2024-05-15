using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject jugador1;
    public GameObject jugador2;
    public GameObject jugador3;
    public GameObject jugador4;

    public GameObject bot1;
    public GameObject bot2;
    public GameObject bot3;
    public GameObject bot4;

    public List<Sprite> skins = new List<Sprite>();

    private void Awake()
    {
        // Obtener los índices de las dos skins seleccionadas para cada equipo desde PlayerPrefs
        int team1SelectedCharacter = PlayerPrefs.GetInt("equipoSeleccionado",0);
        int team2SelectedCharacter = PlayerPrefs.GetInt("equipoSeleccionado2",0);


       

        // Obtener las skins seleccionadas según los índices guardados
        Sprite team1Sprite = skins[team1SelectedCharacter];
        Sprite team2Sprite = skins[team2SelectedCharacter];

        // Asignar las skins seleccionadas a los jugadores y bots de cada equipo
        jugador1.GetComponent<SpriteRenderer>().sprite = team1Sprite;
        jugador2.GetComponent<SpriteRenderer>().sprite = team1Sprite;
        jugador3.GetComponent<SpriteRenderer>().sprite = team1Sprite;
        jugador4.GetComponent<SpriteRenderer>().sprite = team1Sprite;

        bot1.GetComponent<SpriteRenderer>().sprite = team2Sprite;
        bot2.GetComponent<SpriteRenderer>().sprite = team2Sprite;
        bot3.GetComponent<SpriteRenderer>().sprite = team2Sprite;
        bot4.GetComponent<SpriteRenderer>().sprite = team2Sprite;
    }
}
