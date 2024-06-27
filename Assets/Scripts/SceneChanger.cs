/* Author: Chong Yu Xiang  
 * Filename: SceneChanger
 * Descriptions: For changing scenes
 */

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public int targetSceneIndex;

    // Change scene on collision
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ChangeScene();
        }
    }

    // Load scene based on given index
    public void ChangeScene()
    {
        SceneManager.LoadScene(targetSceneIndex);
    }
}
