using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class menuScreen : MonoBehaviour
{
    [SerializeField] private GameObject contentWarningScreen;

    private void Start(){
        contentWarningScreen.SetActive(false);
    }
    public void PlayGame(){
        SceneManager.LoadScene("Basement Cutscenes");
    }

    public void ContentWarning(){
        contentWarningScreen.SetActive(true);
    }

    public void ReturnToMain(){
        contentWarningScreen.SetActive(false);
    }
}
