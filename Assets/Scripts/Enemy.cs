/* Author: Chong Yu Xiang  
 * Filename: Enemy
 * Descriptions: Enemy movement and health
 */

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    GameObject target;

    [SerializeField]
    int hitpoints;

    [SerializeField]
    float max_range;

    [SerializeField]
    float min_range;

    [SerializeField]
    float speed;

    [SerializeField]
    GameObject effect1;

    [SerializeField]
    GameObject effect2;

    [SerializeField]
    GameObject drop;

    // Enemy movement
    public void Update()
    {
        target = GameObject.Find("MainCamera");

        // Find distance between the player and enemy
        float dist = Vector3.Distance(target.transform.position, transform.position);

        // Check if target is within range
        if (dist <= max_range && dist >= min_range)
        {
            // Move to target position
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);

            // Turn towards target
            transform.LookAt(target.transform);

            // Turn on weapon effects
            effect1.SetActive(true);
            effect2.SetActive(true);
        }
        else
        {
            // Turn off weapon effects when out of range
            effect1.SetActive(false);
            effect2.SetActive(false);
        }

        // Destroy enemy when it hits 0 health
        if (hitpoints == 0)
        {
            Instantiate(drop, transform.position, drop.transform.rotation);
            Destroy(gameObject);
        }
    }

    // Detect if enemy has been hit
    private void OnTriggerEnter(Collider other)
    {
        // Check if what hit enemy was a projectile from the blaster
        if (other.gameObject.CompareTag("Projectile")){
            // Reduce health
            hitpoints -= 1;
        }
    }

}
