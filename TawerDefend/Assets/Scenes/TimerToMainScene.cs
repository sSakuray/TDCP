using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerToMainScene : MonoBehaviour
{
    public Text timerText;
    private float timer;

    void Start()
    {
        timer = 10f;
        timerText.text = timer.ToString("F0");
    }

    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = timer.ToString("F0");

        if (timer <= 0f)
        {
            SceneManager.LoadScene(1);
        }
    }
}


