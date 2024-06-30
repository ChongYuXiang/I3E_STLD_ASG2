/* Author: Chong Yu Xiang  
 * Filename: Shoot
 * Descriptions: For shooting blaster
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    Rigidbody projectile;

    [SerializeField]
    float shootSpeed;

    [SerializeField]
    AudioSource shootSound;

    private void Update()
    {
        // Check if left click is pressed
        if (Input.GetButtonDown("Fire1"))
        {
            // Create clone of projectile
            Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            // Send projectile forwards
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, shootSpeed));
            // Play sound effect
            AudioManager.instance.PlaySFX("Shoot");
        }
    }
}
