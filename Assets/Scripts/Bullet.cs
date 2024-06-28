/* Author: Chong Yu Xiang  
 * Filename: Bullet
 * Descriptions: Destroying bullet
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Destroy bullet when colliding
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    // Destroy bullet if it travels too far
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    // For waiting
    private void Start()
    {
        StartCoroutine(waiter());
    }
}
