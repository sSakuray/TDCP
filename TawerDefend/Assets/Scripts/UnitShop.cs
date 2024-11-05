using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UnitShop : MonoBehaviour
{
    [SerializeField] private Button ToShop;
    [SerializeField] private Button BackShop;
    [SerializeField] private GameObject Shop;
    [SerializeField] private Button KrestButton;
    [SerializeField] private Button VoinButton;
    [SerializeField] private Text KrestCountText;
    [SerializeField] private Text VoinCountText;
    [SerializeField] private Text KrestTimerText;
    [SerializeField] private Text VoinTimerText;

    private BeerScript beerScript;

    private int krestCount = 0;
    private int voinCount = 0;

    private float krestTimeElapsed = 0f;
    private float voinTimeElapsed = 0f;

    void Start()
    {
        beerScript = GameObject.FindObjectOfType<BeerScript>();
        LoadCount();
        ToShop.gameObject.SetActive(true);
        Shop.SetActive(false);
        ToShop.onClick.AddListener(OpenShop);
        BackShop.onClick.AddListener(CloseShop);
        KrestButton.onClick.AddListener(AddKrest);
        VoinButton.onClick.AddListener(AddVoin);
    }

    private void OpenShop()
    {
        ToShop.gameObject.SetActive(false);
        Shop.SetActive(true);
    }
    private void CloseShop()
    {
        Shop.SetActive(false);
        ToShop.gameObject.SetActive(true);
    }
    private void AddKrest()
    {
        if (krestTimeElapsed >= 10f)
        {
            int scoreValue;
            if (int.TryParse(beerScript.score.text, out scoreValue) && int.TryParse(beerScript.scoreSHOP.text, out int shopScore) && scoreValue >= 3 && shopScore >= 3)
            {
                scoreValue -= 3;
                shopScore -= 3;
                beerScript.score.text = scoreValue.ToString();
                beerScript.scoreSHOP.text = shopScore.ToString();
                krestCount++;
                KrestCountText.text = krestCount.ToString();
                SaveCount();
                krestTimeElapsed = 0f;
            }
        }
        UpdateKrestTimer();
    }
    private void AddVoin()
    {
        if (voinTimeElapsed >= 10f)
        {
            int scoreValue;
            if (int.TryParse(beerScript.score.text, out scoreValue) && int.TryParse(beerScript.scoreSHOP.text, out int shopScore) && scoreValue >= 5 && shopScore >= 5)
            {
                scoreValue -= 5;
                shopScore -= 5;
                beerScript.score.text = scoreValue.ToString();
                beerScript.scoreSHOP.text = shopScore.ToString();
                voinCount++;
                VoinCountText.text = voinCount.ToString();
                SaveCount();
                voinTimeElapsed = 0f;
            }
        }
        UpdateVoinTimer();
    }
    private void SaveCount()
    {
        PlayerPrefs.SetInt("KrestCount", krestCount);
        PlayerPrefs.SetInt("VoinCount", voinCount);
    }
    private void LoadCount()
    {
        krestCount = PlayerPrefs.GetInt("KrestCount", 0);
        voinCount = PlayerPrefs.GetInt("VoinCount", 0);
        KrestCountText.text = krestCount.ToString();
        VoinCountText.text = voinCount.ToString();
    }
    private void Update()
    {
        if (krestTimeElapsed < 10f)
        {
            krestTimeElapsed += Time.deltaTime;
            UpdateKrestTimer();
        }
        if (voinTimeElapsed < 10f)
        {
            voinTimeElapsed += Time.deltaTime;
            UpdateVoinTimer();
        }
    }
    private void UpdateKrestTimer()
    {
        KrestTimerText.text = ((int)Mathf.Max(0, 10 - krestTimeElapsed)).ToString();
    }
    private void UpdateVoinTimer()
    {
        VoinTimerText.text = ((int)Mathf.Max(0, 10 - voinTimeElapsed)).ToString();
    }
    private void OnDestroy()
    {
        ToShop.onClick.RemoveListener(OpenShop);
        BackShop.onClick.RemoveListener(CloseShop);
        KrestButton.onClick.RemoveListener(AddKrest);
        VoinButton.onClick.RemoveListener(AddVoin);
    }
}


