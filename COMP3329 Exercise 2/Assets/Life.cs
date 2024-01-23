using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    public Slider slider;
    public static Life instance;
    int gameEnd = 0;

    private void Awake()
    {
        instance = this;
    }

    public void SetMaxHP(int health) 
    {
        slider.maxValue = health;
        slider.value = health;
    }
    

    public void lifereduce(int health)
    {
        slider.value -= health;
        if (slider.value == 0) endgame();
    }

    public void endgame()
    {
        gameEnd = 1;
        Time.timeScale = 0;

    }

    void OnGUI()
    {
        if (gameEnd == 1)
            GUI.Label(new Rect(Screen.width / 2 , Screen.height / 2, 500, 100), "Game Over!");
    }
}
