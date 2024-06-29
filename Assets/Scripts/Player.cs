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

    private void Update()
    {

        Debug.DrawLine(playerCamera.position, playerCamera.position + (playerCamera.forward * interactionDistance), Color.red);

        RaycastHit hitInfo;
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hitInfo, interactionDistance))
        {
            if (hitInfo.transform.name == "ExitToGrounds")
            {
                description.text = "Exit";
                prompt.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    sceneManager.SendMessage("ChangeScene", 2);
                }
                
            }
            if (hitInfo.transform.name == "EnterShip")
            {
                description.text = "Enter";
                prompt.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    sceneManager.SendMessage("ChangeScene", 1);
                }

            }
            if (hitInfo.transform.name == "EnterFactory")
            {
                description.text = "Enter";
                prompt.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    sceneManager.SendMessage("ChangeScene", 3);
                }

            }

            if (hitInfo.transform.name == "ScrapCollectible")
            {
                description.text = "Pick Up";
                prompt.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    hitInfo.transform.SendMessage("Collect");
                }

            }
        }
        else
        {
            prompt.SetActive(false);
        }
    }


}
