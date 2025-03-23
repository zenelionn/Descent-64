using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class deathscreenButtons : MonoBehaviour
{
    public static bool Level1;

    public void Start()
    {
        Level1 = true;
    }
    public void Restart()
    {   // reset everyone
        Level1 = true;
        chaseState.jumpscareCheck = false;
        chaseState.isChasingCheck = false;
        SceneManager.LoadScene("The Basement");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
