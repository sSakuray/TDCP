using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayTheGame : MonoBehaviour
{
    [SerializeField] public Button playButton;

    void Start()
    {
        playButton.onClick.AddListener(PlayGame);
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
