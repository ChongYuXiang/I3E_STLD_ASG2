using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int currentHealth = 100;
    public int currentScrap = 0;
    public int currentCore = 0;
    public bool completed = false;

    public static GameManager instance;
    public GameObject sceneManager;

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
        if (currentHealth <= 0)
        {
            sceneManager = GameObject.Find("SceneManager");
            sceneManager.SendMessage("ChangeScene", 5);
            Destroy(gameObject);
        }
    }

    public void IncreaseScrap(int ScoreToAdd)
    {
        currentScrap += ScoreToAdd;
        ScrapText.text = currentScrap.ToString() + "/30";
    }

    public void IncreaseCore(int ScoreToAdd)
    {
        currentCore += ScoreToAdd;
        CoreText.text = currentCore.ToString() + "/1";
    }

    public void CompletionCheck()
    {
        if (currentScrap >= 30 && currentCore >= 1)
        {
            completed = true;
        }
    }
}
