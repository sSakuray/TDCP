using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BeerScript : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public TextMeshProUGUI score;
    public TextMeshProUGUI scoreSHOP;
    public float lifetime = 10f;
    public int scorePerRun = 5;
    private float gameTime;
    private void Start()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            score.text = PlayerPrefs.GetString("Score");
        }
        if (PlayerPrefs.HasKey("ScoreSHOP"))
        {
            scoreSHOP.text = PlayerPrefs.GetString("ScoreSHOP");
        }
        else
        {
            scoreSHOP.text = score.text;
        }
    }
    private void Update()
    {
        gameTime += 1 * Time.deltaTime;
        if (gameTime >= 1)
        {
            lifetime -= 1;
            gameTime = 0;
        }
        if (lifetime <= 0)
        {
            lifetime = 10f;
            int scoreValue = int.Parse(score.text);
            score.text = (scoreValue + scorePerRun).ToString();
            scoreSHOP.text = score.text;
        }
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("Score", score.text);
        PlayerPrefs.SetString("ScoreSHOP", score.text);
    }
    public int GetScorePerRun()
    {
        return scorePerRun;
    }
}
