using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EndGameHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stats;
   public void endGame(){
        Time.timeScale = 0;
        GameObject endScreen = GameObject.Find("EndScreenCanvas");

        endScreen.GetComponent<Canvas>().enabled = true;
        drawData();
   }

   public void drawData(){
    
    stats.text = "You Survived "+(GameObject.Find("TimeManager").GetComponent<TimeManager>().getDayNum() - 1) +" Days"; 
   }
}
