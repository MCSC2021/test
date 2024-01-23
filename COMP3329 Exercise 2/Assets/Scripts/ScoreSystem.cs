using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem instance;
    public static int score = 0;
    public Text scoreText;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        scoreText.text = "Score :" + score.ToString();
    }
    public void addscore(int addscore)
    {
        score += addscore;
        scoreText.text = "Score :" + score.ToString();
    }
}
