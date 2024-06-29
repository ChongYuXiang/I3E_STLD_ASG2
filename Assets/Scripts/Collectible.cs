/* Author: Chong Yu Xiang  
 * Filename: Collectible
 * Descriptions: For collectible items
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField]
    GameObject manager;

    protected virtual void Collected()
    {
        Destroy(gameObject);

        if (gameObject.name == "Scrap")
        {
            manager.GetComponent<GameManager>().IncreaseScrap(1);
        }
        if (gameObject.name == "Engine Core")
        {
            manager.GetComponent<GameManager>().IncreaseCore(1);
        }
    }
}
