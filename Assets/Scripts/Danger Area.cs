/* Author: Chong Yu Xiang  
 * Filename: Danger Area
 * Descriptions: Deal damage to the player over time when in contact
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerArea : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject manager;

    // Function for if the player touches a danger area
    private void OnTriggerEnter(Collider other)
    {
        // Check if what triggered is the Player
        if (other.gameObject.CompareTag("Player"))
        {
            // Repeat sendDamage every second the player is in range
            InvokeRepeating("sendDamage", 0.0f, 1.0f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Stop telling player to take damage
            CancelInvoke();
        }
    }

    private void sendDamage()
    {
        // Tell the player to take damage
        manager = GameObject.Find("GameManager");
        manager.GetComponent<GameManager>().DecreaseHealth(10);
    }
}
