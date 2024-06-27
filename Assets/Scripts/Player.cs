using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    Transform playerCamera;

    [SerializeField]
    float interactionDistance;

    [SerializeField]
    int health;

    [SerializeField]
    GameObject sceneManager;

    int damage = 10;

    private void Update()
    {
        Debug.DrawLine(playerCamera.position, playerCamera.position + (playerCamera.forward * interactionDistance), Color.red);

        RaycastHit hitInfo;
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hitInfo, interactionDistance))
        {
            if (hitInfo.transform.name == "ExitArea")
            {
                sceneManager.SendMessage("ChangeScene");
            }
        }
    }

    public void Damage()
    {
        health -= damage;
        Debug.Log(health);
    }
}
