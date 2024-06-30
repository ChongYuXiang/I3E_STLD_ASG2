/* Author: Chong Yu Xiang  
 * Filename: Game Manager
 * Descriptions: For gameobjects to persist through scenes and to keep track of score and health
 */

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

    // Dont destroy on load
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

    // Call to decrease health
    public void DecreaseHealth(int HealthToRemove)
    {
        currentHealth -= HealthToRemove;
        HealthText.text = currentHealth.ToString();
        AudioManager.instance.PlaySFX("Hurt");

        // Player dies
        if (currentHealth <= 0)
        {
            // Game over scene
            sceneManager = GameObject.Find("SceneManager");
            sceneManager.SendMessage("ChangeScene", 5);
            AudioManager.instance.BGMSource.Stop();
            AudioManager.instance.PlaySFX("Loss");
            Destroy(gameObject);
        }
    }

    // Call when collecting scrap
    public void IncreaseScrap(int ScoreToAdd)
    {
        currentScrap += ScoreToAdd;
        ScrapText.text = currentScrap.ToString() + "/30";
        AudioManager.instance.PlaySFX("Collect");
    }

    // Call when collecting engine core
    public void IncreaseCore(int ScoreToAdd)
    {
        currentCore += ScoreToAdd;
        CoreText.text = currentCore.ToString() + "/1";
        AudioManager.instance.PlaySFX("Collect");
    }

    // Check if all parts are gathered to fix the ship and win the game
    public void CompletionCheck()
    {
        if (currentScrap >= 30 && currentCore >= 1)
        {
            completed = true;
        }
    }
}
