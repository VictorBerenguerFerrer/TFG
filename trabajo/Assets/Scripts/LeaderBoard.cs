using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    public Text mensaje;
    // Start is called before the first frame update
    void Start()
    {
        string leaderboard = DataManager.Instance.LoadMatches();
        mensaje.text = leaderboard;
        
    }

  
}
