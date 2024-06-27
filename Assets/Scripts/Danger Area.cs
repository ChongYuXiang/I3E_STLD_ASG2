using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerArea : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        // Check if what triggered is the Player
        if (other.gameObject.CompareTag("Player"))
        {
            // Tell Player to take damage
            InvokeRepeating("sendDamage", 0.0f, 1.0f);
        }
    }

    private void sendDamage()
    {
        player.SendMessage("Damage");
    }
}
