using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    Transform target;

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

    public void Update()
    {
        // Find distance between the player and enemy
        float dist = Vector3.Distance(target.position, transform.position);

        // Check if target is within range
        if (dist <= max_range && dist >= min_range)
        {
            // Move to target position
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);

            // Turn towards target
            transform.LookAt(target);

            // Turn on weapon effects
            effect1.SetActive(true);
            effect2.SetActive(true);
        }
        else
        {
            effect1.SetActive(false);
            effect2.SetActive(false);
        }
    }
}
