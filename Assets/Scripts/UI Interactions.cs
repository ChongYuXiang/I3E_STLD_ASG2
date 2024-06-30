/* Author: Chong Yu Xiang  
 * Filename: UI Interactions
 * Descriptions: Functions for UI
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInteractions : MonoBehaviour
{
    public GameObject optionsPage;
    public GameObject mainMenu;
    public GameObject creditsPage;
    public GameObject tutorialPage;

    /// Function for slider
    public void SliderChange(float sliderValue)
    {
        Debug.Log(sliderValue);
    }

    // Function for toggle
    public void ToggleChange(bool toggleValue)
    {
        Debug.Log(toggleValue);
    }

    // Change to main menu screen
    public void SwitchToMenu()
    {
        optionsPage.SetActive(false);
        creditsPage.SetActive(false);
        tutorialPage.SetActive(false);
        mainMenu.SetActive(true);
    }

    //  Change to options page
    public void SwitchToOptions()
    {
        optionsPage.SetActive(true);
        mainMenu.SetActive(false);
    }

    // Change to credits page
    public void SwitchToCredits()
    {
        creditsPage.SetActive(true);
        mainMenu.SetActive(false);
    }

    // Change to tutorial page
    public void SwitchToHTP()
    {
        tutorialPage.SetActive(true);
        mainMenu.SetActive(false);
    }

    // Quit Button
    public void QuitGame()
    {
        // Close unity build
        Application.Quit();

        // Stop unity editor
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
