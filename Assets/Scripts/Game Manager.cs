using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int currentHealth = 100;
    public int currentScrap = 0;
    public int currentCore = 0;

    public static GameManager instance;

    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI ScrapText;
    public TextMeshProUGUI CoreText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void DecreaseHealth(int HealthToRemove)
    {
        currentHealth -= HealthToRemove;
        HealthText.text = currentHealth.ToString();
    }

    public void IncreaseScrap(int ScoreToAdd)
    {
        currentScrap += ScoreToAdd;
        ScrapText.text = currentScrap.ToString() + "/1";
    }

    public void IncreaseCore(int ScoreToAdd)
    {
        currentCore += ScoreToAdd;
        CoreText.text = currentCore.ToString() + "/20";
    }
}
