using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public AudioSource buttonSound;

    //Play Button
    public void PlayButtonPressed()
    {
        SceneManager.LoadScene("Level Select");
    }

    //Quit Button
    public void QuitButtonPressed()
    {
        Application.Quit();
    }

}

   



