using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSetting : MonoBehaviour
{
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button continueButton;
    void Start()
    {
        pauseButton.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(false);
        pauseButton.onClick.AddListener(Pause);
        continueButton.onClick.AddListener(Continue);
    }

    private void Pause()
    {
        Time.timeScale = 0;
        pauseButton.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(true);
    }
    private void Continue()
    {
        Time.timeScale = 1;
        pauseButton.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(false);
    }
}

