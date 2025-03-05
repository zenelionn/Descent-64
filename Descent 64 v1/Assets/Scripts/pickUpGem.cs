using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class pickUpGem : MonoBehaviour
{
    [Header("Canvas Stuff")]
    [SerializeField] private Canvas dialogueCanvas;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private KeyCode interactionKey = KeyCode.E;
    [SerializeField] private GameObject EButton;

    [SerializeField] private GameObject gem;

    private bool canInteract;
    // Start is called before the first frame update
    void Start()
    {
        gem.SetActive(true);
        dialogueCanvas.enabled = false;
        canInteract = false;
        EButton.GetComponent<Image>().color = new Color32(70,70,70,255);
    }

    private void OnTriggerEnter(Collider other){
        canInteract = true;
        EButton.GetComponent<Image>().color = new Color32(255,255,255,255);

    }

    private void OnTriggerExit(Collider other){
        canInteract = false;
        EButton.GetComponent<Image>().color = new Color32(70,70,70,255);
        dialogueCanvas.enabled = false;
    }

    void Update(){
        if (canInteract && Input.GetKeyDown(interactionKey)){
            {
                // go to second cutscene
                SceneManager.LoadSceneAsync("Basement Second Cutscene");
                
            }

        }

        if (modelChanger.Transformed == true){
            gem.SetActive(false);
        }
    
    }



    
}
