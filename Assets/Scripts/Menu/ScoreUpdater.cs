using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour
{
    public Text display;
 
    void Start()
    {
        display.text = "Всего уровней пройдено: " + PlayerPrefs.GetInt("LevelsComplited");
    }

}
