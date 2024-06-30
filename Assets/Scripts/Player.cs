/* Author: Chong Yu Xiang  
 * Filename: Player
 * Descriptions: Raycast from player to interact with things
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    Transform playerCamera;

    [SerializeField]
    float interactionDistance;

    [SerializeField]
    GameObject sceneManager;

    [SerializeField]
    GameObject prompt;

    [SerializeField]
    TextMeshProUGUI description;

    private GameObject gameManager;
    private bool completed;

    private void Update()
    {
        // Crate raycast
        Debug.DrawLine(playerCamera.position, playerCamera.position + (playerCamera.forward * interactionDistance), Color.red);

        // Detect what ray has hit
        RaycastHit hitInfo;
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hitInfo, interactionDistance))
        {
            // Ray hits an exit
            if (hitInfo.transform.name == "ExitToGrounds")
            {
                // Activate and change prompt
                description.text = "Exit";
                prompt.SetActive(true);

                // Press E to interact
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Change scene to grounds
                    AudioManager.instance.BGMSource.Stop();
                    AudioManager.instance.PlayBGM("Grounds");
                    sceneManager.SendMessage("ChangeScene", 2);
                }
                
            }

            // Ray hits ship entrance
            if (hitInfo.transform.name == "EnterShip")
            {
                // Activate and change prompt
                description.text = "Enter";
                prompt.SetActive(true);

                // Press E to interact
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Change scene to spaceship
                    AudioManager.instance.BGMSource.Stop();
                    AudioManager.instance.PlayBGM("Ship");
                    sceneManager.SendMessage("ChangeScene", 1);
                }

            }

            // Ray hits factory entrance
            if (hitInfo.transform.name == "EnterFactory")
            {
                // Activate and change prompt
                description.text = "Enter";
                prompt.SetActive(true);

                // Press E to interact
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Change scene to factory
                    AudioManager.instance.BGMSource.Stop();
                    AudioManager.instance.PlayBGM("Factory");
                    sceneManager.SendMessage("ChangeScene", 3);
                }

            }

            // Ray hits scrap
            if (hitInfo.transform.name == "ScrapCollectible" || hitInfo.transform.name == "ScrapCollectible(Clone)")
            {
                // Activate and change prompt
                description.text = "Pick Up";
                prompt.SetActive(true);

                // Press E to interact
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Tell game manager to increase score
                    gameManager = GameObject.Find("GameManager");
                    gameManager.GetComponent<GameManager>().IncreaseScrap(1);

                    // Destroy scrap and remove prompt
                    Destroy(hitInfo.transform.gameObject);
                    prompt.SetActive(false);
                }

            }

            // Ray hits engine core
            if (hitInfo.transform.name == "EngineCore")
            {
                // Activate and change prompt
                description.text = "Pick Up";
                prompt.SetActive(true);

                // Press E to interact
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Tell game manager to increase score
                    gameManager = GameObject.Find("GameManager");
                    gameManager.GetComponent<GameManager>().IncreaseCore(1);

                    // Destroy scrap and remove prompt
                    Destroy(hitInfo.transform.gameObject);
                    prompt.SetActive(false);
                }

            }

            // Ray hits ship engine
            if (hitInfo.transform.name == "FixShip")
            {
                // Activate and change prompt
                description.text = "Fix Ship";
                prompt.SetActive(true);

                // Press E to interact
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Tell game manager to check for collection completion
                    gameManager = GameObject.Find("GameManager");
                    gameManager.GetComponent<GameManager>().CompletionCheck();
                    completed = gameManager.GetComponent<GameManager>().completed;

                    // If all parts are collected
                    if (completed == true)
                    {
                        // Change to victory scene
                        sceneManager.SendMessage("ChangeScene", 4);
                        AudioManager.instance.BGMSource.Stop();
                        AudioManager.instance.PlaySFX("Win");
                        Destroy(gameManager.gameObject);
                    }
                }
            }
        }
        // Not looking at important object
        else
        {
            prompt.SetActive(false);
        }
    }


}
