/* Author: Chong Yu Xiang  
 * Filename: UI Interactions
 * Descriptions: Functions for UI buttons
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInteractions : MonoBehaviour
{
    public GameObject optionsPage;
    public GameObject mainMenu;
    public GameObject creditsPage;
    public GameObject tutorialPage;
    public Slider _VolumeSlider;

    // Tell audio manager to toggle BGM
    public void ToggleBGM()
    {
        AudioManager.instance.ToggleBGM();
    }

    // Tell audio manager to toggle SFX
    public void ToggleSFX()
    {
        AudioManager.instance.ToggleSFX();
    }

    public void Volume()
    {
        AudioManager.instance.Volume(_VolumeSlider.value);
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
    }
}
