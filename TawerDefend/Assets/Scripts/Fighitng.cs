using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fighitng : MonoBehaviour
{
    public Text randomText;
    public GameObject objectaltushka;
    public TextMeshProUGUI text1;
    public Text text2;
    public TextMeshProUGUI text3;
    public Text VoinCountText;
    public Text KrestCountText;
    private float time = 50f;
    private bool isTimerRunning = true;
    void Start()
    {
        text2.text = time.ToString();
        objectaltushka.SetActive(false);
        text1.gameObject.SetActive(true);
        text2.gameObject.SetActive(true);
        text3.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isTimerRunning)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                objectaltushka.SetActive(true);
                int randomNum = Random.Range(1, 1001);
                randomText.text = randomNum.ToString();
                time = 5f;
                isTimerRunning = false;
                text1.gameObject.SetActive(false);
                text2.gameObject.SetActive(false);
                text3.gameObject.SetActive(true);

                int voinCount = int.Parse(VoinCountText.text);
                int krestCount = int.Parse(KrestCountText.text);

                if (voinCount + krestCount > randomNum)
                {
                    Invoke("LoadScene2", 5f);
                }
                else
                {
                    Invoke("LoadScene3", 5f);
                }
            }
            text2.text = Mathf.Round(time).ToString();
        }
    }

    void LoadScene2()
    {
        SceneManager.LoadScene(2);
    }

    void LoadScene3()
    {
        SceneManager.LoadScene(3);
    }
}


