using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public GameObject selectedSkin;

   public GameObject Player;

   public GameObject Player1;

   public GameObject Player2;

   public GameObject Player3;

   private static  Sprite playerSprite;

   public GameObject selectedSkin2;

   public GameObject bot;

   public GameObject bot1;

   public GameObject bot2;

   public GameObject bot3;

   private static  Sprite playerSprite2;
     void Awake()
    {
        playerSprite = selectedSkin.GetComponent<SpriteRenderer>().sprite;
        Player.GetComponent<SpriteRenderer>().sprite = playerSprite;
        Player1.GetComponent<SpriteRenderer>().sprite = playerSprite;
        Player2.GetComponent<SpriteRenderer>().sprite = playerSprite;
        Player3.GetComponent<SpriteRenderer>().sprite = playerSprite;

        playerSprite2 = selectedSkin2.GetComponent<SpriteRenderer>().sprite;
        bot.GetComponent<SpriteRenderer>().sprite = playerSprite2;
        bot1.GetComponent<SpriteRenderer>().sprite = playerSprite2;
        bot2.GetComponent<SpriteRenderer>().sprite = playerSprite2;
        bot3.GetComponent<SpriteRenderer>().sprite = playerSprite2;


    }

}
