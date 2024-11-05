using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerSliderScript : MonoBehaviour
{
    public Slider slider;
    public float lifetime = 10f;
    private float gameTime;
    private void Update()
    {
        slider.value = lifetime;
        gameTime += 1 * Time.deltaTime;
        if (gameTime >= 1)
        {
            lifetime -= 1;
            gameTime = 0;
            if (lifetime <= 0)
            {
                lifetime = 10f;
            }
        }
    }
}